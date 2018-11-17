using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Interface for UnitOfWork pattern
    /// </summary>
    interface IUnitOfWork : IDisposable
    {
        void Complete();
    }
}
