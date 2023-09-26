using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Newtonsoft.Json;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using ScottPlot;
using System.Drawing;
using Color = System.Drawing.Color;
using LibraryConnectingDB;
using LibraryConnectingDB.Models;
using Microsoft.Identity.Client;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        private string Login;
        private IConnectDB dbconnect;
        public Report(string login)
        {
            Login = login;
            InitializeComponent();
            using (OverrideCursor cursor = new OverrideCursor(Cursors.Wait))
            {
                Chart.Plot.Clear();
                dbconnect = new ConnectingDB();

                List<double> marks = new List<double>();
                for (int i = 1; i <= dbconnect.GetModuleCount() ; i++)
                {
                    for (int j = 1; j <= dbconnect.GetModuleLessonsCount(i); j++)
                    {
                        marks.Add(GetMark(i,j,dbconnect));                       
                    }
                }
                for (int i = 0; i < 9; i++)
                {
                    marks[i] *= 100;
                }
                double[] values = new double[marks.Count];
                values = marks.ToArray();
                double[] positions = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
                string[] labels = { "Модуль 1 Урок 1", "Модуль 1 Урок 2", "Модуль 1 Урок 3", "Модуль 2 Урок 1", "Модуль 2 Урок 2", "Модуль 3 Урок 1", "Модуль 3 Урок 2", "Модуль 4 Урок 1", "Модуль 4 Урок 2" };
                Chart.Plot.AddBar(values, positions);
                var bar = Chart.Plot.AddBar(values);
                bar.ShowValuesAboveBars = true;
                Chart.Plot.XTicks(positions, labels);
                Chart.Plot.SetAxisLimits(yMin: 0);
                Chart.Plot.SetAxisLimits(yMax: 100);
                Chart.Plot.Style(ScottPlot.Style.Control);
                bar.FillColor = Color.FromArgb(255, 102, 102);
                Chart.Plot.Grid(lineStyle: LineStyle.Dot);
                Chart.Refresh();
            }
            
        }
        public double GetMark(int ModuleId, int LessonNumb, IConnectDB dbconnect)
        {
            StudentWrite StWrite = dbconnect.FirstOrDefaultWrite(Login, ModuleId,LessonNumb);
            if (StWrite == null) return 0;
            else return Decimal.ToDouble((decimal)StWrite.Mark);
        }

        private void ButtonComeOUT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void ButtonLinkToProfil_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }

        private void ButtonLinkToReport_Click(object sender, RoutedEventArgs e)
        {
            Profile window = new Profile(Login);
            window.Show();
            Close();
        }
    }
}
