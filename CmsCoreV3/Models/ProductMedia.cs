using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class ProductMedia:BaseEntity
    { 
        public ProductMedia() {
            Position = 0;
        }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string MediaUrl {get; set;}
        public long Position {get; set;}
    }
}
