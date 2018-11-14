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
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Cost { get; set; }
    }
}
