using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Services
{
    public class UsuasriosServices : IUsuariosServices
    {
        private readonly IUsuariosServices _context;

        public UsuasriosServices(IUsuariosServices context)
        {
            _context = context;

        }

        public IEnumerable<string> GetUsuarioCod(string cod_usuarios)
        {
            return _context.GetUsuarioCod(cod_usuarios);
        }

        public UsuarioDto GetUsuarios(string cod_usuarios)
        {
            return _context.GetUsuarios(cod_usuarios);

        }
    }
}
