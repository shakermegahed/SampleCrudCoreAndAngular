using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Training.Domain.Entities;
using Training.Domain.ViewModel;

using Training.Implementation;
using Training.Interface;

namespace Training.Api.Filters
{
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        readonly string[] _claim;
        [Inject]
        IUnitOfWork UnitOfWork { get; set; }
        TrainingDbContext db = new TrainingDbContext();
        public JwtAuthorizeAttribute(params string[] claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = "";
            try
            {
                token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                ValidateJwt CheckToken = new ValidateJwt();
                JwtToken.Token = token;
                string Id = "";
                Training.Domain.Enums.Roles? ThisRole = null;
                try
                {
                    Id = CheckToken.GetUserIdFromToken();
                    ThisRole = CheckToken.GetRole();
                    CurrentUser.Role = ThisRole;
                    CurrentUser.User = Id;

                }
                catch
                {
                    CurrentUser.User = null;
                }
                if (context.ActionDescriptor.EndpointMetadata
                               .Any(em => em.GetType() == typeof(AllowAnonymousAttribute)))
                {
                    return;
                }

                if (!CheckToken.IsValid(token))
                {
                    NotAuthrized(context, token);
                }
                else
                {

                    try
                    {
                        AspNetUsers ThisUser = db.AspNetUsers.Find(Id);
                        var url = context.HttpContext.Request.Path;

                        if (ThisUser.LockoutEnabled)
                        {
                            NotAuthrized(context, token, "Is Locked");
                        }
                    }
                    catch
                    {

                    }
                    if (_claim.Contains("User") && _claim.Length == 1)
                    {
                        bool WrongRole = true;
                        foreach (var item in _claim)
                        {
                            if (item == ThisRole.ToString())
                            {
                                WrongRole = false;
                                break;
                            }
                        }
                        if (WrongRole)
                        {
                            NotAuthrized(context, token, "Wrong Role");
                        }
                    }

                    //RegistrationViewModel User = await UserManager.FindByIdAsync(CheckToken.GetSubFromToken(token));
                }
            }
            catch (Exception ex)
            {
                NotAuthrized(context, token);
            }

        }

        private static void NotAuthrized(AuthorizationFilterContext context, string token, string Message = "NotAuthorized")
        {
            context.HttpContext.Response.Headers.Add("authToken", token);
            context.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
            context.Result = new JsonResult("NotAuthorized")
            {
                Value = new MessageResponse
                {
                    Message = Message
                },
            };
        }
    }
}
