using System.ComponentModel.DataAnnotations;

namespace NBSTimeReporting.Assets.DataModels
{
    public class AssetBrand
    {
        public int Id { get; set; }

        [Display(Name = "Brand")]
        public string AssetBrandName { get; set; }
    }
}