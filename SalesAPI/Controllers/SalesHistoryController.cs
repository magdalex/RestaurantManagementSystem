using Microsoft.AspNetCore.Mvc;
using SalesAPI.Models;
using SalesAPI.Service;

namespace SalesAPI.Controllers
{
////////////=============================================================================//////////////
    [Route("api/[controller]")]
    [ApiController]
    public class SalesHistoryController : Controller
    {
        [HttpGet]
        [Route("TotalTables/{id}")]
        public int GetNumberTables(int id)
        {
            SalesService salesService = new SalesService();
            return salesService.getTotalTablesById(id);
        }

        
        [HttpGet]
        [Route("TotalSales/{id}")]
        public decimal GetTotalSales(int id)
        {
            SalesService salesService = new SalesService();
            return salesService.getTotalSalesById(id);
        }

        
        [HttpPost]
        [Route("UpdateSalesHistory")]
        public void UpdateSalesHistory(SaleInfo sale) 
        {
            SalesService salesService = new SalesService();
            salesService.updateSalesHistoryTable(sale.InvoiceTotal, sale.WaiterId);
        }
       
    }
}
////////////=============================================================================//////////////
