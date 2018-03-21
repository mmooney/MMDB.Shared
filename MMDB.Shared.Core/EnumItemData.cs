using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public class EnumItemData
	{
		private int _ID;
		private string _Name;
		private string _DisplayValue;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		public string DisplayValue
		{
			get { return _DisplayValue; }
			set { _DisplayValue = value; }
		}

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
	}
}
