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
    /// Логика взаимодействия для yrokM2_2.xaml
    /// </summary>
    public partial class yrokM2_2 : Window
    {
        private string Login;

        public yrokM2_2(string login)
        {
            Login = login;
            InitializeComponent();
        }

        private void TM2Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y2.Content = new TM2Y2();
        }

        private void ZM2Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y2.Content = new ZM2Y2();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
