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
    /// Interaction logic for CHECKOUTPAGE.xaml
    /// </summary>
    public partial class CHECKOUTPAGE : Window
    {
        public CHECKOUTPAGE()
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

        //do a calculation and show in final price textbox
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //these all do the same function since there is no real checkout; just display the same message box simulating either going to a terminal or successful payment
        //every button will commit the final price text box informations to the sales per day table
        private void debitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void creditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cashButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
