using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CmsCoreV3.Models
{
    public class ShippingFlatRate:BaseEntity
    {
        public bool IsActive {get;set;}
        [StringLength(200)]
        public string MethodTitle {get; set;}
        public float? OrderCost {get;set;}
        public virtual ICollection<AdditionalRate> AdditionalRates {get; set;}
        public PerCostType PerCostType {get; set;}
        public virtual ICollection<AdditionalCost> AdditionalCosts {get; set;}
    }
}