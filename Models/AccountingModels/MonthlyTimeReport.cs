using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class MonthlyTimeReport
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

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }

        //WeekReports !

        [Display(Name = "#1")]
        public int? WeeklyTimeReportId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("WeeklyTimeReportId")]
        public WeeklyTimeReport WTR1 { get; set; }

        [Display(Name = "#2")]
        public int? WeeklyTimeReportId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("WeeklyTimeReportId1")]
        public WeeklyTimeReport WTR2 { get; set; }

        [Display(Name = "#3")]
        public int? WeeklyTimeReportId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("WeeklyTimeReportId2")]
        public WeeklyTimeReport WTR3 { get; set; }

        [Display(Name = "#4")]
        public int? WeeklyTimeReportId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("WeeklyTimeReportId3")]
        public WeeklyTimeReport WTR4 { get; set; }

        [Display(Name = "#5")]
        public int? WeeklyTimeReportId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("WeeklyTimeReportId4")]
        public WeeklyTimeReport WTR5 { get; set; }

        //Total time worked
        [Display(Name = "Total Hours")]
        public decimal TotalTimeWorked { get; set; }

    }
}
