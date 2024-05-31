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
            diplomContext db = new diplomContext();
            {
                var us = db.Employees.Where(x=>x.EmployeeId==g).FirstOrDefault();
                if (us != null)
                {
                   DialogResult res =  MessageBoxHelper.ShowYesNo("Показать данные пользователя?",MessageBoxIcon.Question);                    
                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        grid.Visibility = Visibility.Visible;
                        var r = db.Employees.Where(x=>x.EmployeeId == g).Select(x => x).ToList();
                        DG.ItemsSource = r;
                    }
                    else
                    {
                        
                    }
                }
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
