using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class EmployeesDepartment
    {
        public string DepartmentId { get; set; }
        public string EmployeeId { get; set; }
        public string BuildingNumber { get; set; }

        public virtual Buildings BuildingNumberNavigation { get; set; }
        public virtual Employees Employee { get; set; }
    }
}
