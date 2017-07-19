using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum WeightUnit
    {
        [Display(Name = @"kg")]
        kg = 1,
        [Display(Name = @"g")]
        g = 2,
        [Display(Name = @"lbs")]
        lbs = 3,
        [Display(Name = @"oz")]
        oz = 4,
    }
}
