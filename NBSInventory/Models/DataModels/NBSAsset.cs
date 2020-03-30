using NBSTimeReporting.Assets.DataModels;
using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Site = NBSTimeReporting.Models.DataModels.Site;

namespace NBSTimeReporting.NBSInventory.Models.DataModels
{
    public class NBSAsset
    {
        public int Id { get; set; }

        public string NBSAssetNumber { get; set; }

        public string NBSAssetName { get; set; }

        public int? CompanyId { get; set; }
        [Display(Name = "Owner")]
        [ForeignKey("CompanyId")]
        public Company Owner { get; set; }

        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Location { get; set; }

        public int? AssetStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("AssetStatusId")]
        public AssetStatus AssetStatus { get; set; }

        
        public int? AssetTypeId { get; set; }
        [Display(Name = "Asset type")]
        [ForeignKey("AssetTypeId")]
        public AssetType AssetType { get; set; }

        
        public int? AssetBrandId { get; set; }
        [Display(Name = "Asset brand")]
        [ForeignKey("AssetBrandId")]
        public AssetBrand AssetBrand { get; set; }

       
       

        [Display(Name = "MAC Address")]
        public string MACAddress { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Connectivity")]
        public string Connectivity { get; set; }

        [Display(Name = "Local IP")]
        public string LocalIP { get; set; }

        [Display(Name = "Ethernet 1 LLDP")]
        public string Ethernet1LLDP { get; set; }

        [Display(Name = "Ethernet1")]
        public string Ethernet1 { get; set; }


    }
}
