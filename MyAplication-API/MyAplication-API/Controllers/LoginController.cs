using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAplication_API.Models.DTO;
using MyAplication_API.Models.Request;
using MyAplication_API.Models.Response;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpGet]
        public ActionResult<JwtResponse> GetLogin()
        {
            JwtResponse response = _loginServices.Login();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
        {
            var user = loginRequest.Cod_User.ToUpper();
            var ret = await _loginServices.Validated(user, loginRequest.Password);
            if (ret != null)
            {
                return Ok(ret);
            }
            return BadRequest(ret);
        }
    }
}
