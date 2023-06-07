using LibraryConnectingDB;
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
using LibraryConnectingDB.Models;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для ZM3Y1.xaml
    /// </summary>
    public partial class ZM3Y1 : Page
    {
        static Random random = new Random();
        static string RandomTemp1, RandomTemp2, RandomTemp22, RandomTemp3, RandomTemp32, RandomTemp4, RandomTemp5, RandomTemp6;
        static string RandomTemp7, RandomTemp81, RandomTemp82, RandomTemp9, RandomTemp111, RandomTemp112, RandomTemp113;
        private IConnectDB dbconnect;
        private string Login;
        public ZM3Y1(string login)
        {
            Login = login;
            InitializeComponent();

            string[] arr = { @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_22.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_25.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_52.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_53.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_54.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_51.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_23.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_24.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_55.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_27.jpg"};

            string[] arr1 = { @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_34.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_35.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_36.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_37.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_38.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_39.jpg"};

            string[] arr2 = { @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_40.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_42.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_41.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_45.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_46.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_47.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_48.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_43.jpg"};
            Image img = new Image();
            Image img2 = new Image();
            Image img3 = new Image();
            Image img4 = new Image();
            Image img5 = new Image();
            Image img6 = new Image();

            Image img81 = new Image();
            Image img82 = new Image();
            Image img83= new Image();
            Image img84= new Image();
            Image img85 = new Image();


            img.Source = new BitmapImage(new Uri(arr[random.Next(8, 10)]));
            img2.Source = new BitmapImage(new Uri(arr[random.Next(0, 4)]));
            img3.Source = new BitmapImage(new Uri(arr[random.Next(4, 8)]));

            img4.Source = new BitmapImage(new Uri(arr1[0]));
            img5.Source = new BitmapImage(new Uri(arr1[random.Next(1, 4)]));
            img6.Source = new BitmapImage(new Uri(arr1[random.Next(4, 6)]));

           
            img81.Source = new BitmapImage(new Uri(arr2[0]));
            img82.Source = new BitmapImage(new Uri(arr2[random.Next(0, 2)]));
            img83.Source = new BitmapImage(new Uri(arr2[random.Next(0, 2)]));
            img84.Source = new BitmapImage(new Uri(arr2[random.Next(2, 5)]));
            img85.Source = new BitmapImage(new Uri(arr2[random.Next(5, 8)]));


            Chart2.Content = img;
            Chart1.Content = img2;
            Chart3.Content = img3;

            Chart21.Content = img5;
            Chart11.Content = img4;
            Chart31.Content = img6;

            Chart22.Content = img85;
            Chart12.Content = img82;
            Chart32.Content = img84;
            Chart42.Content = img83;
            Chart121.Content = img81;


            RandomTemp1 = random.Next(5 , 20).ToString();
            RandomTemp2 = random.Next(5, 10).ToString();
            RandomTemp22 = random.Next(5, 100).ToString();
            RandomTemp3 = random.Next(5, 100).ToString();
            RandomTemp4 = random.Next(4, 100).ToString();

            TextTask1M3Y1.Text = $"1.У полного графа  {RandomTemp1}" + "вершин. Сколько у него  ребер? ";
            TextTask2M3Y1.Text = "2. У царя было" + $"{RandomTemp2}" + " детей.Из всех его потомков " + $"{RandomTemp22}" + " имело 3 сыновей остальные умерли бездетными. Сколько потомков было у царя ?";
            TextTask3M3Y1.Text = "3.В некотором царстве в некотором государстве " + $"{RandomTemp3}" + " городов из каждого выходит по 4 дороги. Скольк всего дорог в государстве?";
            TextTask4M3Y1.Text = "4. Про ИБ-2 извесно, что каждый человек в ней знаком ровно с " + $"{RandomTemp4}" + " людьми и для любой группы из " + $"{RandomTemp4}" + " студентов найдется член ИБ-2 , знакомый с каждым из этой группы. Сколько человек в ИБ-2?";
            TextTask5M3Y1.Text = "5. В группе  KБ-2 имеется 9 студентов. Каждый из которых по сообщению каким-то трем другим студентам. Возможна ли сутуация, при которой каждый студетн получит сообщение от тех же трех студентов, кому он посылал сообщения?";
            TextTask6M3Y1.Text = "6. На каком рисунке изображены пары изоморфных графы?";
            TextTask7M3Y1.Text = "7. На каком рисунке изображены порожденные подграфы ?";
            TextTask8M3Y1.Text = "8. Дан граф G. Какие из представленых ниже графов являются остовными подграфами графа G ?";

        }
        public static bool VerificationTask1(TextBox Task1M3Y1)
        {
            if (Task1M3Y1.Text == "" || Task1M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (Convert.ToInt32(RandomTemp1)*(Convert.ToInt32(RandomTemp1)-1)/2 == Convert.ToInt32(Task1M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask2(TextBox Task2M3Y1)
        {
            if (Task2M3Y1.Text == "" || Task2M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (Convert.ToInt32(RandomTemp22) * 3 + Convert.ToInt32(RandomTemp2) == Convert.ToInt32(Task2M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask3(TextBox Task3M3Y1)
        {
            if (Task3M3Y1.Text == "" || Task3M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (Convert.ToInt32(RandomTemp3) *4/2 == Convert.ToInt32(Task3M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask4(TextBox Task4M3Y1)
        {
            if (Task4M3Y1.Text == "" || Task4M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (Convert.ToInt32(RandomTemp4) +1 == Convert.ToInt32(Task4M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask5(TextBox Task4M3Y1)
        {
            if (Task4M3Y1.ToString().Replace(" ", "") == "")
                return false;
            var Task4M3Y11 = Task4M3Y1.ToString().Replace(" ", "");
            if (Task4M3Y11 is string stringAnswer)
            {
                return stringAnswer.ToLower() == "нет";
            }
            return false;
        }
        public static bool VerificationTask6(TextBox Task6M3Y1)
        {
            if (Task6M3Y1.Text == "" || Task6M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (23 == Convert.ToInt32(Task6M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }
        public static bool VerificationTask7(TextBox Task7M3Y1)
        {
            if (Task7M3Y1.Text == "" || Task7M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (13 == Convert.ToInt32(Task7M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }

        public static bool VerificationTask8(TextBox Task8M3Y1)
        {
            if (Task8M3Y1.Text == "" || Task8M3Y1.Text.Replace(" ", "") == "")
                return false;
            if (24 == Convert.ToInt32(Task8M3Y1.Text.Replace(" ", "")))
                return true;
            return false;
        }



        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
               

                decimal resalt = 0.0m;
                if (Task1M3Y1.Text != "" && Task1M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task1M3Y1.Text.Replace(" ", "")) == 96)
                        resalt += 1.0m;
                if (VerificationTask2(Task2M3Y1))
                    resalt += 1.0m;
                if (VerificationTask3(Task3M3Y1))
                    resalt += 1.0m;
                if (Task4M3Y1.Text != "" && Task4M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task4M3Y1.Text.Replace(" ", "")) == 24)
                        resalt += 1.0m;
                if (Task5M3Y1.Text != "" && Task5M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task5M3Y1.Text.Replace(" ", "")) == 140)
                        resalt += 1.0m;
                if (Task6M3Y1.Text != "" && Task6M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task6M3Y1.Text.Replace(" ", "")) == 1680)
                        resalt += 1.0m;
                if (Task7M3Y1.Text != "" && Task7M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task7M3Y1.Text.Replace(" ", "")) == 6720)
                        resalt += 1.0m;
                if (Task8M3Y1.Text != "" && Task8M3Y1.Text.Replace(" ", "") != "")
                    if (Convert.ToInt32(Task8M3Y1.Text.Replace(" ", "")) == 453600)
                        resalt += 1.0m;
                
                

                resalt = Math.Round((resalt / 10.0m), 2);

                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 3, 1);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(3, 1);

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
