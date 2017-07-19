using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Region:BaseEntity
    {
        public Region()
        {
            ChildRegions = new HashSet<Region>();
        }

        [StringLength(200)]
        [Required]
        [Display(Name = "Bölge Adı")]
        public string Name { get; set; }
        [Display(Name = "Bölge Kodu")]
        public string Code { get; set; }
        [Display(Name = "Bölge Tipi")]
        public RegionType RegionType { get; set; }
        [Display(Name = "Üst Bölge")]
        [ForeignKey("ParentRegionId")]
        public long? ParentRegionId { get; set; }
        [Display(Name = "Üst Bölge")]
        public virtual Region ParentRegion { get; set; }
        public virtual ICollection<Region> ChildRegions { get; set; }
    }
}
