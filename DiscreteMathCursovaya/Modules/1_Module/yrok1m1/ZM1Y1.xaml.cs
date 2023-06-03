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
    /// Логика взаимодействия для ZM1Y1.xaml
    /// </summary>
    public partial class ZM1Y1 : Page
    {
        static Random random = new Random();
        static string RandomTemp1, RandomTemp21, RandomTemp22, RandomTemp31, RandomTemp32, RandomTemp4, RandomTemp5, RandomTemp6;
        static string RandomTemp7, RandomTemp81, RandomTemp82, RandomTemp9, RandomTemp111, RandomTemp112, RandomTemp113;
        private IConnectDB dbconnect;
        private string Login;
        public ZM1Y1(string login)
        {
            Login = login;
            InitializeComponent();
            RandomTemp1 = random.Next(5, 10).ToString();
            RandomTemp21 = random.Next(5, 10).ToString();
            RandomTemp22 = random.Next(5, 6).ToString();
            RandomTemp31 = random.Next(5, 9).ToString();
            RandomTemp32 = random.Next(2, 4).ToString();
            RandomTemp4 = random.Next(5, 11).ToString();
            RandomTemp5 = random.Next(3, 9).ToString();
            RandomTemp6 = random.Next(22, 30).ToString();
            RandomTemp7 = random.Next(3, 9).ToString();
            RandomTemp81 = random.Next(4, 6).ToString();
            RandomTemp82 = random.Next(6, 9).ToString();
            RandomTemp9 = random.Next(4, 9).ToString();
            RandomTemp111 = random.Next(3, 4).ToString();
            RandomTemp112 = random.Next(5, 9).ToString();
            RandomTemp113 = random.Next(5, 9).ToString();
            TextTaskM1Y1.Text = $"1. {RandomTemp1}" + " студентов группы ИБ-2 сдают экзамен по философии. Сколькими способами могут быть поставлены им отметки, если известно, что все студенты экзамен сдали ? ";
            TextTask2M1Y1.Text = "2. Сколькими способами " + $"{RandomTemp21}" + " пронумерованных бильярдных шаров могут распределиться по " + $"{RandomTemp22}" + " лузам?";
            TextTask3M1Y1.Text = "3. Сколько существует " + $"{RandomTemp31}" + "-значных телефонных номеров, в первых " + $"{RandomTemp32}" + "-х цифрах которых не встречаются цифры 0 и 3?";
            TextTask4M1Y1.Text = "4. Имеется " + $"{RandomTemp4}" + " пар перчаток различных размеров. Сколькими способами можно выбрать из них одну перчатку на левую руку и одну — на правую руку так, чтобы эти перчатки были различных размеров? ";
            TextTask5M1Y1.Text = "5. Сколько существует " + $"{RandomTemp5}" + "-значных натуральных цифр";
            TextTask6M1Y1.Text = "6. Группа ПМИ-2 состоит из " + $"{RandomTemp6}" + " человек. Надо выбрать старосту группы, заместителя старосты и ответственного за спорт. Сколькими способами может быть сделан выбор, если каждый студент может занимать лишь один пост? ";
            TextTask7M1Y1.Text = "7. Сколько существует " + $"{RandomTemp7}" + "-значных натуральных цифр из нечетных?";
            TextTask8M1Y1.Text = "8. В столовке ЯрГУ есть " + $"{RandomTemp81}" + " различных яблок, которые могут взять бесплатно первые " + $"{RandomTemp82}" + " студентов, причем каждый может взять одно яблоко, или ничего. Сколькими способами это можно сделать?";
            TextTask8M1Y1_1.Text = "А если число яблок, получаемых каждым студентом, не ограничено? ";
            TextTask9M1Y1.Text = "9. Сколько существует " + $"{RandomTemp9}" + "-значных различных чисел";
            TextTask10M1Y1.Text = "10. Сколькими способами можно выбрать из полной колоды карт, содержащей 52 карты, по одной карте каждой масти?";
            TextTask10M1Y1_1.Text = "А если среди вынутых карт нет ни одной пары одинаковых, т.е. двух королей, двух десяток и т. д.?";
            TextTask11M1Y1.Text = "11.В комнате общежития ЯрГУ живут трое студентов. У них есть " + $"{RandomTemp111}" + " чашки, " + $"{RandomTemp112}" + " блюдец и " + $"{RandomTemp113}" + " чайных ложек (все чашки, блюдца и ложки отличаются друг от друга). Сколькими способами они могут накрыть стол для чаепития (каждый получает одну чашку, одно блюдце и одну ложку)?";
        }

        public static bool VerificationTask1(TextBox Task1M1Y1)
        {
            if (Task1M1Y1.Text == "" || Task1M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(3, Convert.ToInt32(RandomTemp1)) == Convert.ToInt32(Task1M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask2(TextBox Task2M1Y1)
        {
            if (Task2M1Y1.Text == "" || Task2M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(Convert.ToInt32(RandomTemp22), Convert.ToInt32(RandomTemp21)) == Convert.ToInt32(Task2M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask3(TextBox Task3M1Y1)
        {
            if (Task3M1Y1.Text == "" || Task3M1Y1.Text.Replace(" ", "") == "")
                return false;
            if ((Math.Pow(8, Convert.ToInt32(RandomTemp32)) * Math.Pow(10, Convert.ToInt32(RandomTemp31) - Convert.ToInt32(RandomTemp32))) == Convert.ToInt32(Task3M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask4(TextBox Task4M1Y1)
        {
            if (Task4M1Y1.Text == "" || Task4M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (Convert.ToInt32(RandomTemp4) * (Convert.ToInt32(RandomTemp4) - 1) == Convert.ToInt32(Task4M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }


        public static bool VerificationTask5(TextBox Task5M1Y1)
        {
            if (Task5M1Y1.Text == "" || Task5M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (9 * Math.Pow(10, Convert.ToInt32(RandomTemp5) - 1) == Convert.ToInt32(Task5M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask6(TextBox Task6M1Y1)
        {
            if (Task6M1Y1.Text == "" || Task6M1Y1.Text.Replace(" ", "") == "")
                return false;
            if ((Convert.ToInt32(RandomTemp6) * (Convert.ToInt32(RandomTemp6) - 1) * (Convert.ToInt32(RandomTemp6) - 2)) == Convert.ToInt32(Task6M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask7(TextBox Task7M1Y1)
        {
            if (Task7M1Y1.Text == "" || Task7M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(5, Convert.ToInt32(RandomTemp7)) == Convert.ToInt32(Task7M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask8(TextBox Task8M1Y1)
        {
            if (Task8M1Y1.Text == "" || Task8M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (MathUtilities.Fact(Convert.ToInt32(RandomTemp82))/MathUtilities.Fact(Convert.ToInt32(RandomTemp82) - Convert.ToInt32(RandomTemp81)) == Convert.ToInt32(Task8M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask8_1(TextBox Task8M1Y1_1)
        {
            if (Task8M1Y1_1.Text == "" || Task8M1Y1_1.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(Convert.ToInt32(RandomTemp82), Convert.ToInt32(RandomTemp81)) == Convert.ToInt32(Task8M1Y1_1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask9(TextBox Task9M1Y1)
        {
            if (Task9M1Y1.Text == "" || Task9M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (9*(362880 / MathUtilities.Fact(10 -Convert.ToInt32(RandomTemp9))) == Convert.ToInt32(Task9M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask10(TextBox Task10M1Y1)
        {
            if (Task10M1Y1.Text == "" || Task10M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (28561 == Convert.ToInt32(Task10M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask10_1(TextBox Task10M1Y1_1)
        {
            if (Task10M1Y1_1.Text == "" || Task10M1Y1_1.Text.Replace(" ", "") == "")
                return false;
            if (17160 == Convert.ToInt32(Task10M1Y1_1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask11(TextBox Task11M1Y1)
        {
            if (Task11M1Y1.Text == "" || Task11M1Y1.Text.Replace(" ", "") == "")
                return false;
            var one = Convert.ToInt32(RandomTemp111);
            var two = Convert.ToInt32(RandomTemp112);
            var three = Convert.ToInt32(RandomTemp113);
            if (one*(one-1)*(one-2)*two*(two-1)*(two-2)*three*(three-1)*(three-2) == Convert.ToInt32(Task11M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }

        bool IsGood(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }

        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                decimal resalt = 0.0m;
                if (VerificationTask1(Task1M1Y1))
                    resalt += 1.0m;
                if (VerificationTask2(Task2M1Y1))
                    resalt += 1.0m;
                if (VerificationTask3(Task3M1Y1))
                    resalt += 1.0m;
                if (VerificationTask4(Task4M1Y1))
                    resalt += 1.0m;
                if (VerificationTask5(Task5M1Y1))
                    resalt += 1.0m;
                if (VerificationTask6(Task6M1Y1))
                    resalt += 1.0m;
                if (VerificationTask7(Task7M1Y1))
                    resalt += 1.0m;
                if (VerificationTask8(Task8M1Y1))
                    resalt += 1.0m;
                if (VerificationTask8_1(Task8M1Y1_1))
                    resalt += 1.0m;
                if (VerificationTask9(Task9M1Y1))
                    resalt += 1.0m;
                if (VerificationTask10(Task10M1Y1))
                    resalt += 1.0m;
                if (VerificationTask10_1(Task10M1Y1_1))
                    resalt += 1.0m;
                if (VerificationTask11(Task11M1Y1))
                    resalt += 1.0m;
                resalt = Math.Round((resalt / 13.0m), 2);


                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 1, 1);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(1, 1);

                    if (user != null)
                    {
                        var test = new StudentWrite()
                        {
                            CountAttempt = 0,
                            Mark = resalt,
                            StudentId = user.Id,
                            LessonId = lesson.Code
                        };
                        dbconnect.AddWriteToDB(test);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при входе в приложение", "Ошибка");
                    }
                }
                else
                {
                    dbconnect.UpdateWriteMarkAndCount(write, resalt);
                }
                MenuLessons window = new MenuLessons(Login);
                window.Show();
                App.Current.MainWindow.Close();
            }
        }
    }
}
