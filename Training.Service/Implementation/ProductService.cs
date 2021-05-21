using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Training.Domain.Entities;
using Training.Domain.Enums;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Pro;
using Training.DTO;
using Training.DTO.ActionFilters;
using Training.Implementation;
using Training.Interface;
using Training.Service.Interface;

namespace Training.Service.Implementation
{
    public class ProductService : BaseService<ProductViewModel, Product>,
        IBaseService<ProductViewModel, Product>, IProductService
    {
 

        public ProductService(IUnitOfWork _UnitOfWork, IMapper _Mapper
            )
            : base(_UnitOfWork, _Mapper)
        {
        }
        public async Task<MessageResponse> Add(CreateProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            await _unitOfWork.GetRepository<Product>().InsertAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new MessageResponse
            {
                Message = "Saved",
                Success = true
            };
        }

        public async Task<MessageResponse> Delete(long id)
        {
            var result = (await _unitOfWork.GetRepository<Product>().GetFirstOrDefaultAsync(x => x.Id == id));
            if (result == null)
            {
                return new MessageResponse
                {
                    Message = "Error",
                    Success = false
                };
            }
            await _unitOfWork.GetRepository<Product>().DeleteAsync(result);
            await _unitOfWork.SaveChangesAsync();
            return new MessageResponse
            {
                Message = "Deleted",
                Success = true
            };
        }

        public async Task<ResponeListDTO<ProductViewModel>> GetAll(ProductFilterDTO Filter)
        {
            Expression<Func<Product, bool>> predicate = (x) => (true);
            Filter.Name = (Filter.Name ?? "").Trim();

            predicate = x =>
            (

             (x.Name.Trim().Contains(Filter.Name) ||
            

             x.Categories.Name.Trim().Contains(Filter.Name))
             && true
             );

            var (Total, ModelList) = await base.GetByCustomConditionAsync(predicate,
            Filter.OrderBy, Filter.OrderType == "" || Filter.OrderType == "Asc" ? OrderTypeEnum.Asc : OrderTypeEnum.Desc,
            Filter.PageIndex, Filter.PageSize, x => x.Categories);

            if (ModelList == null)
            {
                ModelList = new List<ProductViewModel>();
            }



            return new ResponeListDTO<ProductViewModel>
            {
                List = ModelList,
                ResultPaging = new ResponePagingDTO
                {
                    PageSize = Filter.PageSize,
                    RecordsFiltered = Total,
                    RecordsTotal = ModelList.Count
                }
            };
        }

        public async Task<ProductViewModel> GetById(long id)
        {

            var result = (await _unitOfWork.GetRepository<Product>().GetByIdAsync(id));
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<ProductViewModel>(result);
        }

        public async Task<MessageResponse> Update(UpdateProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            await _unitOfWork.GetRepository<Product>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new MessageResponse
            {
                Message = "Updated",
                Success = true
            };
        }
    }
}
