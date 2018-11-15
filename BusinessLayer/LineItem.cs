using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// An object that links an item to an invoice and assigns its possition on the invoice
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// The ID of the accociated invoice.
        /// </summary>
        public int Invoice_ID { get; set; }

        /// <summary>
        /// The item code of the item within this line item.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// The id that represents which of the x numbers of items on an invoice that this item is.
        /// </summary>
        public int LineItemNumber { get; set; }
    }
}
