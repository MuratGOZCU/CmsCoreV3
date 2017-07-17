using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum PaymentAction
    {
        [Display(Name = "Aktarım")]
        Aktarim = 1,
        [Display(Name = "Yetkilendirme")]
        Yetkilendirme = 2
    }
}
