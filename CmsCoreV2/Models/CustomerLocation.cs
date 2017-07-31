using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum CustomerLocation
    {
        [Display(Name = @"Varsayılan Konum Yok")]
        NoDefaultLocation = 1,
        [Display(Name = @"Mağaza Adresi")]
        StoreAddress = 2,
        [Display(Name = @"Coğrafi Konum")]
        GeographicalLocation = 3,
        [Display(Name = @"Coğrafi Konum (sayfa önbellek desteğiyle birlikte)")]
        GeographicalLocationWithPage = 4,
    }
}
