using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    class LineItemRepository : Repository<LineItem>, IRepository<LineItem>, ILineItemRepository
    {
        public LineItemRepository(AdoNetContext context) : base(context)
        {
        }

        public void Add(LineItem item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LineItem> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineItem> Find(Expression<Func<LineItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LineItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineItem> GetLineItemsByItemCode(string ItemCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineItem> GetLineItemsByLineNumber(int line)
        {
            throw new NotImplementedException();
        }

        public void Remove(LineItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LineItem> items)
        {
            throw new NotImplementedException();
        }

        protected override void Map(IDataRecord record, LineItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
