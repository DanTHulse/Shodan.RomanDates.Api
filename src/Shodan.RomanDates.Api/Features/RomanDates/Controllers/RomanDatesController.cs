using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.Services.Interfaces;
using Shodan.RomanDates.Api.Features.RomanDates.ViewModels;

namespace Shodan.RomanDates.Api.Features.RomanDates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanDatesController : ControllerBase
    {
        private readonly ILogger<RomanDatesController> _logger;
        private readonly IRomanDatesService _romanDatesService;

        public RomanDatesController(ILogger<RomanDatesController> logger, IRomanDatesService romanDatesService)
        {
            this._logger = logger;
            this._romanDatesService = romanDatesService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(RomanDatesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RomanDatesViewModel>> GetRomanDate([FromQuery] RomanDatesRequestModel model)
        {
            try
            {
                var result = await this._romanDatesService.GetRomanDate(model);

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
