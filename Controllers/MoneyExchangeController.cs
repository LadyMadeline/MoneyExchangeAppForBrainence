using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneyExchangeAppForBrainence.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Controllers
{
    public class MoneyExchangeController : Controller
    {
        private readonly ILogger<MoneyExchangeController> _logger;

        public MoneyExchangeController(ILogger<MoneyExchangeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Convert(double amount, string fromCurrency, string toCurrency)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
