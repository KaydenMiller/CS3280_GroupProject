using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// This is a context class to help with getting data from ADO.NET and to use the Repostiory pattern
    /// It is based on information provided at the followin URL
    /// http://blog.gauffin.org/2013/01/ado-net-the-right-way/
    /// </summary>
    class AdoNetContext : IDisposable
    {
        /// <summary>
        /// The database connection interface
        /// </summary>
        private readonly IDbConnection _connection;
        /// <summary>
        /// Connection string
        /// </summary>
        private readonly string _connectionString;
        /// <summary>
        /// Read Write Lock for use with threading
        /// </summary>
        private readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
        /// <summary>
        /// The units of work that are currently being performed
        /// </summary>
        private readonly LinkedList<AdoNetUnitOfWork> _unitOfWorks = new LinkedList<AdoNetUnitOfWork>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public AdoNetContext(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new OleDbConnection(connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Will create a unit of work and add it to the list of units of work
        /// </summary>
        /// <returns></returns>
        public IUnitOfWork CreateUnitOfWork()
        {
            var transaction = _connection.BeginTransaction() as OleDbTransaction;
            var uow = new AdoNetUnitOfWork(transaction, RemoveTransaction, RemoveTransaction);

            _rwLock.EnterWriteLock();
            _unitOfWorks.AddLast(uow);
            _rwLock.ExitWriteLock();

            return uow;
        }

        /// <summary>
        /// creates a command for ado.net
        /// </summary>
        /// <returns>The command for use</returns>
        public OleDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand() as OleDbCommand;

            _rwLock.EnterReadLock();
            if (_unitOfWorks.Count > 0)
                cmd.Transaction = _unitOfWorks.First.Value.Transaction;
            _rwLock.ExitReadLock();

            return cmd;
        }

        /// <summary>
        /// Removes a transaction when it is completed
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveTransaction(AdoNetUnitOfWork obj)
        {
            _rwLock.EnterWriteLock();
            _unitOfWorks.Remove(obj);
            _rwLock.ExitWriteLock();
        }

        /// <summary>
        /// closes the connection for use with IDisposable
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
