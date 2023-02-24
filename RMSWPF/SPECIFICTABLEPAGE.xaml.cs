using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using RMSAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for SPECIFICTABLEPAGE.xaml
    /// </summary>
    public partial class SPECIFICTABLEPAGE : Window
    {
        SqlConnection con;
        HttpClient client = new HttpClient();
        public string[] operations { get; set; }
        public int tableValueGlobal;
        public SPECIFICTABLEPAGE(int input)
        {
            InitializeComponent();
            int tableValue = input;
            MessageBox.Show("Welcome to table " + tableValue);
            tableValueGlobal = tableValue;
            tableNumber.Text = tableValue.ToString();

            waiterNameBox.Text = Models.GlobalValues.WaiterID.ToString(); // ADDED THIS TO DISPLAY THE WAITERID!

            client.BaseAddress = new Uri("https://localhost:7083/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
       


        //go to MAIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            TABLELAYOUTPAGE tablelayout = new TABLELAYOUTPAGE();
            this.Visibility = Visibility.Hidden;
            tablelayout.Show();
        }
        
        //reminder what's on the menu, popup that doesn't close the specific table page?
        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPOPUP menuPOPUP = new MenuPOPUP();
            this.Visibility = Visibility.Visible;
            menuPOPUP.Show();
        }
        private void connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // string connectionString = "Data Source=DESKTOP-V50PKCU\\SQLEXPRESS;Initial Catalog=RestaurantManagementSystem;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"; //change this to your connection string!
                //con = new SqlConnection(connectionString);
               // con.Open();
                MessageBox.Show("Connected to table "+ tableValueGlobal);
                //con.Close();

                refreshDataButton_Click(sender, e);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void refreshDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.RefreshCart(tableValueGlobal);
                this.ViewCartTotal(tableValueGlobal);
            }
            catch
            {
                MessageBox.Show("Could not refresh cart.");
            }
        }
        private async void RefreshCart(int tableValue) //this method works
        {

            var response = await client.GetStringAsync("TableCart/GetAllCart/"+tableValue);
            var cart = JsonConvert.DeserializeObject<Response>(response).listTableCart;

            tableCartGrid.ItemsSource = cart;

        }
        private async void ViewCartTotal(int tableValue)
        {

            var response = await client.GetStringAsync("TableCart/ViewCartTotal/"+tableValue);
            var cartTotal = JsonConvert.DeserializeObject<Response>(response).finalPrice;

            finalPriceBox.Text = cartTotal.ToString();

        }

        private async void insertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tableCart = new TableCart()
                {
                    FoodID = int.Parse(foodID.Text),
                    FoodName = foodName.Text,
                    Price = float.Parse(price.Text),
                    qtyCart = int.Parse(quantity.Text)
                };

                var response = await client.PostAsJsonAsync("TableCart/AddToCart/"+tableValueGlobal, tableCart);

                MessageBox.Show(response.StatusCode.ToString());


                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Insert operation failed.");
            }
        }

        private async void updateTableItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableCart tableCart = new TableCart();
                tableCart.FoodID = int.Parse(foodID.Text);
                tableCart.FoodName = foodName.Text;
                tableCart.Price = float.Parse(price.Text);
                tableCart.qtyCart = int.Parse(quantity.Text);

                HttpResponseMessage response = await client.PutAsJsonAsync<TableCart>("TableCart/UpdateCartItem/" + tableCart.FoodID+"/"+tableValueGlobal, tableCart);

                MessageBox.Show("Updated food successfully in the Cart.");

                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Update operation failed.");
            }
        }

        private async void deleteTableItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tableCart = new TableCart()
                {
                    FoodID = int.Parse(foodID.Text)
                };

                var response = await client.DeleteAsync("TableCart/DeleteCartItem/" + tableCart.FoodID+"/"+tableValueGlobal);
                MessageBox.Show("Deleted food from Cart.");

                refreshDataButton_Click(sender, e); //this auto clicks the refresh button at the end of the operation so the user doesnt have to manually press it
            }
            catch
            {
                MessageBox.Show("Delete operation failed.");
            }
        }

        private async void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * 
             *  get all from cart+tableValueGlobal
             *  if(success)
             *  serialize into json
             *  else{return error}
             *  run postTotal
            
            var response = await client.GetStringAsync("TableCart/ViewCartTotal/"+tableValue);
            var cartTotal = JsonConvert.DeserializeObject<Response>(response).finalPrice;

            finalPriceBox.Text = cartTotal.ToString();

            SalesHistory.totalPrice

            var postTotal = await client.PostAsync("/SalesHistory/UpdateSalesHistory", cartObject)
            * 
            * 
            * */

            var response = await client.DeleteAsync("TableCart/PayAndClearCart/" + tableValueGlobal);

            MessageBox.Show("Payment Success");

            refreshDataButton_Click(sender, e);
        }
    }
}
