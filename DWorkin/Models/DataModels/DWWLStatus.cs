using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.DWorkin.Models.DataModels
{
    public class DWWLStatus
    {
        public int Id { get; set; }

        [Display(Name="WL Status")]
        public string DWWLStatusName { get; set; }

    }
}
