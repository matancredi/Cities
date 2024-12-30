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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<City> GetCity()
        {
            List <City> cities = new();

            try
            {
                cities = _cityService.Get();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error when listing cities");
                //return BadRequest();
            }

            //return Ok(cities);
            return cities;
        }
    }
}
