namespace PruebaBCP.Models
{
    public class CurrencyExchange
    {
        public Currency FromCurrency { get; set; }
        public Currency ToCurrency { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal Rate { get; set; }
    }
}
