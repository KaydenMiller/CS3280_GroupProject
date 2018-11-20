using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    /// <summary>
    /// LineItem Repository
    /// </summary>
    public interface ILineItemRepository
    {
        /// <summary>
        /// Will retrieve all line items that are part of invoiceID
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        IEnumerable<LineItem> GetLineItemsByInvoiceID(int invoiceID);

        /// <summary>
        /// Will retrieve all line items that contain the item code
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        IEnumerable<LineItem> GetLineItemsByItemCode(string ItemCode);

        /// <summary>
        /// Will retrieve all line items in this line position
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        IEnumerable<LineItem> GetLineItemsByLineNumber(int line);
    }
}
