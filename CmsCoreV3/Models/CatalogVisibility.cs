using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public enum CatalogVisibility
    {
        [Display(Name="Katalogta ve aramada görünsün")]
        VisibilityBoth = 1,
        [Display(Name="Sadece katalogta görünsün")]
        VisibilityCatalog = 2,
        [Display(Name="Sadece aramada görünsün")]
        VisibilitySearch = 3,
        [Display(Name="Katalogta ve aramada gizlensin")]
        VisibilityHidden = 4
    }
}
