using System;

namespace MMDB.Shared
{
	[Serializable]
	public class UnknownEnumValueException : Exception
	{
		public UnknownEnumValueException(Enum enumValue) : base(FormatMessage(enumValue))
		{
		}

		private static string FormatMessage(Enum enumValue)
		{
			return string.Format("An unrecognized value \"{0}\" was found for enum type \"{1}\"",enumValue,enumValue.GetType().Name);
		}
	}
}
