using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace MMDB.Shared.Web
{
	public class MMDBUserControl : UserControl
	{
		protected string GetStringViewState(string fieldName)
		{
			return WebFormsHelper.GetStringViewState(this.ViewState, fieldName);
		}

		protected string GetStringViewState(string fieldName, string defaultValue)
		{
			return WebFormsHelper.GetStringParameter(this.ViewState, fieldName, defaultValue);
		}

		protected string GetRequiredStringViewState(string fieldName)
		{
			return WebFormsHelper.GetRequiredStringViewState(this.ViewState, fieldName);
		}

		protected void SetStringViewState(string fieldName, string value)
		{
			WebFormsHelper.SetStringViewState(this.ViewState, fieldName, value);
		}

		protected bool? GetBoolViewState(string fieldName)
		{
			return WebFormsHelper.GetBoolViewState(this.ViewState, fieldName);
		}

		protected bool GetBoolViewState(string fieldName, bool defaultValue)
		{
			return WebFormsHelper.GetBoolParameter(this.ViewState, fieldName, defaultValue);
		}

		protected bool GetRequiredBoolViewState(string fieldName)
		{
			return WebFormsHelper.GetRequiredBoolViewState(this.ViewState, fieldName);
		}

		protected void SetBoolViewState(string fieldName, bool value)
		{
			WebFormsHelper.SetBoolViewState(this.ViewState, fieldName, value);
		}

		protected Guid? GetGuidViewState(string fieldName)
		{
			return WebFormsHelper.GetGuidViewState(this.ViewState, fieldName);
		}

		public Guid GetGuidViewState(string fieldName, Guid defaultValue)
		{
			return WebFormsHelper.GetGuidViewState(this.ViewState, fieldName, defaultValue);
		}

		protected Guid GetRequiredGuidViewState(string fieldName)
		{
			return WebFormsHelper.GetRequiredGuidViewState(this.ViewState, fieldName);
		}

		protected void SetGuidViewState(string fieldName, Guid value)
		{
			WebFormsHelper.SetGuidViewState(this.ViewState, fieldName, value);
		}


		protected T? GetEnumViewState<T>(string fieldName) where T : struct
		{
			return WebFormsHelper.GetEnumViewState<T>(this.ViewState, fieldName);
		}

		protected T GetEnumViewState<T>(string fieldName, T defaultValue) where T : struct
		{
			return WebFormsHelper.GetEnumViewState<T>(this.ViewState, fieldName, defaultValue);
		}

		protected T GetRequiredEnumViewState<T>(string fieldName) where T : struct
		{
			return WebFormsHelper.GetRequiredEnumViewState<T>(this.ViewState, fieldName);
		}

		protected void SetEnumViewState<T>(string fieldName, T value) where T : struct
		{
			WebFormsHelper.SetEnumViewState<T>(this.ViewState, fieldName, value);
		}

		protected int? GetIntViewState(string fieldName)
		{
			return WebFormsHelper.GetIntViewState(this.ViewState, fieldName);
		}

		protected int GetIntViewState(string fieldName, int defaultValue)
		{
			return WebFormsHelper.GetIntParameter(this.ViewState, fieldName, defaultValue);
		}

		protected int GetRequiredIntViewState(string fieldName)
		{
			return WebFormsHelper.GetRequiredIntViewState(this.ViewState, fieldName);
		}

		protected void SetIntViewState(string fieldName, int? value)
		{
			WebFormsHelper.SetIntViewState(this.ViewState, fieldName, value);
		}

		protected DateTime? GetDateTimeViewState(string fieldName)
		{
			return WebFormsHelper.GetDateTimeViewState(this.ViewState, fieldName);
		}

		protected DateTime GetDateTimeViewState(string fieldName, DateTime defaultValue)
		{
			return WebFormsHelper.GetDateTimeViewState(this.ViewState, fieldName, defaultValue);
		}

		protected DateTime GetRequiredDateTimeViewState(string fieldName)
		{
			return WebFormsHelper.GetRequiredDateTimeViewState(this.ViewState, fieldName);
		}

		protected void SetDateTimeViewState(string fieldName, DateTime value)
		{
			WebFormsHelper.SetDateTimeViewState(this.ViewState, fieldName, value);
		}

	}
}
