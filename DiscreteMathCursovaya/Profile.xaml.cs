using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private string Login;
        private IConnectDB dbconnect;
        public Profile(string login)
        {
            Login = login;
            InitializeComponent();
            ButtonEditProfile.Content = "Изменить";
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                dbconnect = new ConnectingDB();

                var user = dbconnect.FirstOrDefault(login);
                    TextBoxNameProfile.Text = user.FirstName;
                    TextBoxSurNameProfile.Text = user.LastName.ToString();
                    TextBoxGroupProfile.Text = user.Group.ToString();
                    TextBoxLoginProfile.Text = user.Login;

            }

        }

        #region eye
        private void ShowPasswordA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility.Hidden;
            HidePasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Text = PasswordBoxProfile.Password;
            PasswordBoxProfile.IsEnabled = false;
        }

        private void HidePasswordA_MouseLeave(object sender, MouseEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxProfile.IsEnabled = true;
            PasswordBoxProfile.Focus();
        }

        private void HidePasswordA_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxProfile.IsEnabled = true;
            PasswordBoxProfile.Focus();
        }
        #endregion

        private void ButtonComeOUT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void ButtonLinkToProfil_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
        
        private void ButtonLinkToReport_Click(object sender, RoutedEventArgs e)
        {
            Report window = new Report(Login);
            window.Show();
            Close();
        }

        private protected void ButtonEditProfile_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEditProfile.Content == "Изменить")
            {
                PasswordBoxProfile.IsEnabled = true;
                ShowPasswordA.IsEnabled = true;
                ButtonEditProfile.Content = "Сохранить";
                Cancel.Visibility = Visibility;

            }
            else
            {
                
                if (!PasswordVerification(PasswordBoxProfile))
                {
                    MessageBox.Show("Пароль должен соответствовать следующим требованиям:\n 1.Длина не менее 7 символов \n 2.Cодержит только латинские буквы и цифры \n 3.Cодержит хотя бы 1 букву верхнего регистра \n 4.Cодержит хотя бы 1 букву нижнего регистра \n 5.Cодержит хотя бы 1 цифру", "Ошибка ввода");
                    return;
                }
                using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
                {
                    dbconnect = new ConnectingDB();
                    dbconnect.UpdatePassword(Login, Crypt.GetHashPassword(PasswordBoxProfile.Password));
                }
                CancelEditProfile();

            }
        }
        static bool PasswordVerification(PasswordBox passwordBox)
        {
            string regex = "^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z])[0-9A-Za-z]{7,}$";
            return Regex.IsMatch(passwordBox.Password, regex);
        }
        private void TextBoxProfile_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для изменения этих данных, обратитесь к преподавателю");
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancelEditProfile();
        }
        private void CancelEditProfile()
        {
            ButtonEditProfile.Content = "Изменить";
            PasswordBoxProfile.IsEnabled = false;
            ShowPasswordA.IsEnabled = false;
            Cancel.Visibility = Visibility.Hidden;
            PasswordBoxProfile.Password = "";
        }
    }
}
