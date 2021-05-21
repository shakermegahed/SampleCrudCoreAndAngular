using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Domain.ViewModel;
using Training.Domain.ViewModel.Pro;
using Training.DTO;
using Training.DTO.ActionFilters;
using Training.Service.Interface;

namespace Training.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService
            , ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MessageResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductViewModel viewModel)
        {
            try
            {
                return Ok(await productService.Add(viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MessageResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel viewModel)
        {
            try
            {
                return Ok(await productService.Update(viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(MessageResponse))]
        [HttpGet]
        public async Task<IActionResult> GetProductById(long id)
        {
            try
            {
                ProductViewModel pro = await productService.GetById(id);
                if (pro == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return Ok(pro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponeListDTO<ProductViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [HttpPost]
        public async Task<IActionResult> GetAllProduct(ProductFilterDTO Filter)
        {
            try
            {
                return Ok(await productService.GetAll(Filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MessageResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            try
            {
                return Ok(await productService.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Domain.Entities.Category>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionMessageResponse))]
        [HttpGet]
        public async Task<IActionResult> GetCategory()
       {
            try
            {
                return Ok(await categoryService.GetCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
