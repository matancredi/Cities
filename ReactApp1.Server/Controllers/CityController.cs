using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCity()
        {
            Guid control = Guid.NewGuid();

            _logger.LogInformation($"Searching for cities. Control: {control}");
            List <City> cities = new();

            try
            {
                cities = _cityService.Get();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error when listing cities");
                return BadRequest();
            }

            return Ok(cities);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SaveCity(City city)
        {
            try
            {
                _cityService.Save(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when inserting new city");
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCity(int cityId)
        {
            try
            {
                _cityService.Delete(cityId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting given city");
                return BadRequest();
            }

            return Ok();
        }
    }
}
