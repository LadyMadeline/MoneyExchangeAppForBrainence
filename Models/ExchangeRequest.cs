using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Models
{
    public class ExchangeRequest
    {
        public int ExchangeRequestId { get; set; }

        [DisplayName("From currency")]
        public string FromCurrency { get; set; }

        [DisplayName("Amount")]
        public double FromAmount { get; set; }

        [DisplayName("To currency")]
        public string ToCorrency { get; set; }

        [DisplayName("Converted to")]
        public double ToAmount { get; set; }

        [DisplayName("Date")]
        public string Date { get; set; }

        public ExchangeRequest()
        {

        }

        public ExchangeRequest(int id, string fromCurrency, double fromAmount, string toCurrency, double toAmount, string date)
        {
            this.ExchangeRequestId = id;
            this.FromCurrency = fromCurrency;
            this.FromAmount = fromAmount;
            this.ToCorrency = toCurrency;
            this.ToAmount = Math.Round(toAmount, 2);
            this.Date = date;
        }
    }
}
