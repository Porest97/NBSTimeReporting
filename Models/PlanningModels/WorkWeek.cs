using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.PlanningModels
{
    public class WorkWeek
    {
        public int Id { get; set; }


        //Emloyee
        [Display(Name = "Emlpoyee")]
        public int? PersonId { get; set; }
        [Display(Name = "Emloyee")]
        [ForeignKey("PersonId")]
        public Person Emloyee { get; set; }
        
        
        [Display(Name = "Week #")]
        public int WeekNumber { get; set; }

        public DateTime Monday { get; set; }

        [Display(Name = "#1")]
        public int? ActivityId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("ActivityId")]
        public Activity Activity1 { get; set; }

        [Display(Name = "#2")]
        public int? ActivityId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("ActivityId1")]
        public Activity Activity2 { get; set; }

        [Display(Name = "#3")]
        public int? ActivityId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("ActivityId2")]
        public Activity Activity3 { get; set; }

        [Display(Name = "#4")]
        public int? ActivityId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("ActivityId3")]
        public Activity Activity4 { get; set; }


    }
}
