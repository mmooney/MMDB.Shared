using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace MMDB.Shared.Web
{
	public class MMDBPage : Page
	{
		public string GetStringParameter(string parameterName)
		{
			return WebFormsHelper.GetStringParameter(parameterName);
		}

		public string GetStringParameter(string parameterName, string defaultValue)
		{
			return WebFormsHelper.GetStringParameter(parameterName, defaultValue);
		}

		public string GetRequiredStringParameter(string parameterName)
		{
			return WebFormsHelper.GetRequiredStringParameter(parameterName);
		}

		public int? GetIntParameter(string parameterName)
		{
			return WebFormsHelper.GetIntParameter(parameterName);
		}

		public int GetIntParmeter(string parameterName, int defaultValue)
		{
			return WebFormsHelper.GetIntParameter(parameterName, defaultValue);
		}

		protected int GetRequiredIntParameter(string parameterName)
		{
			return WebFormsHelper.GetRequiredIntParameter(parameterName);
		}

		public bool? GetBoolParameter(string parameterName)
		{
			return WebFormsHelper.GetBoolParameter(parameterName);
		}

		public bool GetBoolParameter(string parameterName, bool defaultValue)
		{
			return WebFormsHelper.GetBoolParameter(parameterName, defaultValue);
		}

		protected bool GetRequiredBoolParameter(string parameterName)
		{
			return WebFormsHelper.GetRequiredBoolParameter(parameterName);
		}

		public Guid? GetGuidParameter(string parameterName)
		{
			return WebFormsHelper.GetGuidParameter(parameterName);
		}

		public Guid GetGuidParameter(string parameterName, Guid defaultValue)
		{
			return WebFormsHelper.GetGuidParameter(parameterName, defaultValue);
		}

		protected Guid GetRequiredGuidParameter(string parameterName)
		{
			return WebFormsHelper.GetRequiredGuidParameter(parameterName);
		}

	}
}
