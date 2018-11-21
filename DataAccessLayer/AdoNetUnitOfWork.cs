using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class AdoNetUnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// Action for rolling back
        /// </summary>
        private readonly Action<AdoNetUnitOfWork> _rolledBack;
        /// <summary>
        /// Action for commiting data and finishing the unit of work
        /// </summary>
        private readonly Action<AdoNetUnitOfWork> _commited;

        private OleDbTransaction _transaction;
        /// <summary>
        /// A transaction with ADO.NET
        /// </summary>
        public OleDbTransaction Transaction { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="rolledBack"></param>
        /// <param name="commited"></param>
        public AdoNetUnitOfWork(OleDbTransaction transaction, Action<AdoNetUnitOfWork> rolledBack, Action<AdoNetUnitOfWork> commited)
        {
            Transaction = transaction;
            _transaction = transaction;
            _rolledBack = rolledBack;
            _commited = commited;
        }

        /// <summary>
        /// Will attempt to complete the unit of work
        /// </summary>
        public void Complete()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("May not call complete changes twice.");
            }

            _transaction.Commit();
            _commited(this);
            _transaction = null;
        }

        /// <summary>
        /// Will close the transaction and finish any parts of the Unit of work 
        /// Used with IDisposable interface for using blocks
        /// </summary>
        public void Dispose()
        {
            if (_transaction == null)
                return;

            _transaction.Rollback();
            _transaction.Dispose();
            _rolledBack(this);
            _transaction = null;
        }
    }
}
