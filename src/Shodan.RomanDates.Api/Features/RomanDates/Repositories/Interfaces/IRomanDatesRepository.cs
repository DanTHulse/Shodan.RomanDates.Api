using System.Threading.Tasks;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;
using Shodan.RomanDates.Api.Features.Shared.Interfaces;
using Shodan.RomanDates.Api.Features.Shared.Repositories.Interfaces;

namespace Shodan.RomanDates.Api.Features.RomanDates.Repositories.Interfaces
{
    public interface IRomanDatesRepository : IRepository, ITransient
    {
        Task<RomanDatesViewModel> GetRomanDate(RomanDatesRequestModel model);
    }
}
