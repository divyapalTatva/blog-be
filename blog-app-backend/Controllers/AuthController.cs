using blog_app_common.GenericResponse;
using blog_app_models.ViewModels;
using blog_app_services.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Dependency Injection
        private readonly IAuthService AuthService;

        public AuthController(IAuthService _AuthService)
        {
            AuthService = _AuthService;
        }
        #endregion

        #region Authentication
        [HttpPost("Authenticate")]
        public async Task<JsonResult> Authenticate([FromBody]LoginVM loginData)
        {
            if (ModelState.IsValid)
            {
                return await AuthService.AuthUser(loginData.password);
            }
            return new JsonResult(new GenericResponse<string> { Message = ResponseMessages.InternalServerError, StatusCode = blog_app_common.GenericResponse.StatusCodes.BadRequest, Result = false });
        }
        #endregion

    }
}
