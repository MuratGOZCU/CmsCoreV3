using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class Customer:BaseEntity
    {
        public string BillingAddress { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingCompanyName { get; set; }
        public long? BillingDistrictId { get; set; }
        public virtual Region BillingDistrict { get; set; }
        public long? BillingCityId { get; set; }
        public virtual Region BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public long? BillingCountryId { get; set; }
        public virtual Region BillingCountry { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingCompanyName { get; set; }
        public long? ShippingDistrictId { get; set; }
        public virtual Region ShippingDistrict { get; set; }
        public long? ShippingCityId { get; set; }
        public virtual Region ShippingCity { get; set; }
        public long? ShippingCountryId { get; set; }
        public virtual Region ShippingCountry { get; set; }
        public string ShippingZipCode { get; set; }
    }
}
