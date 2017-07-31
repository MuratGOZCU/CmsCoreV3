using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum EmailType
    {
        [Display(Name = @"Düz Metin")]
        Text = 1,
        [Display(Name = @"HTML")]
        HTML = 2,
        [Display(Name = @"Çok Parçalı")]
        Pieced = 3,
    }
}
