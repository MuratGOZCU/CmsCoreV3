using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class NameValueItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public IList<NameValueItem> SubItems { get; set; }
    }
}
