using NBSTimeReporting.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Controllers.AccountingControllers
{
    public class Receipt
    {
        public int Id { get; set; }

        //Receipt Settings
        [Display(Name = "Status")]
        public int? ReceiptStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ReceiptStatusId")]
        public ReceiptStatus ReceiptStatus { get; set; }

        [Display(Name = "Type")]
        public int? ReceiptTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("ReceiptTypeId")]
        public ReceiptType ReceiptType { get; set; }

        //TimeReports props !

        //Acounting props !

        //Price props (Sallary for Sallary Receipt)!
    }
}
