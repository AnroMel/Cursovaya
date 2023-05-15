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
using System.Windows.Shapes;

namespace DiscreteMathCursovaya
{
    /// <summary>
    /// Логика взаимодействия для yrokM3_1.xaml
    /// </summary>
    public partial class yrokM3_1 : Window
    {
        public yrokM3_1()
        {
            InitializeComponent();
        }

        private void TM3Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y1.Content = new TM3Y1();
        }

        private void PM3Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y1.Content = new PM3Y1();
        }

        private void ZM3Y1_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM3Y1.Content = new ZM3Y1();
        }
    }
}
