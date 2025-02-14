using Microsoft.EntityFrameworkCore;

namespace Mission06_Schuetzler.Models
{
    //allows to add data to database
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
