using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            CouponProductCategories = new HashSet<CouponProductCategory>();
            ExcludeCouponProductCategories = new HashSet<ExcludeCouponProductCategory>();
            ChildCategories = new HashSet<ProductCategory>();
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
        [Display(Name = "Üst Kategori")]
        public long? ParentCategoryId {get; set;}
        [StringLength(200)]
        [Display(Name = "Üst Kategori")]
        [ForeignKey("ParentCategoryId")]
        public ProductCategory ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ChildCategories {get; set;}
        [StringLength(200)]
        [Display(Name = "Açıklama")]
        
        public string Description { get; set; }
       
        [Display(Name = "Küçük Resim")]
        public string SmallImage { get; set; }
       

        public ICollection<ProductProductCategory> ProductProductCategories { get; set; }
    }
}
