using Microsoft.AspNetCore.Mvc;
using RMSAPI.Models;
using RMSAPI.Service;
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
        [Route("GetAllCart/{tableValue}")]
        public Response GetAllCart(int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewAllCart(con, tableValue);
            return response;
        }
        //View cart Total
        [HttpGet]
        [Route("ViewCartTotal/{tableValue}")]
        public Response ViewCartTotal(int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.ViewCartTotal(con, tableValue);
            return response;
        }
        //INSERT
        [HttpPost]
        [Route("AddToCart/{tableValue}")]
        public Response AddToCart(TableCart tableCart, int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddToCart(con, tableCart, tableValue);
            return response;
        }
        //UPDATE
        [HttpPut]
        [Route("UpdateCartItem/{FoodID}/{tableValue}")]
        public Response UpdateCartItem(TableCart FoodID, int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateCartItem(con, FoodID, tableValue);
            return response;
        }

        //DELETE
        [HttpDelete]
        [Route("DeleteCartItem/{FoodID}/{tableValue}")]
        public Response DeleteMenuItem(string FoodID, int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteCartItem(con, FoodID, tableValue);
            return response;
        }

        [HttpDelete]
        [Route("PayAndClearCart/{tableValue}")]
        public Response PayAndClearCart(int tableValue)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.PayAndClearCart(con, tableValue);
            return response;
        }
    }
}
