using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired().HasDefaultValueSql("NEWID()");
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Title).HasMaxLength(150).IsRequired();
            builder.Property(m => m.Plot).HasMaxLength(500);
            builder.Property(m => m.Director).HasMaxLength(150);
            builder.Property(m => m.Actors).HasMaxLength(150);
            builder.Property(m => m.Writer).HasMaxLength(150);
            builder.HasMany(m => m.Genre).WithMany(g => g.Movies);
            builder.HasMany(m => m.Ratings).WithOne();
            builder.HasMany(m => m.Reviews).WithOne(r => r.Movie).HasForeignKey(m => m.MovieId);
        }
    }
}
