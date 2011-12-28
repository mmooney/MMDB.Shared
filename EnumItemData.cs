/*
	Copyright © 2009 Michael J. Mooney
	All code contained herein is property of Michael J. Mooney (Developer).  
	It is being provided to the Keystone Regional Volleyball Association (Institution)
	as a non-exclusive license for the purposes of its volleyball event registration system.  
	As owner, the Developer reserves the right to reuse this code for any future projects.  
	As licensee, the Institution is granted the right to use and modify this code for exclusively 
	its volleyball event registration system.  The Insitution nor any of its members may not reuse 
	for any other purposes or redistribute this software to any other parties without the 
	expressed written permission of the Developer.
*/
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
