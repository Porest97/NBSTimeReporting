using NBSTimeReporting.Models.AccountingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.ViewModels
{
    public class TransactionsViewModel
    {
        public List<Transaction> Transactions { get; internal set; }
    }
}
