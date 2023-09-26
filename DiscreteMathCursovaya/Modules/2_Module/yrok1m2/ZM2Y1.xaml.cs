using DiscreteMathCursovaya.Modules._2_Module.models;
using DiscreteMathCursovaya.Modules._2_Module.TasksAndResults;
using LibraryConnectingDB.Models;
using LibraryConnectingDB;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DiscreteMathCursovaya
{
    public partial class ZM2Y1 : Page
    {
        private string login;
        private ObservableCollection<TaskItem> taskItems = new();

        public ZM2Y1(string login)
        {
            this.login = login;
            InitializeComponent();
            CreateTasks();
        }

        private void CreateTasks()
        {
            var random = new Random();
            int idx = random.Next(0, 4);

            string[] taskRand = new string[]
            {
                @"\text{12. Каков наибольший коэффициент разложения } (a+b+c)^n \text{,} \\ \text{если сумма полиномиальных коэффициентов равна } 19683?",
                @"\text{12. Каков наибольший коэффициент разложения } (a+b+c+d)^n \text{,} \\ \text{если сумма полиномиальных коэффициентов равна } 16384?",
                @"\text{12. Каков наибольший коэффициент разложения } (a+b+c+d)^n \text{,} \\ \text{если сумма полиномиальных коэффициентов равна } 4096?",
                @"\text{12. Каков наибольший коэффициент разложения } (a+b+c)^n \text{,} \\ \text{если сумма полиномиальных коэффициентов равна } 6561?",

            };

            string[] answerRandTask = new string[]
            {
                "1680",
                "630",
                "180",
                "560",
            };

            Tasks.Lesson1[11] = taskRand[idx];
            Answers.Lesson1[11] = answerRandTask[idx];

            Tasks.Lesson1.ForEach(x => taskItems.Add(new TaskItem(x)));
            tasks.ItemsSource = taskItems;
        }

        private void finishButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = VerificationTasks();

            IConnectDB dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(login, 2, 1);
            if (write == null)
            {
                var user = dbconnect.FirstOrDefault(login);
                var lesson = dbconnect.FirstOrDefaultCodLesson(2, 1);

                if (user != null)
                {
                    var test = new StudentWrite()
                    {
                        CountAttempt = 0,
                        Mark = result,
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
                dbconnect.UpdateWriteMarkAndCount(write, result);
            }
            MenuLessons window = new(login);
            window.Show();
            App.Current.MainWindow.Close();
        }

        public decimal VerificationTasks()
        {
            decimal result = 0.0m;
            for (int i = 0; i < Answers.Lesson1.Count; i++)
            {
                var text = taskItems[i].Answer.Trim();
                if (!string.IsNullOrEmpty(text) && text == Answers.Lesson1[i])
                    result += 1.0m;
            }

            return Math.Round(result / 12.0m, 2);
        }
    }
}