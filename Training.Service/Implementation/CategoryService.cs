using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.DTO;
using Training.Implementation;
using Training.Interface;
using Training.Service.Interface;

namespace Training.Service.Implementation
{
    public class CategoryService : BaseService<Domain.Entities.Category, Domain.Entities.Category>,
        IBaseService<Domain.Entities.Category, Domain.Entities.Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork _UnitOfWork, IMapper _Mapper) : base(_UnitOfWork, _Mapper)
        {

        }


        public async Task<ResponeListDTO<Domain.Entities.Category>> GetCategory()
        {
            try
            {
                List<Domain.Entities.Category> cats = (await base.GetAllAsync()).ModelList;

                return new ResponeListDTO<Domain.Entities.Category>
                {
                    List = cats
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
