﻿using MoneyExchangeAppForBrainence.Data;
using MoneyExchangeAppForBrainence.Models;
using MoneyExchangeAppForBrainence.Repositoris;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Services
{
    public class MoneyExchangeService : IMoneyExchangeService
    {
        private SQLHistoryStorage history { get; set; }

        public MoneyExchangeService(ExchangeRequestContext context)
        {
            this.history = new SQLHistoryStorage(context);
        }

        public string GetRates(string firstCurrency, string secondCurrency)
        {
            string rates = string.Empty;
            string url = String.Format("https://api.exchangeratesapi.io/latest?base={0}&symbols={1}",
                                        Uri.EscapeDataString(firstCurrency),
                                        Uri.EscapeDataString(secondCurrency));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                rates = reader.ReadToEnd();
            }

            return rates;
        }

        public double GetRate(string firstCurrency, string secondCurrency)
        {
            string rates = GetRates(firstCurrency, secondCurrency);
            CurrencyRateList ratesList = JsonSerializer.Deserialize<CurrencyRateList>(rates);
            double rate = ratesList.rates[secondCurrency];
            return rate;
        }

        public double GetConvertedSum(double sum, string firstCurrency, string secondCurrency)
        {
            double rate = GetRate(firstCurrency, secondCurrency);
            double convertedSum = sum * rate;
            history.AddHistory(firstCurrency, sum, secondCurrency, convertedSum);
            return Math.Round(convertedSum, 2);
        }

        public List<ExchangeRequest> GetHistoryStorage()
        {
            return history.GetHistory();
        }

        public void CleanHistoryStorage()
        {
            history.CleanHistory();
        }
    }
}
