namespace RMSAPI.Models
{
    public class TableCart
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public float Price { get; set; }
        public int qtyCart { get; set; }
        public float lineTotal { get; set; }
    }
}
