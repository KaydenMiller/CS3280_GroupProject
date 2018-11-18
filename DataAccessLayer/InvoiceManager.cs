using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class InvoiceManager
    {
        /// <summary>
        /// The connnection string for connecting to the MS Access Database
        /// </summary>
        private readonly static string connectionString = "";

        /// <summary>
        /// The ADONetContext class for connecting to the Access database
        /// </summary>
        private readonly static AdoNetContext context = new AdoNetContext(connectionString);

        /// <summary>
        /// The repository class for accessing invoices
        /// </summary>
        public readonly static IInvoiceRepository invoiceRepository = new InvoiceRepository(context);
    }
}
