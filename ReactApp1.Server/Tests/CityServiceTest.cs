using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Tests
{
    [TestClass]
    public class CityServiceTest
    {
        private readonly ICityService _cityService;
        private readonly Mock<ILogger<CityService>> _logger;
        private readonly Mock<ICityRepository> _cityRepository;

        public CityServiceTest()
        {
            _logger = new Mock<ILogger<CityService>>();
            _cityRepository = new Mock<ICityRepository>();
            _cityService = new CityService(_cityRepository.Object, _logger.Object);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void SaveSucess()
        {
            City city = new()
            {
                Name = "Guararema",
                ID = 1,
                CreationDate = DateTime.Now,
                StateID = 1
            };

            //It.IsAny<>()
            //Assert.AreEqual(a, b)
            //.Returns.Verifiable()
            //.ReturnsAsync
            _cityRepository.Setup(c => c.Save(city)).Verifiable();

            _cityService.Save(city);

            _cityRepository.Verify();
        }
    }
}
