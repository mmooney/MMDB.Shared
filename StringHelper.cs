using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public static class StringHelper
	{
		/// <summary>
		/// Ensures that the string is less than the max size, doesn't explode if NULL
		/// </summary>
		public static string SafeSize(string input, int maxSize)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}
			else if (input.Length < maxSize)
			{
				return input;
			}
			else
			{
				return input.Substring(0, maxSize);
			}
		}

		/// <summary>
		/// Checks if the string is null or empty, if so returns the other value
		/// </summary>
		public static string IsNullOrEmpty(string input, params string[] otherValues)
		{
			string returnValue = input;
			if(string.IsNullOrEmpty(input))
			{
				foreach(string value in otherValues)
				{
					if(!string.IsNullOrEmpty(value))
					{
						returnValue = value;
						break;
					}
				}
			}
			return returnValue;
		}

		/// <summary>
		/// Checks if the string is null, if so returns the other value.  Does not check empty;
		/// </summary>
		public static string IsNull(string input, params string[] otherValues)
		{
			string returnValue = input;
			if (string.IsNullOrEmpty(input))
			{
				foreach (string value in otherValues)
				{
					if (!string.IsNullOrEmpty(value))
					{
						returnValue = value;
						break;
					}
				}
			}
			return returnValue;
		}
	}
}
