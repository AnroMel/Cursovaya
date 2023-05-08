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
                double[] values = { 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0 };
                double[] positions = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                string[] labels = { "Модуль 1 Урок 1", "Модуль 1 Урок 2", "Модуль 1 Урок 3", "Модуль 2 Урок 1", "Модуль 2 Урок 2", "Модуль 3 Урок 1", "Модуль 3 Урок 2", "Модуль 3 Урок 3", "Модуль 4 Урок 1", "Модуль 4 Урок 2", "Модуль 4 Урок 3" };
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
