using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class Supplier : BaseEntity
    {
        public Supplier() {
            Products = new HashSet<Product>();
        }
        [Required]
        [Display(Name="Ad")]
        [StringLength(200)]
        public string Name {get; set;}
        [Required]
        [Display(Name="Yetkili")]
        [StringLength(200)]
        public string Contact {get; set;}
        [Required]
        [Display(Name="Kullanıcı Adı")]
        [StringLength(200)]
        public string UserName {get; set;}
        [Required]
        [Display(Name = "E-posta")]
        [StringLength(200)]
        public string Email {get; set;}
        [Required]
        [Display(Name = "Telefon")]
        [StringLength(200)]
        public string Phone {get; set;}
        [Required]
        [Display(Name = "Adres")]
        [StringLength(4000)]
        public string Address {get; set;}
        [Display(Name = "Bildirim E-postası")]
        [StringLength(4000)]
        public string NotificationEmail {get; set;}
        [Display(Name = "Bildirim Telefonu")]
        [StringLength(4000)]
        public string NotificationPhone {get; set;}
        [Display(Name = "Aktif Mi?")]
        public bool IsActive {get; set;}
        [Display(Name = "Ürünler")]
        public virtual ICollection<Product> Products {get; set;}
    }
}