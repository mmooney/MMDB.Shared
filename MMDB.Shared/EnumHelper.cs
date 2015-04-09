using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace MMDB.Shared
{
	public static class EnumHelper
	{
		public enum EnumDropdownBindingType
		{
			Exact,
			ClearFirstRecord,
			AddEmptyFirstRecord,
			RemoveFirstRecord
		}
		
		public static void DataBind(ListControl ctrl, Type enumType)
		{
			EnumHelper.DataBind(ctrl,enumType,EnumDropdownBindingType.Exact, string.Empty);
		}
		
		public static void DataBind(ListControl ctrl, Type enumType, EnumDropdownBindingType dropdownBindingType)
		{
			EnumHelper.DataBind(ctrl,enumType, dropdownBindingType, string.Empty);
		}

		public static void DataBind(ListControl ctrl, Type enumType, EnumDropdownBindingType dropdownBindingType, string firstRecordText)
		{
			List<EnumItemData> itemList = GetEnumData(enumType).Values.ToList();
			switch(dropdownBindingType)
			{
				case EnumDropdownBindingType.Exact:
					//Do nothing
					break;
				case EnumDropdownBindingType.ClearFirstRecord:
					itemList[0].DisplayValue = firstRecordText;
					break;
				case EnumDropdownBindingType.AddEmptyFirstRecord:
					int firstValue = -1;
					EnumItemData item = new EnumItemData()
					{
						ID = firstValue,
						DisplayValue = firstRecordText,
						Name = null
					};
					itemList.Insert(0,item);
					break;
				case EnumDropdownBindingType.RemoveFirstRecord:
					itemList.RemoveAt(0);
					break;
			}
			ctrl.DataTextField = "DisplayValue";
			ctrl.DataValueField = "ID";
			ctrl.DataSource = itemList;
			ctrl.DataBind();
		}

		public static string GetNullableDisplayValue(object enumValue)
		{
			string returnValue;
			if(enumValue == null)
			{
				returnValue = null;
			}
			else 
			{
				returnValue = EnumHelper.GetDisplayValue(enumValue);
			}
			return returnValue;
		}
		
		public static string GetDisplayValue(object enumValue)
		{
			if(enumValue == null)
			{
				throw new ArgumentNullException("Unable to load enum display value, enumValue parameter is null");
			}
			Type enumType = enumValue.GetType();
			if(!enumType.IsEnum)
			{
				throw new InvalidCastException(string.Format("Unable to load enum display value, type of enumValue parameter is not an enum: {0}",enumType.Name));
			}
			return GetDisplayValue((int)enumValue,enumType);
		}
		
		public static string GetDisplayValue(object dataObject, string enumPropertyName)
		{
			string returnValue = null;
			if(dataObject != null)
			{
				Type objectType = dataObject.GetType();
				PropertyInfo propInfo = objectType.GetProperty(enumPropertyName);
				if(propInfo == null)
				{
					throw new Exception(string.Format("Unable to retreive enum display value, object type {0} does not contain property {1}",objectType.Name,enumPropertyName));
				}
				if(!propInfo.PropertyType.IsEnum)
				{
					throw new Exception(string.Format("Unable to retrieve enum display value, property {0}.{1} is not an enum",propInfo.DeclaringType.Name,propInfo.PropertyType.Name));
				}
				object value = propInfo.GetValue(dataObject,null);
				returnValue = GetDisplayValue(value);
			}
			return returnValue;
		}

		public static string GetDisplayValue(int value, Type enumType)
		{
			Dictionary<int,EnumItemData> enumList = GetEnumData(enumType);
			if(enumList == null)
			{
				throw new ArgumentNullException(string.Format("Failed to load enum list for type {0}",enumType.Name));
			}
			EnumItemData item;
			if(!enumList.TryGetValue(value, out item))
			{
				throw new EnumCastException(value,enumType);
			}
			return item.DisplayValue;
		}

		public static Dictionary<int, EnumItemData> GetEnumData(Type enumType)
		{
			Dictionary<int,EnumItemData> returnList = new Dictionary<int,EnumItemData>();
			Array enumValues = Enum.GetValues(enumType);
			foreach(object value in enumValues)
			{
				int intValue = (int)value;
				string name = Enum.GetName(enumType,value);
				string displayValue = EnumDisplayValueAttribute.GetDisplayValue(value);
				EnumItemData item = new EnumItemData()
				{
					ID = intValue,
					Name = name,
					DisplayValue = displayValue
				};
				returnList.Add(intValue,item);
			}
			return returnList;
		}

		public static T? TryParse<T>(string value) where T: struct
		{
			T? returnValue = null;
			int intValue;
			if (int.TryParse(value, out intValue))
			{
				returnValue = (T)(object)intValue;
			}
			else
			{
				if (Enum.IsDefined(typeof(T), value))
				{
					returnValue = (T)Enum.Parse(typeof(T), value);
				}
				else 
				{
					var nameList = Enum.GetNames(typeof(T));
					var matchingName = nameList.FirstOrDefault(i => !string.IsNullOrEmpty(i) && i.Equals(value, StringComparison.CurrentCultureIgnoreCase));
					if (!string.IsNullOrEmpty(matchingName))
					{
						return (T)Enum.Parse(typeof(T), matchingName);
					}
					else
					{
						return null;
					}
				}
			}
			return returnValue;
		}

		public static T Parse<T>(string value)
		{
			int intValue;
			if(int.TryParse(value,out intValue))
			{
				return (T)(object)intValue;
			}
			else 
			{
				if (Enum.IsDefined(typeof(T), value))
				{
					return (T)Enum.Parse(typeof(T), value);
				}
				else 
				{
					var nameList = Enum.GetNames(typeof(T));
					var matchingName = nameList.FirstOrDefault(i => !string.IsNullOrEmpty(i) && i.Equals(value, StringComparison.CurrentCultureIgnoreCase));
					if (!string.IsNullOrEmpty(matchingName))
					{
						return (T)Enum.Parse(typeof(T), matchingName);
					}
					else
					{
						throw new EnumCastException(value, typeof(T));
					}
				}
			}
		}

		public static object ConvertToEnum(Type type, object value)
		{
			object returnValue;
			if(value == null)
			{
				returnValue = null;
			}
			else if (value is string)
			{
				string stringValue = (string)value;
				int intValue;
				if(int.TryParse(stringValue,out intValue))
				{
					if(!Enum.IsDefined(type,intValue))
					{
						throw new Exception(string.Format("Failed to convert integer value \"{0}\" to enum type \"{1}\"",value,type.Name));
					}
					returnValue = (int)intValue;
				}
				else 
				{
					if(Enum.IsDefined(type,value))
					{
						returnValue = Enum.Parse(type, stringValue);
					}
					else 
					{
						var nameList = Enum.GetNames(type);
						var matchingName = nameList.FirstOrDefault(i=>!string.IsNullOrEmpty(i) && i.Equals(stringValue, StringComparison.CurrentCultureIgnoreCase));
						if(!string.IsNullOrEmpty(matchingName))
						{
							returnValue = Enum.Parse(type, matchingName);
						}
						else 
						{
							throw new Exception(string.Format("Failed to convert string value \"{0}\" to enum type \"{1}\"",value,type.Name));
						}
					}
				}
			}
			else if (value is int)
			{
				if(!Enum.IsDefined(type,value))
				{
					throw new Exception(string.Format("Failed to convert integer value \"{0}\" to enum type \"{1}\"",value,type.Name));
				}
				returnValue = Enum.Parse(type,value.ToString());
			}
			else if(type.IsInstanceOfType(value))
			{
				returnValue = value;
			}
			else 
			{
				throw new Exception(string.Format("Value \"{0}\" is not a valid value of enum type \"{1}\"",value,type));
			}
			return returnValue;
		}

	}
}
