using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_GroupProject.Items
{
	/// <summary>
	/// All the SQL statements to get the data for the items.
	/// </summary>
    public class clsItemsSQL
    {
		/// <summary>
		/// Gets all the items
		/// </summary>
		/// <returns></returns>
		public string GetAllItems()
		{
			return "SELECT ItemCode, ItemDesc, Cost " + 
						"FROM ItemDesc";
		}

		/// <summary>
		/// Returns all the item codes currently existing.
		/// </summary>
		/// <returns></returns>
		public string GetItemCodes()
		{
			return "SELECT ItemCode " + 
						"FROM ItemDesc";
		}

		/// <summary>
		/// Uses the item code to get invoices with the item code.
		/// </summary>
		/// <param name="itemCode"></param>
		/// <returns></returns>
		public string GetInvoicesFromItemCode(string itemCode)
		{
			return "SELECT InvoiceNum " + 
						"FROM LineItems " + 
						"WHERE(ItemCode = " + itemCode + ")";
		}

		/// <summary>
		/// Add's the item to the db
		/// (Not functional)
		/// </summary>
		/// <param name="itemCode">4 length string character</param>
		/// <param name="description">string</param>
		/// <param name="cost">integer cost.</param>
		/// <returns></returns>
		public string AddItem(string itemCode, string description, int cost)
		{
			return "INSERT INTO ItemDesc " + 
						 "(ItemCode, ItemDesc, Cost) " + 
						"VALUES (" + itemCode + ", " + description + ", CCur(CLng("+ cost.ToString() + ")))";
		}
    }
}