using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaBCP.Models;
using PruebaBCP.Services;

namespace PruebaBCP.Controllers
{
    [ApiController]
    [EnableCors("Default")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Currency> Get()
        {
            return _service.GetAll();
        }
    }
}
