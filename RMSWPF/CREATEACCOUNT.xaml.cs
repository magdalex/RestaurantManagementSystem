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
    /// Interaction logic for CREATEACCOUNT.xaml
    /// </summary>
    public partial class CREATEACCOUNT : Window
    {
        HttpClient client = new HttpClient();
        public CREATEACCOUNT()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7084/api/"); ///base path to call *url specific*
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        //create a new waiter account
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            //check if waiter ID already exists <- use messageboxes to give feedback
            //check if username and password are ok <- use messageboxes to give feedback
            //add to waiter table database
            try
            {
                string password = PasswordTextBox.Text;
                var newPost = new AccountPost()       // object being sent
                {
                    EmployeeID = int.Parse(WaiterIDTextBox.Text),
                    Password = password,
                    FirstName = "goomba"
                };
                var post = client.PostAsJsonAsync<AccountPost>("Login/Registration", newPost).Result.Content.ReadAsStringAsync().Result; // send post
                string postReturnString = JsonConvert.DeserializeObject<string>(post);  // gets rid of " dfgdf " from post return

                MessageBox.Show(postReturnString);
                LOGINPAGE login = new LOGINPAGE();
                this.Visibility = Visibility.Hidden;
                login.Show();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("ACCOUNT NOT CREATED!\nACCOUNT ALREADY EXSITS OR INVALID INPUT...\nWAITERID IS A INTEGER DATA TYPE AND PASSWORD IS A STRING TYPE LIMITED TO 10 DIGITS!"); 
            }
        }

        //decide against making a new account, go back to LOGIN PAGE
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            LOGINPAGE login = new LOGINPAGE();
            this.Visibility = Visibility.Hidden;
            login.Show();
        }
    }
}
