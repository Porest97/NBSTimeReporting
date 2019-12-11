using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class TransactionType
    {
        public int Id { get; set; }
        [Display(Name ="Typ")]
        public string TransactionTypeName { get; set; }
    }
}