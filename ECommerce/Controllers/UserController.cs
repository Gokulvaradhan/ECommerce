using ECommerce.Common;
using ECommerceApplication.Common;
using ECommerceApplication.Interface;
using ECommerceDomain.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ApiResponse _response;


        public UserController(IAuthService authService)
        {
            _authService = authService;
            _response = new ApiResponse();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<ApiResponse>> Register(Register register)
        {
            try
            {
                var user = await _authService.Register(register);

                if (!ModelState.IsValid)
                {
                    _response.AddErrors(ModelState.ToString());
                    _response.DisplayMessage = CommonMessage.RegisterationFailed;
                    return _response;
                }


                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.DisplayMessage = CommonMessage.RegistrationSuccess;
                _response.Result = user;
                return _response;
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
        [Route("Login")]
        public async Task<ActionResult<ApiResponse>> Login(Login login)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _response.AddErrors(ModelState.ToString());
                    _response.DisplayMessage = CommonMessage.LoginFailed;
                    return _response;
                }
                var user = await _authService.Login(login);

                if (user is string)
                {
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.DisplayMessage = CommonMessage.LoginFailed;
                    _response.Result = user;
                    return _response;

                }

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.DisplayMessage = CommonMessage.LoginSuccess;
                _response.Result = user;
                return _response;
            }
            catch (Exception)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.AddErrors(CommonMessage.SystemError);
            }
            return _response;
        }

    }
}
