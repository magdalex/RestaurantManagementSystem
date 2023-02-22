using System.Data;
using System.Data.SqlClient;

namespace RMSAPI.Models
{
    public class Application
    {

        //SELECT ALL for MENU
        public Response GetAllMenu(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from MenuTable", con);
            DataTable dt = new DataTable();
            List<MenuItems> listMenu = new List<MenuItems>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MenuItems menuItem = new MenuItems();
                    menuItem.FoodID = (int)dt.Rows[i]["FoodID"];
                    menuItem.FoodName = (string)dt.Rows[i]["FoodName"];
                    menuItem.Price = float.Parse(dt.Rows[i]["Price"].ToString());
                    menuItem.Inventory = (int)dt.Rows[i]["Inventory"];
                    listMenu.Add(menuItem);
                }
            }

            if (listMenu.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Menu items retrieved successfully.";
                response.listMenuItem = listMenu;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No menu items found..";
                response.listMenuItem = null;
            }

            return response;
        }

        //INSERT a new item for MENU
        public Response InsertMenuItem(SqlConnection con, MenuItems menuItem)
        {
            Response response = new Response();
            string query = "INSERT INTO MenuTable VALUES (@FoodID, @FoodName, @Price, @Inventory)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FoodID", menuItem.FoodID);
            cmd.Parameters.AddWithValue("@FoodName", menuItem.FoodName);
            cmd.Parameters.AddWithValue("@Price", menuItem.Price);
            cmd.Parameters.AddWithValue("@Inventory", menuItem.Inventory);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "New item inserted successfully into the menu.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No item inserted.";
            }
            return response;
        }

        //UPDATE an existing item for MENU
        public Response UpdateMenuItem(SqlConnection con, MenuItems menuItem)
        {
            Response response = new Response();
            string query = "UPDATE MenuTable SET FoodName = @FoodName, Price = @Price, Inventory=@Inventory WHERE FoodID = @FoodID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FoodID", menuItem.FoodID);
            cmd.Parameters.AddWithValue("@FoodName", menuItem.FoodName);
            cmd.Parameters.AddWithValue("@Price", menuItem.Price);
            cmd.Parameters.AddWithValue("@Inventory", menuItem.Inventory);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Menu item updated successfully.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No menu items were updated.";
            }
            return response;
        }

        //DELETE an existing item for MENU
        public Response DeleteMenuItem(SqlConnection con, string menuItemID)
        { 
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE from MenuTable WHERE FoodID = '" + menuItemID + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Item menu deleted successfully.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No menu items were deleted.";
            }
            return response;

        }

        public Response ViewAllCart(SqlConnection con)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select *  from Table1", con);
            DataTable dt = new DataTable();
            List<TableCart> listTableCart = new List<TableCart>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableCart tableCart = new TableCart();
                    tableCart.FoodID = (int)dt.Rows[i]["FoodID"];
                    tableCart.FoodName = (string)dt.Rows[i]["FoodName"];
                    tableCart.Price = float.Parse(dt.Rows[i]["Price"].ToString());
                    tableCart.qtyCart = (int)dt.Rows[i]["Quantity"];
                    tableCart.lineTotal = float.Parse(dt.Rows[i]["line_Total"].ToString());

                    listTableCart.Add(tableCart);
                }
            }

            if (listTableCart.Count > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart Retrieved Perfectly";
                response.listTableCart = listTableCart;
            }
            else // Only works if your data table is empty or your connection fails
            {
                response.statusCode = 100;
                response.statusMessage = "No product in cart";
                response.listTableCart = null;
            }

            return response;
        }

        public Response ViewCartTotal(SqlConnection con)
        {
            con.Open();
                Response response = new Response();
                string query = "SELECT sum(line_Total) from Table1";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sqlReader = cmd.ExecuteReader();
            try
            {
                while (sqlReader.Read())
                {
                    response.finalPrice = (float)(Math.Round(Convert.ToDecimal(sqlReader[0]), 2));
                }
            }
            catch { }                           

            return response;
            con.Close();
        } 

        public Response AddToCart(SqlConnection con, TableCart tableCart)
        {
            con.Open();
            Response response = new Response();
            string query = "INSERT INTO Table1 VALUES(@FoodID,@FoodName,@Price,@qtyCart)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FoodID", tableCart.FoodID);
            cmd.Parameters.AddWithValue("@FoodName", tableCart.FoodName);
            cmd.Parameters.AddWithValue("@Price", tableCart.Price);
            cmd.Parameters.AddWithValue("@qtyCart", tableCart.qtyCart);

            string sql1 = "select Inventory from MenuTable where FoodID =" + tableCart.FoodID;
            SqlCommand command1 = new SqlCommand(sql1, con);
            SqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            int inventory = (int)Convert.ToInt64(reader1["Inventory"]);
            int qtyCart = tableCart.qtyCart;
            int i = 0;
            if (inventory >= qtyCart)
            {
                cmd.ExecuteNonQuery();
                i++;
            }

            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Add to cart properly";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No item added to cart";
            }
            return response;
        }

        public Response UpdateCartItem(SqlConnection con, TableCart tableCart)
        {
            Response response = new Response();
            string query = "UPDATE Table1 SET FoodName = @FoodName, Price = @Price, Quantity=@Quantity WHERE FoodID = @FoodID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FoodID", tableCart.FoodID);
            cmd.Parameters.AddWithValue("@FoodName", tableCart.FoodName);
            cmd.Parameters.AddWithValue("@Price", tableCart.Price);
            cmd.Parameters.AddWithValue("@Quantity", tableCart.qtyCart);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart item updated successfully.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No Cart items were updated.";
            }
            return response;
        }

        public Response DeleteCartItem(SqlConnection con, string cartItemID)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE from Table1 WHERE FoodID = '" + cartItemID + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart item deleted successfully.";
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No cart item was deleted.";
            }
            return response;

        }

        public Response PayAndClearCart(SqlConnection con)
        {
            con.Open();
            string sql = "select * from Table1";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string foodID = Convert.ToString(reader["FoodID"]);
                int qty = (int)Convert.ToInt64(reader["Quantity"]);
                string sqlquery1 = "UPDATE menuTable SET Inventory = Inventory -" + qty + "where FoodID =" + foodID;
                SqlCommand command1 = new SqlCommand(sqlquery1, con);
                command1.ExecuteNonQuery();
            }
            string sqlquery2 = "DELETE Table1";// Will change this query to send the data to SalesHistoryTable later
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            command2.ExecuteNonQuery();

            int i = command2.ExecuteNonQuery();
            con.Close();
            Response response = new Response();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMessage = "Cart paid properly";
            }
            else
            {// It can clear the cart and reduce the inventory properly but don't know why it returns fail message 
                response.statusCode = 100;
                response.statusMessage = "Fail to pay the cart";
            }
            return response;
        }
    }
}
