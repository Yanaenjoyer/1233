using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для peredacha.xaml
    /// </summary>
    public partial class peredacha : Window
    {
        public peredacha()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                DG.ItemsSource = db.EquipmentTransfer.Select(x=>x).ToList();
                DG1.ItemsSource = db.ComputerFacilities.Select(x => x).ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {


                string nomotdel = otdel.Text;
                string build = zdan.Text;
                string empid = sot.Text;
                string serial = ser.Text;
                string inventory = inv.Text;

                var nm = db.Department.Where(x => x.DepartmentId == nomotdel).FirstOrDefault();
                if (nm != null)
                {

                }
                else
                {
                    MessageBox.Show("Введите существующий номер отдела");
                }
                var bul = db.Buildings.Where(x => x.BuildingNumber == build).FirstOrDefault();
                if (bul != null)
                {

                }
                else
                {
                    MessageBox.Show("Введите существующий номер здания");
                }
                var emp = db.Employees.Where(x => x.EmployeeId == empid).FirstOrDefault();
                if (bul != null)
                {

                }
                else
                {
                    MessageBox.Show("Введите существующий номер сотрудника");
                }
                var sr = db.ComputerFacilities.Where(x => x.SerialNumber == serial).FirstOrDefault();
                if (sr != null)
                {

                }
                else
                {
                    MessageBox.Show("Введите существующий серийный номер");
                }
                var invnm = db.ComputerFacilities.Where(x => x.InventoryNumber == inventory).FirstOrDefault();
                if (invnm != null)
                {

                }
                else
                {
                    MessageBox.Show("Введите существующий инаентарный номер");
                }
                try
                {
                    EquipmentTransfer eq = new EquipmentTransfer();
                    {
                        eq.DepartmentId = nomotdel;
                        eq.SerialNumber= serial;
                        eq.InventoryNumber = inventory;
                        eq.BuildingNumber = build;
                        eq.EmployeeId = empid;
                        db.Add(eq);
                        db.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}
