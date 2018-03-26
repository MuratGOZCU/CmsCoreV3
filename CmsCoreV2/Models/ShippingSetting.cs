using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CmsCoreV2.Models {
    public class ShippingSetting:BaseEntity
    {
        public long StandardShippingMethodId {get; set;}
        [ForeignKey("StandardShippingMethodId")]
        public ShippingMethod StandardShippingMethod {get;set;}
        public long ShippingFlatRateId {get; set;}
        public ShippingFlatRate ShippingFlatRate {get; set;}
    }
}