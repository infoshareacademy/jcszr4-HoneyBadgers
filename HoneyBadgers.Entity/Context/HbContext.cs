using HoneyBadgers.Entity.Configuration;
using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Entity.Context
{
    public class HbContext : DbContext
    {
        public HbContext(DbContextOptions<HbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteMovieConfiguration());
        }
    }
}
