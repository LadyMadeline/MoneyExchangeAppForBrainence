using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Services
{
    public interface IMoneyExchangeService
    {
        public string GetRates(string firstCurrency, string secondCurrency);
        public double GetRate(string firstCurrency, string secondCurrency);
        public double GetConvertedSum(double sum, string firstCurrency, string secondCurrency);

    }
}
