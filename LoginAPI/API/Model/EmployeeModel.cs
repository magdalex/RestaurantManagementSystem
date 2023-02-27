using Microsoft.AspNetCore.Identity;

namespace API.Model
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
    }
}
