using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Training.Domain.Enums;

namespace Training.Domain.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool EmailSent { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string ThirdName { get; set; }
        public virtual string LastName { get; set; }
        public bool? AcceptedUser { get; set; }
        public string Employer { get; set; }

        public string SSNumber { get; set; }
        public string UserType { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string Address { get; set; }
        public Gender? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string BirthDateHijri { get; set; }
        public string JobDescription { get; set; }
        public string Department { get; set; }
        public string WorkPlace { get; set; }
        //public bool IsDeleted { get; set; } = false;
        public bool ChangePassword { get; set; } = false;
        public bool AcceptPolicy { get; set; } = false;
        public bool SubscribeMailList { get; set; } = false;

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
