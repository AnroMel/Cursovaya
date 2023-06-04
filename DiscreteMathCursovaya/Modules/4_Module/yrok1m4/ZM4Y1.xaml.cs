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
    /// Логика взаимодействия для ZM4Y1.xaml
    /// </summary>
    public partial class ZM4Y1 : Page
    {
        private IConnectDB dbconnect;
        private string Login;
        IEnumerable<CommonTask> tasks;
        public ZM4Y1(string login)
        {
            Login = login;
            InitializeComponent();
            var arrayyy = new Type[]
            {
                typeof(Task1),
                typeof(Task2),
            };

            tasks = arrayyy.Select(item => (CommonTask)Activator.CreateInstance(item)).ToArray();
            /*foreach (var item in arrayyy)
            {
                var a = (CommonTask)Activator.CreateInstance(item);
                MessageBox.Show(a.Question);
            }*/

            TextTaskM1Y1.Text = new Task1().Question;

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

        }
    }
    public abstract class CommonTask
    {
        protected static Random rnd = new Random();
        public string Question { get; protected set; }
        protected CommonTask(string Question)
        {
            this.Question = Question;
        }
        public abstract bool ValidateAnswer(object Answer);
    }

    public class Task1 : CommonTask
    {
        private static int U = rnd.Next(3, 15);
        private static int R = rnd.Next(3, 15);
        public Task1() : base(String.Format(("1. Каждый граф можно превратить в двудольный, " +
            "покрасив все его вершины в белый цвет и добавив чёрную вершину в " +
            "середину каждого ребра. Сколько вершин каждого цвета и сколько " +
            "рёбер у полученного графа, если у исходного было {0} вершин и {1} рёбер?"), U, R))
        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is int[] arrayIntAnswer)
            {
                return arrayIntAnswer[0] == R * 2 && arrayIntAnswer[1] == U && arrayIntAnswer[2] == R;
            }
            return false;
        }
    }
    public class Task2 : CommonTask
    {
        private static int U = rnd.Next(3, 15);
        private static int R = rnd.Next(3, 15);
        public Task2() : base(String.Format(("1. Каждый граф можно превратить в двудольный, " +
            "покрасив все его вершины в белый цвет и добавив чёрную вершину в " +
            "середину каждого ребра. Сколько вершин каждого цвета и сколько " +
            "рёбер у полученного графа, если у исходного было {0} вершин и {1} рёбер?"), U, R))
        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is int[] arrayIntAnswer)
            {
                return arrayIntAnswer[0] == R * 2 && arrayIntAnswer[1] == U && arrayIntAnswer[2] == R;
            }
            return false;
        }
    }
    public class Task34 : CommonTask
    {
        public Task34() : base("Здесь условие задачи 2")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "нет";
            }
            return false;
        }
    }

}
