using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PruebaBCP.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CurrencyExchangeController : ControllerBase
    {
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CurrencyExchangeController> _logger;

        public CurrencyExchangeController(ILogger<CurrencyExchangeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get([FromQuery]string fromCurrency,[FromQuery] string toCurrency)
        {
            var rng = new Random();
            return Summaries;
        }
    }
}
