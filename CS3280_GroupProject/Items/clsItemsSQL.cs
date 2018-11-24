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
		public string GetAllItems()
		{
			return "SELECT ItemCode, ItemDesc, Cost " + 
						"FROM ItemDesc";
		}
    }
}