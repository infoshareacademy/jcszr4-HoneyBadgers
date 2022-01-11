using HoneyBadgers.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyBadgers.Entity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(s => s.Id).IsUnique();
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(m => m.Email).HasMaxLength(200).IsRequired();
            builder.Property(m => m.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(m => m.LastName).IsRequired();
        }
    }
}