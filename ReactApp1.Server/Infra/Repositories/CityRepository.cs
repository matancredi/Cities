using Microsoft.EntityFrameworkCore;
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

        public int Save(City city)
        {
            if (city.ID == 0)
            {
                _context.Entry(city).State = EntityState.Added;
                _context.Add(city);
            }
            else
            {
                _context.Entry(city).State = EntityState.Modified;
            }
            
            return _context.SaveChanges();
        }

        public int Delete(int cityId)
        {
            City? city = _context.Cities.Where(c => c.ID == cityId).FirstOrDefault();
            if (city == null)
            {
                throw new Exception("City with given ID does not exist in the database.");
            }
            _context.Entry(city).State = EntityState.Deleted;
            return _context.SaveChanges();
        }
    }
}
