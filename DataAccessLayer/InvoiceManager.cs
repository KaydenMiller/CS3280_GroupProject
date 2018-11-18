using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class InvoiceManager
    {
        private readonly static string connectionString = "";
        private readonly static AdoNetContext context = new AdoNetContext(connectionString);

        public readonly static IInvoiceRepository InvoiceRepository = new InvoiceRepository(context);
    }
}
