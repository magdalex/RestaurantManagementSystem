using Microsoft.Win32;
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
    /// Interaction logic for SALESHISTORY.xaml
    /// </summary>
    public partial class SALESHISTORY : Window
    {
        public SALESHISTORY()
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

        //close app
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //save whats in the text boxes into SalesHistoryTable
            //close app
        }
    }
}
