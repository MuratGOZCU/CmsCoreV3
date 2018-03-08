using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Parola Doğrula")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
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
        public string City { get; set;  }
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
