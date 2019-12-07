using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name ="Fort Knox #")]
        public int? FortKnoxNumber { get; set; }


    }
}
