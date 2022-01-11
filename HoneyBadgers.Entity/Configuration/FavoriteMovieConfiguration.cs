using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class FavoriteMovieConfiguration : IEntityTypeConfiguration<FavoriteMovie>
    {
        public void Configure(EntityTypeBuilder<FavoriteMovie> builder)
        {
            builder.HasKey(m => new {movieId = m.MovieId, userId = m.UserId});
            builder.Property(m => m.MovieId).IsRequired();
            builder.Property(m => m.UserId).IsRequired();
        }
    }
}