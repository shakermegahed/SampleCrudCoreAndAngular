using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.DTO;
using Training.Service.Interface;

namespace Training.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategsController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategsController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
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
