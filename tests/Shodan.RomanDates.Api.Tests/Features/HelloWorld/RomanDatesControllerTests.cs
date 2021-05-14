using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shodan.RomanDates.Api.Features.RomanDates.Controllers;
using Shodan.RomanDates.Api.Features.RomanDates.RequestModels;
using Shodan.RomanDates.Api.Features.RomanDates.Services.Interfaces;
using Shodan.RomanDates.Api.Tests.Features.RomanDates.MockData;

namespace Shodan.RomanDates.Api.Tests.Features.RomanDates
{
    [TestClass]
    public class RomanDatesControllerTests
    {
        private readonly Mock<ILogger<RomanDatesController>> _mockLogger = new Mock<ILogger<RomanDatesController>>();
        private readonly Mock<IRomanDatesService> _mockRomanDatesService = new Mock<IRomanDatesService>();

        private RomanDatesController _sut;

        [TestInitialize]
        public void Setup()
            => this._sut = new RomanDatesController(this._mockLogger.Object, this._mockRomanDatesService.Object);

        #region GetRomanDate

        [TestMethod]
        public async Task HelloWorld_OnSuccess_ReturnsOk()
        {
            _ = this._mockRomanDatesService.Setup(s => s.GetRomanDate(It.IsAny<RomanDatesRequestModel>()))
                .ReturnsAsync(MockRomanDatesViewModel.GetData);

            var result = await this._sut.GetRomanDate(new RomanDatesRequestModel());

            this._mockRomanDatesService.Verify(v => v.GetRomanDate(It.IsAny<RomanDatesRequestModel>()), Times.Once);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task HelloWorld_OnValidationFailure_ReturnsBadRequest()
        {
            _ = this._mockRomanDatesService.Setup(s => s.GetRomanDate(It.IsAny<RomanDatesRequestModel>()))
                .ReturnsAsync(MockRomanDatesViewModel.GetData);

            var result = await this._sut.GetRomanDate(new RomanDatesRequestModel());

            this._mockRomanDatesService.Verify(v => v.GetRomanDate(It.IsAny<RomanDatesRequestModel>()), Times.Never);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task HelloWorld_OnException_ReturnsInternalServerError()
        {
            _ = this._mockRomanDatesService.Setup(s => s.GetRomanDate(It.IsAny<RomanDatesRequestModel>()))
                .ThrowsAsync(new Exception());

            var result = await this._sut.GetRomanDate(It.IsAny<RomanDatesRequestModel>());

            this._mockRomanDatesService.Verify(v => v.GetRomanDate(It.IsAny<RomanDatesRequestModel>()), Times.Never);

            Assert.IsInstanceOfType(result.Result, typeof(ObjectResult));
        }

        #endregion
    }
}
