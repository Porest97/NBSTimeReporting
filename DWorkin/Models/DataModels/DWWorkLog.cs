using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.DWorkin.Models.DataModels
{
    public class DWWorkLog
    {
        public int Id { get; set; }

        [Display(Name = "WL #")]
        public int WLNumber { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        //Technician
        public int? PersonId { get; set; }
        [Display(Name = "Technician")]
        [ForeignKey("PersonId")]
        public Person Technician { get; set; }

        //DateTime !
        [Display(Name = "Date from")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Date to")]
        public DateTime DateTo { get; set; }

        //Bus. unit, Company, Site !
        [Display(Name = "Bus. unit")]
        public string BusUnit { get; set; }


        public int? CompanyId { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Description
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        //Accounting !

        [Display(Name = "Total hours")]
        public decimal TotalHours { get; set; }

        [Display(Name = "Day off")]
        public decimal DayOffHours{ get; set; }

        [Display(Name = "To invoice")]
        public decimal ToInvoiceHours { get; set; }

        [Display(Name = "OBH")]
        public decimal OBH { get; set; }

        [Display(Name = "WH")]
        public decimal WH { get; set; }

        [Display(Name = "Satisfaction")]
        public decimal WSatisfactionHours { get; set; }

        [Display(Name = "Coefficient")]
        public decimal Coefficient { get; set; }

        // DWorkin WL Status !
        public int? DWWLStatusId { get; set; }
        [Display(Name = "Dworkin WL Status")]
        [ForeignKey("DWWLStatusId")]
        public DWWLStatus DWWLStatus { get; set; }

    }
}
