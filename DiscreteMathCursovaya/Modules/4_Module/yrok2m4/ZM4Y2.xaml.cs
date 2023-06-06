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
                //typeof(Task42_1),
                //typeof(Task42_2),
                //typeof(Task42_3),
                //typeof(Task5),
                //typeof(Task6),
                //typeof(Task7),
                //typeof(Task8),
                //typeof(Task9),
                //typeof(Task10)
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
        private void ButtonFinishTask1_Click(object sender, RoutedEventArgs e)
        {
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                decimal resalt = 0.0m;
               
                if (tasks[0].ValidateAnswer(Task1M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[1].ValidateAnswer(Task2M1Y1.Text))
                    resalt += 1.0m;
                if (tasks[2].ValidateAnswer(Task3M1Y1.Text))
                    resalt += 1.0m;

                resalt = Math.Round((resalt / 10.0m), 2);


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
}
