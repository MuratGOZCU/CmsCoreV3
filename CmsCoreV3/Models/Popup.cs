using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class Popup:BaseEntity
    {
        [Required]
        [StringLength(200)]
        [Display(Name="Ad")]
        public string Name { get; set; }
        [StringLength(200)]
        [Display(Name="Sayfa Bağlantısı")]
        public string PageSlug { get; set; }
        [StringLength(200)]
        [Display(Name="Resim")]
        public string Photo { get; set; }
        [Display(Name="Adres")]
        public string Url { get; set; }
        [Display(Name="Hedef")]
        public string Target { get; set; }
        [Display(Name="Yayında")]
        public bool IsPublished { get; set; }
        [Display(Name="Yayın Tarihi")]
        public DateTime PublishDate { get; set; }
        [Display(Name="Bitiş Tarihi")]
        public DateTime? FinishDate { get; set; }
    }
}
