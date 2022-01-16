using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired();
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.Name).HasMaxLength(150).IsRequired();
        }
    }
}
