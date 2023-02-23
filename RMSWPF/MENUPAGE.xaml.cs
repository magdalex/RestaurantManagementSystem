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

namespace RMSWPF
{
    /// <summary>
    /// Interaction logic for MENUPAGE.xaml
    /// </summary>
    public partial class MENUPAGE : Window
    {
        SqlConnection con;
        HttpClient client = new HttpClient();
        public MENUPAGE()
        {
            client.BaseAddress = new Uri("https://localhost:7083/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }

        //go to MAIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        //connect to database
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=RMSCHAOHAO;Integrated Security=True;TrustServerCertificate=True"; //change this to your connection string!
                con = new SqlConnection(connectionString);
                con.Open();
                MessageBox.Show("Connection established successfully.");
                con.Close();

                refreshButton_Click(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //CREATE ITEM
        private async void insertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var menuItems = new MenuItems()
                {
                    FoodID = int.Parse(foodID.Text),
                    FoodName = foodName.Text,
                    Price = float.Parse(price.Text),
                    Inventory = int.Parse(inventory.Text)
                };

                var response = await client.PostAsJsonAsync("Menu/AddItem/", menuItems);

                MessageBox.Show(response.StatusCode.ToString());


                refreshButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Insert operation failed.");
            }

        }

        //UPDATE ITEM
        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MenuItems menuItems = new MenuItems();
                menuItems.FoodID = int.Parse(foodID.Text);
                menuItems.FoodName = foodName.Text;
                menuItems.Price = float.Parse(price.Text);
                menuItems.Inventory = int.Parse(inventory.Text);

                HttpResponseMessage response = await client.PutAsJsonAsync<MenuItems>("Menu/UpdateItem/" + menuItems.FoodID, menuItems);

                MessageBox.Show("Updated food successfully in the database.");

                refreshButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Update operation failed.");
            }
        }

        //DELETE ITEM
        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var menuItems = new MenuItems()
                {
                    FoodID = int.Parse(foodID.Text)
                };

                var response = await client.DeleteAsync("Menu/DeleteItem/" + menuItems.FoodID);
                MessageBox.Show("Deleted food from database.");

                refreshButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Delete operation failed.");
            }
        }

        //SELECT ITEM
        private void refreshButton_Click(object sender, RoutedEventArgs e)
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
