using NBSTimeReporting.Assets.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBSTimeReporting.Assets.ViewModels
{
    public class AssetsViewModel
    {
        public List<Asset> Assets { get; internal set; }

        public List<AssetBrand> AssetBrands { get; internal set; }

        public List<AssetType> AssetTypes { get; internal set; }
    }
}