using System.ComponentModel.DataAnnotations;

namespace Training.DTO
{
    public class ResponePagingDTO
    {
        [Required]
        public int PageSize { get; set; }

        //count of only coming records
        public int? RecordsTotal { get; set; }

        // count of all records 
        public int RecordsFiltered { get; set; }
    }
}
