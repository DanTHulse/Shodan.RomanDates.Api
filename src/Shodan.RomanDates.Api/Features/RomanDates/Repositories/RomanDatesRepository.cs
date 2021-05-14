using System.Threading.Tasks;
using AutoMapper;
using Shodan.RomanDates.Api.Dto;
using Shodan.RomanDates.Api.Features.RomanDates.Repositories.Interfaces;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;
using Shodan.RomanDates.Api.Features.Shared.Repositories;

namespace Shodan.RomanDates.Api.Features.RomanDates.Repositories
{
    public class RomanDatesRepository : Repository, IRomanDatesRepository
    {
        private readonly IMapper _mapper;

        public RomanDatesRepository(RomanusDbContext templateDbContext, IMapper mapper)
            : base(templateDbContext, mapper)
        {
            this._mapper = mapper;
        }

        public async Task<RomanDatesViewModel> GetRomanDate(RomanDatesRequestModel model)
            => await Task.Run(() => this._mapper.Map<RomanDatesViewModel>(model));
    }
}
