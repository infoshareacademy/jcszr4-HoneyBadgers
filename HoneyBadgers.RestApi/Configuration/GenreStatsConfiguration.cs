using HoneyBadgers.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.RestApi.Configuration
{
    public class GenreStatsConfiguration : IEntityTypeConfiguration<GenreStats>
    {
        public void Configure(EntityTypeBuilder<GenreStats> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired().HasDefaultValueSql("NEWID()");
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.UserEmail).HasMaxLength(200).IsRequired();
            builder.Property(m => m.GenreId).IsRequired();
            builder.Property(m => m.GenreName).HasMaxLength(150).IsRequired();
        }
    }
}
