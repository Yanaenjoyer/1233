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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Main2.xaml
    /// </summary>
    public partial class Main2 : Window
    {
        public Main2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mn = new Main();
            mn.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var per = new peredacha();
            per.Show(); this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var rem = new remont();
            rem.Show(); this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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
    }
}
