using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum SalesLocationOptions
    {
        [Display(Name = "Tüm Ülkelere sat")]
        AllCountry = 1,
        [Display(Name = "Şunlar Dışında Tüm Ülkelere Sat")]
        OutsideCountry = 2,
        [Display(Name = "Belirli Ülkelere Sat")]
        SpecificCountry = 3
    }
}
