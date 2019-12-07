using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class SallaryReport
    {
        public int Id { get; set; }

        //Report Settings
        [Display(Name = "Status")]
        public int? ReportStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReportStatusId")]
        public ReportStatus ReportStatus { get; set; }

        [Display(Name = "Month")]
        public string Month { get; set; }

        //Emloyee
        [Display(Name = "Ëmployee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        //TimeWorket
        [Display(Name = "Hours")]
        public decimal TimeWorked { get; set; }

        //Sallary GET
        [Display(Name = "CpH(kr)")]
        [DataType(DataType.Currency)]
        public decimal PaymentPerHour { get; set; }

        [Display(Name = "TF(kr)")]
        [DataType(DataType.Currency)]
        public decimal TotalPayment { get; set; }

        //Payment
        [Display(Name = "Payed")]
        public bool Payed { get; set; } = false;

        [Display(Name = "Payed(kr)")]
        [DataType(DataType.Currency)]
        public decimal AmountPayed { get; set; }

        [Display(Name = "Remaining")]
        [DataType(DataType.Currency)]
        public decimal DueToPay { get; set; }
    }
}
