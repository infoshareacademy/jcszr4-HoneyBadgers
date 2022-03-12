using HoneyBadgers.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.RestApi.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<ReportGenreStats>
    {
        public void Configure(EntityTypeBuilder<ReportGenreStats> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired().HasDefaultValueSql("NEWID()");
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Body).IsRequired();
        }
    }
}
