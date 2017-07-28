using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductTag:BaseEntity
    {
        public ProductTag()
        {
            ProductProductTags = new HashSet<ProductProductTag>();
        }

        [Required]
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Bağlantı")]
        [StringLength(200)]
        public string Slug { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        public ICollection<ProductProductTag> ProductProductTags { get; set; }
    }
}
