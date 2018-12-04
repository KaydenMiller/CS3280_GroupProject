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
            Invoices = InvoiceManager.InvoiceRepository.GetAll().ToList();
        }

        // 4/23/2018 is a valid date to search for debuging
        private DateTime _selectedDate = DateTime.Today;
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
        public int InvoiceId
        {
            get { return _invoiceId; }
            set { SetProperty(ref _invoiceId, value); }
        }

        private float _totalCharge;
        public float TotalCharge
        {
            get { return _totalCharge; }
            set { SetProperty(ref _totalCharge, value); }
        }

        private bool _invoiceDateSelected = false;
        public bool InvoiceDateSelected
        {
            get { return _invoiceDateSelected; }
            set
            {
                SetProperty(ref _invoiceDateSelected, value);
            }
        }

        private bool _invoiceTotalChargeSelected = false;
        public bool InvoiceTotalChargeSelected
        {
            get { return _invoiceTotalChargeSelected; }
            set
            {
                SetProperty(ref _invoiceTotalChargeSelected, value);
            }
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
