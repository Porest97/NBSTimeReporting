using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.PlanningModels
{
    public class ActivityType
    {
        public int Id { get; set; }

        [Display(Name ="Type")]
        public string ActivityTypeName { get; set; }
    }
}