using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class Account
    {
        public int Id { get; set; }

        [Display(Name="Account")]
        public string AccountName { get; set; }


    }
}
