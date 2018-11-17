using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace CS3280_GroupProject.Search.ViewModel
{
    /// <summary>
    /// This object stores the required information to be displayed
    /// onto the Search Window.
    /// </summary>
    public class SearchViewModel
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string TotalCharge { get; set; }

        public List<Invoice> MyProperty { get; set; }
    }
}
