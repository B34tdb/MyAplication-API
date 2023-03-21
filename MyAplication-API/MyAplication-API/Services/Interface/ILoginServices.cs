using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MyAplication_API.Models.Response;

namespace MyAplication_API.Services.Interface
{
    public interface ILoginServices
    {
        JwtResponse Login();
        Task<string> Validated(string Cod_user, string Password);
    }
}
