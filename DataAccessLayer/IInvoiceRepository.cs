using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        IEnumerable<Invoice> GetInvoicesByDate(DateTime dateTime);
        IEnumerable<Invoice> GetInvoicesByTotalCost(int charge);
    }
}
