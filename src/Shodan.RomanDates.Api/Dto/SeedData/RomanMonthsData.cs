using System.Collections.Generic;
using Shodan.RomanDates.Api.Dto.Models;

namespace Shodan.RomanDates.Api.Dto.SeedData
{
    public static class RomanMonthsData
    {
        public static IEnumerable<RomanMonth> GetData
        {
            get
            {
                return new List<RomanMonth>
                {
                    new RomanMonth(1, "January", "Ianuarias", 29, 0.82),
                    new RomanMonth(2, "February", "Februarias", 28, 0.91),
                    new RomanMonth(3, "March", "Martias", 31, 1.0),
                    new RomanMonth(4, "April", "Apriles", 29, 1.09),
                    new RomanMonth(5, "May", "Maias", 31, 1.18),
                    new RomanMonth(6, "June", "Iunias", 29, 1.27),
                    new RomanMonth(7, "July", "Quintilis", 31, 1.18),
                    new RomanMonth(8, "August", "Sextilis", 29, 1.09),
                    new RomanMonth(9, "September", "Septembres", 29, 1.0),
                    new RomanMonth(10, "October", "Octobres", 31, 0.91),
                    new RomanMonth(11, "November", "Novembres", 29, 0.82),
                    new RomanMonth(12, "December", "Decembres", 29, 0.73)
                };
            }
        }
    }
}
