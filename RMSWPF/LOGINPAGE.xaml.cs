using Newtonsoft.Json;
using RMSWPF.Models;
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
    /// Interaction logic for LOGINPAGE.xaml
    /// </summary>
    public partial class LOGINPAGE : Window
    {
        HttpClient client = new HttpClient();
        public LOGINPAGE()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7084/api/"); //this is the base path for me that got auto-generated-- the port number may be different for you
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        //go to MAIN PAGE
        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = PasswordTextBox.Text;
                var newPost = new AccountPost()       // object being sent
                {
                    EmployeeID = int.Parse(WaiterIDTextBox.Text),
                    Password = password,
                    FirstName = "goomba"
                };

                var post = client.PostAsJsonAsync<AccountPost>("Login", newPost).Result.Content.ReadAsStringAsync().Result; // send post
                string postReturnString = JsonConvert.DeserializeObject<string>(post);  // gets rid of " dfgdf " from post return

                AccountChecks check = new AccountChecks();
                Boolean checkBoolean = check.IsLoggedIn(postReturnString);

                if (checkBoolean) // login successful
                {
                    MessageBox.Show(postReturnString);

                    GlobalValues.WaiterID = int.Parse(WaiterIDTextBox.Text);
                    MainWindow main = new MainWindow();
                    this.Visibility = Visibility.Hidden;
                    main.Show();
                }
                else
                {
                    MessageBox.Show(postReturnString);
                }

            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Unsuccessful Login Attempt, something is wrong with your entered INFORMATION please use integers for WaiterID and String for Password "); 
            }
        }

        //close application entirely
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            CREATEACCOUNT create = new CREATEACCOUNT();
            this.Visibility = Visibility.Hidden;
            create.Show();
        }

        private void WaiterIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
