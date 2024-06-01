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
    /// Логика взаимодействия для remont.xaml
    /// </summary>
    public partial class remont : Window
    {
        public remont()
        {
            InitializeComponent();
        }
        string serialNumber = "";
        string empID = "";
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                DG1.ItemsSource = db.ComputerFacilities.Select(x=>x).ToList();
            }
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {


                string g = Class1.UserID;

                var selectedItem = DG1.SelectedItem as ComputerFacilities;
                if (selectedItem != null)
                {
                    serialNumber = selectedItem.SerialNumber;
                    
                    

                }
                var selectedItem1 = DG1.SelectedItem as ComputerFacilities;
                if (selectedItem1 != null)
                {
                    empID = selectedItem1.EmployeeId;
                    


                }
                UserRepairRequests us  = new UserRepairRequests();
                {
                    var uss = db.UserRepairRequests.Where(x => x.UserId == g).FirstOrDefault();

                    if (uss != null)
                    {

                    }
                    else
                    {
                        us.UserId = g;
                        us.EmployeeId = empID;
                        db.Add(us);
                        db.SaveChanges();
                    }
                       
                }
                RepairRequests rep = new RepairRequests();
                {
                   
                    try
                    {
                        rep.EmployeeId = empID;
                        rep.UserId = g;
                        rep.RepairId = nom.Text;
                        rep.Description = opis.Text;
                        rep.SerialNumber = serialNumber;
                        db.Add(rep);
                        db.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                    
                }
               
            }

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            var adpg = new AdminPage();
            adpg.Show();
            this.Close();
        }

        
    }
}
