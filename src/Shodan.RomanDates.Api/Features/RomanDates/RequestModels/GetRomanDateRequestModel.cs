using System;
using Shodan.RomanDates.Common.Enums;

namespace Shodan.RomanDates.Api.Features.RomanDates.RequestModels
{
    public class GetRomanDateRequestModel
    {
        public DateTime Date { get; set; }

        public Eras Era { get; set; }
    }
}
