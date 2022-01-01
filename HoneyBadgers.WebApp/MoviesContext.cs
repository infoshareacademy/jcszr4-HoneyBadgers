using HoneyBadgers.Logic;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.WebApp
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
    }
}
