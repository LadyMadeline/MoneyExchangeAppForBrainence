using Microsoft.EntityFrameworkCore;
using MoneyExchangeAppForBrainence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeAppForBrainence.Data
{
    public class ExchangeRequestContext : DbContext
    {
        public ExchangeRequestContext(DbContextOptions<ExchangeRequestContext> options)
    : base(options)
        {
        }

        public DbSet<ExchangeRequest> ExchangeRequests { get; set; }
    }
}
