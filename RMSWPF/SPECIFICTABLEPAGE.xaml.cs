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
    /// Interaction logic for SPECIFICTABLEPAGE.xaml
    /// </summary>
    public partial class SPECIFICTABLEPAGE : Window
    {
        public SPECIFICTABLEPAGE()
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
        
        //reminder what's on the menu, popup that doesn't close the specific table page?
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //adds item in text boxes to grid, updates final price textbox
        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //go to checkout page
        private void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            CHECKOUTPAGE checkout = new CHECKOUTPAGE();
            this.Visibility = Visibility.Hidden;
            checkout.Show();
        }
    }
}
