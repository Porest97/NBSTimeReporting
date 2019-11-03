using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Models.SettingModels
{
    public class PersonType
    {
        public int Id { get; set; }

        [Display(Name = "Person Type")]
        public string PersonTypeName { get; set; }
    }
}