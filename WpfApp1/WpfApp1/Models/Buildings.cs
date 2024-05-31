using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Buildings
    {
        public Buildings()
        {
            Department = new HashSet<Department>();
            EmployeesDepartment = new HashSet<EmployeesDepartment>();
        }

        public string BuildingNumber { get; set; }
        public string Home { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<EmployeesDepartment> EmployeesDepartment { get; set; }
    }
}
