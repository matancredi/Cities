using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Infra.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly Context _context;

        public StateRepository(Context context)
        {
            _context = context;
        }

        public List<State> Get()
        {
            if (_context.Cities.Any())
            {
                return _context.States.ToList();
            }
            throw new Exception("No states registered");
        }
    }
}
