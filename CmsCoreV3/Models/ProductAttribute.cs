using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class ProductAttribute 
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string AppTenantId {get; set;}
    }
}
