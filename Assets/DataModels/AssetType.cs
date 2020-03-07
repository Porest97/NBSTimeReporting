using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Assets.DataModels
{
    public class AssetType
    {
        public int Id { get; set; }

        [Display(Name ="Asset type")]
        public string AssetTypeName { get; set; }
    }
}