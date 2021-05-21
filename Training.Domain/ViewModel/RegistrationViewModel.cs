using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using Training.Domain.Enums;

namespace Training.Domain.ViewModel
{
    public class RegistrationViewModel : IdentityUser
    {

        [EmailAddress]
        public override string Email { get; set; }
        public override string UserName { get; set; }

        [NotMapped]
        public virtual string Password { get; set; }
        [JsonIgnore]
        public string Department { get; set; }
        [JsonIgnore]
        public string JobDescription { get; set; }
        [JsonIgnore]
        public string WorkPlace { get; set; }

        public string Address { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string ThirdName { get; set; }
        public virtual string LastName { get; set; }

        public string NormalizedName { get; set; }
       
        public long? NationalityId { get; set; }
        [NotMapped]
        public virtual string CaptchaToken { get; set; }
        public string SSNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthDateHijri { get; set; }
        [NotMapped]
        public string HostName { get; set; }
        [JsonIgnore]
        public override bool LockoutEnabled { get; set; }
        [JsonIgnore]
        public bool ChangePassword { get; set; } = false;
        public bool AcceptPolicy { get; set; } = false;
        public bool SubscribeMailList { get; set; } = false;
        ////
        ////
        [JsonIgnore]
        public override string NormalizedEmail { get { return this.Email; } }
        [JsonIgnore]
        public override string NormalizedUserName { get; set; }
        [JsonIgnore]
        public override bool EmailConfirmed { get; set; }
        [JsonIgnore]
        public bool EmailSent { get; set; }
        [JsonIgnore]
        public override string SecurityStamp { get; set; }
        [JsonIgnore]
        public override string ConcurrencyStamp { get; set; }
        [JsonIgnore]
        public override string PasswordHash { get; set; }
        [JsonIgnore]
        public override bool PhoneNumberConfirmed { get; set; }
        [JsonIgnore]
        public override bool TwoFactorEnabled { get; set; }
        [JsonIgnore]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [JsonIgnore]
        public override int AccessFailedCount { get; set; }
        [JsonIgnore]
        public override string Id { get; set; }
    }
}
