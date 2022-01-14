using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Email).HasMaxLength(200).IsRequired();
            builder.Property(m => m.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(150).IsRequired();
        }
    }
}