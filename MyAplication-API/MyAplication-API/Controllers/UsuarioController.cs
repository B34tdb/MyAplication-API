using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;

namespace MyAplication_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationContext _context;
        public UsuarioController(AplicationContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> Get()
        {
            var readDto = _context.Usuarios;
            return Ok(readDto);
        }
    }
}
