using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CmsCoreV3.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string AppTenantId { get; set; }
        public long? CustomerId {get; set;}
        public Customer Customer {get; set;}
        public DateTime? LastLoginDate {get; set;}
        public DateTime? RegistrationDate {get; set;}
    }
}
