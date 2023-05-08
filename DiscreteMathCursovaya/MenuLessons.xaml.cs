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
using LibraryConnectingDB;
using LibraryConnectingDB.Models;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для MenuLessons.xaml
    /// </summary>
    public partial class MenuLessons : Window
    {
        private string Login;
        private IConnectDB dbconnect;
        public MenuLessons(string login)
        {
            Login = login;
            InitializeComponent();
        }

        private void Yrok1_1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 1, 1);
                if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
                {
                    M1Y1 window = new M1Y1(Login);
                    window.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("Превышено количество попыток");
                }
            }
        }

        private void ButtonComeOUT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void ButtonLinkToProfil_Click(object sender, RoutedEventArgs e)
        {
            Profile window = new Profile(Login);
            window.Show();
            Close();
        }

        private void ButtonLinkToReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
