using DiscreteMathCursovaya.Modules._2_Module.models;
using DiscreteMathCursovaya.Modules._2_Module.TasksAndResults;
using LibraryConnectingDB;
using LibraryConnectingDB.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DiscreteMathCursovaya
{
    public partial class ZM2Y2 : Page
    {
        private string login;
        private ObservableCollection<TaskItem> taskItems =  new();

        private static int Factorial(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private void CreateTasks()
        {
            var random = new Random();
            int rand1 = random.Next(2, 5);
            int rand2 = random.Next(6, 10);

            Tasks.Lesson2[4] = $"\\text{{5. Вычислите коэффициент при }} a^{rand1} \\text{{ в разложении }} (1 + a)^{rand2}";
            Answers.Lesson2[4] = (Factorial(rand2) / (Factorial(rand1) * Factorial(rand2 - rand1))).ToString();

            rand1 = random.Next(2, 10);
            rand2 = random.Next(2, 10);
            Tasks.Lesson2[16] = $"\\text{{17. Найдите }} n \\text{{, если известно, что в разложении }} (1 + x)^n \\\\ \\text{{ коэффициенты при }} x^{rand1} \\text{{ и }} x^{rand2} \\text{{ равны}}";
            Answers.Lesson2[16] = (rand1 + rand2).ToString();

            Tasks.Lesson2.ForEach(x => taskItems.Add(new TaskItem(x)));
            tasks.ItemsSource = taskItems;
        }

        public ZM2Y2(string login)
        {
            this.login = login;
            InitializeComponent();
            CreateTasks();
        }

        private void finishButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var result = VerificationTasks();

            IConnectDB dbconnect = new ConnectingDB();
            var write = dbconnect.FirstOrDefaultWrite(login, 2, 2);
            if (write == null)
            {
                var user = dbconnect.FirstOrDefault(login);
                var lesson = dbconnect.FirstOrDefaultCodLesson(2, 2);

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
            for (int i = 0; i < Answers.Lesson2.Count; i++)
            {
                var text = taskItems[i].Answer.Trim();
                if (!string.IsNullOrEmpty(text) && text == Answers.Lesson2[i])
                    result += 1.0m;
            }

            return Math.Round(result / 17.0m, 2);
        }
    }
}
