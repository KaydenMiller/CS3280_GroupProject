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
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) VALUES({item.Invoice_ID}, {item.LineItemNumber}, {item.ItemCode})";
                command.ExecuteNonQuery();
            }
        }

        public void AddRange(IEnumerable<LineItem> items)
        {
            foreach (LineItem item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) VALUES({item.Invoice_ID}, {item.LineItemNumber}, {item.ItemCode})";
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<LineItem> Find(Expression<Func<LineItem, bool>> predicate)
        {
            List<LineItem> output = new List<LineItem>();

            foreach (LineItem lineItem in GetAll())
            {
                if (predicate.Compile().Invoke(lineItem))
                {
                    output.Add(lineItem);
                }
            }

            return output;
        }

        /// <summary>
        /// The database does not have an id field for LineItem DO NOT USE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LineItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineItem> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM LineItems";
                return ToList(command);
            }
        }

        public IEnumerable<LineItem> GetLineItemsByInvoiceID(int invoiceID)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM LineItems WHERE InvoiceNum = {invoiceID}";
                return ToList(command);
            }
        }

        public IEnumerable<LineItem> GetLineItemsByItemCode(string ItemCode)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM LineItems WHERE ItemCode = {ItemCode}";
                return ToList(command);
            }
        }

        public IEnumerable<LineItem> GetLineItemsByLineNumber(int line)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM LineItems WHERE LineItemNumber = {line}";
                return ToList(command);
            }
        }

        public void Remove(LineItem item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"DELETE FROM LineItems WHERE InvoiceNum = {item.Invoice_ID} AND ItemCode = {item.ItemCode}";
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRange(IEnumerable<LineItem> items)
        {
            foreach (LineItem item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM LineItems WHERE InvoiceNum = {item.Invoice_ID} AND ItemCode = {item.ItemCode}";
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void Map(IDataRecord record, LineItem entity)
        {
            entity.Invoice_ID = (int)record["InvoiceNum"];
            entity.ItemCode = (string)record["ItemCode"];
            entity.LineItemNumber = (int)record["LineItemNumber"];
        }
    }
}
