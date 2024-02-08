using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        protected ApiResponse _response;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _response = new ApiResponse();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var Category = await _categoryService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Category;
                return Ok(_response);
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<ApiResponse>> GeById(int id)
        {
            try
            {
                var Category = await _categoryService.GetByIdAsync(id);
                if (Category == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.SystemError;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Category;

            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateCategoryDto dto)
        {
            try
            {
                var category = await _categoryService.CreateAsync(dto);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = category;
                _response.DisplayMessage = CommonMessage.CreateOperationSuccess;

            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateCategoryDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    return Ok(_response);
                }
                var category = await _categoryService.GetByIdAsync(dto.CategoryId);
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = (CommonMessage.CreateOperationFailed);
                    return Ok(_response);
                }

                await _categoryService.UpdateAsync(dto);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = category;
                _response.DisplayMessage = CommonMessage.UpdateOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = (CommonMessage.UpdateOperationFailed);
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);
                }
                var category = await _categoryService.GetByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);

                }
                await _categoryService.DeleteAsync(id);
                _response.StatusCode = HttpStatusCode.Found;
                _response.IsSuccess = true;
                _response.DisplayMessage = CommonMessage.DeleteOperationSuccess;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.DisplayMessage = (CommonMessage.DeleteOperationFailed);
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
    }
}
