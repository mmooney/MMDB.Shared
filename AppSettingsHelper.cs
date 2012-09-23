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

		public static bool GetBoolSetting(string key, bool defaultValue)
		{
			bool returnValue;
			string tempValue = GetSetting(key);
			if (string.IsNullOrEmpty(tempValue))
			{
				returnValue = defaultValue;
			}
			else
			{
				if (!bool.TryParse(tempValue, out returnValue))
				{
					throw new Exception(string.Format("Failed to parse application setting \"{0}\" into a boolean, value: \"{1}\"", key, tempValue));
				}
			}
			return returnValue;
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

		public static string GetSetting(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

	}
}
