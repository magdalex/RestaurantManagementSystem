namespace SalesAPI.Models
{////////////=============================================================================//////////////
    public class SaleInfo
    {
        public float InvoiceTotal { get; set; }
        public int WaiterId { get; set; }

        public SaleInfo(float invoiceTotal, int waiterId)
        {
            InvoiceTotal = invoiceTotal;
            WaiterId = waiterId;
        }
    }
}////////////=============================================================================//////////////
