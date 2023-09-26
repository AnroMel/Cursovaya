using DiscreteMathCursovaya.Modules._2_Module.yrok2m2;
using System.Windows;

namespace DiscreteMathCursovaya
{
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
            f_yrokM2Y2.Content = new ZM2Y2(Login);
        }

        private void PM2Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y2.Content = new PM2Y2();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
