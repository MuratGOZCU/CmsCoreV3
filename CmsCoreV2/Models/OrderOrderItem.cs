using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsCoreV2.Models
{
    public class OrderOrderItem
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
