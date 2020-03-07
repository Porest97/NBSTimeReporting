using NBSTimeReporting.Assets.DataModels;
using NBSTimeReporting.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.DWorkin.Regus.DataModels
{
    public class RegusAsset
    {
        public int Id { get; set; }

        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        [Display(Name = "Asset type")]
        public int? AssetTypeId { get; set; }
        [Display(Name = "Asset type")]
        [ForeignKey("AssetTypeId")]
        public AssetType AssetType { get; set; }

        [Display(Name = "Asset brand")]
        public int? AssetBrandId { get; set; }
        [Display(Name = "Asset brand")]
        [ForeignKey("AssetBrandId")]
        public AssetBrand AssetBrand { get; set; }

        [Display(Name = "NetBios Name")]
        public string Name { get; set; }

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
