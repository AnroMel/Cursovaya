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

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для yrokM4_1.xaml
    /// </summary>
    public partial class yrokM4_1 : Window
    {
        private string Login;
        public yrokM4_1(string login)
        {
            Login = login;
            InitializeComponent();
            f_yrokM4Y1.Content = new TM4Y1();
        }

        private void TM4Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y1.Content = new TM4Y1();
        }

        private void PM4Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y1.Content = new PM4Y1();
        }

        private void ZM4Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y1.Content = new ZM4Y1(Login);
        }
    }
}
