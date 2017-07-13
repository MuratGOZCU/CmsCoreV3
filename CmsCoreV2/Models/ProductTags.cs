using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductTags
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
