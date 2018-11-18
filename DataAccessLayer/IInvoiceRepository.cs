using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    /// <summary>
    /// Interface to represent an invoice repository
    /// </summary>
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        /// <summary>
        /// Provides the contract to Get Invoices by the DateTime object
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>All invoices with the same date</returns>
        IEnumerable<Invoice> GetInvoicesByDate(DateTime dateTime);

        /// <summary>
        /// Provides the contract to get invoices by the total cost (charge)
        /// </summary>
        /// <param name="charge"></param>
        /// <returns>The invoices with the same total cost</returns>
        IEnumerable<Invoice> GetInvoicesByTotalCost(int charge);
    }
}
