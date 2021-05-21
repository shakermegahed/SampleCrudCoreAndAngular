using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Entities
{
    public partial class AspNetUserLogins
    {
        [Key]
        public long Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
