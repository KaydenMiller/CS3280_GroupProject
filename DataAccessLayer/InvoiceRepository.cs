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
    /// <summary>
    /// Invoice Repository object where the acutal SQL Database access funcitons
    /// will be located
    /// </summary>
    class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AdoNetContext context) : base(context)
        {

        }

        /// <summary>
        /// Adds an invoice to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(Invoice item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"INSERT INTO Invoices (InvoiceNum, InvoiceDate, TotalCost) VALUES({item.ID}, {item.Date}, {item.TotalCost})";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Adds a range of invoices to the database
        /// </summary>
        /// <param name="items"></param>
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

        /// <summary>
        /// Not used at the moment.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> Find(Expression<Func<Invoice, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets an invoice by the invoice id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Invoice Get(int id)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE InvoiceNum = {id}";
                return ToList(command).First();
            }
        }

        /// <summary>
        /// Gets every invoice by the id
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Invoice> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Invoices";
                return ToList(command);
            }
        }

        /// <summary>
        /// Gets the invoice by the date
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> GetInvoicesByDate(DateTime dateTime)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE InvoiceDate = {dateTime}";
                return ToList(command);
            }
        }

        /// <summary>
        /// Gets the invoices by the total cost on the invoice
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        public IEnumerable<Invoice> GetInvoicesByTotalCost(int charge)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Invoices WHERE TotalCost = {charge}";
                return ToList(command);
            }
        }

        /// <summary>
        /// Removes an invoice from the database
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Invoice item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"DELETE FROM Invoices WHERE InvoiceNum = {item.ID}";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove a range of invoice from the database
        /// </summary>
        /// <param name="items"></param>
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

        /// <summary>
        /// Maps the database records to an entity
        /// </summary>
        /// <param name="record"></param>
        /// <param name="entity"></param>
        protected override void Map(IDataRecord record, Invoice entity)
        {
            entity.ID = (int)record["InvoiceNum"];
            entity.Date = (DateTime)record["InvoiceDate"];
            entity.TotalCost = (int)record["TotalCost"];
        }
    }
}
