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
    /// Логика взаимодействия для ZM1Y2.xaml
    /// </summary>
    public partial class ZM1Y2 : Page
    {
        static Random random = new Random();
        static string RandomTemp2, RandomTemp3, RandomTemp10, RandomTemp101;
        private IConnectDB dbconnect;
        private string Login;
        public ZM1Y2(string login)
        {
            Login = login;
            InitializeComponent();
            RandomTemp2 = random.Next(5, 10).ToString();
            RandomTemp3 = random.Next(5, 10).ToString();
            RandomTemp10 = random.Next(2, 4).ToString();
            RandomTemp101 = random.Next(5, 7).ToString();
            TextTask2M1Y1.Text = "В скачках участвуют " + $"{RandomTemp2}" + " лошадей, при этом призы дают лишь трем лошадям, пришедшим первыми. Сколько различных распределений призов может быть? ";
            TextTask3M1Y1.Text = "Сколькими способами можно разместиться студентов КБ-3 из " + $"{RandomTemp3}" + " человек за столом в столовке 7го корпуса?";
            TextTask10M1Y1.Text = "У  Ольги Павловны " + $"{RandomTemp10}" + " одинаковых блокнота и " + $"{RandomTemp101}" + " одинаковых ручек. Каждый день в течение " + $"{Convert.ToInt32(RandomTemp10) + Convert.ToInt32(RandomTemp101)}" + " дней подряд она выдает по одному предмету студенту, который показывает лучший результат на паре. Сколькими способами это может быть сделано? ";
        }
        public static bool VerificationTask2(TextBox TextTask2M1Y1)
        {
            if (TextTask2M1Y1.Text == "" || TextTask2M1Y1.Text.Replace(" ", "") == "")
                return false;
            var temp = Convert.ToInt32(RandomTemp2);
            if (temp*(temp-1)*(temp-2) == Convert.ToInt32(TextTask2M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask3(TextBox TextTask3M1Y1)
        {
            if (TextTask3M1Y1.Text == "" || TextTask3M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (MathUtilities.Fact(Convert.ToInt32(RandomTemp3)) == Convert.ToInt32(TextTask3M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask10(TextBox TextTask10M1Y1)
        {
            if (TextTask10M1Y1.Text == "" || TextTask10M1Y1.Text.Replace(" ", "") == "")
                return false;
            if (MathUtilities.Fact(Convert.ToInt32(RandomTemp10) + Convert.ToInt32(RandomTemp101))/ (MathUtilities.Fact(Convert.ToInt32(RandomTemp10))*MathUtilities.Fact(Convert.ToInt32(RandomTemp101))) == Convert.ToInt32(TextTask10M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }

        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                decimal resalt = 0.0m;
                if(Task1M1Y1.Text != "" && Task1M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task1M1Y1.Text.Replace(" ", "")) == 96)
                        resalt += 1.0m;
                if (VerificationTask2(Task2M1Y1))
                    resalt += 1.0m;
                if (VerificationTask3(Task3M1Y1))
                    resalt += 1.0m;
                if (Task4M1Y1.Text != "" && Task4M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task4M1Y1.Text.Replace(" ", "")) == 24)
                        resalt += 1.0m;
                if(Task5M1Y1.Text != "" && Task5M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task5M1Y1.Text.Replace(" ", "")) == 140)
                        resalt += 1.0m;
                if (Task6M1Y1.Text != "" && Task6M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task6M1Y1.Text.Replace(" ", "")) == 1680)
                        resalt += 1.0m;
                if (Task7M1Y1.Text != "" && Task7M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task7M1Y1.Text.Replace(" ", "")) == 6720)
                        resalt += 1.0m;
                if (Task8M1Y1.Text != "" && Task8M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task8M1Y1.Text.Replace(" ", "")) == 453600)
                        resalt += 1.0m;
                if (Task9M1Y1.Text != "" && Task9M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task9M1Y1.Text.Replace(" ", "")) == 360)
                        resalt += 1.0m;
                if (VerificationTask10(Task10M1Y1))
                        resalt += 1.0m;
                if (Task11M1Y1.Text != "" && Task11M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task11M1Y1.Text.Replace(" ", "")) == 228)
                        resalt += 1.0m;
                resalt = Math.Round((resalt / 11.0m), 2);


                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 1, 2);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(1, 2);

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
    }
}
