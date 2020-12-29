using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaBCP.ViewModels
{
    public class CurrencyExchangeCalculatorPayload
    {
        public decimal Amount { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
    }
}
