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
        //TEACHER RECOMMENDED TO REMOVE THIS PAGE?
        
        public TABLELAYOUTPAGE()
        {
            InitializeComponent();
            //can we establish connection automatically? like, refresh it and establish it just because the user pressed to go to this page to not have a connect button
        }

        //go to MAIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        //these display by colour on front end which are currently available, which are occupied -- not sure how to do this yet
        //https://www.youtube.com/watch?v=aBh0weP1bmo&ab_channel=IlfordGrammarSchool?


        //IF PRESS BACK TO LAYOUT, OPENS A NEW WINDOW ENTIRELY... FIX THIS
        //individual table buttons, since each table has its own database table
        private void table1Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table1 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table1.Show();
        }

        private void table2Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table2 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table2.Show();

        }

        private void Table3Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table3 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table3.Show();
        }

        private void Table4Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table4 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table4.Show();
        }

        private void Table5Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table5 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table5.Show();
        }

        private void Table6Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table6 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table6.Show();
        }

        private void Table7Button_Click(object sender, RoutedEventArgs e)
        {
            SPECIFICTABLEPAGE table7 = new SPECIFICTABLEPAGE();
            this.Visibility = Visibility.Hidden;
            table7.Show();
        }

    }
}
