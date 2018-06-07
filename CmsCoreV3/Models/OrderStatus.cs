using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Ödeme Bekleniyor")]
        PaymentWaiting = 1,
        [Display(Name = "İşleniyor")]
        BeingProcessed = 2,
        [Display(Name = "Beklemede")]
        OnStandBy = 3,
        [Display(Name = "Tamamlandı")]
        Completed = 4,
        [Display(Name = "Iptal Edildi")]
        Cancelled = 5,
        [Display(Name = "Iade Edildi")]
        Refunded = 6,
        [Display(Name = "Başarısız")]
        Unsuccessful = 7
    }
}
