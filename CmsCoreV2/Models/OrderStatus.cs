using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Ödeme Bekleniyor")]
        OdemeBekleniyor = 1,
        [Display(Name = "İşleniyor")]
        Isleniyor = 2,
        [Display(Name = "Beklemede")]
        Beklemede = 3,
        [Display(Name = "Tamamlandı")]
        Tamamlandı = 4,
        [Display(Name = "Iptal Edildi")]
        IptalEdildi = 5,
        [Display(Name = "Iade Edildi")]
        IadeEdildi = 6,
        [Display(Name = "Başarısız")]
        Basarısız = 7
    }
}
