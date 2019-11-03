using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.SettingModels
{
    public class SiteType
    {
        public int Id { get; set; }

        [Display(Name = "Site Type")]
        public string SiteTypeName { get; set; }
    }
}
