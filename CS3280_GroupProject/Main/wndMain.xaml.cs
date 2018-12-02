/********************************************************************************************
 * CS3280_GroupProject/Main
 * Chukwuebuka Odu
 * 
 * This program is part of the CS3280_GroupProject. It houses the logic of the main window
 *******************************************************************************************/


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
using System.Reflection;
using CS3280_GroupProject.Items;
using CS3280_GroupProject.Search;


namespace CS3280_GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// using variable to create instance of the clsMainLogic class.
        /// </summary>
        clsMainLogic clsMain;

        ///<summary>
        ///To know if date is selected
        ///</summary>
        bool dateSelect = false;

        /// <summary>
        /// This constructor initialises form and fill the grid with the hightest invoice number
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                clsMain = new clsMainLogic(); //Instance of the clsMainLogic class
                DateTime db = clsMain.getDate();
                string data = db.ToString();
                datepicker.Text = data; //Puts invoice's date into the date picker
                addItemButton.IsEnabled = false;
                removeItembutton.IsEnabled = false;
                saveBut.IsEnabled = false;
                datepicker.IsEnabled = false;
                itemsListcomboBox.IsEnabled = false;
                InvoiceNoBox.Content = clsMain.getInvoiceNum();
                currInvoiceDataGrid.ItemsSource = clsMain.getData();
                orderTotalBox.Content = "$" + clsMain.getTotalCost();
                currInvoiceDataGrid.IsReadOnly = false;
                deleteMsgLabel.Visibility = Visibility.Hidden;
                saveMsgLabel.Visibility = Visibility.Hidden;
                rememberMsgLabel.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method handles the errors
        /// </summary>
        /// <param name="sourceClass">the source class</param>
        /// <param name="sourceMethod">the source method</param>
        /// <param name="Error">the error message</param>
        private void CheckingErrors(string sourceClass, string sourceMethod, string Error)
        {
            try
            {
                MessageBox.Show(sourceClass + "." + sourceMethod + " -> " + Error);
            }
            catch (System.Exception e)
            {
                System.IO.File.AppendAllText("C:\\bug.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Method to open the item inventory window
        /// </summary>
        /// <param name="sender">Items menu item</param>
        /// <param name="e">Click</param>
        private void ItemInventory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndItems wndItems = new wndItems(); //calls wndItems form
                wndItems.ShowDialog();
                //Display the new changes if any
                if (wndItems.IsChanged)
                {
                    //Load the combo box with items
                    clsMain.updateItemWindow();
                    List<string> list = clsMain.getItems();
                    itemsListcomboBox.Items.Clear(); //empty the combo box 
                    for (int i = 0; i < list.Count; i++)
                    {
                        itemsListcomboBox.Items.Add(list.ElementAt(i));
                    }
                }
                deleteMsgLabel.Visibility = Visibility.Hidden;
                               
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method will open up the Search form to search the database for a particular invoice.
        /// </summary>
        /// <param name="sender">Search for Invoice menu item</param>
        /// <param name="e">Click</param>
        private void Btn_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                wndSearch wndSearch = new wndSearch(); //calls wndSearch form
                wndSearch.ShowDialog();
                //Display the new changes if any, .ie. if any new invoice was selected
                if (wndSearch.selected_Invoice != "")
                {
                    string isInvoice = wndSearch.selected_Invoice;
                    clsMain.setCost(0); //Reset cost 
                    clsMain.newInvoice(isInvoice);
                    clsMain.setInvoiceNum(isInvoice); //Fixes a bug I ran into
                    currInvoiceDataGrid.ItemsSource = clsMain.getData();
                    DateTime d = clsMain.getDate();
                    string data = d.ToString();
                    datepicker.Text = data; //Puts invoice's date into the date picker
                    deleteIvoiceButton.IsEnabled = true;
                    newInvoiceButton.IsEnabled = true;
                    removeItembutton.IsEnabled = false;
                    saveBut.IsEnabled = false;
                    datepicker.IsEnabled = false;
                    editButton.IsEnabled = true;
                    addItemButton.IsEnabled = false;
                    itemsListcomboBox.IsEnabled = false;
                    InvoiceNoBox.Content = clsMain.getInvoiceNum();
                    orderTotalBox.Content = "$" + clsMain.getTotalCost();
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method closes the whole form
        /// </summary>
        /// <param name="sender">Exit</param>
        /// <param name="e">Click</param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method will get the cost of the item and display it in the item cost textbox.
        /// </summary>
        /// <param name="sender">Combo box item</param>
        /// <param name="e">Selection Change</param>
        private void selectItemCombo(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string item = (string)itemsListcomboBox.SelectedValue; //Get item from combo box
                item = item.Substring(0, item.IndexOf(' ')); //Get the ItemCode
                itemCost.Content = "$" + clsMain.getCost(item);
                deleteMsgLabel.Visibility = Visibility.Hidden;
                if (dateSelect)
                {
                    rememberMsgLabel.Visibility = Visibility.Hidden;
                    saveBut.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method adds the item selected from the combo box
        /// </summary>
        /// <param name="sender">Add button</param>
        /// <param name="e">Click</param>
        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (itemsListcomboBox.SelectedItem == null)
                {
                    return; // return nothing if nothing is added
                }
                string item = (string)itemsListcomboBox.SelectedValue; //Get item 
                item = item.Substring(0, item.IndexOf(' ')); //Get the Item Code 
                currInvoiceDataGrid.ItemsSource = null;  //currInvoiceDataGrid to null
                clsMain.addItem(item);
                orderTotalBox.Content = "$" + clsMain.getTotalCost();
                currInvoiceDataGrid.ItemsSource = clsMain.getData(); // currInvoiceDataGrid having the new item
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method removes the item selected from the combo box
        /// </summary>
        /// <param name="sender">Remove Item</param>
        /// <param name="e">Click</param>
        private void removeItembutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currInvoiceDataGrid.SelectedItem == null)
                {
                    return;
                }
                object item = currInvoiceDataGrid.SelectedItem;

                //initialising string variables to item selected
                string Code = (currInvoiceDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string Desc = (currInvoiceDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string Cost = (currInvoiceDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                var selectedItem = currInvoiceDataGrid.SelectedItem;
                int index = currInvoiceDataGrid.SelectedIndex;
                currInvoiceDataGrid.ItemsSource = null; //Need to redo the list
                clsMain.removeItem(index);
                orderTotalBox.Content = "$" + clsMain.getTotalCost();
                itemsListcomboBox.SelectedValue = "";
                itemCost.Content = "";
                currInvoiceDataGrid.ItemsSource = clsMain.getData();
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        ///This method saves the new created invoice
        /// </summary>
        /// <param name="sender">Save button</param>
        /// <param name="e">Click</param>
        private void saveBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //make sure the input boxes has values
                DateTime date = new DateTime();
                if (datepicker.Text != "" && currInvoiceDataGrid.HasItems)
                {
                    date = datepicker.SelectedDate.Value; // holds the selected date
                    string data = date.ToString();

                    //populate the grid
                    if (InvoiceNoBox.Content.ToString() == "TBD")
                    {
                        clsMain.insertDate(data);
                        string newInvoice = clsMain.newInvoice("");
                        clsMain.setInvoiceNum(newInvoice);
                        InvoiceNoBox.Content = clsMain.getInvoiceNum();
                    }
                    List<string> items = new List<string>();
                    for (int i = 0; i < currInvoiceDataGrid.Items.Count; i++)
                    {
                        //Gets the code from the selected item
                        currInvoiceDataGrid.SelectedItem = currInvoiceDataGrid.Items.GetItemAt(i);
                        object item = currInvoiceDataGrid.SelectedItem;

                        //initialising string variable to item selected
                        string Code = (currInvoiceDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        items.Add(Code);

                    }
                    clsMain.updateChanges(InvoiceNoBox.Content.ToString(), items);

                    itemsListcomboBox.IsEnabled = false;
                    datepicker.IsEnabled = false;
                    removeItembutton.IsEnabled = false;
                    saveBut.IsEnabled = false;
                    addItemButton.IsEnabled = false;
                    newInvoiceButton.IsEnabled = true;
                    editButton.IsEnabled = true;
                    saveMsgLabel.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method allows the creation of new invoices
        /// </summary>
        /// <param name="sender">New button</param>
        /// <param name="e">Click</param>
        private void newInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //clear the grid, date, invi=oice number, and disable and enable some buttons
                currInvoiceDataGrid.ItemsSource = null;
                currInvoiceDataGrid.Items.Clear();
                InvoiceNoBox.Content = "TBD";
                clsMain.setCost(0);
                orderTotalBox.Content = "$" + clsMain.getTotalCost();
                datepicker.Text = "";
                addItemButton.IsEnabled = true;
                removeItembutton.IsEnabled = true;
                saveBut.IsEnabled = false;
                newInvoiceButton.IsEnabled = false;
                deleteIvoiceButton.IsEnabled = false;
                editButton.IsEnabled = false;
                datepicker.IsEnabled = true;
                itemsListcomboBox.IsEnabled = true;
                deleteMsgLabel.Visibility = Visibility.Hidden;
                saveMsgLabel.Visibility = Visibility.Hidden;
                rememberMsgLabel.Visibility = Visibility.Visible;

                //populate the combo box with items 
                List<string> list = clsMain.getItems();
                for (int i = 0; i < list.Count; i++)
                {
                    itemsListcomboBox.Items.Add(list.ElementAt(i));
                }
                clsMain.ResetCurrentInvoice();
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method allows the editing of Invoice been displayed    
        /// </summary>
        /// <param name="sender">Edit Invoice button</param>
        /// <param name="e">Click</param>
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                datepicker.IsEnabled = true;
                itemsListcomboBox.IsEnabled = true;
                addItemButton.IsEnabled = true;
                saveBut.IsEnabled = true;
                removeItembutton.IsEnabled = true;
                newInvoiceButton.IsEnabled = false;
                editButton.IsEnabled = false;
                deleteMsgLabel.Visibility = Visibility.Hidden;
                saveMsgLabel.Visibility = Visibility.Hidden;

                //populate the combo box with items 
                List<string> list = clsMain.getItems();
                for (int i = 0; i < list.Count; i++)
                {
                    itemsListcomboBox.Items.Add(list.ElementAt(i));
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method deletes the active invoice, i.e. the displayed invoice
        /// it asks the the user if they really want to delete the invoice before taking any action
        /// </summary>
        /// <param name="sender">Delete Invoice button</param>
        /// <param name="e">Click</param>
        private void deleteIvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ingore the button if no invoice was selected
                if (InvoiceNoBox.Content.ToString() == "")
                {
                     return;
                }

                //Display MessageBox to verify choice
                MessageBoxResult isDelete = MessageBox.Show("You will not be able to undo deleted invoice. " +
                    "Are you sure you want to delete invoice?", "Delete Invoice",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (isDelete == MessageBoxResult.Yes)
                {
                    string invoice = InvoiceNoBox.Content.ToString();

                    // Clear out all records in the invoice
                    clsMain.deleteInvoice(invoice);
                    InvoiceNoBox.Content = "";
                    datepicker.Text = "";
                    orderTotalBox.Content = "";
                    itemCost.Content = "";
                    itemsListcomboBox.Items.Clear();
                    currInvoiceDataGrid.ItemsSource = null;
                    itemsListcomboBox.IsEnabled = false;
                    editButton.IsEnabled = false;
                    deleteIvoiceButton.IsEnabled = false;
                    newInvoiceButton.IsEnabled = true;
                    deleteMsgLabel.Visibility = Visibility.Visible;
                    saveMsgLabel.Visibility = Visibility.Hidden;
                    rememberMsgLabel.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
