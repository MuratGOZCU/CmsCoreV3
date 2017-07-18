using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class MetaField:BaseEntity
    {
        
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual ICollection<OrderMetaField> OrderMetaFields { get; set; }
    }
}
