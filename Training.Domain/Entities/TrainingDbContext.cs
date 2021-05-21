using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Training.Domain.Entities
{
    public partial class TrainingDbContext : DbContext
    {
        public TrainingDbContext()
        {
        }

        public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //public virtual DbSet<Course> Course { get; set; }
        //public virtual DbSet<ElectronicBroadcast> ElectronicBroadcast { get; set; }
        //public virtual DbSet<RequestMaster> UserCourseRequest { get; set; }
        //public virtual DbSet<CourseTermAndConditions> CourseTermAndConditions { get; set; }
        //public virtual DbSet<FAQ> FAQ { get; set; }
        //public virtual DbSet<LKPNationality> LKPNationality { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
       // public virtual DbSet<CourseStatus> CourseStatus { get; set; }
       // public virtual DbSet<CourseTypes> CourseTypes { get; set; }
       // public virtual DbSet<Trainee> Trainee { get; set; }
       // public virtual DbSet<Dictionary> Dictionary { get; set; }
       // public virtual DbSet<Titles> Titles { get; set; }
       // public virtual DbSet<LKPProTypeInfo> LKPProTypeInfo { get; set; }
       // public virtual DbSet<Governmental> Governmental { get; set; }
       // public virtual DbSet<InActiveReason> InActiveReason { get; set; }
       // public virtual DbSet<AspNetUserHistory> AspNetUserHistory { get; set; }
       // public virtual DbSet<TraineeHistory> TraineeHistory { get; set; }
       // public virtual DbSet<GovernmentalHistory> GovernmentalHistory { get; set; }
       // public virtual DbSet<UserCourseRevisionTypes> UserCourseRevisionTypes { get; set; }
       // public virtual DbSet<CourseCancelReason> CourseCancelReason { get; set; }
       // public virtual DbSet<CourseExtraSetting> CourseExtraSetting { get; set; }
       // public virtual DbSet<Log> Log { get; set; }
       // public virtual DbSet<LogTableDictionary> LogTableDictionary { get; set; }
       // public virtual DbSet<RequestMaster> RequestMaster { get; set; }
       // public virtual DbSet<RequestDetails> RequestDetails { get; set; }
       // public virtual DbSet<LkpRequestType> LkpRequestType { get; set; }
       // public virtual DbSet<LkpRequestStatus> LkpRequestStatus { get; set; }

       // public virtual DbSet<Payment> Payment { get; set; }

       // public virtual DbSet<Notification> Notification { get; set; }
       
       // public virtual DbSet<LkpTaskStatus> LkpTaskStatus { get; set; }
       // public virtual DbSet<RequestTasks> RequestTasks { get; set; }
       // public virtual DbSet<RequestTaskUsers> RequestTaskUsers { get; set; }
       // public virtual DbSet<TranieeEnergyForm> TranieeEnergyForm { get; set; }
       // public virtual DbSet<TranieeProCourseForm> TranieeProCourseForm { get; set; }
       // public virtual DbSet<ApprovedCourses> ApprovedCourses { get; set; }
       // public virtual DbSet<CourseAttachment> CourseAttachment { get; set; }
       // public virtual DbSet<ProCourseWords> ProCourseWords { get; set; }
       // public virtual DbSet<WaitingListPriority> WaitingListPriority { get; set; }
       // public virtual DbSet<TechnicalSupport> TechnicalSupport { get; set; }
       // public virtual DbSet<TechnicalSupportMails> TechnicalSupportMails { get; set; }
       // public virtual DbSet<Exemptionletter> Exemptionletter { get; set; }
       // public virtual DbSet<Attendance> Attendance { get; set; }
       //// public virtual DbSet<TestResults> TestResults { get; set; }
       // public virtual DbSet<CourseEvaluationQuestion> CourseEvaluationQuestion { get; set; }
       // public virtual DbSet<TraineeCourseEvaluation> TraineeCourseEvaluation { get; set; }
       // public virtual DbSet<CourseEvaluationAnswerOptions> CourseEvaluationAnswerOptions { get; set; }
       // public virtual DbSet<TraineeCourseCertificate> TraineeCourseCertificate { get; set; }
       // public virtual DbSet<CertificateConfiguration> CertificateConfiguration { get; set; }

       // public virtual DbSet<ElectronicNewsletter> ElectronicNewsletter { get; set; }

       // public virtual DbSet<Advertisement> Advertisement { get; set; }
       // public virtual DbSet<Errors> Errors { get; set; }
       // public virtual DbSet<MainRequsetWithRelatedRequest> MainRequsetWithRelatedRequest { get; set; }
       // public virtual DbSet<RequestReTakeExamDetails> RequestReTakeExamDetails { get; set; }
       // public virtual DbSet<RequestRecruitEmailSetting> RequestRecruitEmailSetting { get; set; }
       // public virtual DbSet<RequestRecruitEmailsCounts> RequestRecruitEmailsCounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
