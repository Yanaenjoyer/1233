using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Employees
    {
        public Employees()
        {
            ComputerFacilities = new HashSet<ComputerFacilities>();
            EmployeesDepartment = new HashSet<EmployeesDepartment>();
            User = new HashSet<User>();
        }

        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Home { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public virtual ICollection<ComputerFacilities> ComputerFacilities { get; set; }
        public virtual ICollection<EmployeesDepartment> EmployeesDepartment { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
