using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CS3280_GroupProject.Main;
using BusinessLayer;

namespace CS3280_GroupProject.Items
{
	/// <summary>
	/// Business logic for the Items window.
	/// </summary>
    class clsItemsLogic
    {
		/// <summary>
		/// Variable to hold dataset from query result
		/// </summary>
		DataSet queryResult;

		/// <summary>
		/// Variable holding dataset to be printed.
		/// </summary>
		DataSet itemsResult;

		/// <summary>
		/// Creating Instance of the clsDataAccess to gain access to the database
		/// </summary>
		clsDataAccess query;

		/// <summary>
		/// Instance of the clsItemsSQL query class
		/// </summary>
		clsItemsSQL SQLIns;

		/// <summary>
		/// Gets the initial query and sql files.
		/// </summary>
		public clsItemsLogic()
		{
			SQLIns = new clsItemsSQL();
			query = new clsDataAccess();
			int iRet = 0;
			queryResult = query.ExecuteSQLStatement(SQLIns.GetAllItems(), ref iRet);
			itemsResult = queryResult;
		}

		/// <summary>
		/// Gets all the items from the database.
		/// </summary>
		/// <returns>DataView of the table.</returns>
		public DataView getData()
		{
			try
			{
				return itemsResult.Tables[0].DefaultView;
			}
			catch (Exception ex)
			{
				throw new Exception("Something went wrong with getting a view for clsItemsLogic.getData()");
			}
		}

		/// <summary>
		/// Verifies user input for itemCode.
		/// Checks if it's already used, and if there are invoices with this item code (TODO: Split into different method)
		/// </summary>
		/// <param name="itemCode">4 lengthstring of the code to check.</param>
		/// <returns></returns>
		public bool itemCodeVerification(string itemCode)
		{
			//TODO: Check string length.
			int iRet = 0;
			queryResult = query.ExecuteSQLStatement(SQLIns.GetItemCodes(), ref iRet);

			foreach (DataRow row in queryResult.Tables[0].Rows)
			{
				if (row[0].ToString() == itemCode)
				{
					throw new DataException("Cannot use an item code that already exists.");
				}
			}

			/*queryResult = query.ExecuteSQLStatement(SQLIns.GetInvoicesFromItemCode(itemCode), ref iRet);

			foreach (DataRow row in queryResult.Tables[0].Rows)
			{
				if (row != null)
				{
					throw new Exception("Item Code in use. Cannot delete item code being used.");
				}
			}
			*/
			return true;
		}

		/// <summary>
		/// Will check if the item isn't being used anywhere.
		/// </summary>
		/// <param name="itemCode">Item to check</param>
		/// <returns>true if not being used. False otherwise.</returns>
		public bool CanDeleteItem(string itemCode)
		{
			return true;
		}

		/// <summary>
		/// Add's the item to the database. (Broken)
		/// </summary>
		/// <param name="itemCode"></param>
		/// <param name="description"></param>
		/// <param name="cost"></param>
		public void AddItem(string itemCode, string description, int cost)
		{
			int iRet = 0;


			//query.ExecuteNonQuery(SQLIns.AddItem(itemCode, description, cost));
		}
	}
}
