using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;
using MyAplication_API.Models.DTO;
using MyAplication_API.Models.Helpers;
using MyAplication_API.Models.Request;
using MyAplication_API.Models.Response;
using MyAplication_API.Services.Interface;

namespace MyAplication_API.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly TokenService _tokenService;
        //private readonly ILoginServices _loginRequest;
        //private readonly IUsuariosServices _usariosServices;

        public LoginServices(TokenService tokenService 
            //ILoginServices loginRequest, 
            //IUsuariosServices usuariosServices
            )
        {


            _tokenService = tokenService;
            //_usariosServices = usuariosServices;
            //_loginRequest = loginRequest;
        }

        public JwtResponse Login()
        {
            //receber um usuario e senha por parametro, 
            //valiudar user4 e psw é valido 
            // quem é o user 
            //gerar o tokend do user quando for certo ou retornar fault

            var let = _tokenService.CreateToken(new UsuarioDto()
            {
                cod_usuarios = "teste",
                nom_usuarios = "teste",
                txt_email = "teste",
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

        //public Result Validated(string Cod_user, string Password)
        //{
        //    throw new NotImplementedException();
        //}

        //public Result validated(string user, string password)
        //{
        //    var retorno = _loginrequest.validated(cod_user, password);
        //    if (retorno == null)
        //    {
        //        var luser = _usariosservices.getusuarios(cod_user);
        //        var perfilinfo = _usariosservices.getusuariocod(cod_usuarios);


        //    }

        //}
        //public Result Validated(string cod_user, string password)
        //{
        //    var user = _loginRequest.GetByCodUser(cod_user);

        //    if (user == null)
        //    {
        //        return Result.Failure("User not found.");
        //    }

        //    if (user.Password != password)
        //    {
        //        return Result.Failure("Invalid password.");
        //    }

        //    // Login successful
        //    var dto = new LoginResponseDto
        //    {
        //        Id = user.Id,
        //        Role = user.Role,
        //        Email = user.Email
        //    };
        //    return Result.Success(dto);
        //}

    }
}
