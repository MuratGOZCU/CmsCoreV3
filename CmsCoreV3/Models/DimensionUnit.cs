using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum DimensionUnit
    {
        [Display(Name = @"m")]
        m = 1,
        [Display(Name = @"cm")]
        cm = 2,
        [Display(Name = @"mm")]
        mm = 3,
        [Display(Name = @"in")]
        inc = 4,
        [Display(Name = @"yd")]
        yd = 5,
    }
}
