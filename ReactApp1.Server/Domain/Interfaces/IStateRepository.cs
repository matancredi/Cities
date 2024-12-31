using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Domain.Interfaces
{
    public interface IStateRepository
    {
        public List<State> Get();
    }
}
