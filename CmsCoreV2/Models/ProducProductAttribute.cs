using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProducProductAttribute 
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductAttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}
