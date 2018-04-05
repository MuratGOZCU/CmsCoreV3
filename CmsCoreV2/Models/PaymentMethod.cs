using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class PaymentMethod:BaseEntity
    {
        [StringLength(200)]
        [Display(Name="Başlık")]
        public string Title { get; set; }
        [StringLength(200)]
        [Display(Name="Kod")]
        public string Code { get; set; }
        [Display(Name="Aktif Mi?")]
        public bool Enable { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [StringLength(200)]
        [Display(Name = "API Adresi")]
        public string ApiUrl {get; set;}
        [StringLength(200)]
        [Display(Name = "API Kullanıcı Adı")]
        public string ApiUserName {get; set;}
        [StringLength(200)]
        [Display(Name = "API Parola")]
        public string ApiPassword {get; set;}
    }
}
