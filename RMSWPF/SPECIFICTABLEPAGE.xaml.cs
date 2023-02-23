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
using Newtonsoft.Json;
using Microsoft.Identity.Client;
using Microsoft.Data.SqlClient;

namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for SPECIFICTABLEPAGE.xaml
    /// </summary>
    public partial class SPECIFICTABLEPAGE : Window
    {
//        GlobalValues.WaiterName = waiterNameBox.Text;
//        GlobalValues.FinalPrice = finalPriceBox.Text;

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

 ////////////=============================================================================//////////////
        private async void checkoutButton_Click(object sender, RoutedEventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7083");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var myContent = JsonConvert.SerializeObject("99");
            var stringContent = new StringContent(myContent.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/SalesHistory/UpdateSalesHistory", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string TABLENAME = "TABLE1";
                deleteRecords(TABLENAME);
            }
            else
            {
                MessageBox.Show("Error code: " + response.StatusCode);
            }
        }

        private static HttpResponseMessage deleteRecords(string TABLENAME) //? Not sure how to delete individual tables, because I don't see y'all's code
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7083");
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = client.DeleteAsync(TABLENAME).Result;
            return response;
        }

 ////////////=============================================================================//////////////



        private void menuButton_Click_1(object sender, RoutedEventArgs e)
        {
            MenuPOPUP menuPop = new MenuPOPUP();
            this.Visibility = Visibility.Visible;
            menuPop.Show();
        }
    }
}
