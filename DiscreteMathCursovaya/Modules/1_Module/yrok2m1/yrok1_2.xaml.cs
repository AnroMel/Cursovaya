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
using System.Windows.Shapes;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для yrok1_2.xaml
    /// </summary>
    public partial class yrok1_2 : Window
    {
        private string Login;
        public yrok1_2(string login)
        {
            Login = login;
            InitializeComponent();
            f_yrokM1Y2.Content = new TM1Y2();
        }

        private void TM1Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y2.Content = new TM1Y2();
        }

        private void PM1Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y2.Content = new PM1Y2();
        }

        private void ZM1Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM1Y2.Content = new ZM1Y2(Login);
            Back.Visibility = Visibility.Hidden;

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
