using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationContext _context;
        private readonly IUsuariosServices _services;
        public UsuarioController(AplicationContext context, IUsuariosServices usuariosServices)
        {
            _context = context;
            _services = usuariosServices;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDto>> Get()
        {
            var readDto = _context.Usuarios;
            return Ok(readDto);
        }

        [AllowAnonymous]
        [HttpGet("ByCod")]
        public async Task<ActionResult<UsuarioDto>> Get(string cod_usuarios)
        {
            var read = await _services.GetUsuarioCod(cod_usuarios);
            if (read == null)
            {
                return NotFound();
            }
            return Ok(read);
        }

        [AllowAnonymous]
        [HttpGet("Cod")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios(string cod_usuarios)
        {
            var read = await _services.GetUsuarios(cod_usuarios);
            if (read == null)
            {
                return NotFound();
            }
            return Ok(read);
        }
    }
}
