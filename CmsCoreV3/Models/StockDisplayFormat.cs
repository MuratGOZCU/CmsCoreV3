using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum StockDisplayFormat
    {
        [Display(Name = @"Stokta kalan miktarı her zaman göster")]
        AlwaysShow = 1,
        [Display(Name = @"Stokta kalan miktarı sadece düşük olduğunda göster")]
        ShowWhenLow = 2,
        [Display(Name = @"Stokta kalan miktarı asla gösterme")]
        NeverShow = 3,
    }
}
