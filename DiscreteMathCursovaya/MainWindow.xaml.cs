
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
using LibraryConnectingDB;
using LibraryConnectingDB.Models;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConnectDB dbconnect;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonComeInAuthorization_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxLoginAuthorization.Text == "")
            {
                MessageBox.Show("Введите логин", "Ошибка ввода");
                return;
            }
            if (PasswordBoxAuthorization.Password == "")
            {
                MessageBox.Show("Введите пароль", "Ошибка ввода");
                return;
            }
            //ПОИСК ПОЛЬЗОВАТЕЛЯ В БД
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                dbconnect = new ConnectingDB();
                var user = dbconnect.FirstOrDefaultLoginAndPassword(TextBoxLoginAuthorization.Text, Crypt.GetHashPassword(PasswordBoxAuthorization.Password));
                if (user == null)
                {
                    MessageBox.Show("Неправильно введен логин или пароль ", "Ошибка ввода");
                }
                else
                {
                    
                    MenuLessons window = new MenuLessons(TextBoxLoginAuthorization.Text);
                    window.Show();
                    Close();

                }
            }
        }

        private void ButtonLinkToRegistrationAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration();
            window.Show();
            Close();
        }


        #region eye
        private void ShowPasswordA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility.Hidden;
            HidePasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Text = PasswordBoxAuthorization.Password;
            PasswordBoxAuthorization.IsEnabled = false;
        }
        private void HidePasswordA_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxAuthorization.IsEnabled = true;
            PasswordBoxAuthorization.Focus();
        }
        private void HidePasswordA_MouseLeave(object sender, MouseEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxAuthorization.IsEnabled = true;
            PasswordBoxAuthorization.Focus();
        }
        #endregion

        
    }
}
