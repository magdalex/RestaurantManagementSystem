using Microsoft.AspNetCore.Mvc;
using RMSAPI.Models;
using System.Data.SqlClient;

namespace RMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly IConfiguration configuration1;
        public MenuController(IConfiguration configuration2)
        {
            configuration1 = configuration2;
        }


        //SELECT
        // GET: api/<MenuController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */


        //for the MENU

        //SELECT
        [HttpGet]
        [Route("SeeMenu")]
        public Response GetAllMenu()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllMenu(con);
            return response;
        }


        //INSERT
        [HttpPost]
        [Route("AddItem")]
        public Response InsertMenuItem(MenuItems menuItem)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.InsertMenuItem(con, menuItem);
            return response;
        }

        //UPDATE
        [HttpPut]
        [Route("UpdateItem/{menuItemID}")]
        public Response UpdateMenuItem(MenuItems menuItem)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateMenuItem(con, menuItem);
            return response;
        }

        //DELETE
        [HttpDelete]
        [Route("DeleteItem/{menuItemID}")]
        public Response DeleteMenuItem(string menuItemID) 
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("restaurantCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteMenuItem(con, menuItemID);
            return response;
        }

    }
}
