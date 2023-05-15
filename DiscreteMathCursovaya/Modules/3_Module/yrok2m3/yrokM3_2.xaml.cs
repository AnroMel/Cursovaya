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
    /// Логика взаимодействия для yrokM3_2.xaml
    /// </summary>
    public partial class yrokM3_2 : Window
    {
        public yrokM3_2()
        {
            InitializeComponent();
        }

        private void TM3Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y2.Content = new TM3Y2();
        }

        private void PM3Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y2.Content = new PM3Y2();
        }

        private void ZM3Y2_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y2.Content = new ZM3Y2();
        }
    }
}
