using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.SettingModels
{
    public class PersonStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string PersonStatusName { get; set; }
    }
}