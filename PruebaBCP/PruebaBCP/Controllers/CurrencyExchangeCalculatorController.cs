using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaBCP.Services;
using PruebaBCP.ViewModels;

namespace PruebaBCP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyExchangeCalculatorController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeCalculatorController> _logger;
        private readonly ICurrencyExchangeService _service;

        public CurrencyExchangeCalculatorController(ILogger<CurrencyExchangeCalculatorController> logger, ICurrencyExchangeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [EnableCors("Default")]
        public CurrencyExchangeCalculatorResponse Get([FromBody]CurrencyExchangeCalculatorPayload payload)
        {
            return _service.CalculateChangeExchange(payload.FromCurrency, payload.ToCurrency, payload.Amount);
        }
    }



}
