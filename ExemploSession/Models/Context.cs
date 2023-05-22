using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ExemploSession.Models;

namespace ExemploSession.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
