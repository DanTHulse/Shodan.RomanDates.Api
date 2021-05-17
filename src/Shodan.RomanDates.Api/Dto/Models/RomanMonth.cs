using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shodan.RomanDates.Api.Dto.Models
{
    [Table("month", Schema = "romanus")]
    public partial class RomanMonth
    {
        public RomanMonth()
        {
        }

        public RomanMonth(int monthId, string monthName, string latinMonthName, int monthLengthDays, double averageHour)
        {
            this.MonthId = monthId;
            this.MonthName = monthName;
            this.LatinMonthName = latinMonthName;
            this.MonthLengthDays = monthLengthDays;
            this.AverageDaytimeHourLength = averageHour;
        }

        [Key]
        [Column("month_id")]
        public int MonthId { get; set; }

        [Column("month_name")]
        public string MonthName { get; set; }

        [Column("latin_month_name")]
        public string LatinMonthName { get; set; }

        [Column("month_length_days")]
        public int MonthLengthDays { get; set; }

        [Column("average__daytime_hour_length", TypeName = "decimal(3, 2)")]
        public double AverageDaytimeHourLength { get; set; }
    }
}
