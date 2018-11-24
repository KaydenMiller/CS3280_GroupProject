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


namespace CS3280_GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        /// <summary>
        /// this variable lets the main know if any change occured
        /// please remember to set isChanged = true; 
        /// if InsertButton, UpdateButton, DeleteButton is clicked on
        /// </summary>
        private bool isChanged = false;

		/// <summary>
		/// Business Logic container
		/// </summary>
		clsItemsLogic itemsLogic;

        public wndItems()
        {
            InitializeComponent();
			itemsLogic = new clsItemsLogic();
			ItemGrid.ItemsSource = itemsLogic.getData();
        }

        /// <summary>
        /// Main window can access isChanged bool variable 
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return isChanged;
            }
        }

		/// <summary>
		/// Either makes the data grid able to be modified, or will make visible a few text boxes. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addItemBtn_Click(object sender, RoutedEventArgs e)
		{
			isChanged = true;
		}

		/// <summary>
		/// Either makes the selected row able to be edited, or will copy the data to some text boxes to
		/// be changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void editItemBtn_Click(object sender, RoutedEventArgs e)
		{
			isChanged = true;
		}

		/// <summary>
		/// Verifies that the item isn't being used by any of the invoices, then marks it for deletion
		/// with the submit button. Raises a red error if anything goes wrong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void removeItemBtn_Click(object sender, RoutedEventArgs e)
		{
			isChanged = true;
		}

		/// <summary>
		/// Nothing in this window will be sent to the database until this button is clicked.
		/// All changes are then verified in here, then committed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void updateBtn_Click(object sender, RoutedEventArgs e)
		{
			isChanged = true;
		}
	}
}
