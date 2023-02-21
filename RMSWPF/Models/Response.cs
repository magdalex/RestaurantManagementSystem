using System.Collections.Generic;

namespace RMSAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
        public MenuItems menuItem { get; set; }
        /*public Table1 table1 { get; set; }
        public Table2 table2 { get; set; }
        public Table3 table3 { get; set; }
        public Table4 table4 { get; set; }
        public Table5 table5 { get; set; }
        public Table6 table6 { get; set; }
        public Table7 table7 { get; set; }*/
        public List<MenuItems> listMenuItem { get; set; }
        /*public List<Table1> listTable1 { get; set; }
        public List<Table2> listTable2 { get; set; }
        public List<Table3> listTable3 { get; set; }
        public List<Table4> listTable4 { get; set; }
        public List<Table5> listTable5 { get; set; }
        public List<Table6> listTable6 { get; set; }
        public List<Table7> listTable7 { get; set; }
        public float finalPrice1 { get; set; }
        public float finalPrice2 { get; set; }
        public float finalPrice3 { get; set; }
        public float finalPrice4 { get; set; }
        public float finalPrice5 { get; set; }
        public float finalPrice6 { get; set; }
        public float finalPrice7 { get; set; }*/
    }
}
