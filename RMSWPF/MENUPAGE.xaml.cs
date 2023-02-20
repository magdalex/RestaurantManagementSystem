using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using RMSWPF.Models;

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
            client.BaseAddress = new Uri("https://localhost:7083/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") );
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
            string connectionString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=RMS;Integrated Security=True;Pooling=False";
            con = new SqlConnection(connectionString);
            con.Open();
            MessageBox.Show("Connection established to database successfully.");
            con.Close();

        }

        //CREATE ITEM
        private async void insertButton_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = new MenuItems()
            {
                FoodName = nameBox.Text,
                Category = categoryBox.Text,
                Price = float.Parse(priceBox.Text)
            };

            var response = await client.PostAsJsonAsync("Menu/AddItem", menuItem);

            MessageBox.Show("Inserted item successfully into the menu.");

            refreshButton_Click(sender, e);
        }

        //UPDATE ITEM
        private async void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = new MenuItems()
            {
                FoodName = nameBox.Text,
                Category = categoryBox.Text,
                Price = float.Parse(priceBox.Text)
            };

            var response = await client.PutAsJsonAsync("Menu/UpdateItem/" + menuItem.FoodName, menuItem);

            MessageBox.Show("Updated menu successfully.");

            refreshButton_Click(sender, e);
        }

        //DELETE ITEM
        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = new MenuItems()
            {
                FoodName = nameBox.Text
            };

            var response = await client.DeleteAsync("Menu/DeleteIem/" + menuItem.FoodName);

            MessageBox.Show("Deleted menu item successfully.");

            refreshButton_Click(sender, e);
        }

        //SELECT ITEM
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.refreshMenu();
            }
            catch
            {
                MessageBox.Show("Could not refresh menu.");
            }
        }

        //auto refresh method
        private async void refreshMenu()
        {
            var response = await client.GetStringAsync("Menu/SeeMenu");
            var menuItem = JsonConvert.DeserializeObject<Response>(response).listMenu;

            menuGrid.ItemsSource = menuItem;
        }
    }
}
