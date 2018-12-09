/*****************************************************************************************
 * CS3280_GroupProject/Main
 * Chukwuebuka Odu
 * 
 * This class is part of the CS3280_GroupProject. It houses the logic of main display
 ****************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Windows;

namespace CS3280_GroupProject.Main
{
    /// <summary>
    /// This class handles the Main window logic
    /// </summary>
    class clsMainLogic
    {

        /// <summary>
        /// Variable to hold dataset from query result
        /// </summary>
        DataSet queryResult;

        /// <summary>
        /// this variable holds dataset to be printed out
        /// </summary>
        DataSet invoiceResult;

        /// <summary>
        /// Creating Instance of the clsDataAccess to gain access to the database
        /// </summary>
        clsDataAccess query;

        /// <summary>
        /// Instance of the clsmainSQL query class
        /// </summary>
        clsMainSQL SQLIns;

        /// <summary>
        /// this variable will hold output of the of clsMainSQL
        /// </summary>
        private string mainQuery;

        /// <summary>
        /// Variable to hold the date
        /// </summary>
        DateTime date;

        /// <summary>
        /// this variable will be Holding the invoice Number
        /// </summary>
        private string invoiceNum;

        /// <summary>
        /// this variable will be Holding the price
        private string price;

        /// <summary>
        /// This list variable holds items to fill the combo box 
        /// </summary>
        public List<string> itemList;

        /// <summary>
        /// This list variable holds the item from an invoice
        /// </summary>
        public List<string> invoiceItem;

        /// <summary>
        /// This variable holds the total cost of the invoice
        /// </summary>
        Decimal totalCost = 0;

        /// <summary>
        /// Constructor for MainWindow logic 
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                SQLIns = new clsMainSQL();
                query = new clsDataAccess(); //creating Instance of DataAccess class
                invoiceNum = loadInvoice("");
                int iRet = 0;
                mainQuery = SQLIns.getInvoiceItems(invoiceNum); //obtains the items of an invoice
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                invoiceItem = new List<string>();
                invoiceResult = queryResult; //set the output to the dataset
                for (int i = 0; i < iRet; i++)
                {
                    invoiceItem.Add(queryResult.Tables[0].Rows[i][0].ToString() + " : " + queryResult.Tables[0].Rows[i].ItemArray[1].ToString());
                }
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
        /// This method outputs the invoice using the invoice number.
        /// </summary>
        /// <param name="invoiceNum">String invoiceNum</param>
        /// <returns></returns>
        public string loadInvoice(string invoiceNum)
        {
            try
            {
                mainQuery = SQLIns.getInvoice(invoiceNum);
                int iRet = 0;  //the rows to return

                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet); //get the invoice number and invoice date
                date = (DateTime)queryResult.Tables[0].Rows[0][1];
                invoiceNum = queryResult.Tables[0].Rows[0][0].ToString();

                iRet = 0;
                mainQuery = SQLIns.getItems(); //Gets all items 
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                itemList = new List<string>();
                for (int i = 0; i < queryResult.Tables[0].Rows.Count; i++)
                {
                    itemList.Add(queryResult.Tables[0].Rows[i][0].ToString() + " : " +
                        queryResult.Tables[0].Rows[i].ItemArray[1].ToString());
                }
                //Gets all items using the invoice number
                mainQuery = SQLIns.getInvoiceItems(invoiceNum);
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                invoiceItem = new List<string>();
                invoiceResult = queryResult; //put into dataset 
                for (int i = 0; i < queryResult.Tables[0].Rows.Count; i++)
                {
                    invoiceItem.Add(queryResult.Tables[0].Rows[i][0].ToString() + " : " +
                        queryResult.Tables[0].Rows[i].ItemArray[1].ToString()
                        + " : " + queryResult.Tables[0].Rows[i].ItemArray[2].ToString());
                    if (decimal.TryParse(queryResult.Tables[0].Rows[i].ItemArray[2].ToString(), out decimal price))
                    {
                        totalCost += price;
                    }
                }
                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method updates the total cost
        /// </summary>
        /// <returns></returns>
        public void setTotalCost(string num, string total)
        {
            try
            {
                 SQLIns.updateInvoiceTotal(num, total.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method gets the invoice number to be displayed
        /// </summary>
        /// <returns>invoiceNum</returns>
        public string getInvoiceNum()
        {
            try
            {
                return invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method sets the cost of the invoice.
        /// </summary>
        /// <param name="price">cost</param>
        public void setCost(decimal price)
        {
            try
            {
                totalCost = price;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// This method returns the cost of an item.
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>cost</returns>
        public string getCost(string item)
        {
            try
            {
                mainQuery = SQLIns.getCost(item);
                int iRet = 0;
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                price = queryResult.Tables[0].Rows[0][0].ToString(); //Get cost from DataSet
                return price;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns the totalCost
        /// </summary>
        /// <returns>totalCost</returns>
        public string getTotalCost()
        {
            try
            {
                return totalCost.ToString("#####0.00");
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method will add a new item 
        /// </summary>
        /// <param name="code">code</param>
        public void addItem(string code)
        {
            try
            {
                mainQuery = SQLIns.getSelItem(code); //get the specified item
                int iRet = 0;
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                updateTotalCost("add", queryResult.Tables[0].Rows[0][2].ToString()); 
                //Add new item
                invoiceResult.Tables[0].Rows.Add(queryResult.Tables[0].Rows[0][0].ToString(), 
                    queryResult.Tables[0].Rows[0][1].ToString(), queryResult.Tables[0].Rows[0][2].ToString());
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// TThis method will remove item 
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="desc">desc</param>
        /// <param name="itemCost">itemCost</param>
        public void removeItem(int index)
        {
            try
            {
                string itemCost = invoiceResult.Tables[0].Rows[index][2].ToString();
                updateTotalCost("sub", itemCost); //calls total update
                invoiceResult.Tables[0].Rows.RemoveAt(index); //remove that specifed item
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is used to update the total cost if an item was removed or added
        /// </summary>
        /// <param name="action">additon or subtraction</param>
        /// <param name="cost">cost</param>
        public void updateTotalCost(string action, string itemCost)
        {
            try
            {
                bool isNum = Decimal.TryParse(itemCost, out decimal price); //validate the itemcost
                if (isNum && action.Equals("add"))
                {
                    totalCost += price;
                }
                else if (isNum && action.Equals("sub"))
                {
                    totalCost -= price;
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method inserts the date into the db.
        /// </summary>
        /// <param name="date">date</param>
        public void insertDate(string date, string total)
        {
            try
            {
                mainQuery = SQLIns.putInvoiceDate(date, total); 
                int numRows = query.ExecuteNonQuery(mainQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method outputs the date
        /// </summary>
        /// <returns>date</returns>
        public DateTime getDate()
        {
            try
            {
                return date;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns the items of an invoice
        /// </summary>
        /// <returns>dsInvoice.Tables[0].DefaultView</returns>
        public DataView getData()
        {
            try
            {
                return invoiceResult.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + 
                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns the list of all items.
        /// </summary>
        /// <returns>listItems</returns>
        public List<string> getItems()
        {
            try
            {
                return itemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method is used to update the list
        /// </summary>
        /// <returns>listItems</returns>
        public void updateItemWindow()
        {
            try
            {
                int iRet = 0;
                mainQuery = SQLIns.getItems(); 
                queryResult = query.ExecuteSQLStatement(mainQuery, ref iRet);
                itemList.Clear();
                for (int i = 0; i < queryResult.Tables[0].Rows.Count; i++)
                {
                    itemList.Add(queryResult.Tables[0].Rows[i][0].ToString() + " : " + 
                        queryResult.Tables[0].Rows[i].ItemArray[1].ToString());
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is used to delete the current invoice from the database.
        /// </summary>
        /// <param name="invoice">invoice</param>
        public void deleteInvoice(string invoice)
        {
            try
            {
                mainQuery = SQLIns.deleteLineItem(invoice); //Delete line items
                int rows = query.ExecuteNonQuery(mainQuery);
                mainQuery = SQLIns.deleteInvoice(invoice); //Delete invoice
                rows = query.ExecuteNonQuery(mainQuery);
                invoiceNum = ""; 
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method will Update all changes.
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="items">items</param>
        public void updateChanges(string invoice, List<string> items)
        {
            try
            {
                mainQuery = SQLIns.deleteLineItem(invoice);
                int rows = query.ExecuteNonQuery(mainQuery);
                for (int i = 0; i < items.Capacity; i++)
                {
                    //check for out of bounds
                    if (i == items.Count)
                    {
                        break;
                    }
                    mainQuery = SQLIns.insertLineItems(invoice, (i + 1).ToString(), items.ElementAt(i));
                    rows = query.ExecuteNonQuery(mainQuery);
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// This method resets the dataset
        /// </summary>
        public void ResetCurrentInvoice()
        {
            try
            {
                int count = invoiceResult.Tables[0].Rows.Count;
                //Remove all items from the dataset
                for (int i = 0; i < count; i++)
                {
                    invoiceResult.Tables[0].Rows.RemoveAt(0); //remove that specifed item
                }
            }
            catch (Exception ex)
            {
                CheckingErrors(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// This method is for checking error for getting invoice number
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        public void setInvoiceNum(string k)
        {
            try
            {
                invoiceNum = k;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}
