using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public static class DateTimeHelper
	{
		public const string TimeZoneIdentifier_EasternStandardTime = "Eastern Standard Time";
		public const string TimeZoneIdentifier_MountainStandardTime = "Mountain Standard Time";
		public const string TimeZoneIdentifier_CentralStandardTime = "Central Standard Time";
		public const string TimeZoneIdentifier_PacificStandardTime = "Pacific Standard Time";

		public static DateTime FromUtcToTimeZone(DateTime utcTime, string timeZoneIdentifier)
		{
			DateTime localTime;
			TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneIdentifier);
			localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzInfo);
			return localTime;
		}

		public static DateTime FromTimeZoneToUtc(DateTime localTime, string timeZoneIdentifier)
		{
			DateTime utcTime;
			TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneIdentifier);
			if (localTime.Kind == DateTimeKind.Local)
			{
				localTime = new DateTime(localTime.Ticks, DateTimeKind.Unspecified);
			}
			utcTime = TimeZoneInfo.ConvertTimeToUtc(localTime, tzInfo);
			return utcTime;
		}

		public static string FormatDateTime(DateTime? utcDateTime, string timeZoneIdentifier)
		{
			if (utcDateTime.HasValue)
			{
				TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneIdentifier);
				DateTime localDateTime = FromUtcToTimeZone(utcDateTime.Value, timeZoneIdentifier);
				return string.Format("{0:MM/dd/yy H:mm} {1}", localDateTime, GetAbbreviation(timeZoneIdentifier));
			}
			else
			{
				return null;
			}
		}

		public static string GetAbbreviation(string timeZoneIdentifier)
		{
			var map = new Dictionary<string, string>()
			{
				{"eastern standard time","est"},
				{"mountain standard time","mst"},
				{"central standard time","cst"},
				{"pacific standard time","pst"}
				//etc...
			};
			string returnValue;
			if(!map.TryGetValue(timeZoneIdentifier.ToLower(), out returnValue))
			{
				returnValue = timeZoneIdentifier;
			}
			return returnValue;
		}
	}
}
