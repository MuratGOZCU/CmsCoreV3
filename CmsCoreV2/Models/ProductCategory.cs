using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            CouponProductCategories = new HashSet<CouponProductCategory>();
            ExcludeCouponProductCategories = new HashSet<ExcludeCouponProductCategory>();
        }
        [Display(Name = "Ürün Kategorileri")]
        public virtual ICollection<CouponProductCategory> CouponProductCategories { get; set; }
        [Display(Name = "Kategorileri Hariç Tut")]
        public virtual ICollection<ExcludeCouponProductCategory> ExcludeCouponProductCategories { get; set; }
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
       

        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }
    }
}
