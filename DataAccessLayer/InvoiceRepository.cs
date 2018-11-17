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
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCost) VALUES({item.ID}, {item.Date}, {item.TotalCost})";
                command.ExecuteNonQuery();
            }
        }

        public void AddRange(IEnumerable<Invoice> items)
        {
            foreach (Invoice item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCost) VALUES({item.ID}, {item.Date}, {item.TotalCost})";
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Invoice> Find(Expression<Func<Invoice, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Invoice Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE InvoiceNum = {id}";
                return ToList(command).First();
            }
        }

        public IEnumerable<Invoice> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Invoices";
                return ToList(command);
            }
        }

        public IEnumerable<Invoice> GetInvoicesByDate(DateTime dateTime)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE InvoiceDate = {dateTime}";
                return ToList(command);
            }
        }

        public IEnumerable<Invoice> GetInvoicesByTotalCost(int charge)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE TotalCost = {charge}";
                return ToList(command);
            }
        }

        public void Remove(Invoice item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"DELETE FROM Invoices WHERE InvoiceNum = {item.ID}";
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRange(IEnumerable<Invoice> items)
        {
            foreach (Invoice item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM Invoices WHERE InvoiceNum = {item.ID}";
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void Map(IDataRecord record, Invoice entity)
        {
            entity.ID = (int)record["InvoiceNum"];
            entity.Date = (DateTime)record["InvoiceDate"];
            entity.TotalCost = (int)record["TotalCost"];
        }
    }
}
