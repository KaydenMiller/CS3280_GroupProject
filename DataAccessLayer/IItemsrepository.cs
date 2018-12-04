using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    /// <summary>
    /// Interface to represent the contract for specialized Items Repository Methods
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Will retrieve any item with the EXACT description entered.
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        IEnumerable<Item> GetItemByDescription(string desc);

        /// <summary>
        /// Will retrieve any item with the cost entered
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        IEnumerable<Item> GetItemByExactCost(float cost);
    }
}
