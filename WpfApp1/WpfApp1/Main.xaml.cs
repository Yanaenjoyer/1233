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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                DG1.ItemsSource = db.ComputerFacilities.Select(x => x).ToList();
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {


                ComputerFacilities path = DG1.SelectedItem as ComputerFacilities;
                //MessageBox.Show(" ID: " + path.SerialNumber + "\n Исполнитель: " + path.InventoryNumber + "\n Альбом: " + path.EmployeeId
                //    + "\n Год: " + path.Description);

                if (path != null)
                {
                    try
                    {
                        var entityToUpdate = db.ComputerFacilities.Where(x => x.EmployeeId == path.EmployeeId).FirstOrDefault();

                        if (entityToUpdate != null)
                        {
                            entityToUpdate.SerialNumber = path.SerialNumber;
                            entityToUpdate.InventoryNumber = path.InventoryNumber;
                            entityToUpdate.EmployeeId = path.EmployeeId;
                            entityToUpdate.Type = path.Type;
                            entityToUpdate.Description = path.Description;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
                    }
                }
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                var selectedItem = DG1.SelectedItem as ComputerFacilities;
                if (selectedItem != null)
                {
                    db.ComputerFacilities.Remove(selectedItem);
                    db.SaveChanges();

                    DG1.ItemsSource = db.ComputerFacilities.ToList();
                }
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            if (Class1.Role == "User")
            {
                var us = new Main2();
                us.Show();
                this.Close();
            }
            else
            {

                var adm = new AdminPage();
                adm.Show();
                this.Close();
            }
        }

        private void Addsvt_Click(object sender, RoutedEventArgs e)
        {
            var newsvt = new newsvt();
            newsvt.Show();
            this.Close();
        }
    }
}
