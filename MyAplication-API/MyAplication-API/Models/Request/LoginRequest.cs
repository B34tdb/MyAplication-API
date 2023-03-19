using System.ComponentModel.DataAnnotations;

namespace MyAplication_API.Models.Request
{
    public class LoginRequest
    {
        [Required]
        public string Cod_User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
