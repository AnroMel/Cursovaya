using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        static Random random = new Random();
        private IConnectDB dbconnect;
        private string Login;
        CommonTask[] tasks;
        public ZM4Y1(string login)
        {
            Login = login;
            InitializeComponent();
            var arrayyy = new Type[]
            {
                typeof(Task1),
                typeof(Task2),
                typeof(Task4),
                typeof(Task5),
                typeof(Task6),
                typeof(Task7),
                typeof(Task8),
                typeof(Task9),
                typeof(Task10)
            };
            tasks = arrayyy.Select(item => (CommonTask)Activator.CreateInstance(item)).ToArray();
            string[] arr = { @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф1.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф2.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф3.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф4.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф5.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф6.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф7.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф8.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф9.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф10.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф11.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф12.png",
                @"pack://application:,,,/Modules/4_Module/yrok1m4/Граф13.png" };
            Image img = new Image();
            Image img2 = new Image();
            Image img3 = new Image();
            img.Source = new BitmapImage(new Uri(arr[random.Next(0, 4)]));
            img2.Source = new BitmapImage(new Uri(arr[random.Next(4, 8)]));
            img3.Source = new BitmapImage(new Uri(arr[random.Next(8, 13)]));
            Chart2.Content = img;
            Chart1.Content = img2;
            Chart3.Content = img3;



            TextTaskM1Y1.Text = tasks[0].Question;
            TextTask3M1Y1.Text = tasks[1].Question;
            TextTask4M1Y1.Text = new Task2().Question2;
            TextTask5M1Y1.Text = tasks[2].Question;
            TextTask6M1Y1.Text = tasks[3].Question;
            TextTask7M1Y1.Text = tasks[4].Question;
            TextTask8M1Y1.Text = tasks[5].Question;
            TextTask9M1Y1.Text = tasks[6].Question;
            TextTask10M1Y1.Text = tasks[7].Question;



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
                if (Task1M1Y1.Text.Replace(" ", "") != ""&& Task1M1Y1_1.Text.Replace(" ", "") != "" && Task1M1Y1_2.Text.Replace(" ", "") != "")
                { 
                  int[] ans = new int[3] { Convert.ToInt32(Task1M1Y1.Text.Replace(" ", "")), Convert.ToInt32(Task1M1Y1_1.Text.Replace(" ", "")), Convert.ToInt32(Task1M1Y1_2.Text.Replace(" ", "")) };
                  if (tasks[0].ValidateAnswer(ans))
                    resalt += 1.0m;
                }
                if (tasks[1].ValidateAnswer(Task3M1Y1.Text))
                    resalt += 1.0m;
                if (new Task2().ValidateAnswer2(Task4M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[2].ValidateAnswer(Task5M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[3].ValidateAnswer(Task6M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[4].ValidateAnswer(Task7M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[5].ValidateAnswer(Task8M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[6].ValidateAnswer(Task9M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[7].ValidateAnswer(Task10M1Y1.Text))
                    resalt += 1.0m;
                if(tasks[8].ValidateAnswer(Task11M1Y1.Text))
                    resalt += 1.0m;
                resalt = Math.Round((resalt / 10.0m), 2);


                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 4, 1);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(4, 1);

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
    public abstract class CommonTask
    {
        protected static Random rnd = new Random() ;
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
        private static int U = rnd.Next(10, 20) * 2;

        public Task2() : base(String.Format(("2. В классе {0} человек. " +
            "На праздник каждый мальчик подарил каждой девочке по цветку. " +
            "Какое наибольшее число цветков могло быть подарено"), U))

        {

        }
        public string Question2 = String.Format(("A если в классе {0} человек"), U + 1);
        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                    return intAnswer == (int)((U * U) / 4);               
            }
            return false;
        }
        public bool ValidateAnswer2(object Answer)
        {

            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                U += 1;
                return intAnswer == (int)((U * U) / 4);
            }
            return false;
        }
    }
    public class Task4 : CommonTask
    {//
        private static int girls = rnd.Next(3, 15);
        private static int boys = rnd.Next(3, 15);
        private static int allgirls = rnd.Next(3, 15);
        public Task4() : base(String.Format(("3. На школьном балу каждый мальчик станцевал с {0} девочками," +
            " а каждая девочка — с {1} мальчиками." +
            " Сколько мальчиков пришло на бал, если всего было {2} девочек?"), girls, boys, allgirls))
        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                return intAnswer == boys * allgirls / girls;
            }
            return false;
        }
    }

    public class Task5 : CommonTask
    {
        private static int bullys = rnd.Next(10, 21);
        private static int snowballs = rnd.Next(10, 21);

        public Task5() : base(String.Format(("4. {0} хулиганов кидали снежки в окна школы. " +
            "Первый хулиган попал в окно ровно 1 раз, второй — ровно 2 раза, …, {0}-ый — ровно {0} раз," +
            " причём никакой хулиган не попал в одно и то же окно дважды." +
            " В каждое школьное окно либо попали снежком {1} раз, либо не попали вовсе. " +
            "Сколько школьных окон пострадали от снежков?"), bullys, snowballs))

        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                return intAnswer == ((2 + (bullys - 1) / 2) * bullys) / snowballs;
            }
            return false;
        }
    }
    public class Task6 : CommonTask
    {
        private static int hokeyistG = rnd.Next(10, 21);
        private static int hokeyistH = rnd.Next(10, 21);
        private static int gimnastkaG = rnd.Next(10, 21);
        private static int gimnastkaH = rnd.Next(10, 21);

        public Task6() : base(String.Format(("5. В школе олимпийского резерва каждый хоккеист дружит с {0} гимнастками и {1} хоккеистами из школы," +
            " а каждая гимнастка дружит с {2} гимнастками и {3} хоккеистами." +
            " Какое наименьшее суммарное количество хоккеистов и гимнасток может учиться в школе олимпийского резерва?"), hokeyistG, hokeyistH, gimnastkaG, gimnastkaH))

        {

        }
        public int schet(int hockeyG, int gimnastkaHock)
        {
            if (hockeyG < gimnastkaHock)
            {
                hockeyG *= 2;
                return schet(hockeyG, gimnastkaHock);
            }
            return hockeyG;
        }

        public override bool ValidateAnswer(object Answer)
        {
            int x, y;
            x = schet(hokeyistG, gimnastkaH);
            y = schet(gimnastkaH, hokeyistG);
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));

            if (Answer is int intAnswer)
            {
                return intAnswer == x + y;
            }
            return false;
        }
    }
    public class Task7 : CommonTask
    {
        private static int U = rnd.Next(4, 10) * 2 + 1;
        public Task7() : base(String.Format(("6. Можно ли нарисовать на плоскости {0} отрезков так, чтобы каждый пересекался ровно с тремя другими?"), U))
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString();
            if (Answer is string stringAnswer)
            {
                if (U % 2 != 0)
                    return stringAnswer.ToLower() == "нет";
                else return stringAnswer.ToLower() == "да";
            }
            return false;
        }
    }
    public class Task8 : CommonTask
    {
        public Task8() : base("7. В классе 30 человек. Может ли быть так, что 9 из них имеют по 3 друга (в этом классе), 11 - по 4 друга, а 10 по 5 друзей?")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString();
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "нет";
            }
            return false;
        }
    }
    public class Task9 : CommonTask
    {
        public Task9() : base("8.  Джон, приехав из Диснейленда, рассказывал, что там," +
            " на заколдованном озере имеются 7 островов, с каждого из которых ведет 1, 3 или 5 мостов. " +
            "Верно ли, что хотя бы один из этих мостов обязательно выходит на берег озера?")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString();
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "да";
            }
            return false;
        }
    }
    public class Task10 : CommonTask
    {
        public Task10() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (12 == intAnswer)
                    return true;
            }
            return false;
        }
    }

}
