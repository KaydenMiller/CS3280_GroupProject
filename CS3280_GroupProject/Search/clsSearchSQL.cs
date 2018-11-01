using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject.Search
{
    public class clsSearchSQL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string SearchForDate(DateTime dateTime)
        {
            string dateOfInvoice = dateTime.ToString("MM/dd/yyyy");
            string SQL = $"SELECT * FROM Invoices WHERE InvoiceDate = {dateOfInvoice};";
            return SQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public string SearchSQLTestMethod(string invoiceID)
        {
            string SQL = $"SELECT * FROM Invoices WHERE InvoiceNum = {invoiceID};";
            return SQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalCharges"></param>
        /// <returns></returns>
        public string SearchTotalCharges(string totalCharges)
        {
            string SQL = $"SELECT * FROM Invoices WHERE TotalCharges = {totalCharges};";
            return SQL;
        }
    }
}
