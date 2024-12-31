using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Domain.Interfaces
{
    public interface IStateService
    {
        public List<State> Get();
    }
}
