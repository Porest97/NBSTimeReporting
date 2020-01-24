using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.PlanningModels
{
    public class Activity
    {
        public int Id { get; set; }

        public string ActivityName { get; set; }

        public int? ActivityStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ActivityStatusId")]
        public ActivityStatus ActivityStatus { get; set; }

        public int? ActivityTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("ActivityTypeId")]
        public ActivityType ActivityType { get; set; }

        [Display(Name = "Start DateTime Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd/ddd HH:mm}")]
        public DateTime FromDateTime { get; set; }

        [Display(Name = "End DateTime Day")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd/ddd HH:mm}")]
        public DateTime ToDateTime { get; set; }

        [Display(Name = "Duration")]
        public decimal Duration { get; set; }

        

    }
}
