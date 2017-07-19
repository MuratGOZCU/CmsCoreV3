using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Currency:BaseEntity
    {
        [StringLength(200)]
        [Display(Name ="Para Birimi")]
        public string Currencies { get; set; }
        [StringLength(200)]
        [Display(Name = "Binlik Ayırıcı")]
        public string ThousandsSeparator { get; set; }
        [StringLength(200)]
        [Display(Name = "Ondalık Ayırıcı")]
        public string DecimalSeparator { get; set; }
        [StringLength(200)]
        [Display(Name = "Ondalık Sayısı")]
        public string DecimalScale { get; set; }
    }
}
