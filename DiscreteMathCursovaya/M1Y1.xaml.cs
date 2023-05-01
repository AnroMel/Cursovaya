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

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для M1Y1.xaml
    /// </summary>
    public partial class M1Y1 : Window
    {
        static Random random = new Random();
        static string RandomTemp1;
        static string RandomTemp21;
        static string RandomTemp22;
        static string RandomTemp31;
        static string RandomTemp32;
        static string RandomTemp4;
        static string RandomTemp5;
        static string RandomTemp6;
        static string RandomTemp7;
        static string RandomTemp8;
        static string RandomTemp9;
        public M1Y1()
        {
            InitializeComponent();
            RandomTemp1 = random.Next(5, 10).ToString();
            RandomTemp21 = random.Next(10, 15).ToString();
            RandomTemp22 = random.Next(5, 8).ToString();
            RandomTemp31 = random.Next(5, 9).ToString();
            RandomTemp32 = random.Next(2, 4).ToString();
            RandomTemp4 = random.Next(5, 11).ToString();
            RandomTemp5 = random.Next(3, 9).ToString();
            RandomTemp6 = random.Next(22, 30).ToString();
            RandomTemp7 = random.Next(3, 9).ToString();
            TextTaskM1Y1.Text = $"{RandomTemp1}" + " студентов группы ИБ-2 сдают экзамен по философии. Сколькими способами могут быть поставлены им отметки, если известно, что все студенты экзамен сдали ? ";
            TextTask2M1Y1.Text = "Сколькими способами " + $"{RandomTemp21}" + " пронумерованных бильярдных шаров могут распределиться по " + $"{RandomTemp22}" + " лузам?";
            TextTask3M1Y1.Text = "Сколько существует " + $"{RandomTemp31}" + "-значных телефонных номеров, в первых " + $"{RandomTemp32}" + "-х цифрах которых не встречаются цифры 0 и 3?";
            TextTask4M1Y1.Text = "Имеется "+$"{RandomTemp4}"+" пар перчаток различных размеров. Сколькими способами можно выбрать из них одну перчатку на левую руку и одну — на правую руку так, чтобы эти перчатки были различных размеров? ";
            TextTask5M1Y1.Text = "Сколько существует " + $"{RandomTemp5}" + "-значных натуральных цифр";
            TextTask6M1Y1.Text = "Группа ПМИ-2 состоит из " + $"{RandomTemp6}" + "человек. Надо выбрать старосту группы, заместителя старосты и ответственного за спорт. Сколькими способами может быть сделан выбор, если каждый студент может занимать лишь один пост? ";
            TextTask7M1Y1.Text = "Сколько существует " + $"{RandomTemp7}" + "-значных натуральных цифр из нечетных?";


        }

        public static bool VerificationTask1(TextBox Task1M1Y1)
        {
            if(Math.Pow(3, Convert.ToInt32(RandomTemp1)) == Convert.ToInt32(Task1M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask2(TextBox Task2M1Y1)
        {
            if (Math.Pow(Convert.ToInt32(RandomTemp21), Convert.ToInt32(RandomTemp22)) == Convert.ToInt32(Task2M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask3(TextBox Task3M1Y1)
        {
            if ((Math.Pow(8, Convert.ToInt32(RandomTemp32)) * Math.Pow(10, Convert.ToInt32(RandomTemp31) - Convert.ToInt32(RandomTemp32))) == Convert.ToInt32(Task3M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask4(TextBox Task4M1Y1)
        {
            if (Convert.ToInt32(RandomTemp4)*(Convert.ToInt32(RandomTemp4) -1) == Convert.ToInt32(Task4M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask5(TextBox Task5M1Y1)
        {
            if (9 * Math.Pow(10, Convert.ToInt32(RandomTemp5) -1) == Convert.ToInt32(Task5M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask6(TextBox Task6M1Y1)
        {
            if ((Convert.ToInt32(RandomTemp6) * (Convert.ToInt32(RandomTemp6)-1) * (Convert.ToInt32(RandomTemp6) - 2)) == Convert.ToInt32(Task6M1Y1.Text))
                return true;
            return false;
        }
        public static bool VerificationTask7(TextBox Task7M1Y1)
        {
            if (Math.Pow(5, Convert.ToInt32(RandomTemp7)) == Convert.ToInt32(Task7M1Y1.Text))
                return true;
            return false;
        }
        
        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            if (VerificationTask1(Task1M1Y1))
            {
                
            }
            if (VerificationTask2(Task2M1Y1))
            {
                
            }

        }

    }
}
