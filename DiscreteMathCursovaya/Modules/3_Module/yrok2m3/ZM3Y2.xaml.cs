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
    /// Логика взаимодействия для ZM3Y2.xaml
    /// </summary>
    public partial class ZM3Y2 : Page
    {
        private string Login;
        CommonTask[] tasks;
        static Random random = new Random();
        static string RandomTemp1, RandomTemp2, RandomTemp22, RandomTemp3, RandomTemp32, RandomTemp4, RandomTemp5, RandomTemp6;
        static string RandomTemp7, RandomTemp81, RandomTemp82, RandomTemp9, RandomTemp111, RandomTemp112, RandomTemp113;
        private IConnectDB dbconnect;
        int RT2;
        public ZM3Y2(string login)
        {
            Login = login;
            InitializeComponent();

            string[] arr = { @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_28.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_29.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_30.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_31.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_32.jpg",

             
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_49.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_50.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_61.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_64.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_62.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_63.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_65.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_66.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_67.jpg",
               

                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_33.jpg"};

            string[] arr2 = { @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_40.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_42.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_41.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_45.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_46.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_47.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_48.jpg",
                 @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_56.jpg",
                  @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_57.jpg",
                   @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_59.jpg",
                    @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_60.jpg",

                @"pack://application:,,,/Modules/3_Module/yrok2m3/Frame_43.jpg"};
            Image img = new Image();
            Image img2 = new Image();
            Image img3 = new Image();
            Image img4 = new Image();
            Image img5 = new Image();
            Image img6 = new Image();
            Image img81 = new Image();
            Image img82 = new Image();
            Image img83 = new Image();
            Image img84 = new Image();
            Image img85 = new Image();
            Image img91 = new Image();
            Image img92 = new Image();
            
            img.Source = new BitmapImage(new Uri(arr[0]));
            img2.Source = new BitmapImage(new Uri(arr[random.Next(1, 16)]));


            img3.Source = new BitmapImage(new Uri(arr[2]));
            img4.Source = new BitmapImage(new Uri(arr[random.Next(0, 2)]));

            img5.Source = new BitmapImage(new Uri(arr[3]));
            img6.Source = new BitmapImage(new Uri(arr[random.Next(4, 6)]));
           
            img91.Source = new BitmapImage(new Uri(arr[3]));
            img92.Source = new BitmapImage(new Uri(arr[random.Next(4, 6)]));

            Chart2.Content = img2;
            Chart1.Content = img;

            Chart52.Content = img3;
            Chart51.Content = img4;

            Chart62.Content = img5;
            Chart61.Content = img6;
            
            Chart18.Content = img5;
            Chart28.Content = img6;

            img81.Source = new BitmapImage(new Uri(arr2[0]));
            img82.Source = new BitmapImage(new Uri(arr2[random.Next(1, 3)]));
            img83.Source = new BitmapImage(new Uri(arr2[random.Next(3, 7)]));
            img84.Source = new BitmapImage(new Uri(arr2[random.Next(7, 9)]));
            img85.Source = new BitmapImage(new Uri(arr2[random.Next(9, 11)]));


            

            Chart22.Content = img81;
            Chart12.Content = img82;
            Chart32.Content = img84;
            Chart42.Content = img85;
            Chart121.Content = img81;

            RandomTemp1 = random.Next(8, 15).ToString();
            RandomTemp2 = random.Next(5, 10).ToString();
            RandomTemp22 = random.Next(5, 100).ToString();
            RandomTemp3 = random.Next(5, 100).ToString();
            RandomTemp4 = random.Next(4, 100).ToString();
             RT2 = 2 * Convert.ToInt32(RandomTemp2);
            TextTask1M3Y2.Text = $"1 какое максимальное количество ребер может быть в простом слабо связном ориентированном графе на "+ $"{RandomTemp1}" +" вершинах ? ";
            TextTask2M3Y2.Text = "2. какое максимальное число ребер может быть в простом двудольном неорентированом графе на" + $"{RT2}" + " вершинах ?";
            TextTask3M3Y2.Text = "3.сколько различных остовных подграфов может иметь простой связный граф G построеный на  " + $"{RandomTemp3}" + " вершинах?";
            TextTask4M3Y2.Text = "4. на какой картинке изображено объединение графов? (нумерация картинок 1 2)";
            TextTask5M3Y2.Text = "5. на какой картинке изображено произведение графов? (нумерация картинок 1 2)";
            TextTask6M3Y2.Text = "6. на какой картинке изображено удаление вершины графа? (нумерация картинок 1 2)";
            TextTask7M3Y2.Text = "7. Дан граф G. Какие из представленых ниже графов являются индуцироваными подграфами графа G ?";
            TextTask8M3Y2.Text = "8. на какой картинке изображено соединение графов? (нумерация картинок 1 2) ";





        }

        public static bool VerificationTask1(TextBox Task1M3Y2)
        {
            if (Task1M3Y2.Text == "" || Task1M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(2, Convert.ToInt32(RandomTemp1)) == Convert.ToInt32(Task1M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask2(TextBox Task2M3Y2)
        {
            if (Task2M3Y2.Text == "" || Task2M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(2,2*Convert.ToInt32(RandomTemp2)) == Convert.ToInt32(Task2M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask3(TextBox Task3M3Y2)
        {
            if (Task3M3Y2.Text == "" || Task3M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (Math.Pow(2, 2 * Convert.ToInt32(RandomTemp2)) == Convert.ToInt32(Task3M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask4(TextBox Task4M3Y2)
        {
            if (Task4M3Y2.Text == "" || Task4M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (2 == Convert.ToInt32(Task4M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask5(TextBox Task5M3Y2)
        {
            if (Task5M3Y2.Text == "" || Task5M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (2 == Convert.ToInt32(Task5M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask6(TextBox Task6M3Y2)
        {
            if (Task6M3Y2.Text == "" || Task6M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (2 == Convert.ToInt32(Task6M3Y2.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask7(TextBox Task7M3Y2)
        {
            if (Task7M3Y2.Text == "" || Task7M3Y2.Text.Replace(" ", "") == "")
                return false;
            if (34 == Convert.ToInt32(Task7M3Y2.Text.Replace(" ", "")))
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
               

                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 3, 2);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(3, 2);

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
