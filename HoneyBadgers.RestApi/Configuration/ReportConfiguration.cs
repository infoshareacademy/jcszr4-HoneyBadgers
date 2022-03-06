using HoneyBadgers.RestApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.RestApi.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired().HasDefaultValueSql("NEWID()");
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Body).IsRequired();
        }
    }
}
