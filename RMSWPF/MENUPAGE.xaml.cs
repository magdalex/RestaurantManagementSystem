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
    /// Interaction logic for MENUPAGE.xaml
    /// </summary>
    public partial class MENUPAGE : Window
    {
        public MENUPAGE()
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

        //connect to database
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //CREATE ITEM
        private void insertButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //UPDATE ITEM
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //DELETE ITEM
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //SELECT ITEM
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
