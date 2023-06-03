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
    /// Логика взаимодействия для yrok1.xaml
    /// </summary>
    public partial class yrok1 : Window
    {
        private string Login;
        public yrok1(string login)
        {
            Login = login;
            InitializeComponent();
            f_yrokM1Y1.Content = new TM1Y1();
        }

        private void TM1Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y1.Content = new TM1Y1();
        }

        private void PM1Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y1.Content = new PM1Y1();
        }

        private void ZM1Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y1.Content = new ZM1Y1(Login);
        }
    }
}
