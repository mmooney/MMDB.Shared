using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public static class NameHelper
	{
		public static string GetFullName(string firstName, string lastName)
		{
			string returnValue;
			if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
			{
				returnValue = string.Format("{0} {1}", firstName, lastName);
			}
			else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
			{
				returnValue = lastName;
			}
			else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
			{
				returnValue = firstName;
			}
			else
			{
				returnValue = "";
			}
			return returnValue;
		}
	}
}
