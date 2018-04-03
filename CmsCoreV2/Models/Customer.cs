using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Customer:BaseEntity
    {
        [Display(Name="Adres")]
        [StringLength(4000)]
        public string Address { get; set; }
        [Display(Name="Ad")]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Display(Name="Soyad")]
        [StringLength(200)]
        public string LastName { get; set; }
        [Display(Name="Firma Adı")]
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(200)]
        [Display(Name="İlçe")]
        public string County { get; set; }
        [StringLength(200)]
        [Display(Name="Şehir")]
        public string City { get; set; }
        [StringLength(200)]
        [Display(Name="Posta Kodu")]
        public string ZipCode { get; set; }
        [StringLength(200)]
        [Display(Name="Ülke")]
        public string Country { get; set; }
        [StringLength(200)]
        [Display(Name="Cadde/Sokak")]
        public string Street { get; set; }
        [StringLength(200)]
        [Display(Name="Telefon")]
        public string Phone { get; set; }
        [StringLength(200)]
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }
        [StringLength(4000)]
        [Display(Name="Teslimat Adresi")]
        public string ShippingAddress { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Ad")]
        public string ShippingFirstName { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Soyad")]
        public string ShippingLastName { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Firma Adı")]
        public string ShippingCompanyName { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat İlçe")]
        public string ShippingCounty { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Şehir")]
        public string ShippingCity { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Ülke")]
        public string ShippingCountry { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Cadde/Sokak")]
        public string ShippingStreet { get; set; }
        [StringLength(200)]
        [Display(Name="Teslimat Posta Kodu")]
        public string ShippingZipCode { get; set; }
    }
}
