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

namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for TABLELAYOUTPAGE.xaml
    /// </summary>
    public partial class TABLELAYOUTPAGE : Window
    {
        public TABLELAYOUTPAGE()
        {
            InitializeComponent();
        }

        //go to MAIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void Table1Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(1);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table3Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(3);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table2Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(2);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table4Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(4);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table5Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(5);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table6Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(6);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }

        private void Table7Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE specific = new SPECIFICTABLEPAGE(7);
            this.Visibility = Visibility.Hidden;
            specific.Show();
        }
    }
}
