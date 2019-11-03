using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.SettingModels
{
    public class SiteStatus
    {
        public int Id { get; set; }

        [Display(Name = "Site Status")]
        public string SiteStatusName { get; set; }
    }
}
