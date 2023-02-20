using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSWPF.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public MenuItems menuItem { get; set; }
        public List<MenuItems> listMenu { get; set; }
    }
}
