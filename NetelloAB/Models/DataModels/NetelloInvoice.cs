using NBSTimeReporting.DWorkin.Models.DataModels;
using NBSTimeReporting.DWorkin.Regus.DataModels;
using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.NetelloAB.Models.DataModels
{
    public class NetelloInvoice
    {
        public int Id { get; set; }

        //NetelloInvoice Payload props.
        public int? RegusTicketId { get; set; }
        [Display(Name = "Ticket")]
        [ForeignKey("RegusTicketId")]
        public RegusTicket RegusTicket { get; set; }

        public int? DWWorkLogId { get; set; }
        [Display(Name = "Work Log")]
        [ForeignKey("DWWorkLogId")]
        public DWWorkLog DWWorkLog { get; set; }

        // Invoicing props.

        [Display(Name = "Hours")]
        public decimal WLHours { get; set; }

        [Display(Name = "Mtrl. Kost")]
        public decimal MaterialKost { get; set; }

        [Display(Name = "Price (Hrs.)")]
        public decimal HourPrice { get; set; }

        [Display(Name = "Total to pay")]
        public decimal TotalKost { get; set; }

        public int? InvoiceStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("InvoiceStatusId")]
        public InvoiceStatus InvoiceStatus { get; set; }

        [Display(Name = "Due to pay. Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }


        [Display(Name = "Payed. Date")]
        [DataType(DataType.Date)]
        public DateTime? PayedDate { get; set; }

        // Internal Invoicing props.

        [Display(Name ="Fort Nox #")]
        public string FoerNoxNumber { get; set; }


    }
}
