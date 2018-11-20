﻿/*******************************************************************************************
 * CS3280_GroupProject/Main
 * Chukwuebuka Odu
 * 
 * This class is part of the CS3280_GroupProject. It houses the SQL logic of main display
 ******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CS3280_GroupProject.Main
{
    /// <summary>
    /// This class handles the SQL query for the Main window logic
    /// </summary>
    public class clsMainSQL
    {

        /// <summary>
        /// This methods for returing the cost of an item.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns>String sql</returns>
        public String getCost(String ItemCode)
        {
            try
            {
                return "SELECT Cost " +
                        "FROM ItemDesc " +
                        "WHERE ItemCode = \"" + ItemCode + "\""; 
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns data using itemCode
        /// </summary>
        /// <param name="itemCode">itemCode</param>
        /// <returns>String sql</returns>
        public String getSelItem(String itemCode)
        {
            try
            {
                return "SELECT * " +
                        "FROM ItemDesc " +
                        "WHERE ItemCode = \"" + itemCode + "\"";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method returns all desc and item code from the ItemDesc table.
        /// </summary>
        /// <returns>String sql</returns>
        public String getItems()
        {
            try
            {
                return "SELECT ItemCode, ItemDesc " +
                        "FROM ItemDesc " +
                        "ORDER BY ItemCode";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This sql method outputs new invoice date to the Invoice table.
        /// </summary>
        /// <param name="date">String date</param>
        /// <returns>String sql</returns>
        public String putInvoiceDate(String date)
        {
            try
            {
                return "INSERT INTO Invoices (InvoiceDate) " +
                        "VALUES (\"" + date.ToString() + "\")";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This sql method gets the invoice from the invoices table
        /// </summary>
        /// <returns>String sql</returns>
        public String getInvoice(String invoiceNum)
        {
            try
            {               
                if (invoiceNum == "") // select the max if nothing is specified
                {
                    return "SELECT InvoiceNum, InvoiceDate " +
                        "FROM Invoices " +
                        "WHERE InvoiceNum = " +
                        "(SELECT MAX(InvoiceNum) FROM Invoices)";
                }
                //Else get a particular invoice
                return "SELECT InvoiceNum, InvoiceDate " +
                        "FROM Invoices " +
                        "WHERE InvoiceNum = " + invoiceNum.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This sql method for inserting into the LineItems table.
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        /// <param name="lineItemNum">lineItemNum</param>
        /// <param name="itemCode">itemCode</param>
        /// <returns>String sql</returns>
        public String insertLineItems(String invoiceNum, String lineItemNum, String itemCode)
        {
            try
            {
                return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                        "VALUES (" + invoiceNum + ", " + lineItemNum + ", \"" + itemCode + "\")";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method gets all the items using specified invoiceNum.
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        /// <returns>String sql</returns>
        public String getInvoiceItems(String invoiceNum)
        {
            try
            {
                return "SELECT ITEMDESC.ItemCode, ITEMDESC.ItemDesc, ITEMDESC.Cost " +
                        "FROM ITEMDESC, LINEITEMS " +
                        "WHERE ITEMDESC.ItemCode = LINEITEMS.ItemCode " +
                            "AND LINEITEMS.InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method is used to update the date of an invoice using the invoice number and date on record
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        /// <param name="date">date</param>
        /// <returns>String sql</returns>
        public String updateInvoiceDate(String invoiceNum, String date)
        {
            try
            {
                return "UPDATE INVOICES " +
                        "SET InvoiceDate = \"" + date.ToString() + "\" " +
                        "WHERE invoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method delete the items from the lineitem table.
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        /// <returns>String sql</returns>
        public String deleteLineItem(String invoiceNum)
        {
            try
            {
                return "DELETE FROM LINEITEMS " +
                        "WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// This method deletes an invoice from Invoice table.
        /// </summary>
        /// <param name="invoiceNum">invoiceNum</param>
        /// <returns>String sql</returns>
        public String deleteInvoice(String invoiceNum)
        {
            try
            {
                return "DELETE FROM INVOICES " +
                        "WHERE InvoiceNum = " + invoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

    }
}