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
    /// Interaction logic for CREATEACCOUNT.xaml
    /// </summary>
    public partial class CREATEACCOUNT : Window
    {
        public CREATEACCOUNT()
        {
            InitializeComponent();
        }

        //create a new waiter account
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            //check if waiter ID already exists <- use messageboxes to give feedback
            //check if username and password are ok <- use messageboxes to give feedback
            //add to waiter table database
        }

        //decide against making a new account, go back to LOGIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            LOGINPAGE login = new LOGINPAGE();
            this.Visibility = Visibility.Hidden;
            login.Show();
        }
    }
}
