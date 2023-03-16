using AutoMapper;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Services
{
    public class UsuasriosServices : IUsuariosServices
    {
        private readonly AplicationContext _context;
        private readonly IMapper _mapper;

        public UsuasriosServices(AplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    
        public IEnumerable<UsuarioDto> GetUsuarioDtos()
        {
            throw new NotImplementedException();
        }
    }
}
