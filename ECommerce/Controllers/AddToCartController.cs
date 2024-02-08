using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.Interface;
using ECommerceDomain.CartItem;
using ECommerceInfrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartController : ControllerBase
    {

        private readonly IAddToCartService _addToCartService;

        protected ApiResponse _response;

        public AddToCartController(IAddToCartService addToCartService)
        {
             _response = new ApiResponse();
            _addToCartService= addToCartService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            try
            {
                 await _addToCartService.AddToCartAsync();
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
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
                  await _addToCartService.DeleteAsync(id);
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    return Ok(_response);

                }
               
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
