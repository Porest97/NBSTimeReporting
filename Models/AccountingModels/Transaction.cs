using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class Transaction
    {
        public int ID { get; set; }

        public int AccountId { get; set; }
        [Display(Name = "Account")]
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public int TransactionTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Trans. Date")]
        public DateTime TransactionDateTime { get; set; }

        [Display(Name = "Trans. Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Text")]
        public string TransactionText { get; set; }




    }
}
