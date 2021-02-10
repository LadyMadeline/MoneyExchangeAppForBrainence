using MoneyExchangeAppForBrainence.Data;
using MoneyExchangeAppForBrainence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Repositoris
{
    public class SQLHistoryStorage
    {
        public ExchangeRequestContext Context { get; set; }

        public SQLHistoryStorage(ExchangeRequestContext context)
        {
            this.Context = context;
        }

        public void AddHistory(string firstCurrency, double sum, string secondCurrency, double convertedSum)
        {
            string date = DateTime.Today.ToShortDateString();
            ExchangeRequest exchangeRequest = new ExchangeRequest(0, firstCurrency, sum, secondCurrency, convertedSum, date);
            Context.Add<ExchangeRequest>(exchangeRequest);
            Context.SaveChanges();
        }

        public List<ExchangeRequest> GetHistory()
        {
            return Context.ExchangeRequests.ToList();
        }

        public void CleanHistory()
        {
            foreach (ExchangeRequest item in Context.ExchangeRequests)
            {
                Context.ExchangeRequests.Remove(item);
            }

            Context.SaveChanges();
        }
    }
}
