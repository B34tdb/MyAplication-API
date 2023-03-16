namespace MyAplication_API.Models.Response
{
    public class JwtResponse
    {
        public string CodUsuario { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Admin { get; set; }
    }
}
