using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shodan.RomanDates.Api.Features.RomanDates.Repositories.Interfaces;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.Services;
using Shodan.RomanDates.Api.Tests.Features.RomanDates.MockData;

namespace Shodan.RomanDates.Api.Tests.Features.RomanDates
{
    [TestClass]
    public class RomanDatesServiceTests
    {
        private readonly Mock<ILogger<RomanDatesService>> _mockLogger = new Mock<ILogger<RomanDatesService>>();
        private readonly Mock<IRomanDatesRepository> _mockRomanDatesRepository = new Mock<IRomanDatesRepository>();

        private RomanDatesService _sut;

        [TestInitialize]
        public void Setup()
            => this._sut = new RomanDatesService(this._mockLogger.Object, this._mockRomanDatesRepository.Object);

        [TestMethod]
        public async Task HelloWorld_CalledOnce()
        {
            _ = this._mockRomanDatesRepository.Setup(s => s.GetRomanDate(It.IsAny<RomanDatesRequestModel>()))
                .ReturnsAsync(MockRomanDatesViewModel.GetData);

            _ = await this._sut.GetRomanDate(It.IsAny<RomanDatesRequestModel>());

            this._mockRomanDatesRepository.Verify(v => v.GetRomanDate(It.IsAny<RomanDatesRequestModel>()), Times.Once);
        }
    }
}
