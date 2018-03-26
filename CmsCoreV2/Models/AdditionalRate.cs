using System.ComponentModel.DataAnnotations.Schema;

namespace CmsCoreV2.Models
{
    public class AdditionalRate:BaseEntity
    {
        public string Name {get;set;}
        public float AdditionalCost {get;set;}
        //public PerCostType PerCostType {get;set;}
        public long ShippingFlatRateId {get; set;}
        [ForeignKey("ShippingFlatRateId")]
        public ShippingFlatRate ShippingFlatRate {get;set;}
    }
}