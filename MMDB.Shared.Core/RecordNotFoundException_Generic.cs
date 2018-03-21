using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
    [Serializable]
    public class RecordNotFoundException<T> : Exception
    {
		public RecordNotFoundException(object recordID) : base(FormatMessage<T>(recordID))
		{			
		}
		
		public RecordNotFoundException(string fieldName, object fieldValue) : base(FormatMessage<T>(fieldName,fieldValue))
		{
		}

		private static string FormatMessage<RecordType>(string fieldName, object fieldValue)
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
            return string.Format("Unable to load {0} record where field {1} equals \"{2}\"", typeof(RecordType).Name, fieldName, valueString);
		}

        private static string FormatMessage<RecordType>(object recordID)
		{
            return string.Format("Unable to load {0} record for ID {1}, record not found", typeof(RecordType).Name, recordID);
		}
    }
}
