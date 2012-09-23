using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MMDB.Shared
{
	public static class AppSettingsHelper
	{
		public static string GetRequiredSetting(string key)
		{
			string returnValue = GetSetting(key);
			if (string.IsNullOrEmpty(returnValue))
			{
				throw new Exception(string.Format("Missing required configuration setting \"{0}\"", key));
			}
			return returnValue;
		}

		public static bool GetRequiredBoolSetting(string key)
		{
			bool? value = GetBoolSetting(key);
			if(!value.HasValue)
			{
				throw new Exception(string.Format("Missing required configuration setting \"{0}\"", key));
			}
			return value.Value;
		}

		public static bool? GetBoolSetting(string key)
		{
			bool? returnValue;
			bool tempValue;
			string stringValue = GetSetting(key);
			if (string.IsNullOrEmpty(stringValue))
			{
				returnValue = null;
			}
			else if (!bool.TryParse(stringValue, out tempValue))
			{
				throw new Exception(string.Format("Failed to parse application setting \"{0}\" into a boolean, value: \"{1}\"", key, stringValue));
			}
			else
			{
				returnValue = tempValue;
			}
			return returnValue;
		}

		public static bool GetBoolSetting(string key, bool defaultValue)
		{
			return GetBoolSetting(key).GetValueOrDefault(defaultValue);
		}

		public static int GetRequiredIntSetting(string key)
		{
			int? value = GetIntSetting(key);
			if (!value.HasValue)
			{
				throw new Exception(string.Format("Missing required configuration setting \"{0}\"", key));
			}
			return value.Value;
		}

		public static int? GetIntSetting(string key)
		{
			int? returnValue;
			int tempValue;
			string stringValue = GetSetting(key);
			if (string.IsNullOrEmpty(stringValue))
			{
				returnValue = null;
			}
			else if (!int.TryParse(stringValue, out tempValue))
			{
				throw new Exception(string.Format("Failed to parse application setting \"{0}\" into a integer, value: \"{1}\"", key, stringValue));
			}
			else
			{
				returnValue = tempValue;
			}
			return returnValue;
		}

		public static int GetIntSetting(string key, int defaultValue)
		{
			return GetIntSetting(key).GetValueOrDefault(defaultValue);
		}

		public static string GetSetting(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

	}
}
