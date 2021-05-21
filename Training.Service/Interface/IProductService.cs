using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Pro;
using Training.DTO;
using Training.DTO.ActionFilters;

namespace Training.Service.Interface
{
    public interface IProductService
    {
        Task<MessageResponse> Add(CreateProductViewModel viewModel);
        Task<MessageResponse> Update(UpdateProductViewModel viewModel);
        Task<ProductViewModel> GetById(long id);
        Task<MessageResponse> Delete(long id);
        Task<ResponeListDTO<ProductViewModel>> GetAll(ProductFilterDTO Filter);

    }
}
