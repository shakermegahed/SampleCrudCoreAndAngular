using System.Collections.Generic;

namespace Training.DTO
{
    public class ResponeListDTO<T>
    {
        public List<T> List { get; set; }

        public ResponePagingDTO ResultPaging { get; set; }
    }
}
