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
using System.Net.Http;
using System.Net.Http.Headers;


namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for SALESHISTORY.xaml
    /// </summary>
    public partial class SALESHISTORY : Window
    {
        //GlobalValues.TablesServed = totalTableServed.Text;
        public SALESHISTORY()
        {
            InitializeComponent();
            //this.totalTableServed.Text = "Butts";
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



////////////=============================================================================//////////////
        private void refreshButton_Click(object sender, RoutedEventArgs e) 
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7083");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            refreshTotalSales(client);
            refreshTotalTables(client);
        }

        private void refreshTotalTables(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/SalesHistory/TotalTables").Result;
            if (response.IsSuccessStatusCode)
            {
                this.totalTableServed.Text = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode);
            }
        }

        private void refreshTotalSales(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/SalesHistory/TotalSales").Result;
            if (response.IsSuccessStatusCode)
            {
                this.totalSales.Text = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode);
            }
        }
////////////=============================================================================//////////////

    }
}
