using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Offering.DataModels
{
    public class Offer
    {
        public int Id { get; set; }

        //DateTime Offering !
        [Display(Name = "Offering Date")]
        public DateTime? DateTimeOffered { get; set; }

        //Employee Identity
        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        //Offering to !
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Ticket 
        [Display(Name = "Ticket #")]
        public string TicketNumber { get; set; }

        [Display(Name = "Job Description")]
        public string Description { get; set; }

        //Scheduling

        [Display(Name = "Schedule Start")]
        public DateTime? DateTimeScheduledStart { get; set; }

        [Display(Name = "Schedule End")]
        public DateTime? DateTimeScheduledEnd { get; set; }

        //Offer calculations !



        //Manhours Kost !
        [Display(Name = "Hours")]       
        public double HoursOnSite { get; set; }

        [Display(Name = "Price per hour")]
        [DataType(DataType.Currency)]
        public double PricePerHour { get; set; }

        [Display(Name = "Kost Hours")]
        [DataType(DataType.Currency)]
        public double KostHours { get; set; }

        //Material Kost !

        [Display(Name = "Kost MTRL")]
        [DataType(DataType.Currency)]
        public double KostMtrl { get; set; }

        //Risk assesment !

        [Display(Name = "Riskfaktor")]
        public double Riskfaktor { get; set; }

        //Total offer amount !

        [Display(Name = "Total Offer")]
        [DataType(DataType.Currency)]
        public double TotalOfferAmount { get; set; }

                                 

    }
}
