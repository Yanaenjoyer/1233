using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;
using MessageBox = System.Windows.Forms.MessageBox;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Window
    {
        public RegPage()
        {
            diplomContext db = new diplomContext();
            {
                string q = Class1.Login;
                string q1 = Class1.Role;
                aa.Content = q + "\n" + q1;
            }
            InitializeComponent();
        }
        string emp = "";
        string usid = "";
        string role = "";
        string login = "";
        string pass = "";
        public static class MessageBoxHelper
        {
            const string _defaultCaption = "Message";
            const MessageBoxButtons _defaultButtons = MessageBoxButtons.OK;

            public static void Show(string message, MessageBoxIcon icon)
            {
                MessageBox.Show(message, _defaultCaption, MessageBoxButtons.YesNo, icon);
            }

            public static DialogResult ShowYesNo(string message, MessageBoxIcon icon)
            {
                return MessageBox.Show(message, _defaultCaption, MessageBoxButtons.YesNo, icon);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
               
                try
                {
                     emp = EmployeeID.Text;
                }
                catch
                {
                    EmployeeID.Clear();
                    MessageBox.Show("Введите праввильный тип данных в Id сотрудника");
                }
                try
                {
                     usid = UserID.Text;
                }
                catch
                {
                    UserID.Clear();
                    MessageBox.Show("Введите праввильный тип данных в Id пользователя");
                }
                try
                {
                     role = Role.Text;
                }
                catch
                {
                    Role.Clear();
                    MessageBox.Show("Введите праввильный тип данных в Роле");
                }
                try
                {                   
                     login = Login.Text;
                }
                catch
                {
                    Login.Clear();
                    MessageBox.Show("Введите праввильный тип данных в Логине");
                }
                try
                {
                     pass = Password.Text;
                }                              
                catch
                {
                    Password.Clear();
                    MessageBox.Show("Введите праввильный тип данных в пароле");
                }
                try
                {
                    

                    User user = new User();
                    user.EmployeeId = emp;
                    user.UserId = usid;
                    user.Role = role;
                    user.Login = login;
                    user.Password = pass;
                    db.User.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Успешно");
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }



        }       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string g = EmployeeID.Text;
            string g1 = Login.Text;
            string g2 = EmployeeID.Text;
            string g3 = UserID.Text;
            int w = 0;
            diplomContext db1 = new diplomContext();
            {
                var us = db1.Employees.Where(x=>x.EmployeeId==g).FirstOrDefault();
                var log = db1.User.Where(x=>x.Login==g1).FirstOrDefault();
                var emp = db1.User.Where(x=>x.EmployeeId== g2).FirstOrDefault();

                var us1 = db1.User.Where(x => x.UserId == g3).FirstOrDefault();
                if (log !=null)
                {
                    Login.Text = "";
                    Login.Background = Brushes.Red;
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    w++;
                }
                else
                {
                    Login.Background = Brushes.White;
                }
                if (emp != null)
                {
                    EmployeeID.Text = "";
                    EmployeeID.Background = Brushes.Red;
                    MessageBox.Show("Пользователь с таким ID сотрудника уже существует");
                    w++;
                }
                else
                {
                    EmployeeID.Background = Brushes.White;
                }
                if (us1 != null)
                {
                    UserID.Text = "";
                    UserID.Background = Brushes.Red;
                    MessageBox.Show("Пользователь с таким ID пользователя уже существует");
                    w++;
                }
                else
                {
                    UserID.Background = Brushes.White;
                }
                //if (us != null)
                //{
                //    if (w == 0)
                //    {


                //        DialogResult res = MessageBoxHelper.ShowYesNo("Показать данные сотрудника?", MessageBoxIcon.Question);
                //        if (res == System.Windows.Forms.DialogResult.Yes)
                //        {
                //            grid.Visibility = Visibility.Visible;
                //            var r = db.Employees.Where(x => x.EmployeeId == g).Select(x => x).ToList();
                //            DG.ItemsSource = r;
                //        }
                //        else
                //        {

                //        }
                //    }
                    
                //}
            }
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
         grid.Visibility = Visibility.Hidden;
            
        }

        private void nosotr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var AdminPage  = new AdminPage();
            AdminPage.Show();
            this.Close();
        }
    }   
}
