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
    /// Логика взаимодействия для yrokM4_2.xaml
    /// </summary>
    public partial class yrokM4_2 : Window
    {
        private string Login;
        public yrokM4_2(string login)
        {
            Login = login;
            InitializeComponent();
            f_yrokM4Y2.Content = new TM4Y2();
        }

        private void TM4Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y2.Content = new TM4Y2();
        }

        private void PM4Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y2.Content = new PM4Y2();
        }

        private void ZM4Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y2.Content = new ZM4Y2(Login);
            Back.Visibility = Visibility.Hidden;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
