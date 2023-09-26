using DiscreteMathCursovaya.Modules._2_Module.yrok1m2;
using System.Windows;

namespace DiscreteMathCursovaya
{
    public partial class yrokM2_1 : Window
    {
        private string Login;

        public yrokM2_1(string login)
        {
            Login = login;
            InitializeComponent();
        }

        private void TM2Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y1.Content = new TM2Y1();
        }

        private void ZM2Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y1.Content = new ZM2Y1(Login);
        }

        private void PM2Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y1.Content = new PM2Y1();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
