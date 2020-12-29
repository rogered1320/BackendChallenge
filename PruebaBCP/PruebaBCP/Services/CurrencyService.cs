using System.Collections.Generic;
using System.Linq;
using PruebaBCP.Models;
using PruebaBCP.Repositories;
using PruebaBCP.ViewModels;

namespace PruebaBCP.Services
{

    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAll();
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _repository;
        public CurrencyService(ICurrencyRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Currency> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
