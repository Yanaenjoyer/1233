using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Orders
    {
        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}
