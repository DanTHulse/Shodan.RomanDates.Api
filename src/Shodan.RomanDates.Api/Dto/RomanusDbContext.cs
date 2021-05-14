using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
