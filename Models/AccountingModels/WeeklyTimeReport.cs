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
    public class WeeklyTimeReport
    {
        public int Id { get; set; }

        //Report Settings
        [Display(Name = "Status")]
        public int? ReportStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReportStatusId")]
        public ReportStatus ReportStatus { get; set; }

        [Display(Name = "Week")]
        public string WeekNumber { get; set; }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
       
        //Display Id string for adding the WTR to the MTR !
        [Display(Name = "WTR#")]
        public string WTRName { get { return string.Format("{0} {1} ", WeekNumber, Emloyee); } }


        //Emloyee
        [Display(Name = "Emlpoyee")]
        public int? PersonId { get; set; }
        [Display(Name = "Emloyee")]
        [ForeignKey("PersonId")]
        public Person Emloyee { get; set; }

        //Days !
        //#1
        [Display(Name ="Monday")]
        [DataType(DataType.Date)]
        public DateTime Day1 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day1Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day1Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay1 { get; set; }

        //#2
        [Display(Name = "Tuesday")]
        [DataType(DataType.Date)]
        public DateTime Day2 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day2Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day2Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay2 { get; set; }

        //#3
        [Display(Name = "Wednesday")]
        [DataType(DataType.Date)]
        public DateTime Day3 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day3Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day3Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay3 { get; set; }

        //#4
        [Display(Name = "Thursday")]
        [DataType(DataType.Date)]
        public DateTime Day4 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day4Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day4Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay4 { get; set; }

        //#5
        [Display(Name = "Friday")]
        [DataType(DataType.Date)]
        public DateTime Day5 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day5Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day5Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay5 { get; set; }

        //#6
        [Display(Name = "Saturday")]
        [DataType(DataType.Date)]
        public DateTime Day6 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day6Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day6Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay6 { get; set; }

        //#6
        [Display(Name = "Sunday")]
        [DataType(DataType.Date)]
        public DateTime Day7 { get; set; }
        [Display(Name = "Shift started")]
        [DataType(DataType.Time)]
        public DateTime? Day7Started { get; set; }

        [Display(Name = "Shift ended")]
        [DataType(DataType.Time)]
        public DateTime? Day7Ended { get; set; }

        [Display(Name = "Hours")]
        public decimal WorkedDay7 { get; set; }

        [Display(Name = "Total Hours")]
        public decimal WorkedHoursTotal { get; set; }

    }
}
