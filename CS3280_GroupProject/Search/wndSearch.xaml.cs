using CS3280_GroupProject.Search.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS3280_GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {

        /// <summary>
        /// this variable holds the invoice selected from the search form
        /// please don't forget to Set the string variables (selectedInvoice = ) to Selected 
        /// item when the select button is clicked on
        /// </summary>
        private string selectedInvoice = "";

        public wndSearch()
        {
            DataContext = new SearchViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// the invoice Choice get, set method
        /// </summary>
        public string selected_Invoice
        {
            get
            {
                return selectedInvoice;
            }
            set
            {
                selectedInvoice = value;
            }
        }

        ///<summary>
        /// Event handler for when the search window is finished loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// The filter button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterResults_Click(object sender, RoutedEventArgs e)
        {
            SearchViewModel viewModel = DataContext as SearchViewModel;

            viewModel.FilteredInvoices = viewModel.Invoices;

            

            if (viewModel.TotalCharge >= 0)
            {
                viewModel.FilteredInvoices = (from invoice in viewModel.FilteredInvoices
                                              where invoice.TotalCost == viewModel.TotalCharge
                                              select invoice).ToList();
            }

            if (viewModel.InvoiceId != 0)
            {
                viewModel.FilteredInvoices = (from invoice in viewModel.FilteredInvoices
                                             where invoice.ID == viewModel.InvoiceId
                                             select invoice).ToList();
            }
        }

        private static readonly Regex _regexValidateTotalCharge = new Regex("[^0-9.-]+");
        private static bool IsTotalChargeTextAllowed(string text)
        {
            return !_regexValidateTotalCharge.IsMatch(text);
        }
        private void txtTotalCharge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTotalChargeTextAllowed(e.Text);
        }
    }
}
