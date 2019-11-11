using NBSTimeReporting.Models.DataModels;
using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Models.AccountingModels
{
    public class EmployeeAccount
    {
        public int Id { get; set; }

        //EmployeeAccount Settings
        [Display(Name = "Status")]
        public int? AccountStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("AccountStatusId")]
        public AccountStatus AccountStatus { get; set; }

        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }

        //Employee Identity
        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        //EmployeeAccount Description
        [Display(Name = "Description")]
        public string EmployeeAccountDescription { get; set; }

    }
}
