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

        public Invoice SearchByID(int InvoiceID)
        {
            return InvoiceManager.InvoiceRepository.Get(InvoiceID);
        }

        public IEnumerable<Invoice> SearchByDate(DateTime date)
        {
            return InvoiceManager.InvoiceRepository.GetInvoicesByDate(date);
        }

        public IEnumerable<Invoice> SearchByCharge(int charge)
        {
            return InvoiceManager.InvoiceRepository.GetInvoicesByTotalCost(charge);
        }

        public IEnumerable<Invoice> SearchCombined(Expression<Func<Invoice, bool>> predicate)
        {
            return void;
        }
    }
}
