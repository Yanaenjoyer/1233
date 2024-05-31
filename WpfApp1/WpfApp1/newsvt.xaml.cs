using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для newsvt.xaml
    /// </summary>
    public partial class newsvt : Window
    {
      
       public newsvt()
        {
            InitializeComponent();
        }
        string s = "";
        string proizvoditel = "";
        string type = "";
        string proizvoditel1 = "";
        string processor = "";
        string videocard = "";
        string monik = "";
        string hdd = "";
        string oZy = "";
       


        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
               
                string selectedValue = selectedItem.Content.ToString();

                
                 s = selectedValue;
                if(s == "Ноутбук")
                {
                    
                }    
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
        }
        private void proizvod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;          
                string selectedValue = selectedItem.Content.ToString();
                proizvoditel = selectedValue;
               
            }
        }
        public bool CheckSNExists(string nameFromTextBox)
        {
            using (var context = new diplomContext())
            {
                var cmp = new ComputerFacilities { SerialNumber = nameFromTextBox };
                bool exists = context.ComputerFacilities.Any(u => u.SerialNumber == cmp.SerialNumber);
                return exists;
            }
        }
        public bool CheckINExists(string nameFromTextBox)
        {
            using (var context = new diplomContext())
            {
                var cmp = new ComputerFacilities { InventoryNumber = nameFromTextBox };
                bool exists = context.ComputerFacilities.Any(u => u.InventoryNumber == cmp.InventoryNumber);
                return exists;
            }
        }
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                type = selectedValue;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ser = sernum.Text;
            string invent = invnum.Text;
            string sot = sotnum.Text;

            diplomContext db = new diplomContext();
            {
                bool SNExists = CheckSNExists(ser);
                if (SNExists)
                {
                    MessageBox.Show("Такой серийный номер есть в бд");
                }
                else
                {
                    ComputerFacilities comp = new ComputerFacilities();
                    try
                    {
                        comp.SerialNumber = ser;
                        comp.InventoryNumber = invent;
                        comp.EmployeeId = sot;
                        db.Add(comp);
                        db.SaveChanges();
                    }
                    catch
                    {
                        bool INExists = CheckINExists(invent);

                        if (INExists)
                        {
                            MessageBox.Show("Такой инвентарный номер есть в бд");
                        }
                        else
                        {
                            try
                            {
                                comp.SerialNumber = ser;
                                comp.InventoryNumber = invent;
                                comp.EmployeeId = sot;
                                db.Add(comp);
                                db.SaveChanges();
                            }
                            catch
                            {
                                var emp = new ComputerFacilities { EmployeeId = sot };
                                var existingUser = db.ComputerFacilities.FirstOrDefault(u => u.EmployeeId == emp.EmployeeId);
                                if (existingUser == null)
                                {
                                    MessageBox.Show("Пользователь с таким именем отсутствует.");
                                }
                                else
                                {
                                    try
                                    {
                                        comp.SerialNumber = ser;
                                        comp.InventoryNumber = invent;
                                        comp.EmployeeId = sot;
                                        db.Add(comp);
                                        db.SaveChanges();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Все данные прошли проверку.Перейдите к заполнению характеристик СВТ");
                                        save.IsEnabled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            

                string mod1 = model1.Text;
                diplomContext db = new diplomContext();
                {


                    string ser = sernum.Text;
                    string invent = invnum.Text;
                    string sot = sotnum.Text;
                    string g = "";
                    string mod = model.Text;
                    string spd = speed.Text;
                    if (scan.IsChecked == true)
                    {
                        g = "Да";
                    }
                    else
                    {
                        g = "Нет";
                    }
                    ComputerFacilities comp = new ComputerFacilities();
                    comp.SerialNumber = ser;
                    comp.InventoryNumber = invent;
                    comp.EmployeeId = sot;
                    comp.Type = s;
                    comp.Description = "Производитель" + " " + proizvoditel + "/" + "Модель" + " " + mod + "/" + "Тип печати" + " " + type + "/" + "Скорость печати" + " " + spd + "/" + "Наличие сканера" + " " + g;

                    try
                    {
                        db.Add(comp);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            
            
        }

        

        private void proc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                processor = selectedValue;

            }
        }

        private void video_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                videocard = selectedValue;

            }
        }

        private void monitor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                monik = selectedValue;

            }
        }

        private void hddssd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                hdd = selectedValue;

            }
        }

        private void ozy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                oZy = selectedValue;

            }
        }

        private void proizvod1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
                string selectedValue = selectedItem.Content.ToString();
                proizvoditel1 = selectedValue;

            }
        }
    }
}
