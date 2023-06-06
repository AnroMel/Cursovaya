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
    /// Логика взаимодействия для ZM1Y3.xaml
    /// </summary>
    public partial class ZM1Y3 : Page
    {
        static Random random = new Random();
        static string RandomTemp2n, RandomTemp2k, RandomTemp5n, RandomTemp5k, RandomTemp6n, RandomTemp6k, RandomTemp7;
        private IConnectDB dbconnect;
        private string Login;
        public ZM1Y3(string login)
        {
            Login = login;
            InitializeComponent();
            RandomTemp2n = random.Next(10, 12).ToString();
            RandomTemp2k = random.Next(5, 8).ToString();
            RandomTemp5n = random.Next(2, 4).ToString();
            RandomTemp5k = random.Next(2, 4).ToString();
            RandomTemp6n = random.Next(5, 13).ToString();
            RandomTemp6k = random.Next(2, 4).ToString();
            RandomTemp7 = random.Next(8, 18).ToString();
            TextTask2M1Y1.Text = "2. В деканате находится " + $"{RandomTemp2n}" + " листов для заявления на повышение стипендии. Сколькими способами можно взять " + $"{RandomTemp2k}" + " листов? ";
            TextTask5M1Y1.Text = "Сколькими способами можно выбрать из этой же группы " + $"{RandomTemp5n}" + "-х юношей и " + $"{RandomTemp5k}" + "-х девушек для участия в сценке КВН? ";
            TextTask6M1Y1.Text = "4. В столовой ЯрГУ продается " + $"{RandomTemp6n}" + " видов салатов. Очередной покупатель получил чек на " + $"{RandomTemp6k}" + " салата. Считая, что любой набор товаров равно-возможен, определить число возможных заказов ";
            TextTask7M1Y1.Text = "5. В спортивной секции занимается " + $"{RandomTemp7}" + " баскетболистов. Сколько может быть организовано тренером разных спортивных пятерок?";
        }
        public static bool VerificationTask2(TextBox TextTask2M1Y1)
        {
            if (TextTask2M1Y1.Text == "" || TextTask2M1Y1.Text.Replace(" ", "") == "")
                return false;
            var n = Convert.ToInt32(RandomTemp2n);
            var k = Convert.ToInt32(RandomTemp2k);
            if (MathUtilities.Fact(n)/(MathUtilities.Fact(n-k)* MathUtilities.Fact(k)) == Convert.ToInt32(TextTask2M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask5(TextBox TextTask5M1Y1)
        {
            if (TextTask5M1Y1.Text == "" || TextTask5M1Y1.Text.Replace(" ", "") == "")
                return false;
            var n = Convert.ToInt32(RandomTemp5n);
            var k = Convert.ToInt32(RandomTemp5k);
            if ((355687428096000/(MathUtilities.Fact(17-n)*MathUtilities.Fact(n)))*(6227020800/(MathUtilities.Fact(13 - k)*MathUtilities.Fact(k))) == Convert.ToInt32(TextTask5M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask6(TextBox TextTask6M1Y1)
        {
            if (TextTask6M1Y1.Text == "" || TextTask6M1Y1.Text.Replace(" ", "") == "")
                return false;
            var n = Convert.ToInt32(RandomTemp6n);
            var k = Convert.ToInt32(RandomTemp6k);
            if (MathUtilities.Fact(n+k-1)/(MathUtilities.Fact(n - 1)*MathUtilities.Fact(k)) == Convert.ToInt32(TextTask6M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask7(TextBox TextTask7M1Y1)
        {
            if (TextTask7M1Y1.Text == "" || TextTask7M1Y1.Text.Replace(" ", "") == "")
                return false;
            var n = Convert.ToInt32(RandomTemp7);
            if (MathUtilities.Fact(n) / (MathUtilities.Fact(n - 5) * 120) == Convert.ToInt32(TextTask7M1Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }

        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                decimal resalt = 0.0m;
                if (Task1M1Y1.Text != "" && Task1M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task1M1Y1.Text.Replace(" ", "")) == 2598960)
                        resalt += 1.0m;
                if (VerificationTask2(Task2M1Y1))
                    resalt += 1.0m;
                if (Task3M1Y1.Text != "" && Task3M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task3M1Y1.Text.Replace(" ", "")) == 214)
                        resalt += 1.0m;
                if (Task4M1Y1.Text != "" && Task4M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task4M1Y1.Text.Replace(" ", "")) == 221)
                        resalt += 1.0m;
                if (VerificationTask5(Task5M1Y1))
                    resalt += 1.0m;
                if (VerificationTask6(Task6M1Y1))
                    resalt += 1.0m;
                if (VerificationTask7(Task7M1Y1))
                    resalt += 1.0m;
                if (Task8M1Y1.Text != "" && Task8M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task8M1Y1.Text.Replace(" ", "")) == 350)
                        resalt += 1.0m;
                if (Task9M1Y1.Text != "" && Task9M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task9M1Y1.Text.Replace(" ", "")) == 1000)
                        resalt += 1.0m;
                if (Task10M1Y1.Text != "" && Task10M1Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task10M1Y1.Text.Replace(" ", "")) == 220)
                        resalt += 1.0m;
                resalt = Math.Round((resalt / 10.0m), 2);

                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 1, 3);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(1, 3);

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
