 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Training.Domain.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using Training.Api.Filters;
using Training.Interface;
using Training.Implementation;
using Training.Service.Interface;
using Training.Service.Implementation;
using AutoMapper;
using Training.DTO.MapProfile;
using Training.Domain.ViewModel;
using Swashbuckle.AspNetCore.SwaggerUI;

using Microsoft.Extensions.Options;
using Training.DTO;
using Training.DTO.Localization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;

using DinkToPdf.Contracts;
using DinkToPdf;

using Microsoft.AspNetCore.DataProtection;

using System.IO;
using Hangfire;
using Hangfire.SqlServer;
using System;



namespace Training.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "AllowOrigin";
        private readonly bool IsAllowAllCrospolicyName = true;
        protected string SchedualTaskExp => Configuration.GetSection("HangFireExp").GetValue<string>("SchedualTaskExp");

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DbContext
            services.AddDbContext<TrainingDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<TrainingDbContext>, Repository<TrainingDbContext>>();


            using (var context = new TrainingDbContext())
            {
                context.Database.Migrate();
            }

            #endregion

            #region Localization
            //services.Configure<RequestLocalizationOptions>(o =>
            //{
            //    var SupportedCultrues = new List<CultureInfo>
            //    {
            //        new CultureInfo("ar-SA"),
            //        new CultureInfo("en-US")
            //    };
            //    o.DefaultRequestCulture =new RequestCulture( ArCustomCulture.GetCustomCulture();
            //    //o.DefaultRequestCulture.Culture.DateTimeFormat = new CultureInfo("en-GB").DateTimeFormat;
            //    //o.DefaultRequestCulture.UICulture.DateTimeFormat = new CultureInfo("en-GB").DateTimeFormat;
            //    o.SupportedCultures = SupportedCultrues;
            //    o.SupportedUICultures = SupportedCultrues;

            //    o.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { } };
            //});
            services.AddLocalization(options => options.ResourcesPath = nameof(Resource));

            #endregion

            #region Jwt
            var key = Encoding.ASCII.GetBytes(Jwt.Key);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidIssuer = Jwt.Issuer,
                        ValidAudience = Jwt.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
            services.ConfigureApplicationCookie(o =>
            {
                o.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = (ctx) =>
                    {
                        ctx.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .SetIsOriginAllowed(isOriginAllowed: _ => true); //for all origins;
                    //builder.SetIsOriginAllowed(isOriginAllowed: _ => true); //for all origins
                });

                IConfigurationSection CorsWebsite = Configuration.GetSection("AllowAll");
                string[] itemArray = CorsWebsite.AsEnumerable().ToList().Where(x => !string.IsNullOrEmpty(x.Value)).Select(x => x.Value).ToArray();

                options.AddPolicy("Client4200", builder =>
                {
                    builder.WithOrigins(itemArray).AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                    .SetIsOriginAllowed(isOriginAllowed: _ => true); //for all origins;;
                });
            });


            #endregion

            #region JasonResponseFormate and Filters


//o =>{o.Filters.Add(typeof(SetLanguage));}
            services.AddMvc().AddNewtonsoftJson()
                 .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             ).AddJsonOptions(opts =>
             {
                 //opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             })
;
            #endregion

            #region Swagger
            services.AddSwaggerGen();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api 1", Version = "v1" });
                options.OperationFilter<CustomHeaderSwaggerAttribute>();
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

                //options.OperationFilter<SwaggerFileOperationFilter>();
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Name = "Authorization"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //{"Bearer", new string[] { }},
            });
            #endregion

            #region Mapping

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion Mapping

            #region Debdancy Injection

            services.AddScoped<IJwt, ValidateJwt>();
           
            services.AddScoped<IEncryption, Encryption>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
          
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            #endregion



            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My API");
                c.DocExpansion(DocExpansion.None);
            });
            #endregion

            #region Cors
            if (IsAllowAllCrospolicyName)
            {
                app.UseCors("AllowAll");
            }
            else
            {
                app.UseCors("Client4200");
            }

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());


            #endregion

            #region Localization
            var LocalOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(LocalOption.Value);
            #endregion

   


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
          
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
             
            });

        }
    }
}
