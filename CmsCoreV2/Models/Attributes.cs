using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Attributes:BaseEntity
    {

        [Display(Name = "Ad")]

        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Bağlantı")]
        [MaxLength(200)]
        public string Slug { get; set; }

        [Display(Name = "Görünsün mü?")]
        bool IsVisible { get; set; }

        [Display(Name = "Varyasyonlar")]
        bool Variations { get; set; }

        [Display(Name = "Nitelik Türü")]
        [EnumDataType(typeof(AttributeTypes))]
        public AttributeTypes AttributeType { get; set; }

        [Display(Name = "Sıralama Düzeni")]
        [EnumDataType(typeof(AttributePositions))]
        public AttributePositions AttributePosition { get; set; }


    }
}
