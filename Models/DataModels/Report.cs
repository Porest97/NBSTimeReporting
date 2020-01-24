using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.DataModels
{
    public class Report
    {
        public int Id { get; set; }

        //Report Settings
        [Display(Name = "Status")]
        public int? ReportStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReportStatusId")]
        public ReportStatus ReportStatus { get; set; }

        [Display(Name = "Type")]
        public int? ReportTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("ReportTypeId")]
        public ReportType ReportType { get; set; }


        //Emloyee
        [Display(Name = "Emlpoyee")]
        public int? PersonId { get; set; }
        [Display(Name = "Emloyee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        //Site
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Ticket
        [Display(Name = "Ticket")]
        public int? TicketId { get; set; }
        [Display(Name = "Ticket")]
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        //DateTimeStarted
        [Display(Name = "Shift started")]
        public DateTime DateTimeStarted { get; set; }
        [Display(Name = "Shift ended")]
        public DateTime DateTimeEnded { get; set; }
        [Display(Name = "Hours worked")]
        public decimal WorkHours { get; set; }
    }
}
