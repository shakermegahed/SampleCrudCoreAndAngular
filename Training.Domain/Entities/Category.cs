using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Training.Domain.Entities
{
   public class Category
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }

    }
}
