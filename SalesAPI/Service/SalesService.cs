using System.Data.SqlClient;
using SalesAPI.Models;

namespace SalesAPI.Service
{
////////////=============================================================================//////////////
    public class SalesService
    {
        static string conString = "Data Source=DESKTOP-VMP9DN3;Initial Catalog=RMSCHAOHAO;Integrated Security=True";
       

        //SPECIFICTABLE page CHECKOUT button -> POST final price, waiter name, and generate invoice number to saleshistoryTABLE
        public void updateSalesHistoryTable(double finalPrice)
        {
            SalesResponse salesResponse = new SalesResponse();
            SqlConnection con = new SqlConnection(conString);
            string query = "INSERT INTO SalesHistoryTable(Invoice_Total, Waiter_Name) VALUES (@Invoice_Total, @Waiter_Name)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Invoice_Total", finalPrice);
            cmd.Parameters.AddWithValue("@Waiter_Name", "David");
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                salesResponse.statusCode = 200;
                salesResponse.statusMessage = "Sales History updated successfully.";
                
            } else
            {
                salesResponse.statusCode = 100;
                salesResponse.statusMessage = "Sales History could not be updated.";
            }

       
        }

        //show Total Tables Served by waiterID
        public int getTotalTablesById()
        {
            SalesResponse salesResponse = new SalesResponse();
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT Count(Invoice_Total) FROM SalesHistoryTable WHERE Waiter_Name = 'DAVID'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = System.Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;
           
           //codes and messages
        }

        public int getTotalSalesById()
        {
            SalesResponse salesResponse = new SalesResponse();
            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT SUM(Invoice_Total) FROM SalesHistoryTable WHERE Waiter_Name = 'DAVID'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = System.Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;
        }
       
    }
}
////////////=============================================================================//////////////
