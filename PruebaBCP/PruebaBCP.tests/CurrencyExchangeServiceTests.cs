using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using PruebaBCP.Models;
using PruebaBCP.Repositories;
using PruebaBCP.Services;

namespace PruebaBCP.tests
{

    [TestFixture]
    public class CurrencyExchangeServiceTests
    {
        private CurrencyExchangeService service;
        private Mock<ICurrencyExchangeRepository> repoMock;
        private Mock<ICurrencyRepository> currencyRepoMock;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<ICurrencyExchangeRepository>();
            currencyRepoMock = new Mock<ICurrencyRepository>();
            service = new CurrencyExchangeService(repoMock.Object, currencyRepoMock.Object);
        }

        [Test]
        public void ValidateSameFromAsTo()
        {
            var dbCurrency = new Currency();
            var amount = 100;
            currencyRepoMock.Setup(x => x.Get("PEN")).Returns(dbCurrency);
            var result = service.CalculateChangeExchange("PEN", "PEN", amount);
            Assert.AreEqual(0, repoMock.Invocations.Count);
            Assert.IsTrue(dbCurrency == result.FromCurrency && dbCurrency == result.ToCurrency);
            Assert.AreEqual(amount, result.ConvertResult);
        }

        [Test]
        public void ValidateDifferentFromAndTo()
        {
            var penCurrency = new Currency() { Code = "PEN", Name = "" };
            var usdCurrency = new Currency() { Code = "USD", Name = "" };
            var rate = (decimal)2.62;
            var currencyExchange = new CurrencyExchange()
            {
                ToCurrency = usdCurrency,
                FromCurrency = usdCurrency,
                Rate = rate
            };


            var amount = 100;
            repoMock.Setup(x => x.Find("PEN", "USD")).Returns(currencyExchange);

            var result = service.CalculateChangeExchange("PEN", "USD", amount);

            Assert.AreEqual(0, currencyRepoMock.Invocations.Count);
            Assert.AreEqual(amount * rate, result.ConvertResult);
        }
    }
}
