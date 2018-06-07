using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum TaxClass
    {
        [Display(Name="Standart")]
        Standard = 1,
        [Display(Name="Azaltılmış")]
        Reduced = 2,
        [Display(Name="Sıfır")]
        Zero = 3

    }
}
