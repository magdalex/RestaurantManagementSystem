using API.Controller;
using API.Model;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace API.Service
{
    public class EmployeeService
    {
        String conString = Model.ConnectionString.conString;



        public string ViewAllEmployees()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from dbo.Employee", con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            List<EmployeeModel> list = new List<EmployeeModel>();
            ResponseModel response = new ResponseModel();


            if (dataTable.Rows.Count > 0)
            {

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeID = Convert.ToInt32(dataTable.Rows[i]["EmployeeId"]);
                    employee.Password = Convert.ToString(dataTable.Rows[i]["Password"]);
                    employee.FirstName = Convert.ToString(dataTable.Rows[i]["FName"]);
                    list.Add(employee);
                }

            }
            if (list.Count > 0)
            {
                return JsonConvert.SerializeObject(list);
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data found";
                return JsonConvert.SerializeObject(response);
            }
        }


        public string ViewAllEmployeesByID(int employeeID)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from dbo.Employee where EmployeeID = " + employeeID, con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            List<EmployeeModel> list = new List<EmployeeModel>();
            ResponseModel response = new ResponseModel();


            if (dataTable.Rows.Count > 0)
            {

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeID = Convert.ToInt32(dataTable.Rows[i]["EmployeeId"]);
                    employee.Password = Convert.ToString(dataTable.Rows[i]["Password"]);
                    employee.FirstName = Convert.ToString(dataTable.Rows[i]["FName"]);
                    list.Add(employee);
                }

            }
            if (list.Count > 0)
            {
                return JsonConvert.SerializeObject(list);
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data found";
                return JsonConvert.SerializeObject(response);
            }

        }


        public string LOGIN(EmployeeModel employeeObject)
        {

            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from dbo.Employee where EmployeeID = " + employeeObject.EmployeeID + " AND Password = '" + employeeObject.Password + "'", con);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);


            Boolean validLogin = false;
            if (dataTable.Rows.Count > 0)
            {
                validLogin = true;
                //return validLogin;
                return "LOGIN VALID";


            }
            else
            {
                //return validLogin;   
                return "LOGIN INVALID";
            }
        }


         public string REGISTER(EmployeeModel employeeObject)
          {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand("INSERT INTO EMPLOYEE(EmployeeID,Password) VALUES ("+ employeeObject.EmployeeID + ",'" + employeeObject.Password + "')",con);
                con.Open();
                int i = cmd.ExecuteNonQuery();  // We have to use this instead of a DataAdapter/Table because we are not getting any returned data
                con.Close();                                // instead we are getting rows successfully updated which is the return type...
                if (i > 0)
                {
                    return "Account Created";
                } else
                {
                    return "Error, Account Not Created";
                }



          }








        /* 
         * 
         * if(boolean LOGIN == false;)
         * MessageBox.Show("Unable To LOGIN");
         * else{
         * MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
         * 
         * 
         * 
         * 
        */


    }
}

