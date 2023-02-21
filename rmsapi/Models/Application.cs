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
    }
}
