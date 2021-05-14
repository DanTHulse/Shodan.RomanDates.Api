using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shodan.RomanDates.Api.Features.RomanDates.Repositories.Interfaces;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.Services.Interfaces;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;

namespace Shodan.RomanDates.Api.Features.RomanDates.Services
{
    public class RomanDatesService : IRomanDatesService
    {
        private readonly ILogger<RomanDatesService> _logger;
        private readonly IRomanDatesRepository _helloWorldRepository;

        public RomanDatesService(ILogger<RomanDatesService> logger, IRomanDatesRepository helloWorldRepository)
        {
            this._logger = logger;
            this._helloWorldRepository = helloWorldRepository;
        }

        public async Task<RomanDatesViewModel> GetRomanDate(RomanDatesRequestModel model)
            => await this._helloWorldRepository.GetRomanDate(model);
    }
}
