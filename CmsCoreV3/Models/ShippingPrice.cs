using System.ComponentModel.DataAnnotations.Schema;

namespace CmsCoreV3.Models
{
    public class ShippingPrice:BaseEntity
    {
        public ShippingPrice()
        {

        }

        public long ProductId {get; set;}
        [ForeignKey("ProductId")]
        public Product Product {get; set;}
        public long ShippingZoneId {get; set;}
        [ForeignKey("ShippingZoneId")]
        public ShippingZone ShippingZone {get; set;}
        public float Price {get; set;}
    }
}