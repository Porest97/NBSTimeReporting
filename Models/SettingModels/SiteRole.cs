﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.SettingModels
{
    public class SiteRole
    {
        public int Id { get; set; }

        [Display(Name = "Site Role")]
        public string SiteRoleName { get; set; }
    }
}
