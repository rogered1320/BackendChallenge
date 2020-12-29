using PruebaBCP.Repositories;
using PruebaBCP.ViewModels;

namespace PruebaBCP.Services
{

    public interface ICurrencyExchangeService
    {
        CurrencyExchangeCalculatorResponse CalculateChangeExchange(string fromCurrency, string toCurrency, decimal amount);
    }

    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepository _repository;
        public CurrencyExchangeService(ICurrencyExchangeRepository repository)
        {
            _repository = repository;
        }

        public CurrencyExchangeCalculatorResponse CalculateChangeExchange(string fromCurrency, string toCurrency, decimal amount)
        {
            var exchange = _repository.Find(fromCurrency, toCurrency);
            var newAmount = exchange.Rate * amount;

            return new CurrencyExchangeCalculatorResponse
            {
                FromCurrency = exchange.FromCurrency,
                ToCurrency = exchange.ToCurrency,
                Amount = amount,
                NewAmount = newAmount
            };
        }
    }
}
