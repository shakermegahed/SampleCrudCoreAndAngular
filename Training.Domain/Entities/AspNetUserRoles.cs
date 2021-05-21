using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Domain.Entities
{
    public partial class AspNetUserRoles
    {
        [Key]
        public long Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
