using Microsoft.AspNetCore.Mvc;
using SalesAPI.Service;

namespace SalesAPI.Controllers
{
////////////=============================================================================//////////////
    [Route("api/[controller]")]
    [ApiController]
    public class SalesHistoryController : Controller
    {
        [HttpGet]
        [Route("TotalTables")]
        public int GetNumberTables()
        {
            SalesService salesService = new SalesService();
            return salesService.getTotalTablesById();
        }

        
        [HttpGet]
        [Route("TotalSales")]
        public int GetTotalSales()
        {
            SalesService salesService = new SalesService();
            return salesService.getTotalSalesById();
        }

        
        [HttpPost]
        [Route("UpdateSalesHistory")]
        public void UpdateSalesHistory([FromBody]double value) 
        {
            SalesService salesService = new SalesService();
            salesService.updateSalesHistoryTable(value);
        }
       
    }
}
////////////=============================================================================//////////////
