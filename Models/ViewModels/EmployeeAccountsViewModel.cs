using NBSTimeReporting.Models.AccountingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.ViewModels
{
    public class EmployeeAccountsViewModel
    {
        public List<EmployeeAccount> EmployeeAccounts { get; internal set; }
    }
}
