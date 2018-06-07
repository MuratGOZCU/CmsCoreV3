using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class ShippingZoneRegion
    {
        public long RegionId { get; set; }
        public Region Region { get; set; }
        public long ShippingZoneId { get; set; }
        public ShippingZone ShippingZone { get; set; }
        public string AppTenantId {get; set;}
    }
}
