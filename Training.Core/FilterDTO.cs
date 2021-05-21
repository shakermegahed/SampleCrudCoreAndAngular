using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Training.Domain.Enums;

namespace Training.Core
{
    public  class FilterDTO
    {
        [Required]
        public int PageIndex { get; set; }
        [Required]
        public int PageSize{ get; set; } 
        public string OrderBy { get; set; }
        public string OrderType { get; set; }
        public string Filter { get; set; }
       // public Lang Lang { get; set; }
    }
}
