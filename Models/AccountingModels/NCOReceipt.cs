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
    public class NCOReceipt
    {
        public int Id { get; set; }

        //NCOReceipt Settings
        [Display(Name = "Status")]
        public int? ReceiptStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReceiptStatusId")]
        public ReeceiptStatus ReceiptStatus { get; set; }

        // Site props !
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Employee props!
        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        // TimeReporting props !
        //Day1
        [Display(Name = "Shift start")]
        public DateTime? Day1Start { get; set; }
        [Display(Name = "Shift end")]
        public DateTime? Day1End { get; set; }
        [Display(Name = "Hours Day1")]
        public decimal TimeWorkedDay1 { get; set; }

        //Day2
        [Display(Name = "Shift start")]
        public DateTime? Day2Start { get; set; }
        [Display(Name = "Shift end")]
        public DateTime? Day2End { get; set; }
        [Display(Name = "Hours Day2")]
        public decimal TimeWorkedDay2 { get; set; }

        //Day3
        [Display(Name = "Shift start")]
        public DateTime? Day3Start { get; set; }
        [Display(Name = "Shift end")]
        public DateTime? Day3End { get; set; }
        [Display(Name = "Hours Day3")]
        public decimal TimeWorkedDay3 { get; set; }

        //Day4
        [Display(Name = "Shift start")]
        public DateTime? Day4Start { get; set; }
        [Display(Name = "Shift end")]
        public DateTime? Day4End { get; set; }
        [Display(Name = "Hours Day4")]
        public decimal TimeWorkedDay4 { get; set; }

        //Day5
        [Display(Name = "Shift start")]
        public DateTime? Day5Start { get; set; }
        [Display(Name = "Shift end")]
        public DateTime? Day5End { get; set; }
        [Display(Name = "Hours Day5")]
        public decimal TimeWorkedDay5 { get; set; }

        //Total Time Wored !
        [Display(Name = "Hours Worked")]
        public decimal TotalTimeWorked { get; set; }

        // Sallary per hour !
        [Display(Name = "Sallary/Hour")]
        public decimal SallaryPerHour { get; set; }

        // Total Sallary !
        [Display(Name = "Total Sallary")]
        public decimal TotalSallary { get; set; }

        // Payment !
        [Display(Name = "Payed")]
        public decimal SallaryPayed { get; set; }
        [Display(Name = "Due To Pay")]
        public decimal SallaryDueToPay { get; set; }

        // FullPayment DateTime !
        [Display(Name ="Payed Date")]
        [DataType(DataType.Date)]
        public DateTime? DateFullyPayed { get; set; }
    }
}
