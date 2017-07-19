using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum CurrencyPosition
    {
        [Display(Name = @"Sağda")]
        Right = 1,
        [Display(Name = @"Solda")]
        Left = 2,
        [Display(Name = @"Solda boşlukla")]
        SpaceOnTheLeft = 3,
        [Display(Name = @"Sağda boşlukla")]
        SpaceOnTheRight = 4,
    }
}
