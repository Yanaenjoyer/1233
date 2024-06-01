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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string usid = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            diplomContext db = new diplomContext();
            {
                var users = db.User.Where(x => x.Login == login.Text && x.Password == password.Password).FirstOrDefault();

                if (users != null)
                {
                    usid = users.UserId;
                    Class1.UserID = usid;
                    if (users.Role == "Admin")
                    {
                        var AdminPage = new AdminPage();
                        AdminPage.Show();
                        this.Close();
                    }
                    else
                    {
                        var Main2 = new Main2();
                        Main2.Show();
                        this.Close();
                    }
                 
                }
                else
                {
                    MessageBox.Show("введите корректные данные для входа или попросите администратора зарегестрировать вас в системе");
                    
                }

            }
        }
    }
}
