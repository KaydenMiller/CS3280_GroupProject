﻿using System;
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

		public clsItemsLogic()
		{
			SQLIns = new clsItemsSQL();
			query = new clsDataAccess();
			int iRet = 0;
			queryResult = query.ExecuteSQLStatement(SQLIns.GetAllItems(), ref iRet);
			itemsResult = queryResult;
		}

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
	}
}
