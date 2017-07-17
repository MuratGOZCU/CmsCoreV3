using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductMedia
    { 

        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long MediaId { get; set; }
        public Media Media { get; set; }
    }
}
