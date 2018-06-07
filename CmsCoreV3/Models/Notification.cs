using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class Notification:BaseEntity
    {
        [StringLength(200)]
        [Display(Name = "Bildirim Adı")]
        public string Name {get; set;}
        [Display(Name = "Konu")]
        [StringLength(200)]
        public string Subject {get; set;}
        [Display(Name = "Gövde")]
        public string Body {get; set;}
        [Display(Name = "E-posta Gönderilecek Adresler")]
        public string MailTo {get; set;}
        [Display(Name = "Bilgi E-postası Gönderilecek Adresler")]
        public string MailCc {get; set;}
        [Display(Name = "Aktif Mi?")]
        public bool IsActive {get; set;}
    }
}