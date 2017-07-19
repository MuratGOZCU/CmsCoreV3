using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum FileDownloadMethod
    {
        [Display(Name = @"İndirmeleri zorla")]
        ForceDownloads = 1,
        [Display(Name = @"X-Accel-Redirect/X-Sendfile")]
        XAccelRedirect = 2,
        [Display(Name = @"Sadece yönlendirme")]
        RoutingOnly = 3,
    }
}
