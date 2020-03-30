using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.DWorkin.Regus.DataModels
{
    public class RegusTicket
    {
        public int Id { get; set; }
        
        

        // Tickets settings
        [Display(Name = "Priority")]
        public int? TicketPriorityId { get; set; }
        [Display(Name = "Priority")]
        [ForeignKey("TicketPriorityId")]
        public TicketPriority TicketPriority { get; set; }
        [Display(Name = "Status")]
        public int? TicketStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("TicketStatusId")]
        public TicketStatus TicketStatus { get; set; }

        [Display(Name = "Type")]
        public int? TicketTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("TicketTypeId")]
        public TicketType TicketType { get; set; }

        //Tickets orgin
        [Display(Name = "RT #")]
        public string RegusTicketNumber { get; set; }
        [Display(Name = "INC#")]
        public string IncidentNumber { get; set; }

        [Display(Name = "Created")]
        public DateTime? Created { get; set; }

        [Display(Name = "Creator")]
        public int? PersonId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("PersonId")]
        public Person Creator { get; set; }

        //Tickets Location
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Tickets Destination
        [Display(Name = "Received")]
        public DateTime? Received { get; set; }

        [Display(Name = "Receiver")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Receiver")]
        [ForeignKey("PersonId1")]
        public Person Receiver { get; set; }

        //Tickets Sceduling
        [Display(Name = "FE Scheduled")]
        public DateTime? FEScheduled { get; set; }

        [Display(Name = "FE Assigned")]
        public int? PersonId2 { get; set; }
        [Display(Name = "FE Assigned")]
        [ForeignKey("PersonId2")]
        public Person FEAssigned { get; set; }

        //Tickets Description
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Tickets Logg
        [Display(Name = "FE Enters Site")]
        public DateTime? FEEntersSite { get; set; }

        [Display(Name = "FE Exits Site")]
        public DateTime? FEEExitsSite { get; set; }

        [Display(Name = "Logg")]
        public string Logg { get; set; }

        //Tickets Resolution
        [Display(Name = "Resolved")]
        public DateTime? IssueResolved { get; set; }


        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        //Tickets Timereport props !
        [Display(Name = "WL#")]
        public string WLNumber { get; set; }

        [Display(Name = "WL Hours")]
        public decimal WLHours { get; set; }

        // Incedent to Invoice concatination

       

       
    }
}
