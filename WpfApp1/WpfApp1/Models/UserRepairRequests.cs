using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class UserRepairRequests
    {
        public UserRepairRequests()
        {
            RepairRequests = new HashSet<RepairRequests>();
        }

        public string EmployeeId { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<RepairRequests> RepairRequests { get; set; }
    }
}
