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
    /// Логика взаимодействия для ZM4Y2.xaml
    /// </summary>
    public partial class ZM4Y2 : Page
    {
        static Random random = new Random();
        private IConnectDB dbconnect;
        private string Login;
        CommonTask[] tasks;
        public ZM4Y2(string login)
        {
            Login = login;
            var arrayyy = new Type[]
            {
                typeof(Task42_1),
                typeof(Task42_2),
                typeof(Task42_3),
                typeof(Task42_4),
                typeof(Task42_5),
                typeof(Task42_6),
                typeof(Task42_7),
                typeof(Task42_7_2),
                typeof(Task42_8),

            };
            InitializeComponent();

            tasks = arrayyy.Select(item => (CommonTask)Activator.CreateInstance(item)).ToArray();
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
               
                if (tasks[0].ValidateAnswer(Task1M1Y1.Text)) //6
                    resalt += 1.0m;
                if (tasks[1].ValidateAnswer(Task2M1Y1.Text))//7
                    resalt += 1.0m;
                if (tasks[2].ValidateAnswer(Task3M1Y1.Text))//8
                    resalt += 1.0m;
                if (tasks[3].ValidateAnswer(Task4M1Y1.Text))//1
                    resalt += 1.0m;
                if (tasks[4].ValidateAnswer(Task5M1Y1.Text))//2
                    resalt += 1.0m;
                if (tasks[5].ValidateAnswer(Task6M1Y1.Text))//3
                    resalt += 1.0m;
                if (tasks[6].ValidateAnswer(Task7M1Y1.Text))//4
                    resalt += 0.5m;
                if (tasks[7].ValidateAnswer(Task7M1Y1_1.Text))//4
                    resalt += 0.5m;
                if (tasks[8].ValidateAnswer(Task8M1Y1.Text))//5
                    resalt += 1.0m;
                resalt = Math.Round((resalt / 8.0m), 2);


                dbconnect = new ConnectingDB();
                var write = dbconnect.FirstOrDefaultWrite(Login, 4, 2);
                if (write == null)
                {
                    var user = dbconnect.FirstOrDefault(Login);
                    var lesson = dbconnect.FirstOrDefaultCodLesson(4, 2);

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
    public class Task42_1 : CommonTask
    {
        public Task42_1() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (3840 == intAnswer)
                    return true;
            }
            return false;
        }
    }
    public class Task42_2 : CommonTask
    {
        public Task42_2() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (40 == intAnswer)
                    return true;
            }
            return false;
        }
    }
    public class Task42_3 : CommonTask
    {
        public Task42_3() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (0 == intAnswer)
                    return true;
            }
            return false;
        }
    }
    public class Task42_4 : CommonTask //1
    {
        public Task42_4() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString().Replace(" ", "");
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "да";
            }
            return false;
        }
    }
    public class Task42_5 : CommonTask //2
    {
        public Task42_5() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString().Replace(" ", "");
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "adeghjibfklc";
            }
            return false;
        }
    }
    public class Task42_6 : CommonTask //3
    {
        public Task42_6() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Answer.ToString().Replace(" ", "");
            if (Answer is string stringAnswer)
            {
                return stringAnswer.ToLower() == "adebghjfcikl";
            }
            return false;
        }
    }
    public class Task42_7 : CommonTask //4 //vershin 2 otvet 18
    {
        public Task42_7() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (2 == intAnswer)
                    return true;
            }
            return false;
        }
    }
    public class Task42_7_2 : CommonTask //4 //vershin 2 otvet 18
    {
        public Task42_7_2() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (18 == intAnswer)
                    return true;
            }
            return false;

        }
    }

    public class Task42_8 : CommonTask //5
    {
        public Task42_8() : base(" ")
        { }

        public override bool ValidateAnswer(object Answer)
        {
            if (Answer.ToString().Replace(" ", "") == "")
                return false;
            Answer = Convert.ToInt32(Answer.ToString().Replace(" ", ""));
            if (Answer is int intAnswer)
            {
                if (124578 == intAnswer)
                    return true;
            }
            return false;
        }
    }
}
