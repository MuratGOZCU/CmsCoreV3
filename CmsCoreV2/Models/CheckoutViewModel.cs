using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name ="Ülke")]
        public string BillingCountry { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string BillingFirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string BillingLastName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Kimlik/Vergi No")]
        public string BillingIdentityNumber { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string BillingCompanyName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string BillingAddress { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Cadde/Sokak")]
        public string BillingStreet { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Şehir")]
        public string BillingCity { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "İlçe")]
        public string BillingCounty { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string BillingZipCode { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "E-posta")]
        public string BillingEmail { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string BillingPhone { get; set; }
        [StringLength(200)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ülke")]
        public string DeliveryCountry { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string DeliveryFirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string DeliveryLastName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Firma Adı")]
        public string DeliveryCompanyName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string DeliveryAddress { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Cadde/Sokak")]
        public string DeliveryStreet { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Şehir")]
        public string DeliveryCity { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "İlçe")]
        public string DeliveryCounty { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string DeliveryZipCode { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Sipariş Notları")]
        public string DeliveryNotes { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ödeme Yöntemi")]
        public string PaymentMethod { get; set; }
        public Order Order { get; set; }
    }
}
