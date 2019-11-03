﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.SettingModels
{
    public class ReportType
    {
        public int Id { get; set; }

        [Display(Name ="Type")]
        public string ReportTypeName { get; set; }
    }
}
