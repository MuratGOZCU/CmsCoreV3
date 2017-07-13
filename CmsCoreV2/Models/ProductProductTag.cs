using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class ProductProductTag 
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long ProductTagId { get; set; }
        //public ProductTag ProductTag { get; set; }

    }
}
