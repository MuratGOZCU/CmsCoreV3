using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ShippingClass:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Gönderi Sınıfı Adı")]
        public string ShippingClassName { get; set; }
        [StringLength(200)]
        [Display(Name = "Kısa isim")]
        public string Slug { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
