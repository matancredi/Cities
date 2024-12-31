using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : ControllerBase
    {
        private readonly ILogger<StateController> _logger;
        private readonly IStateService _stateService;

        public StateController(ILogger<StateController> logger, IStateService stateService)
        {
            _stateService = stateService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetStates()
        {
            List <State> states = new();

            try
            {
                states = _stateService.Get();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error when listing states");
                return BadRequest();
            }

            return Ok(states);
        }

    }
}
