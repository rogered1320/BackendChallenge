using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaBCP.Contexts;
using PruebaBCP.Models;

namespace PruebaBCP.Repositories
{
    public interface ICurrencyExchangeRepository
    {
        CurrencyExchange Find(string fromCurrency, string toCurrency);
    }

    public class CurrencyExchangeRepository: ICurrencyExchangeRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyExchangeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CurrencyExchange Find(string fromCurrency, string toCurrency)
        {
            return _context.CurrencyExchanges
                .Include(x => x.FromCurrency)
                .Include(x => x.ToCurrency)
                .First(x => x.FromCurrencyCode == fromCurrency && x.ToCurrencyCode == toCurrency);
        }
    }
}
