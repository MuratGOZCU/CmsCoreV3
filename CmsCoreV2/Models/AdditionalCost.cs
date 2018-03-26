using System.ComponentModel.DataAnnotations.Schema;

namespace CmsCoreV2.Models {
    public class AdditionalCost:BaseEntity
    {
        public long ShippingClassId {get; set;}
        public ShippingClass ShippingClass {get; set;}
        public float Cost {get; set;}
        public float ShippingPrice {get; set;}
        public long ShippingFlatRateId {get; set;}
        [ForeignKey("ShippingFlatRateId")]
        public ShippingFlatRate ShippingFlatRate {get;set;}
    }
}