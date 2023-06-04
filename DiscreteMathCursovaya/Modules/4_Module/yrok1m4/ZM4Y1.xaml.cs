﻿using System;
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
            };

            tasks = arrayyy.Select(item => (CommonTask)Activator.CreateInstance(item)).ToArray();
            /*foreach (var item in arrayyy)
            {
                var a = (CommonTask)Activator.CreateInstance(item);
                MessageBox.Show(a.Question);
            }*/

            TextTaskM1Y1.Text = tasks[0].Question;
            TextTask3M1Y1.Text = tasks[1].Question;
            TextTask4M1Y1.Text = new Task2().Question2;
            TextTask5M1Y1.Text = tasks[2].Question;
            TextTask6M1Y1.Text = tasks[3].Question;

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
                int[] ans = new int[3] { Convert.ToInt32(Task1M1Y1.Text.Replace(" ","")), Convert.ToInt32(Task1M1Y1_1.Text.Replace(" ", "")), Convert.ToInt32(Task1M1Y1_2.Text.Replace(" ", "")) };
               
                if (tasks[0].ValidateAnswer(ans))
                    resalt += 1.0m;
                if (tasks[1].ValidateAnswer(Task3M1Y1))
                    resalt += 1.0m;
                if (tasks[1].ValidateAnswer(Task4M1Y1))
                    resalt += 1.0m;
                if (tasks[2].ValidateAnswer(Task5M1Y1))
                    resalt += 1.0m;
                if (tasks[3].ValidateAnswer(Task6M1Y1))
                    resalt += 1.0m;
                resalt = Math.Round((resalt / 13.0m), 2);


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
        private static int U = rnd.Next(10, 20) * 2;

        public Task2() : base(String.Format(("2. В классе {0} человек. " +
            "На праздник каждый мальчик подарил каждой девочке по цветку. " +
            "Какое наибольшее число цветков могло быть подарено"), U))

        {

        }
        public string Question2 = String.Format(("3. Тот же вопрос, но если в классе {0} человек"),U+1);
        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is int intAnswer)
            {
                if (U % 2 == 0)
                    return intAnswer == (int)((U * U) / 4);
                else
                {
                U += 1;
                return intAnswer == (int)((U * U) / 4); 
                }
            }
            return false;
        }
    }
    public class Task4 : CommonTask
    {
        private static int girls = rnd.Next(3, 15);
        private static int boys = rnd.Next(3, 15);
        private static int allgirls = rnd.Next(3, 15);
        public Task4() : base(String.Format(("4. На школьном балу каждый мальчик станцевал с {0} девочками," +
            " а каждая девочка — с {1} мальчиками." +
            " Сколько мальчиков пришло на бал, если всего было {2} девочек?"), girls, boys, allgirls))
        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is int intAnswer)
            {
                return intAnswer == boys*allgirls/girls;
            }
            return false;
        }
    }

    public class Task5 : CommonTask
    {
        private static int bullys = rnd.Next(10, 21);
        private static int snowballs = rnd.Next(10, 21);

        public Task5() : base(String.Format(("5. {0} хулиганов кидали снежки в окна школы. " +
            "Первый хулиган попал в окно ровно 1 раз, второй — ровно 2 раза, …, {0}-ый — ровно {0} раз," +
            " причём никакой хулиган не попал в одно и то же окно дважды." +
            " В каждое школьное окно либо попали снежком {1} раз, либо не попали вовсе. " +
            "Сколько школьных окон пострадали от снежков?"), bullys,snowballs))

        {

        }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer is int intAnswer)
            {
                return intAnswer == ((2 + (bullys-1)/2)*bullys)/snowballs;
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
