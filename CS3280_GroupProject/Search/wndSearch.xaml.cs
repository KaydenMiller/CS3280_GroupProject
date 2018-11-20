using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public wndSearch()
        {
            DataContext = new ViewModel.SearchViewModel();
            InitializeComponent();
        }

        /// <summary>
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

        }
    }
}
