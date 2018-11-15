using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// This is all information that will represent an Invoice Record in
    /// the Database.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// The id value of the invoice that represents the primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The date that the invoice was created
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The summation of the cost of all line items on the invoice
        /// </summary>
        public int TotalCost { get; set; }
    }
}
