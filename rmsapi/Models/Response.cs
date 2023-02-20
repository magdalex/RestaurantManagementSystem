namespace RMSAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public MenuItems menuItem { get; set; }
        public List<MenuItems> listMenuItem { get; set; }
    }
}
