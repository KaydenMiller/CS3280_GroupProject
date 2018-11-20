using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly static string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb";

        /// <summary>
        /// The ADONetContext class for connecting to the Access database
        /// </summary>
        private readonly static AdoNetContext context = new AdoNetContext(connectionString);

        /// <summary>
        /// The repository class for accessing invoices
        /// </summary>
        public readonly static IInvoiceRepository InvoiceRepository = new InvoiceRepository(context);
    }
}
