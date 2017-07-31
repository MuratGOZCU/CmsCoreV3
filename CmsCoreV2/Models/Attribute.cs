using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Attribute:BaseEntity
    {
        public Attribute()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        [Required]
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "Bağlantı")]
        [StringLength(200)]
        public string Slug { get; set; }

        [Display(Name = "Görünsün mü?")]
        public bool IsVisible { get; set; }

        [Display(Name = "Varyasyonlar")]
        public bool Variations { get; set; }

        [Display(Name = "Nitelik Türü")]
        [EnumDataType(typeof(AttributeType))]
        public AttributeType AttributeType { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        [Display(Name = "Sıralama Düzeni")]
        [EnumDataType(typeof(AttributePosition))]
        public AttributePosition AttributePosition { get; set; }


    }
}
