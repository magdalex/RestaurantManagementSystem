using Azure;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using Response = RMSAPI.Models.Response;

namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for MenuPOPUP.xaml
    /// </summary>
    public partial class MenuPOPUP : Window
    {
        SqlConnection con;
        HttpClient client = new HttpClient();
        public MenuPOPUP()
        {
            client.BaseAddress = new Uri("https://localhost:7083/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        //close popup
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            //CLOSE WINDOW
            this.Close();
        }

        //connect to database
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //string connectionString = "Data Source=localhost;Initial Catalog=test_db;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"; //change this to your connection string!
               // con = new SqlConnection(connectionString);
                //con.Open();
                MessageBox.Show("Connection established successfully.");
               // con.Close();

                RefreshButton_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.RefreshProducts(); //calls the refresh method
            }
            catch
            {
                MessageBox.Show("Could not refresh inventory.");
            }

        }
        private async void RefreshProducts() //this method works
        {

            var response = await client.GetStringAsync("Menu/SeeMenu/"); //this is the path that gets called
            var food = JsonConvert.DeserializeObject<Response>(response).listMenuItem; //maps fields of json to response class

            menuGrid.ItemsSource = food; //puts it straight into the datagrid

        }
    }
}
