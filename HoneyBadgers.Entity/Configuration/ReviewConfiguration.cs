using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired();
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.MovieId).IsRequired();
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.Title).IsRequired().HasMaxLength(250);
        }
    }
}