using MyAplication_API.Models.DTO;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;



namespace MyAplication_API.Models.Helpers
{
    public class TokenService
    {
        private readonly IConfiguration _config;
            public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(UsuarioDto usuarioDto, bool admin)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuarioDto.nom_usuaario),
                new Claim("role", admin ? "ADMIN": "User"),
                new Claim ("cod", usuarioDto.cod_usuario),
            };
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Security:CypherKey"]));
            var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddDays(2));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
