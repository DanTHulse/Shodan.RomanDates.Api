using System;
using Shodan.RomanDates.Common.Enums;

namespace Shodan.RomanDates.Common.Helpers
{
    public static class DateTimeHelpers
    {
        public static int ConvertToAucYear(this int year, Eras era)
            => era == Eras.AD ? year + 753 : 754 - year;

        public static (int year, Eras era) ConvetToGregorianYear(this int aucYear)
        {
            var year = aucYear - 753;
            return year > 0 ? (year, Eras.AD) : (Math.Abs(year) + 1, Eras.BC);
        }

        public static int IntercalaryMonthLength(this int aucYear)
            => MathHelpers.Modulo(aucYear, 2) == 0 ? 27 : 0;
    }
}
