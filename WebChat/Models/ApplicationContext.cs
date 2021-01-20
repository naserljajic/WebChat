
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebChat.Models.Configuration;

namespace WebChat.Models
{
    public class ApplicationContext : IdentityDbContext<Korisnik>
    {
        public ApplicationContext(DbContextOptions  options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Korisnik> korisniks { get; set; }
    }
}
