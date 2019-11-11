using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.ViewModels
{
    public class SettingsViewModel
    {
        //People
        public List<PersonRole> PersonRoles { get; internal set; }

        public List<PersonStatus> PersonStatuses { get; internal set; }

        public List<PersonType> PersonTypes { get; internal set; }               

        //Sites
        public List<SiteRole> SiteRoles { get; internal set; }

        public List<SiteStatus> SiteStatuses { get; internal set; }

        public List<SiteType> SiteTypes { get; internal set; }

        //Companies
        public List<CompanyRole> CompanyRoles { get; internal set; }

        public List<CompanyStatus> CompanyStatuses { get; internal set; }

        public List<CompanyType> CompanyTypes { get; internal set; }

        //Tickets
        public List<TicketPriority> TicketPriorities { get; internal set; }

        public List<TicketStatus> TicketStatuses { get; internal set; }

        public List<TicketType> TicketTypes { get; internal set; }

        //Reports
        public List<ReportStatus> ReportStatuses { get; internal set; }

        public List<ReportType> ReportTypes { get; internal set; }

        //Surveys
       
        public List<SurveyStatus> SurveyStatuses { get; internal set; }

        public List<SurveyType> SurveyTypes { get; internal set; }

        //Accounts

        public List<AccountStatus> AccountStatuses { get; internal set; }
    }
}
