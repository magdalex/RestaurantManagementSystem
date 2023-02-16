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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //go to MENU PAGE
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            MENUPAGE menu = new MENUPAGE();
            this.Visibility = Visibility.Hidden;
            menu.Show();
        }

        //go to LOGIN PAGE
        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            LOGINPAGE login = new LOGINPAGE();
            this.Visibility = Visibility.Hidden;
            login.Show();
        }

        //go to TABLE LAYOUT PAGE
        private void tableLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            TABLELAYOUTPAGE layout = new TABLELAYOUTPAGE();
            this.Visibility = Visibility.Hidden;
            layout.Show();
        }

        //go to SALES HISTORY PAGE
        private void salesHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            SALESHISTORY history = new SALESHISTORY();
            this.Visibility = Visibility.Hidden;
            history.Show();
        }
    }
}
