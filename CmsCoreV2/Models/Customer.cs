using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Customer:BaseEntity
    {
        [StringLength(4000)]
        public string Address { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string CompanyName { get; set; }
        [StringLength(200)]
        public string County { get; set; }
        [StringLength(200)]
        public string City { get; set; }
        [StringLength(200)]
        public string ZipCode { get; set; }
        [StringLength(200)]
        public string Country { get; set; }
        [StringLength(200)]
        public string Street { get; set; }
        [StringLength(200)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string UserName { get; set; }
        [StringLength(4000)]
        public string ShippingAddress { get; set; }
        [StringLength(200)]
        public string ShippingFirstName { get; set; }
        [StringLength(200)]
        public string ShippingLastName { get; set; }
        [StringLength(200)]
        public string ShippingCompanyName { get; set; }
        [StringLength(200)]
        public string ShippingCounty { get; set; }
        [StringLength(200)]
        public string ShippingCity { get; set; }
        [StringLength(200)]
        public string ShippingCountry { get; set; }
        [StringLength(200)]
        public string ShippingZipCode { get; set; }
    }
}
