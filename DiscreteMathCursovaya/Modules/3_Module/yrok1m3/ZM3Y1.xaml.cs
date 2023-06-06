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
            RandomTemp1 = random.Next(5 , 20).ToString();
            RandomTemp2 = random.Next(5, 10).ToString();
            RandomTemp22 = random.Next(5, 100).ToString();
            RandomTemp3 = random.Next(5, 100).ToString();
            RandomTemp4 = random.Next(4, 100).ToString();

            TextTask1M3Y1.Text = $"1.У полного графа  {RandomTemp1}" + "вершин. Сколько у него  ребрами? ";
            TextTask2M3Y1.Text = "2. У царя было" + $"{RandomTemp2}" + " детей.Из всех его потомков " + $"{RandomTemp22}" + " имело 3 сыновей остальные умерли бездетными. Сколько потомков было у царя ?";
            TextTask3M3Y1.Text = "3.В некотором царстве в некотором государстве " + $"{RandomTemp3}" + " городов из каждого выходит по 4 дороги. Скольк всего дорог в государстве?";
            TextTask4M3Y1.Text = "4. Про ИБ-2 извесно, что каждый человек в ней знаком ровно с " + $"{RandomTemp4}" + " людьми и для любой группы из " + $"{RandomTemp4}" + " студентов найдется член ИБ-2 , знакомый с каждым из этой группы. Сколько человек в ИБ-2?";
            
            string[] arr = { @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_22.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_23.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_24.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_25.jpg",
                @"pack://application:,,,/Modules/3_Module/yrok1m3/Frame_27.jpg"};
            Image img = new Image();
            Image img2 = new Image();
            Image img3 = new Image();
            img.Source = new BitmapImage(new Uri(arr[random.Next(0, 2)]));
            img2.Source = new BitmapImage(new Uri(arr[random.Next(2, 4)]));
            img3.Source = new BitmapImage(new Uri(arr[4]));
            Chart2.Content = img3;
            Chart1.Content = img2;
            Chart3.Content = img;
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
