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
using System.Data;


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

		/// <summary>
		/// The string to display if the item code is used for an item.
		/// </summary>
		const string ITEMCODEUSED_ERROR = "Item code is already used. Please pick another one.";

		/// <summary>
		/// The string to display if the item code is used for an invoice.
		/// </summary>
		const string ITEMCODEINUSE_ERROR = "Item code is being used in invoices. Please pick another one.";

		/// <summary>
		/// The string to display if the price isn't an integer.
		/// </summary>
		const string ITEMCOST_ERROR = "Item MUST be a plain integer.";

		/// <summary>
		/// Makes the logic, then get's the data to put into the data grid.
		/// </summary>
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
			toggleInputVisibility(true);
			resetInput();
			ItemGrid.SelectedItem = null;
			ItemCodeInput.IsEnabled = true;
			ItemDescriptionInput.IsEnabled = true;
			ItemCostInput.IsEnabled = true;
		}

		/// <summary>
		/// Either makes the selected row able to be edited, or will copy the data to some text boxes to
		/// be changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void editItemBtn_Click(object sender, RoutedEventArgs e)
		{
			ItemCodeInput.IsEnabled = false;
			string update = ItemDescriptionInput.Text;
			ItemDescriptionInput.Text += "p";
			ItemDescriptionInput.Text = update;
		}

		/// <summary>
		/// Verifies that the item isn't being used by any of the invoices, then marks it for deletion
		/// with the submit button. Raises a red error if anything goes wrong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void removeItemBtn_Click(object sender, RoutedEventArgs e)
		{
			ItemCodeInput.IsEnabled = false;
			ItemDescriptionInput.IsEnabled = false;
			ItemCostInput.IsEnabled = false;
		}

		/// <summary>
		/// Nothing in this window will be sent to the database until this button is clicked.
		/// All changes are then verified in here, then committed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void updateBtn_Click(object sender, RoutedEventArgs e)
		{
			int result;
			if (!Int32.TryParse(ItemCostInput.Text, out result))
			{
				ErrorLabel.Content = ITEMCOST_ERROR;
				ErrorLabel.Visibility = Visibility.Visible;
			}
			else if (ItemCodeInput.IsEnabled == true)
			{
				itemsLogic.AddItem(ItemCodeInput.Text, ItemDescriptionInput.Text, result);
				isChanged = true;
				resetInput();
				ItemGrid.ItemsSource = itemsLogic.getData();
			}
			else
			{

			}
		}

		/// <summary>
		/// Changes the visibility of all the inputs for adding and editing an item.
		/// </summary>
		/// <param name="visible">Boolean true for visible, false for invisible.</param>
		private void toggleInputVisibility(bool visible)
		{
			ItemCodeLabel.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
			ItemCodeInput.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
			ItemDescriptionLabel.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
			ItemDescriptionInput.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
			ItemCostLabel.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
			ItemCostInput.Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
		}
		
		/// <summary>
		/// Resets the input boxes and the flags.
		/// </summary>
		private void resetInput()
		{
			ItemCodeInput.Text = "";
			ItemDescriptionInput.Text = "";
			ItemCostInput.Text = "";
			ErrorLabel.Visibility = Visibility.Hidden;
			updateBtn.IsEnabled = false;
		}

		/// <summary>
		/// Fills in the 3 text input fields to what the selection is.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGrid grid = sender as DataGrid;
			toggleInputVisibility(true);
			resetInput();
			object row = grid.SelectedItem;

			if (grid.SelectedItem != null)
			{
				ItemCodeInput.Text = (grid.SelectedCells[0].Column.GetCellContent(row) as TextBlock).Text;
				ItemDescriptionInput.Text = (grid.SelectedCells[1].Column.GetCellContent(row) as TextBlock).Text;
				ItemCostInput.Text = (grid.SelectedCells[2].Column.GetCellContent(row) as TextBlock).Text;
			}

			editItemBtn.IsEnabled = true;
			removeItemBtn.IsEnabled = true;
			ErrorLabel.Visibility = Visibility.Hidden;
		}

		/// <summary>
		/// Verifies the input, then using that either lets the update button be pressed or show an error code.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InputVerification(object sender, TextChangedEventArgs e)
		{
			ErrorLabel.Visibility = Visibility.Hidden;
			bool validCode = false;
			bool validCost = false;
			if (ItemGrid.SelectedItem != null)
			{
				if (ItemCodeInput.Text == (ItemGrid.SelectedCells[0].Column.GetCellContent(ItemGrid.SelectedItem) as TextBlock).Text && ItemCodeInput.IsEnabled == false)
				{
					validCode = true;
				}
			}
			else
			{
				try
				{
					itemsLogic.itemCodeVerification(ItemCodeInput.Text);
					validCode = true;
				}
				catch (DataException ex)
				{
					ErrorLabel.Content = ITEMCODEUSED_ERROR;
					ErrorLabel.Visibility = Visibility.Visible;
				}
				//FIXME: Item verification
				/*catch (Exception ex2)
				{
					ErrorLabel.Content = ITEMCODEINUSE_ERROR;
					ErrorLabel.Visibility = Visibility.Visible;
					//TODO: Show invoices item is used in.
				}*/
			}

			if (!Int32.TryParse(ItemCostInput.Text, out int value))
			{
				ErrorLabel.Content = ITEMCOST_ERROR;
				ErrorLabel.Visibility = Visibility.Visible;
			}
			else { validCost = true; }

			if (validCode && validCost)
			{
				updateBtn.IsEnabled = true;
			}
		}

		//TODO: Make an error handling method.
	}
}
