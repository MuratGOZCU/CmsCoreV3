using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum ApiPermission
    {
        [Display(Name = @"Oku")]
        Read = 1,
        [Display(Name = @"Yaz")]
        Wriete = 2,
        [Display(Name = @"Oku/Yaz")]
        ReadAndWrite = 3,
    }
}
