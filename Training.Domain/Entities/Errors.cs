using System;
using System.ComponentModel.DataAnnotations;

namespace Training.Domain.Entities
{
    public class Errors
    {
        [Key]
        public long Id { get; set; }
        public string Error { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}