using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public enum EnableForShipmentMethods
    {

        [Display(Name = "Sabit Fiyat")]
        SabitFiyat = 1,
        [Display(Name = "Ücretsiz Gönderim")]
        UcretsizGonderim = 2,
        [Display(Name = "Mağazadan Teslim")]
        MagazadanTeslim = 3
    }
}
