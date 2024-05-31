using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class ComputerFacilities
    {
        public ComputerFacilities()
        {
            EquipmentTransfer = new HashSet<EquipmentTransfer>();
        }

        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<EquipmentTransfer> EquipmentTransfer { get; set; }
    }
}
