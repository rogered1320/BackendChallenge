using System.ComponentModel.DataAnnotations;

namespace PruebaBCP.ViewModels
{
    public class CurrencyExchangeCalculatorPayload
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "La divisa debe seguir el formato de ISO 4217")]
        public string FromCurrency { get; set; }
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "La divisa debe seguir el formato de ISO 4217")]
        public string ToCurrency { get; set; }
    }
}
