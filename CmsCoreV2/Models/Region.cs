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
            ShippingRegions = new HashSet<SettingRegion>();
            SalesLocations = new HashSet<SaleRegion>();
            ShippingLocations = new HashSet<ShippingRegion>();
            ChildRegions = new HashSet<Region>();
        }
        [Display(Name = "Gönderi Bölgeleri")]
        public virtual ICollection<SettingRegion> ShippingRegions { get; set; }
        [Display(Name = "Satış Konumları")]
        public virtual ICollection<SaleRegion> SalesLocations { get; set; }
        [Display(Name = "Gönderi Konumları")]
        public virtual ICollection<ShippingRegion> ShippingLocations { get; set; }
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
