using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AdoNetContext context) : base(context)
        {

        }

        public void Add(Invoice item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Invoice> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> Find(Expression<Func<Invoice, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Invoice Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetInvoicesByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetInvoicesByTotalCost(int charge)
        {
            throw new NotImplementedException();
        }

        public void Remove(Invoice item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Invoice> items)
        {
            throw new NotImplementedException();
        }

        protected override void Map(IDataRecord record, Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
