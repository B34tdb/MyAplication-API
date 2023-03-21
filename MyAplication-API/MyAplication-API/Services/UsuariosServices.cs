using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly AplicationContext _context;

        public UsuariosServices(AplicationContext context)
        {
            _context = context;
        }

        public async Task<UsuarioDto> GetUsuarioCod(string cod_usuarios)
        {
            var ola = await _context.Usuarios.FirstOrDefaultAsync(u => u.cod_usuarios == cod_usuarios);
            if (ola == null)
            {
                return null;
            }
            return ola;
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuarios(string cod_usuarios)
        {
            var read = await _context.Usuarios.Where(u => u.cod_usuarios == cod_usuarios).ToListAsync();
            if (read == null)
            {
                return null;
            }
            return read;

        }
    }
}
