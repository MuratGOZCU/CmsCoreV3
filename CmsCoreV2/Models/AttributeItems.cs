using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class AttributeItems
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Değer")]
        [MaxLength(200)]
        public string Value { get; set; }

        [Display(Name = "Bağlantı")]
        [MaxLength(200)]
        public string Slug { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [ForeignKey("ProductAttributeId")]
        [Display(Name = "Ürün Niteliği")]
        public Attributes Attribute { get; set; }

        
    }
}
