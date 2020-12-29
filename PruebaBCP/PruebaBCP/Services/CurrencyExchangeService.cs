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
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyExchangeService(ICurrencyExchangeRepository repository, ICurrencyRepository currencyRepository)
        {
            _repository = repository;
            _currencyRepository = currencyRepository;
        }

        public CurrencyExchangeCalculatorResponse CalculateChangeExchange(string fromCurrency, string toCurrency, decimal amount)
        {
            if (fromCurrency == toCurrency) return GetWithoutConversion(fromCurrency, amount);


            var exchange = _repository.Find(fromCurrency, toCurrency);
            var newAmount = exchange.Rate * amount;
            return new CurrencyExchangeCalculatorResponse
            {
                FromCurrency = exchange.FromCurrency,
                ToCurrency = exchange.ToCurrency,
                Amount = amount,
                ConvertResult = newAmount,
                Rate = exchange.Rate
            };
        }

        private CurrencyExchangeCalculatorResponse GetWithoutConversion(string fromCurrency, decimal amount)
        {
            var currency = _currencyRepository.Get(fromCurrency);
            return new CurrencyExchangeCalculatorResponse
            {
                FromCurrency = currency,
                ToCurrency = currency,
                Amount = amount,
                ConvertResult = amount,
                Rate = 1
            };
        }
    }
}
