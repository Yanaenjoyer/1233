using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для user_managment.xaml
    /// </summary>
    public partial class user_managment : Window
    {
        public user_managment()
        {
            InitializeComponent();
        }
       
        string EmployeeID = "";
        string UserID = "";
        string Role = "";
        string Login = "";
        string Password = "";



        string emp = "";
        string usid = "";
        string role = "";
        string login = "";
        string pass = "";
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                DG.ItemsSource = db.User.Select(x=>x).ToList();
            }
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }
        User selectedItem;
        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {


                User path = DG.SelectedItem as User;
               

                if (path != null)
                {
                    try
                    {
                        var entityToUpdate = db.User.Where(x => x.UserId == path.UserId).FirstOrDefault();

                        if (entityToUpdate != null)
                        {
                            entityToUpdate.UserId = path.UserId;
                            entityToUpdate.EmployeeId = path.EmployeeId;
                            entityToUpdate.Role = path.Role;
                            entityToUpdate.Login = path.Login;
                            entityToUpdate.Password = path.Password;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
                    }
                }
            }
            //nomsot.Visibility= Visibility.Visible;
            //nomus.Visibility= Visibility.Visible;
            //rol.Visibility= Visibility.Visible;
            //log.Visibility= Visibility.Visible;
            //par.Visibility= Visibility.Visible;
            //diplomContext db = new diplomContext();
            //{
            //    selectedItem = DG.SelectedItem as User;
            //    Class1.qwe = selectedItem;
            //    if (selectedItem != null)
            //    {
            //         EmployeeID = selectedItem.EmployeeId.ToString();
            //         UserID = selectedItem.UserId.ToString();
            //         Role =selectedItem.Role.ToString();
            //         Login = selectedItem.Login.ToString();
            //         Password = selectedItem.Password.ToString();



            //        DG.ItemsSource = db.User.ToList();
            //    }
            //}
            //nomsot.Text = EmployeeID.ToString();
            //nomus.Text = UserID.ToString();
            //rol.Text = Role.ToString();
            //log.Text = Login.ToString();
            //par.Text = Password.ToString();
            //izm.Visibility = Visibility.Visible;

        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                var selectedItem = DG.SelectedItem as User;
                if (selectedItem != null)
                {
                    db.User.Remove(selectedItem);
                    db.SaveChanges();

                    DG.ItemsSource = db.User.ToList();
                }
            }
            
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //    try
            //    {
            //        emp = nomsot.Text;
            //    }
            //    catch
            //    {
            //        nomsot.Clear();
            //        System.Windows.MessageBox.Show("Введите праввильный тип данных в Id сотрудника");
            //    }
            //    try
            //    {
            //        usid = nomus.Text;
            //    }
            //    catch
            //    {
            //        nomus.Clear();
            //        System.Windows.MessageBox.Show("Введите праввильный тип данных в Id пользователя");
            //    }
            //    try
            //    {
            //        role = rol.Text;
            //    }
            //    catch
            //    {
            //        rol.Clear();
            //        System.Windows.MessageBox.Show("Введите праввильный тип данных в Роле");
            //    }
            //    try
            //    {
            //        login = log.Text;
            //    }
            //    catch
            //    {
            //        log.Clear();
            //        System.Windows.MessageBox.Show("Введите праввильный тип данных в Логине");
            //    }
            //    try
            //    {
            //        pass = par.Text;
            //    }
            //    catch
            //    {
            //        par.Clear();
            //        System.Windows.MessageBox.Show("Введите праввильный тип данных в пароле");
            //    }

            //    diplomContext db = new diplomContext();
            //    {
            //        if (selectedItem != null)
            //        {
            //            var entityToUpdate = db.User.Where(x => x.UserId == selectedItem.UserId).FirstOrDefault();

            //            if (entityToUpdate != null)
            //            {
            //                entityToUpdate.EmployeeId = emp;
            //                entityToUpdate.UserId = usid;
            //                entityToUpdate.Role= role;
            //                entityToUpdate.Login = login;
            //                entityToUpdate.Password = pass; 
            //                try
            //                {
            //                    db.SaveChanges();
            //                }
            //                catch 
            //                {
            //                    Exception ex = new Exception();
            //                    System.Windows.MessageBox.Show(ex.ToString());
            //                }
            //                DG.ItemsSource = db.User.ToList();
            //            }
            //        }
            //    }
            //    nomsot.Visibility = Visibility.Hidden;
            //    nomus.Visibility = Visibility.Hidden;
            //    rol.Visibility = Visibility.Hidden;
            //    log.Visibility = Visibility.Hidden;
            //    par.Visibility = Visibility.Hidden;
        }
    }
}
