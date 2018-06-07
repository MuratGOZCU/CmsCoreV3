using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum CategoryView
    {
        [Display(Name = @"Ürünleri göster")]
        ShowProduct = 1,
        [Display(Name = @"Alt kategorileri göster")]
        ShowSubcategories = 2,
        [Display(Name = @"Alt kategorileri & ürünleri göster")]
        ShowSubcategoriesAndShowProduct = 3

    }
}
