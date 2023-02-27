using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSWPF.Models
{
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
}
