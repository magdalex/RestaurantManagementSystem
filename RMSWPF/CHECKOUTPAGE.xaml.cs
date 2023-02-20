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
            SPECIFICTABLEPAGE table = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table.Show();
        }

        //do a calculation and show in final price textbox
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //these all do the same function since there is no real checkout; just display the same message box simulating either going to a terminal or successful payment
        //every button will commit the final price text box informations to the sales per day table
        //VERY IMPORTANT: this.Close() does not close the application FULLY, just clears the table for the next customer
        private void debitButton_Click(object sender, RoutedEventArgs e)
        {
            //add code to commit the final price, final tip, etc. information to sales per day table
            
            //add code to clear the table's table info for the next customer

            MessageBox.Show("Please move to terminal to complete transaction.");
            
            //go back to admin page
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
            
        }

        private void creditButton_Click(object sender, RoutedEventArgs e)
        {
            //add code to commit the final price, final tip, etc. information to sales per day table

            //add code to clear the table's table info for the next customer

            MessageBox.Show("Please move to terminal to complete transaction.");
            
            //go back to admin page
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void cashButton_Click(object sender, RoutedEventArgs e)
        {
            //add code to commit the final price, final tip, etc. information to sales per day table

            //add code to clear the table's table info for the next customer

            MessageBox.Show("Transaction complete!");

            //go back to admin page
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
    }
}
