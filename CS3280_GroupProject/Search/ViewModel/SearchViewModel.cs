using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLayer;


namespace CS3280_GroupProject.Search.ViewModel
{
    /// <summary>
    /// This object stores the required information to be displayed
    /// onto the Search Window.
    /// </summary>
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            //Invoices = InvoiceManager.InvoiceRepository.GetAll().ToList();
        }

        private List<Invoice> _invoices;
        public List<Invoice> Invoices
        {
            get { return _invoices; }
            set
            {
                SetProperty(ref _invoices, value);
            }
        }

        private List<Invoice> _filteredInvoices;
        public List<Invoice> FilteredInvoices
        {
            get { return _filteredInvoices; }
            set
            {
                SetProperty(ref _filteredInvoices, value);
            }
        }
    }
}
