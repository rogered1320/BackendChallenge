using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PruebaBCP.Contexts;
using PruebaBCP.Models;

namespace PruebaBCP.Repositories
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAll();
        Currency Get(string code);
    }

    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _context.Currencies.ToList();
        }

        public Currency Get(string code)
        {
            return _context.Currencies.First(x => x.Code == code);
        }
    }
}
