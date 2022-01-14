using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            builder.HasKey(m => new {movieId = m.MovieId, userId = m.UserId});
            builder.Property(m => m.MovieId).IsRequired();
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.Status).IsRequired();
        }
    }
}