using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using MyAplication_API.Models;
using MyAplication_API.Models.DTO;
using MyAplication_API.Models.Helpers;
using MyAplication_API.Models.Request;
using MyAplication_API.Models.Response;
using MyAplication_API.Services.Interface;
using System.Text.Json;

namespace MyAplication_API.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly TokenService _tokenService;
        private readonly AplicationContext _usariosServices;

        public LoginServices(
            TokenService tokenService,
            AplicationContext usuariosServices
            )
        {
            _tokenService = tokenService;
            _usariosServices = usuariosServices;
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



        public async Task<string> Validated(string Cod_user, string password)
        {

            var luser = await _usariosServices.Usuarios.FirstOrDefaultAsync(u=> u.cod_usuarios == Cod_user && u.txt_senha == password);
            if (luser != null)
            {
                var admin = false;
                if (luser.role == "Admin")
                {
                    admin = true;

                }
                var token = _tokenService.CreateToken(luser, admin);
                var jwtResponse = new JwtResponse
                {
                    Name = luser.nom_usuarios,
                    Email = luser.txt_email,
                    Admin = admin,
                    Token = token,
                };
                String serial = JsonSerializer.Serialize(jwtResponse);

                return serial;

            }
            return String.Empty;

        }
    }
}
