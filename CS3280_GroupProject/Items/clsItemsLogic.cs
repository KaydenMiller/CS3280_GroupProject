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
    class clsItemsLogic
    {
		/// <summary>
		/// Variable to hold dataset from query result
		/// </summary>
		DataSet queryResult;

		/// <summary>
		/// Creating Instance of the clsDataAccess to gain access to the database
		/// </summary>
		clsDataAccess query;

		/// <summary>
		/// Instance of the clsItemsSQL query class
		/// </summary>
		clsItemsSQL SQLIns;

		/// <summary>
		/// This list variable holds items to fill the combo box 
		/// </summary>
		public List<Item> itemList;

		public clsItemsLogic()
		{
			SQLIns = new clsItemsSQL();
			query = new clsDataAccess();

		}
	}
}
