using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.PlanningModels
{
    public class ActivityStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string ActivityStatusName { get; set; }
    }
}