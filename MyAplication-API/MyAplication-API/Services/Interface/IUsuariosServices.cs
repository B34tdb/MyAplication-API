using MyAplication_API.Models.DTO;

namespace MyAplication_API.Services.Interface
{
    public interface IUsuariosServices
    {

        public Task<IEnumerable<UsuarioDto>> GetUsuarios(string cod_usuarios);

        public Task<UsuarioDto> GetUsuarioCod(string cod_usuarios);
    }
}
