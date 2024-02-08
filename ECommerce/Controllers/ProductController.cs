using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.DTO.MenClothing;
using ECommerceApplication.DTO.MenClothingType;
using ECommerceApplication.Interface;
using ECommerceApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        protected ApiResponse _response;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
            _response = new ApiResponse();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var Type = await _ProductService.GetAllAsync();
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Type;
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
                var Type = await _ProductService.GetByIdAsync(id);
                if (Type == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.DisplayMessage = CommonMessage.SystemError;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = Type;

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
        public async Task<ActionResult<ApiResponse>> GetFilter( int? categoryId,int?subcategoryId, int? ProductId)
        {
            try
            {
                var product = await _ProductService.GetByFilterAsync( categoryId,subcategoryId, ProductId);
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
        public async Task<ActionResult<ApiResponse>> Create([FromBody] CreateProductDto dto)
        {
            try
            {
                var  product = await _ProductService.CreateAsync(dto);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = product;
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
        public async Task<ActionResult<ApiResponse>> Update([FromBody] UpdateProductDto dto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    return Ok(_response);
                }
                var product = await _ProductService.GetByIdAsync(dto.ProductId);
                if (product == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = (CommonMessage.UpdateOperationFailed);
                    return Ok(_response);
                }

                await _ProductService.UpdateAsync(dto);

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = product;
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
                var product = await _ProductService.GetByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);

                }
                await _ProductService.DeleteAsync(id);
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

