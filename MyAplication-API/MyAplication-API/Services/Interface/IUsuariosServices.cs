using MyAplication_API.Models.DTO;

namespace MyAplication_API.Services.Interface
{
    public interface IUsuariosServices
    {
        public UsuarioDto GetUsuarios(string cod_usuarioss);

        public IEnumerable<string> GetUsuarioCod(string cod_usuarios);
    }
}
