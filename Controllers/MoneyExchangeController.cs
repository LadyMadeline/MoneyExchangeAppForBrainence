using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneyExchangeAppForBrainence.Models;
using MoneyExchangeAppForBrainence.Services;
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
        public IMoneyExchangeService MoneyExchangeService { get; set; }

        public MoneyExchangeController(ILogger<MoneyExchangeController> logger, IMoneyExchangeService moneyExchangeService)
        {
            _logger = logger;
            MoneyExchangeService = moneyExchangeService;
        }

        public IActionResult Convert(double amount, string fromCurrency, string toCurrency)
        {
            if (String.IsNullOrEmpty(fromCurrency))
            {
                return View();
            }
            
            double toAmount = MoneyExchangeService.GetConvertedSum(amount, fromCurrency, toCurrency);
            ViewData["fromAmount"] = amount;
            ViewData["toAmount"] = Math.Round(toAmount, 2);
            return View();

        }

        public IActionResult GetHistory()
        {
            List<ExchangeRequest> history = MoneyExchangeService.GetHistoryStorage();
            return View("History", history);
        }

        public IActionResult CleanHistory()
        {
            MoneyExchangeService.CleanHistoryStorage();
            List<ExchangeRequest> history = MoneyExchangeService.GetHistoryStorage();
            return View("History", history);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
