using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired();
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.Source).HasMaxLength(150).IsRequired();
            builder.Property(m => m.Value).HasMaxLength(150).IsRequired();
        }
    }
}