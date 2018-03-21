using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class TaxRate:BaseEntity
    {
        [Display(Name = "Vergi Sınıfı")]
        public TaxClass TaxClass {get; set;}
        [Display(Name = "İlçe")]
        public long? DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        [Display(Name = "İlçe")]
        public Region District { get; set; }
        [StringLength(200)]
        [Display(Name ="Ülke Kodu")]
        public string CountryCode { get; set; }
        [Display(Name = "Şehir Plaka Kodu")]
        public string CityPlateCode { get; set; }
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
