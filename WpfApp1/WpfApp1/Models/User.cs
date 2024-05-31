using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
        }

        public string EmployeeId { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual UserRepairRequests UserRepairRequests { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
