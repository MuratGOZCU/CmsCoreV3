using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class SaleRegion
    {
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}
