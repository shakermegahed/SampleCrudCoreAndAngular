using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Training.Domain.Entities
{
  public  class Product
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Price { get; set; }

        [ForeignKey(nameof(Categories))]
        public long CategoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
