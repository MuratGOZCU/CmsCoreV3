using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class EmailTemplate:BaseEntity
    {
        public EmailType EmailType { get; set; }
        [Display(Name = "Etkinleştir")]
        public bool EnableThisEmailNotification { get; set; }
        [Display(Name = "Alıcılar")]
        public string Recipients { get; set; }
        [StringLength(200)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [StringLength(200)]
        [Display(Name = "Email Başlığı")]
        public string EmailTitle { get; set; }
        [StringLength(200)]
        [Display(Name = "Şablon")]
        public string Template { get; set; }
    }
}
