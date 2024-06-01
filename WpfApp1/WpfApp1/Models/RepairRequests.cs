using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class RepairRequests
    {
        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string RepairId { get; set; }
        public string Description { get; set; }

        public string SerialNumber { get; set; }

        public virtual UserRepairRequests UserRepairRequests { get; set; }
    }
}
