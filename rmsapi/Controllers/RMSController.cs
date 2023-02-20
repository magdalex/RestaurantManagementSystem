using Microsoft.AspNetCore.Mvc;
using RMSAPI.Models;
using System.Data.SqlClient;

namespace RMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMSController : Controller
    {
        private readonly IConfiguration configuration1;
        public RMSController(IConfiguration configuration2)
        {
            configuration1 = configuration2;
        }


        //SELECT
        // GET: api/<RMSController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        //for the MENU

        //SELECT
        [HttpGet]
        [Route("Menu/SeeMenu")]
        public Response GetAllMenu()
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("ProductCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllMenu(con);
            return response;
        }


        //INSERT
        [HttpPost]
        [Route("Menu/AddItem")]
        public Response InsertMenuItem(MenuItems menuItem)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.InsertMenuItem(con, menuItem);
            return response;
        }

        //UPDATE
        [HttpPost]
        [Route("Menu/UpdateItem")]
        public Response UpdateMenuItem(MenuItems menuItem)
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.UpdateMenuItem(con, menuItem);
            return response;
        }

        //DELETE
        [HttpDelete]
        [Route("Menu/DeleteItem/{id}")]
        public Response DeleteMenuItem(string menuItemName) 
        {
            SqlConnection con = new SqlConnection(configuration1.GetConnectionString("productCon").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteMenuItem(con, menuItemName);
            return response;
        }

    }
}
