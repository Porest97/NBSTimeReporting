using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.TimeReportingExternal.DataModels
{
    public class Oct2020
    {
        public int Id { get; set; }

        //Emloyee
        [Display(Name = "Emlpoyee")]
        public int? PersonId { get; set; }
        [Display(Name = "Emloyee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        //TimeReports
        //Week 1

        [Display(Name = "#1")]
        public int? TimeReportId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("TimeReportId")]
        public TimeReport TimeReport1 { get; set; }

        [Display(Name = "#2")]
        public int? TimeReportId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("TimeReportId1")]
        public TimeReport TimeReport2 { get; set; }

        [Display(Name = "#3")]
        public int? TimeReportId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("TimeReportId2")]
        public TimeReport TimeReport3 { get; set; }

        [Display(Name = "#4")]
        public int? TimeReportId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("TimeReportId3")]
        public TimeReport TimeReport4 { get; set; }

        [Display(Name = "#5")]
        public int? TimeReportId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("TimeReportId4")]
        public TimeReport TimeReport5 { get; set; }

        [Display(Name = "#6")]
        public int? TimeReportId5 { get; set; }
        [Display(Name = "#6")]
        [ForeignKey("TimeReportId5")]
        public TimeReport TimeReport6 { get; set; }

        [Display(Name = "#7")]
        public int? TimeReportId6 { get; set; }
        [Display(Name = "#7")]
        [ForeignKey("TimeReportId6")]
        public TimeReport TimeReport7 { get; set; }

        // Week 2
        [Display(Name = "#8")]
        public int? TimeReportId7 { get; set; }
        [Display(Name = "#8")]
        [ForeignKey("TimeReportId7")]
        public TimeReport TimeReport8 { get; set; }

        [Display(Name = "#9")]
        public int? TimeReportId8 { get; set; }
        [Display(Name = "#9")]
        [ForeignKey("TimeReportId8")]
        public TimeReport TimeReport9 { get; set; }

        [Display(Name = "#10")]
        public int? TimeReportId9 { get; set; }
        [Display(Name = "#10")]
        [ForeignKey("TimeReportId9")]
        public TimeReport TimeReport10 { get; set; }

        [Display(Name = "#11")]
        public int? TimeReportId10 { get; set; }
        [Display(Name = "#11")]
        [ForeignKey("TimeReportId10")]
        public TimeReport TimeReport11 { get; set; }

        [Display(Name = "#12")]
        public int? TimeReportId11 { get; set; }
        [Display(Name = "#12")]
        [ForeignKey("TimeReportId11")]
        public TimeReport TimeReport12 { get; set; }

        [Display(Name = "#13")]
        public int? TimeReportId12 { get; set; }
        [Display(Name = "#13")]
        [ForeignKey("TimeReportId12")]
        public TimeReport TimeReport113 { get; set; }

        [Display(Name = "#14")]
        public int? TimeReportId13 { get; set; }
        [Display(Name = "#14")]
        [ForeignKey("TimeReportId13")]
        public TimeReport TimeReport13 { get; set; }

        //Calc Props !

        public double HoursWorked { get; set; }

        public double TotalPayment { get; set; }

    }
}
