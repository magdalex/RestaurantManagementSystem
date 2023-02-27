using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {



        // GET: api/login
        [HttpGet]
        public string GetAllEmployees()
        {
            EmployeeService empService = new();
            return empService.ViewAllEmployees();

        }


        // GET: api/login/5           
        [HttpGet("{employeeID}")]
        public string GetByEmployeeID(int employeeID)
        {
            EmployeeService empService = new();
            return empService.ViewAllEmployeesByID(employeeID);
        }


        

        // POST: { "EmployeeID" : 12,"Password" : "pw12" }
        [HttpPost]
        public string LOGIN(EmployeeModel employeeObject)
        {
            EmployeeService empService = new();
            return empService.LOGIN(employeeObject);  
        }




        // POST: { "EmployeeID" : 12,"Password" : "pw12" }
        [HttpPost]
        [Route("Registration")]
        public string REGISTER(EmployeeModel employeeObject)
        {
            EmployeeService empService = new();
            return empService.REGISTER(employeeObject);
        }












        // UNIMPLMENTED FUNCTIONS !!!!

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
