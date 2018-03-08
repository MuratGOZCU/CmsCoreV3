using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Cadde/Sokak")]
        public string Street { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Ülke")]
        public string Country { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "İlçe")]
        public string County { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}
