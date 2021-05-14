using System.Threading.Tasks;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;
using Shodan.RomanDates.Api.Features.Shared.Interfaces;

namespace Shodan.RomanDates.Api.Features.RomanDates.Services.Interfaces
{
    public interface IRomanDatesService : ITransient
    {
        Task<RomanDatesViewModel> GetRomanDate(RomanDatesRequestModel model);
    }
}
