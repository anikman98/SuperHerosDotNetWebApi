using Microsoft.EntityFrameworkCore;

namespace SuperHeros.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
               
        }

        public DbSet<Superhero> Supehero { get; set; }
    }
}