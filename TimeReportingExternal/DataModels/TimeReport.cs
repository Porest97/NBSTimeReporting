using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.TimeReportingExternal.DataModels
{
    public class TimeReport
    {
        public int Id { get; set; }

        //Location
        [Display(Name = "Customer")]
        public int? SiteId { get; set; }
        [Display(Name = "Customer")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Incident
        [Display(Name = "Incident")]
        public string IncidentNumber { get; set; }
        [Display(Name = "From")]

        //Worked Hours
        public DateTime ShiftStarted { get; set; }
        [Display(Name = "To")]
        public DateTime ShiftEnded { get; set; }
        [Display(Name = "Hours")]
        public double WorkedHours { get; set; }

        //Payments
        [Display(Name = "Fee")]
        public double FeeHour { get; set; }

        [Display(Name = "Total Fee")]
        public double TotalFee { get; set; }

        //Tagging - Notes
        [Display(Name = "Notes")]
        public string Notes { get; set; }

    }
}
