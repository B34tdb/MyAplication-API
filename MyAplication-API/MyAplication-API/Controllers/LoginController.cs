using Microsoft.AspNetCore.Mvc;
using MyAplication_API.Models.DTO;
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
        
    }
}
