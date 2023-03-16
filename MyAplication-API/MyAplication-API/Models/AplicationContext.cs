using Microsoft.EntityFrameworkCore;
using MyAplication_API.Models.DTO;

namespace MyAplication_API.Models
{
    public class AplicationContext : DbContext
    {

        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

        public DbSet<LoginDto> Logins { get; set; }

        public DbSet<UsuarioDto> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDto>().HasNoKey();
        }
    }
}
