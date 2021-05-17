using Microsoft.EntityFrameworkCore;
using Shodan.RomanDates.Api.Dto.Configurations;
using Shodan.RomanDates.Api.Dto.Models;

namespace Shodan.RomanDates.Api.Dto
{
    public class RomanusDbContext : DbContext
    {
        public RomanusDbContext()
        {
        }

        public RomanusDbContext(DbContextOptions<RomanusDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RomanMonth> RomanMonths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new RomanMonthConfiguration());
        }
    }
}
