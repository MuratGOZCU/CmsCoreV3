using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class OrderMetaField
    {
        public long MetaFieldId { get; set; }
        public MetaField MetaField { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public string AppTenantId { get; set; }
    }
}
