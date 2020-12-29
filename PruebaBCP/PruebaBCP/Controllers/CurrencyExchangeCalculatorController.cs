using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaBCP.Models;
using PruebaBCP.Services;
using PruebaBCP.ViewModels;

namespace PruebaBCP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyExchangeCalculatorController : ControllerBase
    {
        private readonly ILogger<CurrencyExchangeCalculatorController> _logger;
        private readonly ICurrencyExchangeService _service;

        public CurrencyExchangeCalculatorController(ILogger<CurrencyExchangeCalculatorController> logger, ICurrencyExchangeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public CurrencyExchangeCalculatorResponse Get([FromQuery]CurrencyExchangeCalculatorPayload payload)
        {
            return _service.CalculateChangeExchange(payload.FromCurrency, payload.ToCurrency, payload.Amount);
        }
    }



}
