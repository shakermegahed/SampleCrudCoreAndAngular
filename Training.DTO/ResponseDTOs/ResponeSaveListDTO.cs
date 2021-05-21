using System.Collections.Generic;

namespace Training.DTO
{
    public class ResponeSaveListDTO<TModel>
    {
        public List<TModel> List { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }

    }
}
