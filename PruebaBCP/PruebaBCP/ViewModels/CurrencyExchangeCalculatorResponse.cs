using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaBCP.Models;

namespace PruebaBCP.ViewModels
{
    public class CurrencyExchangeCalculatorResponse
    {
        public decimal Amount { get; set; }
        public Currency FromCurrency { get; set; }
        public Currency ToCurrency { get; set; }
        public decimal NewAmount { get; set; }
    }
}
