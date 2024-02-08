using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.DTO.MenClothingType;
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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _MenClothTypeService;
        protected ApiResponse _response;
        public SubCategoryController( ISubCategoryService menClothTypeService)
        {
            _MenClothTypeService = menClothTypeService;
            _response = new ApiResponse();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var subcategory = await _MenClothTypeService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = subcategory;
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
                var subcategory = await _MenClothTypeService.GetByIdAsync(id);
                if (subcategory == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.SystemError;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = subcategory;

            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return Ok(_response);
        }
        [HttpGet]
        [Route("Filter")]
        public async Task<ActionResult<ApiResponse>> GetFilter(int? categoryId, int? subcategoryId)
        {
            try
            {
                var product = await _MenClothTypeService.GetByFilterAsync(categoryId, subcategoryId);
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
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateSubCategoryDto dto)
        {
            try
            {
                var subcategory = await _MenClothTypeService.CreateAsync(dto);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = subcategory;
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
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateSubCategoryDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    return Ok(_response);
                }
                var subcategory = await _MenClothTypeService.GetByIdAsync(dto.SubCategoryId);
                if (subcategory == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = (CommonMessage.CreateOperationFailed);
                    return Ok(_response);
                }

                await _MenClothTypeService.UpdateAsync(dto);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = subcategory;
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
                var Type = await _MenClothTypeService.GetByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);

                }
                await _MenClothTypeService.DeleteAsync(id);
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
