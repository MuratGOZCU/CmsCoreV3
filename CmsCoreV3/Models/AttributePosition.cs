using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum AttributePosition
    {
        [Display(Name = "İsime Göre Sırala")]
        Name = 1,
        [Display(Name = "Nitelik Kimliğine Göre Sırala")]
        PositionId = 2
    }
}
