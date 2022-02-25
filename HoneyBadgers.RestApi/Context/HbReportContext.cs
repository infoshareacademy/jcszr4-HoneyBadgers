using HoneyBadgers.RestApi.Configuration;
using HoneyBadgers.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.RestApi.Context
{
    public class HbReportContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HbReportContext(DbContextOptions<HbReportContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Report> Reports { get; set; }
        public DbSet<GenreStats> GenreStats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GenreStatsConfiguration());
        }
    }
}
