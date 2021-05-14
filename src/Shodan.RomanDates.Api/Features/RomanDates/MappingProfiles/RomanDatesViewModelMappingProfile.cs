using AutoMapper;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;

namespace Shodan.RomanDates.Api.Features.RomanDates.MappingProfiles
{
    public class RomanDatesViewModelMappingProfile : Profile
    {
        public RomanDatesViewModelMappingProfile()
        {
            _ = this.CreateMap<RomanDatesRequestModel, RomanDatesViewModel>()
                .ReverseMap();
        }
    }
}
