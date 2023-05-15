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
    /// Логика взаимодействия для yrokM4_3.xaml
    /// </summary>
    public partial class yrokM4_3 : Window
    {
        public yrokM4_3()
        {
            InitializeComponent();
        }

        private void TM4Y3_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y3.Content = new TM4Y3();
        }

        private void PM4Y3_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y3.Content = new PM4Y3();

        }

        private void ZM4Y3_Click(object sender, RoutedEventArgs e)
        {
            f_yrokM4Y3.Content = new ZM4Y3();
        }
    }
}
