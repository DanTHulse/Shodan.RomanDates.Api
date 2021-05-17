using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shodan.RomanDates.Api.Dto.Models;
using Shodan.RomanDates.Api.Dto.SeedData;

namespace Shodan.RomanDates.Api.Dto.Configurations
{
    public partial class RomanMonthConfiguration : IEntityTypeConfiguration<RomanMonth>
    {
        public void Configure(EntityTypeBuilder<RomanMonth> builder)
        {
            _ = builder.HasKey(e => e.MonthId)
                .HasName("pk_month_month_id");

            _ = builder.HasData(RomanMonthsData.GetData);
        }
    }
}
