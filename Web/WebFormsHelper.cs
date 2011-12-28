using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace MMDB.Shared.Web
{
	public static class WebFormsHelper
	{
		private static HttpRequest Request
		{
			get 
			{
				return HttpContext.Current.Request;
			}
		}

		public static string GetStringParameter(string parameterName)
		{
			string returnValue = null;
			if (WebFormsHelper.Request.Params.AllKeys.Contains(parameterName, StringComparer.InvariantCultureIgnoreCase))
			{
				returnValue = WebFormsHelper.Request.Params[parameterName];
			}
			return returnValue;
		}

		public static string GetStringParameter(string parameterName, string defaultValue)
		{
			string returnValue = WebFormsHelper.GetStringParameter(parameterName);
			if(string.IsNullOrEmpty(returnValue))
			{
				returnValue = defaultValue;
			}
			return returnValue;
		}

		public static string GetRequiredStringParameter(string parameterName)
		{
			string returnValue = WebFormsHelper.GetStringParameter(parameterName);
			if (string.IsNullOrEmpty(returnValue))
			{
				throw new Exception(string.Format("Missing {0} parameter", returnValue));
			}
			return returnValue;
		}

		public static int? GetIntParameter(string parameterName)
		{
			int? returnValue = null;
			string stringValue = WebFormsHelper.GetStringParameter(parameterName);
			if(!string.IsNullOrEmpty(stringValue))
			{
				int tempInt;
				if (!int.TryParse(stringValue, out tempInt))
				{
					throw new Exception(string.Format("Failed to parse integer parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
				}
				returnValue = tempInt;
			}
			return returnValue;
		}

		public static int GetIntParameter(string parameterName, int defaultValue)
		{
			int? returnValue = GetIntParameter(parameterName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static int GetRequiredIntParameter(string parameterName)
		{
			int? value = WebFormsHelper.GetIntParameter(parameterName);
			if (!value.HasValue)
			{
				throw new Exception(string.Format("Missing {0} Parameter", parameterName));
			}
			return value.Value;
		}

		public static bool? GetBoolParameter(string parameterName)
		{
			bool? returnValue = null;
			string stringValue = GetStringParameter(parameterName);
			if(!string.IsNullOrEmpty(stringValue))
			{
				bool tempBool;
				if (!bool.TryParse(stringValue, out tempBool))
				{
					throw new Exception(string.Format("Failed to parse bool parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
				}
				returnValue = tempBool;
			}
			return returnValue;
		}
		
		public static bool GetBoolParameter(string parameterName, bool defaultValue)
		{
			bool? returnValue = WebFormsHelper.GetBoolParameter(parameterName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static bool GetRequiredBoolParameter(string parameterName)
		{
			bool? value = WebFormsHelper.GetBoolParameter(parameterName);
			if (!value.HasValue)
			{
				throw new Exception(string.Format("Missing {0} Parameter", parameterName));
			}
			return value.Value;
		}

		public static Guid? GetGuidParameter(string parameterName)
		{
			Guid? returnValue = null;
			string stringValue = WebFormsHelper.GetStringParameter(parameterName);
			if(!string.IsNullOrEmpty(stringValue))
			{
				Guid tempGuid;
				if (!Guid.TryParse(stringValue, out tempGuid))
				{
					throw new Exception(string.Format("Failed to parse Guid parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
				}
				returnValue = tempGuid;
			}
			return returnValue;
		}

		public static Guid GetGuidParameter(string parameterName, Guid defaultValue)
		{
			Guid? returnValue = WebFormsHelper.GetGuidParameter(parameterName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static Guid GetRequiredGuidParameter(string parameterName)
		{
			Guid? guid = WebFormsHelper.GetGuidParameter(parameterName);
			if (!guid.HasValue)
			{
				throw new Exception(string.Format("Missing {0} Parameter", parameterName));
			}
			return guid.Value;
		}

		public static string GetStringViewState(StateBag viewState, string fieldName)
		{
			return (string)viewState[fieldName];
		}

		public static string GetStringParameter(StateBag viewState, string fieldName, string defaultValue)
		{
			string returnValue = WebFormsHelper.GetStringViewState(viewState, fieldName);
			if (string.IsNullOrEmpty(returnValue))
			{
				returnValue = defaultValue;
			}
			return returnValue;
		}

		public static string GetRequiredStringViewState(StateBag viewState, string fieldName)
		{
			string returnValue = WebFormsHelper.GetStringViewState(viewState, fieldName);
			if (string.IsNullOrEmpty(returnValue))
			{
				throw new Exception(string.Format("Missing required ViewState string value \"{0}\"", fieldName));
			}
			return returnValue;
		}

		public static void SetStringViewState(StateBag viewState, string fieldName, string value)
		{
			viewState[fieldName] = value;
		}

		public static bool? GetBoolViewState(StateBag viewState, string fieldName)
		{
			bool? returnValue = null;
			if (viewState[fieldName] != null)
			{
				returnValue = (bool)viewState[fieldName];
			}
			return returnValue;
		}

		public static bool GetBoolParameter(StateBag viewState, string fieldName, bool defaultValue)
		{
			bool? returnValue = WebFormsHelper.GetBoolViewState(viewState, fieldName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static bool GetRequiredBoolViewState(StateBag viewState, string fieldName)
		{
			bool? returnValue = WebFormsHelper.GetBoolViewState(viewState, fieldName);
			if (!returnValue.HasValue)
			{
				throw new Exception(string.Format("Missing required ViewState boolean value \"{0}\"", fieldName));
			}
			return returnValue.Value;
		}

		public static void SetBoolViewState(StateBag viewState, string fieldName, bool value)
		{
			viewState[fieldName] = value;
		}

		public static Guid? GetGuidViewState(StateBag viewState, string fieldName)
		{
			Guid? returnValue = null;
			if (viewState[fieldName] != null)
			{
				returnValue = (Guid)viewState[fieldName];
			}
			return returnValue;
		}

		public static Guid GetGuidViewState(StateBag viewState, string fieldName, Guid defaultValue)
		{
			Guid? returnValue = WebFormsHelper.GetGuidViewState(viewState, fieldName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static Guid GetRequiredGuidViewState(StateBag viewState, string fieldName)
		{
			Guid? returnValue = WebFormsHelper.GetGuidViewState(viewState, fieldName);
			if (!returnValue.HasValue)
			{
				throw new Exception(string.Format("Missing required ViewState GUID value \"{0}\"", fieldName));
			}
			return returnValue.Value;
		}

		public static void SetGuidViewState(StateBag viewState, string fieldName, Guid value)
		{
			viewState[fieldName] = value;
		}

		public static T? GetEnumViewState<T>(StateBag viewState, string fieldName) where T : struct
		{
			T? returnValue = null;
			if (viewState[fieldName] != null)
			{
				returnValue = (T)viewState[fieldName];
			}
			return returnValue;
		}

		public static T GetEnumViewState<T>(StateBag viewState, string fieldName, T defaultValue) where T : struct
		{
			T? returnValue = WebFormsHelper.GetEnumViewState<T>(viewState, fieldName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static T GetRequiredEnumViewState<T>(StateBag viewState, string fieldName) where T: struct
		{
			T? returnValue = WebFormsHelper.GetEnumViewState<T>(viewState, fieldName);
			if (!returnValue.HasValue)
			{
				throw new Exception(string.Format("Missing required ViewState {0} value \"{1}\"", typeof(T).Name, fieldName));
			}
			return returnValue.Value;
		}

		public static void SetEnumViewState<T>(StateBag viewState, string fieldName, T value) where T : struct
		{
			viewState[fieldName] = value;
		}

		public static int? GetIntViewState(StateBag viewState, string fieldName)
		{
			int? returnValue = null;
			if (viewState[fieldName] != null)
			{
				returnValue = (int)viewState[fieldName];
			}
			return returnValue;
		}

		public static int GetIntParameter(StateBag viewState, string fieldName, int defaultValue)
		{
			int? returnValue = WebFormsHelper.GetIntViewState(viewState, fieldName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static int GetRequiredIntViewState(StateBag viewState, string fieldName)
		{
			int? returnValue = WebFormsHelper.GetIntViewState(viewState, fieldName);
			if (!returnValue.HasValue)
			{
				throw new Exception(string.Format("Missing required ViewState integer value \"{0}\"", fieldName));
			}
			return returnValue.Value;
		}

		public static void SetIntViewState(StateBag viewState, string fieldName, int? value)
		{
			if (value.HasValue)
			{
				viewState[fieldName] = value.Value;
			}
			else
			{
				viewState[fieldName] = null;
			}
		}
	}
}
