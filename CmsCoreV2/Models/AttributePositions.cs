using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum AttributePositions
    {
        [Display(Name = "İsim")]
        Name = 1,
        [Display(Name = "Nitelik Kimliği")]
        Id = 1

    }
}
