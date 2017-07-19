using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class TaxRate:BaseEntity
    {
        [StringLength(200)]
        [Display(Name ="Ülke Kodu")]
        public string CountryCode { get; set; }
        [Display(Name = "Şehir Plaka Kodu")]
        public int CityPlateCode { get; set; }
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }
        [Display(Name = "Oran")]
        public float Rate { get; set; }
        [StringLength(200)]
        [Display(Name = "Vergi Adı")]
        public string TaxName { get; set; }
        [Display(Name = "Öncelik")]
        public int TaxRatePriority { get; set; }
        [Display(Name = "Bileşik")]
        public bool TaxRateCompound { get; set; }
        [Display(Name = "Gönderim")]
        public bool TaxRateShipping { get; set; }
    }
}
