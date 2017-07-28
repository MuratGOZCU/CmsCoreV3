using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ShippingLocationsOptions
    {
        [Display(Name = "Satış Yaptığınız Tüm Ülkelere Gönder")]
        AllSalesCountry = 1,
        [Display(Name = "Tüm Ülkelere Gönder")]
        AllCountry = 2,
        [Display(Name = "Sadece Belirli Ülkelere Gönder")]
        SpecificCountry = 3,
        [Display(Name = "Gönderimi & Gönderi Hesaplamalarını Devre Dışı Bırak")]
        ShippingCountry = 4
    }
}
