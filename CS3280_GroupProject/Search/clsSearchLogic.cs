using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLayer;
using System.Linq.Expressions;

namespace CS3280_GroupProject.Search
{
    class clsSearchLogic
    {
        public clsSearchLogic()
        {
            
        }

        /// <summary>
        /// Searches for an invoices with a specific invoiceID
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <returns></returns>
        public Invoice SearchByID(int InvoiceID)
        {
            return InvoiceManager.InvoiceRepository.Get(InvoiceID);
        }

        /// <summary>
        /// Searches for all invoices that matcha set date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> SearchByDate(DateTime date)
        {
            return InvoiceManager.InvoiceRepository.GetInvoicesByDate(date);
        }

        /// <summary>
        /// Searches for all invoices that match a total cost
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> SearchByCharge(int charge)
        {
            return InvoiceManager.InvoiceRepository.GetInvoicesByTotalCost(charge);
        }

        /// <summary>
        /// Search for an invoice based on a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>All invoices that match the predicates expression</returns>
        public IEnumerable<Invoice> SearchOnPredicate(Expression<Func<Invoice, bool>> predicate)
        {
            List<Invoice> filteredInvoices = new List<Invoice>();

            foreach (Invoice invoice in InvoiceManager.InvoiceRepository.GetAll().ToList())
            {
                if (predicate.Compile().Invoke(invoice))
                {
                    filteredInvoices.Add(invoice);
                }
            }

            return filteredInvoices;
        }
    }
}
