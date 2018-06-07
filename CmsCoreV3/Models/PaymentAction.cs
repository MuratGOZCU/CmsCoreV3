using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum PaymentAction
    {
        [Display(Name = "Aktarım")]
        Transfer = 1,
        [Display(Name = "Yetkilendirme")]
        Authorize = 2
    }
}
