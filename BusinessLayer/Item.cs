using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// An item that can be added to an invoice
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The itme code that acts as the primary key for this item
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// The item description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The cost of this item
        /// </summary>
        public float Cost { get; set; }
    }
}
