﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.SettingModels
{
    public class TicketStatus
    {
        public int Id { get; set; }

        [Display(Name ="Status")]
        public string TicketStatusName { get; set; }
    }
}
