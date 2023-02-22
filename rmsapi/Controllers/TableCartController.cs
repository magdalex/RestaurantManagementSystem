using Microsoft.AspNetCore.Mvc;
using RMSAPI.Models;
using System.Data.SqlClient;

namespace RMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCartController : Controller
    {
        private readonly IConfiguration configuration1; // receive the connection state with sql server
        public TableCartController(IConfiguration configuration2)
        {
            configuration1 = configuration2;
        }
        //View cart ALL
        [HttpGet]
        [Route("GetAllCart")]
        public Response GetAllCart()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewAllCart(con);
            return response;
        }
        //View cart Total
        [HttpGet]
        [Route("ViewCartTotal")]
        public Response ViewCartTotal()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewCartTotal(con);
            return response;
        }
        //INSERT
        [HttpPost]
        [Route("AddToCart")]
        public Response AddToCart(TableCart tableCart)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddToCart(con, tableCart);
            return response;
        }
        //UPDATE
        [HttpPut]
        [Route("UpdateCartItem/{FoodID}")]
        public Response UpdateCartItem(TableCart FoodID)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateCartItem(con, FoodID);
            return response;
        }

        //DELETE
        [HttpDelete]
        [Route("DeleteCartItem/{FoodID}")]
        public Response DeleteMenuItem(string FoodID)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteCartItem(con, FoodID);
            return response;
        }

        [HttpDelete]
        [Route("PayAndClearCart")]
        public Response PayAndClearCart()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.PayAndClearCart(con);
            return response;
        }
    }
}
