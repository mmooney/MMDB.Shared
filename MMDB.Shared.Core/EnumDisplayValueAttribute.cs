using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MMDB.Shared
{
	public class EnumDisplayValueAttribute : Attribute
	{
		public string DisplayValue { get; private set;}
		
		public EnumDisplayValueAttribute(string displayValue)
		{
			this.DisplayValue = displayValue;
		}

		internal static string GetDisplayValue(object value)
		{
			if(value == null)
			{
				return null;
			}
			string returnValue = value.ToString();
			Type enumType = value.GetType();
			if(!enumType.IsEnum)
			{
				throw new Exception(string.Format("Unable to load enum display value, value is not an enum: \"{0}\"",value));
			}
			
			FieldInfo field = enumType.GetField(value.ToString());
			if(field == null)
			{
				throw new Exception(string.Format("Unable to load enum display value, could not find field \"{0}\" in type \"{1}\"",value.ToString(),enumType.Name));
			}
			EnumDisplayValueAttribute[] attributeList = (EnumDisplayValueAttribute[])field.GetCustomAttributes(typeof(EnumDisplayValueAttribute),false);
			if(attributeList != null && attributeList.Length > 0)
			{
				returnValue = attributeList[0].DisplayValue;
			}
			return returnValue;
		}
	}
}
