using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum StorePageView
    {
        [Display(Name = @"Ürünleri göster")]
        ShowProducts = 1,
        [Display(Name = @"Kategorileri göster")]
        ShowCategories = 2,
        [Display(Name = @"Kategorileri & ürünleri göster")]
        ShowProductsAndCategories = 3,
    }
}
