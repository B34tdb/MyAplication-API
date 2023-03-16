using MyAplication_API.Models.DTO;

namespace MyAplication_API.Services.Interface
{
    public interface IUsuariosServices
    {
        IEnumerable<UsuarioDto>GetUsuarioDtos();
    }
}
