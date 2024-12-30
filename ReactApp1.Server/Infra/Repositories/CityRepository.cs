using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Infra.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly Context _context;

        public CityRepository(Context context)
        {
            _context = context;
        }

        public List<City> Get()
        {
            if (_context.Cities.Any())
            {
                return _context.Cities.ToList();
            }
            throw new Exception("Não existem cidades cadastradas");
        }
    }
}
