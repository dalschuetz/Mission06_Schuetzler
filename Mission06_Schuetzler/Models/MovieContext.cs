using Microsoft.EntityFrameworkCore; // Entity Framework

namespace Mission06_Schuetzler.Models // Models, Namespace
{
    // Allows to add data to database
    public class MovieContext : DbContext // DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) // Constructor, Dependency Injection
        {
        }

        public DbSet<Movie> Movies { get; set; } // DbSet, Entity Framework
        public DbSet<Category> Categories { get; set; } // DbSet, Entity Framework
    }
}
