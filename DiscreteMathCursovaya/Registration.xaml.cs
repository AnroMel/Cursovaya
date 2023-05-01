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
using System.Text.RegularExpressions;
using LibraryConnectingDB;
using LibraryConnectingDB.Models;
namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private IConnectDB dbconnect;
        private string? Login;
        private string? Group;
        private Rectangle[] rectangles;
        public Registration()
        {
            InitializeComponent();
            Login = TextBoxLoginRegestration.Text;
            rectangles = new Rectangle[]
            {
                imgG1,
                imgG2,
                imgG3,
            };
        }

        private void ButtonComeInRegestration_Click(object sender, RoutedEventArgs e)
        {
            if (!NameVerification(TextBoxNameRegestration))
            {
                MessageBox.Show("Имя должно соответствовать следующим требованиям:\n 1.Длина не менее 3 символов и не более 30 \n 2.Cодержит только буквы русского алфавита", "Ошибка ввода");
                return;
            }
            if (!NameVerification(TextBoxSurNameRegestration))
            {
                MessageBox.Show("Фамилия должна соответствовать следующим требованиям:\n 1.Длина не менее 3 символов и не более 30 \n 2.Cодержит только буквы русского алфавита", "Ошибка ввода");
                return;
            }
            if (!userGroup.HasValue)
            {
                MessageBox.Show("Выберите группу", "Ошибка ввода");
                return;
            }
            if (!Verification(TextBoxLoginRegestration))
            {
                MessageBox.Show("Логин должен соответствовать следующим требованиям:\n 1.Длина не менее 3 символов и не более 30 \n 2.Cодержит только латинские буквы и цифры", "Ошибка ввода");
                return;
            }
            if (IsUserExists())
                return;
           
            if (!PasswordVerification(PasswordBoxRegestration))
            {
                MessageBox.Show("Пароль должен соответствовать следующим требованиям:\n 1.Длина не менее 7 символов \n 2.Cодержит только латинские буквы и цифры \n 3.Cодержит хотя бы 1 букву верхнего регистра \n 4.Cодержит хотя бы 1 букву нижнего регистра \n 5.Cодержит хотя бы 1 цифру", "Ошибка ввода");
                return;
            }

            //КЛАДЕМ ЗНАЧЕНИЯ В БД
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                dbconnect = new ConnectingDB();
                dbconnect.AddUserToDB(
                    new User()
                    {

                        FirstName = TextBoxNameRegestration.Text,
                        LastName = TextBoxSurNameRegestration.Text,
                        Login = TextBoxLoginRegestration.Text,
                        Password = Crypt.GetHashPassword(PasswordBoxRegestration.Password),
                        Group = Group
                    }
                    );
            
                MenuLessons window = new MenuLessons(Login);
                window.Show();
                Close();
            }
        }
        public static bool NameVerification(TextBox temp)
        {
            string regex = "^[А-я]{3,}$";
            return Regex.IsMatch(temp.Text, regex);
        }
        public static bool Verification(TextBox temp)
        {
            string regex = "^[0-9A-zА-я]{3,}$";
            return Regex.IsMatch(temp.Text, regex);
        }
        static bool PasswordVerification(PasswordBox passwordBox)
        {
            string regex = "^(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z])[0-9A-Za-z]{7,}$";
            return Regex.IsMatch(passwordBox.Password, regex);
        }
        public Boolean IsUserExists()
        {
            //ПРОВЕРКА НА СУЩЕСТВУЮЩИЙ ЛОГИН В БД
            dbconnect = new ConnectingDB();
            var user = dbconnect.FirstOrDefault(TextBoxLoginRegestration.Text);
            if (user != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует ");
                return true;
            }    
                return false;
        }

        #region GroupSelection
        bool? userGroup = null;
        private void Group1_Click(object sender, RoutedEventArgs e)
        {
            var currentButton = (sender as Button);
            Group = currentButton.Content.ToString();
            int num = int.Parse(currentButton.Name.Last().ToString())-1;
            userGroup = true;
            foreach (var rectangle in rectangles)
            {
                rectangle.Visibility = Visibility.Hidden;
            }
            rectangles[num].Visibility = Visibility;
        }
        #endregion

        #region eye
        private void ShowPasswordA_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility.Hidden;
            HidePasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Visibility = Visibility;
            TextBoxShowPasswordA.Text = PasswordBoxRegestration.Password;
            PasswordBoxRegestration.IsEnabled = false;
        }

        private void HidePasswordA_MouseLeave(object sender, MouseEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxRegestration.IsEnabled = true;
            PasswordBoxRegestration.Focus();
        }

        private void HidePasswordA_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordA.Visibility = Visibility;
            HidePasswordA.Visibility = Visibility.Hidden;
            TextBoxShowPasswordA.Visibility = Visibility.Hidden;
            PasswordBoxRegestration.IsEnabled = true;
            PasswordBoxRegestration.Focus();
        }
        #endregion

        private void ButtonLinkToRegistrationAuthorization_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
