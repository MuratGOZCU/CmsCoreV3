using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Customer:BaseEntity
    {
        [StringLength(200)]
        public string BillingAddress { get; set; }
        [StringLength(200)]
        public string BillingFirstName { get; set; }
        [StringLength(200)]
        public string BillingLastName { get; set; }
        [StringLength(200)]
        public string BillingCompanyName { get; set; }
        public long? BillingDistrictId { get; set; }
        public virtual Region BillingDistrict { get; set; }
        public long? BillingCityId { get; set; }
        public virtual Region BillingCity { get; set; }
        [StringLength(200)]
        public string BillingZipCode { get; set; }
        public long? BillingCountryId { get; set; }
        public virtual Region BillingCountry { get; set; }
        [StringLength(200)]
        public string ShippingAddress { get; set; }
        [StringLength(200)]
        public string ShippingFirstName { get; set; }
        [StringLength(200)]
        public string ShippingLastName { get; set; }
        [StringLength(200)]
        public string ShippingCompanyName { get; set; }
        public long? ShippingDistrictId { get; set; }
        public virtual Region ShippingDistrict { get; set; }
        public long? ShippingCityId { get; set; }
        public virtual Region ShippingCity { get; set; }
        public long? ShippingCountryId { get; set; }
        public virtual Region ShippingCountry { get; set; }
        [StringLength(200)]
        public string ShippingZipCode { get; set; }
    }
}
