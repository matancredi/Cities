using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Services
{
    public class CityService : ICityService
    {
        public ICityRepository _cityRepository; 

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        //adicioanr polly
        public List<City> Get()
        {
            return _cityRepository.Get();
        }

        public int Save(City city)
        {
            return _cityRepository.Save(city);
        }

        public int Delete(int cityId)
        {
            return _cityRepository.Delete(cityId);
        }
    }
}
