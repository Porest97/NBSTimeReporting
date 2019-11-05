using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.DataModels
{
    public class Survey
    {
        public int Id { get; set; }
        // Surveys settings
                
        [Display(Name = "Status")]
        public int? SurveyStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("SurveyStatusId")]
        public SurveyStatus SurveyStatus { get; set; }

        [Display(Name = "Type")]
        public int? SurveyTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("SurveyTypeId")]
        public SurveyType SurveyType { get; set; }

        //Ticket Settings from witch I fetch the location, FE, SurveyDate, No. of Floor/s, Survey Completed By:
        //A.	Description of the issues (customer’s feedback).

        [Display(Name = "Ticket")]
        public int? TicketId { get; set; }
        [Display(Name = "Ticket")]
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        //Survey Report Version
        [Display(Name = "Version:")]
        public string Version { get; set; }

        //Time spent on site values witch I pickup from the Ticket

        [Display(Name = "Survey Started")]
        public DateTime? SurveyStarted { get; set; }

        [Display(Name = "Survey Ended")]
        public DateTime? SurveyEnded { get; set; }

        //WiFi Props !
        [Display(Name = "No. of Access Point/s Installed:")]
        public string NumberOfAPs { get; set; }

        [Display(Name = "Brand/Model of Access Point/s:")]
        public string APBrandModel { get; set; }

        //Survey Content props !

        [Display(Name = "Installed Access Point Locations (AP Floor Map):")]
        [DataType(DataType.ImageUrl)]
        public string APFloorMap { get; set; }

        [Display(Name = "NetSpot Report:")]
        [DataType(DataType.ImageUrl)]
        public string NetSpotReport { get; set; }

        [Display(Name = "Speedtest:")]
        [DataType(DataType.ImageUrl)]
        public string SpeedTestIMG { get; set; }



    }
}
