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
    /// Логика взаимодействия для yrokM2_1.xaml
    /// </summary>
    public partial class yrokM2_1 : Window
    {
        private string Login;

        public yrokM2_1(string login)
        {
            Login = login;
            InitializeComponent();
        }

        private void TM2Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y1.Content = new TM2Y1();
        }

        private void ZM2Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM2Y1.Content = new ZM2Y1();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuLessons window = new MenuLessons(Login);
            window.Show();
            Close();
        }
    }
}
