using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
    [Serializable]
	public class EnumCastException : Exception
	{
		public EnumCastException(string value, Type enumType) : base(FormatMessage(value, enumType))
		{
		}

		public EnumCastException(int value, Type enumType) : base(FormatMessage(value, enumType))
		{
		}

		private static string FormatMessage(int value, Type enumType)
		{
			return string.Format("Unable to cast int value \"{0}\" to enum type \"{1}\"", value, enumType);
		}

		private static string FormatMessage(string value, Type enumType)
		{
			return string.Format("Unable to cast string value \"{0}\" to enum type \"{1}\"", value, enumType);
		}
	}
}
