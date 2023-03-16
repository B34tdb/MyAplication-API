using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;
using MyAplication_API.Models.DTO;
using MyAplication_API.Models.Helpers;
using MyAplication_API.Models.Response;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly TokenService _tokenService;
        public LoginServices(TokenService tokenService)
        {

            _tokenService = tokenService;
        }

        public JwtResponse Login()
        {
            //receber um usuario e senha por parametro, 
            //valiudar user4 e psw é valido 
            // quem é o user 
            //gerar o tokend do user quando for certo ou retornar fault

            var let = _tokenService.CreateToken(new UsuarioDto()
            {
                cod_usuario = "teste",
                nom_usuaario = "teste",
                text_email = "teste",
                txt_senha = "teste",
                txt_troca_senha = "teste"
            }, true);
            var response = new JwtResponse()
            {
                CodUsuario = "teste",
                Name = "teste",
                Email = "teste",
                Admin = true,
                Token = let,
            };
            return response;
        }
    }
}
