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
       
        public ZM3Y2(string login)
        {
            Login = login;
            InitializeComponent();

            
            RandomTemp1 = random.Next(8, 15).ToString();
            RandomTemp2 = random.Next(5, 10).ToString();
            RandomTemp22 = random.Next(5, 100).ToString();
            RandomTemp3 = random.Next(5, 100).ToString();
            RandomTemp4 = random.Next(4, 100).ToString();

            TextTask1M3Y2.Text = $"1 какое максимальное количество ребер может быть в простом слабо связном ориентированном графе на Э"+ $"{RandomTemp1}" +" вершинах ? ";
            TextTask2M3Y2.Text = "2. У царя было" + $"{RandomTemp2}" + " детей.Из всех его потомков " + $"{RandomTemp22}" + " имело 3 сыновей остальные умерли бездетными. Сколько потомков было у царя ?";
            TextTask3M3Y2.Text = "3.В некотором царстве в некотором государстве " + $"{RandomTemp3}" + " городов из каждого выходит по 4 дороги. Скольк всего дорог в государстве?";
            TextTask4M3Y2.Text = "4. Про ИБ-2 извесно, что каждый человек в ней знаком ровно с " + $"{RandomTemp4}" + " людьми и для любой группы из " + $"{RandomTemp4}" + " студентов найдется член ИБ-2 , знакомый с каждым из этой группы. Сколько человек в ИБ-2?";


        }

        public static bool VerificationTask1(TextBox Task1M3Y2)
        {
            if (Task1M3Y2.Text == "" || Task1M3Y2.Text.Replace(" ", "") == "")
                return false;
            if ( 81 == Convert.ToInt32(Task1M3Y2.Text.Replace(" ", "")))
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
