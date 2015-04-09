using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDB.ListHelpers
{
	public class ListOptions
	{
		public int? PageSize { get; set; }
		public string SortField { get; set; }
		public int? PageNumber { get; set; }	//1-BASED FOOL!
		public bool? SortAscending { get; set; }

        public static ListOptions SetDefaults(ListOptions listOptions, int pageSize, int pageNumber, string sortField, bool sortAscending)
        {
            if(listOptions == null)
            {
                listOptions = new ListOptions();
            }
            listOptions.PageSize = listOptions.PageSize.GetValueOrDefault(pageSize);
            listOptions.PageNumber = listOptions.PageNumber.GetValueOrDefault(pageNumber);
            listOptions.SortField = !string.IsNullOrEmpty(listOptions.SortField) ? listOptions.SortField : sortField;
            listOptions.SortAscending = listOptions.SortAscending.GetValueOrDefault(sortAscending);
            return listOptions;
        }
    }
}
