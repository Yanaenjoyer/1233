using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class EquipmentTransfer
    {
        public string DepartmentId { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string EmployeeId { get; set; }

        public virtual ComputerFacilities ComputerFacilities { get; set; }
        public virtual Department Department { get; set; }
    }
}
