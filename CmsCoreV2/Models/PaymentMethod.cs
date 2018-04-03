using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class PaymentMethod:BaseEntity
    {
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Code { get; set; }
        public bool Enable { get; set; }
        public string Description { get; set; }
        [StringLength(200)]
        public string ApiUrl {get; set;}
        [StringLength(200)]
        public string ApiUserName {get; set;}
        [StringLength(200)]
        public string ApiPassword {get; set;}
    }
}
