using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ShippingRegion
    {
        public long RegionId { get; set; }
        public Region Region { get; set; }
        public long SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}
