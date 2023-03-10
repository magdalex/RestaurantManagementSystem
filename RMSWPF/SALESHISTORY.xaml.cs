using Microsoft.Win32;
using Newtonsoft.Json;
using RMSWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7085");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            refreshTotalSales(client);
            refreshTotalTables(client);
        }

        private async void refreshTotalTables(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/SalesHistory/TotalTables/" + GlobalValues.WaiterID);
            if (response.IsSuccessStatusCode)
            {
                this.totalTableServed.Text = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode);
            }
        }

        private async void refreshTotalSales(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("api/SalesHistory/TotalSales/" + GlobalValues.WaiterID);
            if (response.IsSuccessStatusCode)
            {
                this.totalSales.Text = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode);
            }
        }
    }
}
