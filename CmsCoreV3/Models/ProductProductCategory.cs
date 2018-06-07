﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV3.Models
{
    public class ProductProductCategory 
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string AppTenantId { get; set; }
    }
}
