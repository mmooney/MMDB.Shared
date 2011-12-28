using System;

namespace MMDB.Shared
{
	[Serializable]
	public class RecordNotFoundException : Exception
	{
		public RecordNotFoundException(Type recordType, int recordID) : base(FormatMessage(recordType,recordID))
		{			
		}
		
		public RecordNotFoundException(Type recordType, string fieldName, object fieldValue) : base(FormatMessage(recordType,fieldName,fieldValue))
		{
		}

		private static string FormatMessage(Type recordType, string fieldName, object fieldValue)
		{
			string valueString;
			if(fieldValue == null)
			{
				valueString = "<NULL>";
			}
			else
			{
				valueString = Convert.ToString(fieldValue);
			}
			return string.Format("Unable to load {0} record where field {1} equals \"{2}\"",recordType.Name,fieldName,valueString);
		}
		
		private static string FormatMessage(Type recordType, int recordID)
		{
			return string.Format("Unable to load {0} record for ID {1}, record not found",recordType.Name,recordID);
		}
	}
}
