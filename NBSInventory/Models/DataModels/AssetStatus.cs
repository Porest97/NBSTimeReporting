using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.NBSInventory.Models.DataModels
{
    public class AssetStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string AssetStatusName { get; set; }
    }
}