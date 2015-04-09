using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

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

        public static long? GetLongParameter(string parameterName)
        {
            long? returnValue = null;
            string stringValue = WebFormsHelper.GetStringParameter(parameterName);
            if (!string.IsNullOrEmpty(stringValue))
            {
                long tempInt;
                if (!long.TryParse(stringValue, out tempInt))
                {
                    throw new Exception(string.Format("Failed to parse long parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
                }
                returnValue = tempInt;
            }
            return returnValue;
        }

        public static long GetLongParameter(string parameterName, long defaultValue)
        {
            long? returnValue = GetLongParameter(parameterName);
            return returnValue.GetValueOrDefault(defaultValue);
        }

        public static long GetRequiredLongParameter(string parameterName)
        {
            long? value = WebFormsHelper.GetLongParameter(parameterName);
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

		public static DateTime? GetDateTimeParameter(string parameterName)
		{
			DateTime? returnValue = null;
			string stringValue = GetStringParameter(parameterName);
			if (!string.IsNullOrEmpty(stringValue))
			{
				DateTime tempDate;
				if (!DateTime.TryParse(stringValue, out tempDate))
				{
					throw new Exception(string.Format("Failed to parse DateTime parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
				}
				returnValue = tempDate;
			}
			return returnValue;
		}

		public static DateTime GetDateTimeParameter(string parameterName, DateTime defaultValue)
		{
			DateTime? returnValue = WebFormsHelper.GetDateTimeParameter(parameterName);
			return returnValue.GetValueOrDefault(defaultValue);
		}

		public static DateTime GetRequiredDateTimeParameter(string parameterName)
		{
			DateTime? value = WebFormsHelper.GetDateTimeParameter(parameterName);
			if (!value.HasValue)
			{
				throw new Exception(string.Format("Missing {0} Parameter", parameterName));
			}
			return value.Value;
		}

		public static DateTime? GetDateTimeViewState(StateBag viewState, string fieldName)
		{
			DateTime? returnValue = null;
			if (viewState[fieldName] != null)
			{
				returnValue = (DateTime)viewState[fieldName];
			}
			return returnValue;
		}

		public static DateTime GetRequiredDateTimeViewState(StateBag viewState, string fieldName)
		{
			DateTime? returnValue = WebFormsHelper.GetDateTimeViewState(viewState, fieldName);
			if (!returnValue.HasValue)
			{
				throw new Exception(string.Format("Missing required ViewState DateTime value \"{0}\"", fieldName));
			}
			return returnValue.Value;
		}

		public static void SetDateTimeViewState(StateBag viewState, string fieldName, DateTime value)
		{
			viewState[fieldName] = value;
		}

		public static Guid? GetGuidParameter(string parameterName)
		{
			Guid? returnValue = null;
			string stringValue = WebFormsHelper.GetStringParameter(parameterName);
			if(!string.IsNullOrEmpty(stringValue))
			{
				Guid tempGuid;
				if (!GuidTryParse(stringValue, out tempGuid))
				{
					throw new Exception(string.Format("Failed to parse Guid parameter \"{0}\" for value \"{1}\"", parameterName, stringValue));
				}
				returnValue = tempGuid;
			}
			return returnValue;
		}

		/// http://geekswithblogs.net/colinbo/archive/2006/01/18/66307.aspx
		/// <summary>
		/// Converts the string representation of a Guid to its Guid 
		/// equivalent. A return value indicates whether the operation 
		/// succeeded. 
		/// </summary>
		/// <param name="s">A string containing a Guid to convert.</param>
		/// <param name="result">
		/// When this method returns, contains the Guid value equivalent to 
		/// the Guid contained in <paramref name="s"/>, if the conversion 
		/// succeeded, or <see cref="Guid.Empty"/> if the conversion failed. 
		/// The conversion fails if the <paramref name="s"/> parameter is a 
		/// <see langword="null" /> reference (<see langword="Nothing" /> in 
		/// Visual Basic), or is not of the correct format. 
		/// </param>
		/// <value>
		/// <see langword="true" /> if <paramref name="s"/> was converted 
		/// successfully; otherwise, <see langword="false" />.
		/// </value>
		/// <exception cref="ArgumentNullException">
		///        Thrown if <pararef name="s"/> is <see langword="null"/>.
		/// </exception>
		public static bool GuidTryParse(string s, out Guid result)
		{
			if (s == null)
				throw new ArgumentNullException("s");
			Regex format = new Regex(
				"^[A-Fa-f0-9]{32}$|" +
				"^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
				"^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
			Match match = format.Match(s);
			if (match.Success)
			{
				result = new Guid(s);
				return true;
			}
			else
			{
				result = Guid.Empty;
				return false;
			}
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

		public static DateTime GetDateTimeViewState(StateBag viewState, string fieldName, DateTime defaultValue)
		{
			DateTime? returnValue = WebFormsHelper.GetDateTimeViewState(viewState, fieldName);
			return returnValue.GetValueOrDefault(defaultValue);
		}
	}
}
