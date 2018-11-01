using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject.Search
{
    public class clsSearchSQL
    {
        public string SearchSQLTestMethod(string sInvoiceID)
        {
            string SQL = $"SELECT * FROM Invoices WHERE InvoiceNum = {sInvoiceID};";
            return SQL;
        }
    }
}
