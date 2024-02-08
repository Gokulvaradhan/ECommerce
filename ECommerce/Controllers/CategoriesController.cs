using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.Interface;
using ECommerceApplication.Service;
using ECommerceDomain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        protected ApiResponse _response;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
            _response = new ApiResponse();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var Category = await _categoriesService.GetAllAsync();
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
                var Category = await _categoriesService.GetByIdAsync(id);
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
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateCategoriesDto dto)
        {
            try
            {
                var category = await _categoriesService.createAsync(dto);
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
        [HttpGet]
        [Route("Filter")]
        public async Task<ActionResult<ApiResponse>> GetFilter(int? Id, int? CategoryId)
        {
            try
            {
                var product = await _categoriesService.GetByFilterAsync(Id, CategoryId);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = product;


            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return _response;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateCategoriesDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    return Ok(_response);
                }
                var category = await _categoriesService.GetByIdAsync(dto.CategoryId);
                if (category == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = (CommonMessage.CreateOperationFailed);
                    return Ok(_response);
                }

                await _categoriesService.UpdateAsync(dto);

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
                var category = await _categoriesService.GetByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);

                }
                await _categoriesService.DeleteAsync(id);
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
