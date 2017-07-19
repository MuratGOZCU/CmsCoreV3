using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class PaymentMethod:BaseEntity
    {
        public bool  Enable { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public bool EnableCheckPayments { get; set; }
        public bool EnablePayAtTheDoor { get; set; }
        public EnableForShipmentMethods EnableForShipmentMethods { get; set; }
        public bool AcceptForVirtualOrders { get; set; }
        public bool EnablePayPalStandart { get; set; }
        public string PayPalEmail { get; set; }
        public bool PayPalTestMethod { get; set; }
        public bool DebugRegister { get; set; }
        public string BuyerEmail { get; set; }
        public string PayPalIdentityKey { get; set; }
        public string InvoiceFront { get; set; }
        public bool SubmissionInformation { get; set; }
        public bool AddressInvalid { get; set; }
        public PaymentAction PaymentAction { get; set; }
        public string PageFormat { get; set; }
        public string ImageAddress { get; set; }
        public string ApiUserName { get; set; }
        public string ApiPassword { get; set; }
        public string ApiSignature { get; set; }


    }
}
