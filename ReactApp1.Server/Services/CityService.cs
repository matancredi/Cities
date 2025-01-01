using Polly;
using Polly.Retry;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Services
{
    public class CityService : ICityService
    {
        public ICityRepository _cityRepository;
        public ILogger<CityService> _logger;
        public RetryPolicy _retryPolicy;

        public CityService(ICityRepository cityRepository, ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
            _retryPolicy = WaitRetryPolicy();
        }

        private RetryPolicy WaitRetryPolicy()
        {
            return Policy.Handle<Exception>()
                .WaitAndRetry(
                    3,
                    retryAttempt => TimeSpan.FromSeconds(1),
                    (exception, tempo, retryCount, context) =>
                    {
                        _logger.LogWarning(exception, $"Error when executing one method from CityService. Retry #{retryCount}");
                    }                
                );
        }

        //private AsyncRetryPolicy WaitRetryPolicyAsync()
        //{
        //    return Policy.Handle<Exception>()
        //        .WaitAndRetryAsync(
        //            3,
        //            retryAttempt => TimeSpan.FromSeconds(1),
        //            (exception, tempo, retryCount, context) =>
        //            {
        //                _logger.LogWarning(exception, $"Error when executing one method from CityService. Retry #{retryCount}");
        //            }
        //        );
        //}

        //adicioanr polly
        public List<City> Get()
        {
            return _retryPolicy.Execute(() => _cityRepository.Get());
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
