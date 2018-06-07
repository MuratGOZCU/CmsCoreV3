using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CmsCoreV3.Models
{
    public class ShippingZone:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string Name {get;set;}
        [Display(Name = "Bölgeler")]
        public virtual ICollection<ShippingZoneRegion> ShippingZoneRegions {get;set;}
        public virtual ICollection<ShippingPrice> ShippingPrices {get;set;}
    }
}