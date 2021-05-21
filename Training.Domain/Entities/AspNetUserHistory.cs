using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Training.Domain.Enums;

namespace Training.Domain.Entities
{
    public class AspNetUserHistory
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool? AcceptedUser { get; set; }
        public string Employer { get; set; }
        public long? NationalityId { get; set; }
        public string SSNumber { get; set; }
        public string UserType { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string BirthDateHijri { get; set; }
        public string JobDescription { get; set; }
        public string Department { get; set; }
        public bool ChangePassword { get; set; } = false;
        public string Role { get; set; }
    }
}
