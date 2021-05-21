using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.DTO;

namespace Training.Service.Interface
{
    public interface ICategoryService
    {
        public Task<ResponeListDTO<Domain.Entities.Category>> GetCategory();
    }
}
