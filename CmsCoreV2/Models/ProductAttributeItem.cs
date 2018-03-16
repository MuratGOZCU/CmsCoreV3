using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductAttributeItem 
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long AttributeItemId { get; set; }
        public AttributeItem AttributeItem { get; set; }
        public string AppTenantId {get; set;}
    }
}
