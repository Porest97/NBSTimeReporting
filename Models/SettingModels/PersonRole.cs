using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.SettingModels
{
    public class PersonRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string PersonRoleName { get; set; }
    }
}