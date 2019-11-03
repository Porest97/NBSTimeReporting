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
        public List<PersonRole> PersonRoles { get; internal set; }

        public List<PersonStatus> PersonStatuses { get; internal set; }

        public List<PersonType> PersonTypes { get; internal set; }               

        public List<SiteRole> SiteRoles { get; internal set; }

        public List<SiteStatus> SiteStatuses { get; internal set; }

        public List<SiteType> SiteTypes { get; internal set; }

        public List<CompanyRole> CompanyRoles { get; internal set; }

        public List<CompanyStatus> CompanyStatuses { get; internal set; }

        public List<CompanyType> CompanyTypes { get; internal set; }


    }
}
