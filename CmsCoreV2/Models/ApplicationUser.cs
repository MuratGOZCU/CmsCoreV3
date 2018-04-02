using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CmsCoreV2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string AppTenantId { get; set; }
        public long? CustomerId {get; set;}
        public Customer Customer {get; set;}
        /*
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
        public string Phone { get; set; }*/
    }
}
