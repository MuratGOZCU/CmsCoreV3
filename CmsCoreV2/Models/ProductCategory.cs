using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductCategory : BaseEntity
    {
        [StringLength(200)]
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [StringLength(200)]
        [Display(Name = "Üst Kategori")]
        public ProductCategory parentCategory { get; set; }
        [StringLength(200)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
       
        [Display(Name = "Küçük Resim")]
        public string SmallImage { get; set; }
        [StringLength(200)]
        [Display(Name = "Renk")]
        public string Color { get; set; }
    }
}
