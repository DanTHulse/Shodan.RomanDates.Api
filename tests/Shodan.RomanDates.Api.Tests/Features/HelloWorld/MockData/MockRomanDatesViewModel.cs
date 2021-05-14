using System.Collections.Generic;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;

namespace Shodan.RomanDates.Api.Tests.Features.RomanDates.MockData
{
    public static class MockRomanDatesViewModel
    {
        public static RomanDatesViewModel GetData
        {
            get
            {
                return new RomanDatesViewModel
                {
                };
            }
        }

        public static IEnumerable<RomanDatesViewModel> GetListData
        {
            get
            {
                return new List<RomanDatesViewModel>
                {
                    GetData,
                    GetData,
                    GetData,
                    GetData,
                    GetData
                };
            }
        }

        public static IEnumerable<RomanDatesViewModel> GetEmptyList
        {
            get
            {
                return new List<RomanDatesViewModel>
                {
                };
            }
        }
    }
}
