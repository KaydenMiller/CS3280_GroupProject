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
        /// <summary>
        /// Ctor
        /// </summary>
        public SearchViewModel()
        {
            Invoices = InvoiceManager.InvoiceRepository.GetAll().ToList();
        }

        // 4/23/2018 is a valid date to search for debuging
        private DateTime _selectedDate = DateTime.Today;
        /// <summary>
        /// Date to filter by
        /// </summary>
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                SetProperty(ref _selectedDate, value);
            }
        }

        // 5000 is a valid id
        private int _invoiceId = 0;
        /// <summary>
        /// invoice id to filter by
        /// </summary>
        public int InvoiceId
        {
            get { return _invoiceId; }
            set { SetProperty(ref _invoiceId, value); }
        }

        private float _totalCharge;
        /// <summary>
        /// Total Charge to filter by
        /// </summary>
        public float TotalCharge
        {
            get { return _totalCharge; }
            set { SetProperty(ref _totalCharge, value); }
        }

        private bool _invoiceIdSelected = false;
        /// <summary>
        /// Bool to determine cbx
        /// </summary>
        public bool InvoiceIdSelected
        {
            get { return _invoiceIdSelected; }
            set
            {
                SetProperty(ref _invoiceIdSelected, value);
            }
        }

        private bool _invoiceDateSelected = false;
        /// <summary>
        /// Bool to determine cbx
        /// </summary>
        public bool InvoiceDateSelected
        {
            get { return _invoiceDateSelected; }
            set
            {
                SetProperty(ref _invoiceDateSelected, value);
            }
        }

        private bool _invoiceTotalChargeSelected = false;
        /// <summary>
        /// Bool to determine cbx
        /// </summary>
        public bool InvoiceTotalChargeSelected
        {
            get { return _invoiceTotalChargeSelected; }
            set
            {
                SetProperty(ref _invoiceTotalChargeSelected, value);
            }
        }


        private List<Invoice> _invoices;
        /// <summary>
        /// The list of unfiltered invoices 
        /// This may be depricated soon
        /// </summary>
        public List<Invoice> Invoices
        {
            get { return _invoices; }
            set
            {
                SetProperty(ref _invoices, value);
            }
        }

        private List<Invoice> _filteredInvoices;
        /// <summary>
        /// the list of filtered invoices
        /// </summary>
        public List<Invoice> FilteredInvoices
        {
            get { return _filteredInvoices; }
            set
            {
                SetProperty(ref _filteredInvoices, value);
            }
        }

        private Invoice _selectedInvoice;
        /// <summary>
        /// The currently selected invoice
        /// </summary>
        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                SetProperty(ref _selectedInvoice, value);
            }
        }
    }
}
