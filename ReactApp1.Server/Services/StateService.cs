using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Services
{
    public class StateService : IStateService
    {
        public IStateRepository _stateRepository; 

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        //adicioanr polly
        public List<State> Get()
        {
            return _stateRepository.Get();
        }

    }
}
