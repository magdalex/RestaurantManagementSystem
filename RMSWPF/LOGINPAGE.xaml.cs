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
    /// Interaction logic for LOGINPAGE.xaml
    /// </summary>
    public partial class LOGINPAGE : Window
    {
        public LOGINPAGE()
        {
            InitializeComponent();
        }

        //go to MAIN PAGE
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        //close application entirely
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            //close program
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            CREATEACCOUNT create = new CREATEACCOUNT();
            this.Visibility = Visibility.Hidden;
            create.Show();
        }
    }
}
