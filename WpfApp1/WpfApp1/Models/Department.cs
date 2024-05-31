using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Department
    {
        public Department()
        {
            EquipmentTransfer = new HashSet<EquipmentTransfer>();
        }

        public string DepartmentId { get; set; }
        public string BuildingNumber { get; set; }
        public int PersonNumber { get; set; }
        public int SeatsNumber { get; set; }

        public virtual Buildings BuildingNumberNavigation { get; set; }
        public virtual ICollection<EquipmentTransfer> EquipmentTransfer { get; set; }
    }
}
