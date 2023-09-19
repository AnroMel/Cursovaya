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
                    yrok1 window = new yrok1 (Login);
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
            Report window = new Report(Login);
            window.Show();
            Close();
        }

        private void Yrok1_2_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 1, 2);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrok1_2 window = new yrok1_2(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }

        private void Yrok1_3_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 1, 3);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrok1_3 window = new yrok1_3(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }

        private void Yrok2_1_Click(object sender, RoutedEventArgs e)
        {
            yrokM2_1 window = new yrokM2_1(Login);
            window.Show();
            Close();

        }

        private void Yrok2_2_Click(object sender, RoutedEventArgs e)
        {
            yrokM2_2 window = new yrokM2_2(Login);
            window.Show();
            Close();
        }

        private void Yrok3_1_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 3, 1);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrokM3_1 window = new yrokM3_1(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }

        private void Yrok3_2_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 3, 2);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrokM3_2 window = new yrokM3_2(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }

        private void Yrok4_1_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 4, 1);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrokM4_1 window = new yrokM4_1(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }

        private void Yrok4_2_Click(object sender, RoutedEventArgs e)
        {
            dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(Login, 4, 2);
            if (write == null || write.CountAttempt == 0 || write.CountAttempt == 1)
            {
                yrokM4_2 window = new yrokM4_2(Login);
                window.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Превышено количество попыток");
            }
        }
    }
}
