using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace MMDB.Shared.Tests
{
    public class EnumHelperTests
    {
		public enum TestEnum
		{
			[EnumDisplayValue("Test Value 1")]
			TestValue1 = 1,
			TestValue2 = 2
		}

		[Test]
		public void TryParse_ValidString_Success()
		{
			var result = EnumHelper.TryParse<TestEnum>("TestValue1");
			Assert.That(result.HasValue);
			Assert.AreEqual(TestEnum.TestValue1, result.Value);
		}

		[Test]
		public void TryParse_WrongCase_Success()
		{
			var result = EnumHelper.TryParse<TestEnum>("testvalue1");
			Assert.That(result.HasValue);
			Assert.AreEqual(TestEnum.TestValue1, result.Value);
		}

		[Test]
		public void TryParse_IntAsString_Success()
		{
			var result = EnumHelper.TryParse<TestEnum>("1");
			Assert.That(result.HasValue);
			Assert.AreEqual(TestEnum.TestValue1, result.Value);
		}

		[Test]
		public void TryParse_InValidString_ReturnsNull()
		{
			var result = EnumHelper.TryParse<TestEnum>("bad value");
			Assert.That(!result.HasValue);
		}

		[Test]
		public void Parse_ValidString_Success()
		{
			var result = EnumHelper.Parse<TestEnum>("TestValue1");
			Assert.AreEqual(TestEnum.TestValue1, result);
		}

		[Test]
		public void Parse_WrongCase_Success()
		{
			var result = EnumHelper.Parse<TestEnum>("testvalue1");
			Assert.AreEqual(TestEnum.TestValue1, result);
		}

		[Test]
		public void Parse_IntAsString_Success()
		{
			var result = EnumHelper.Parse<TestEnum>("1");
			Assert.AreEqual(TestEnum.TestValue1, result);
		}

		[Test]
		public void Parse_InvalidString_ThrowsException()
		{
			Assert.Throws<EnumCastException>(()=>EnumHelper.Parse<TestEnum>("bad value"));
		}

		[Test]
		public void GetDisplayValue_ReturnsDisplayValue()
		{
			string result = EnumHelper.GetDisplayValue(TestEnum.TestValue1);
			Assert.AreEqual("Test Value 1", result);
		}

		[Test]
		public void GetDisplayValue_DefaultsToEnumValue()
		{
			string result = EnumHelper.GetDisplayValue(TestEnum.TestValue2);
			Assert.AreEqual("TestValue2", result);
		}

		[Test]
		public void GetDisplayValue_Null_ThrowsException()
		{
			Assert.Throws<ArgumentNullException>(()=>EnumHelper.GetDisplayValue(null));
		}

		[Test]
		public void GetDisplayValue_NonEnum_ThrowsException()
		{
			Assert.Throws<InvalidCastException>(()=>EnumHelper.GetDisplayValue("blah blah blah"));
		}

		[Test]
		public void DataBind_Default()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum));
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(2, itemData.Count);
		}

		[Test]
		public void Databind_Exact()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum), EnumHelper.EnumDropdownBindingType.Exact);
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(2, itemData.Count);
			Assert.AreEqual("Test Value 1", itemData[0].DisplayValue);
			Assert.AreEqual("TestValue2", itemData[1].DisplayValue);
		}

		[Test]
		public void Databind_ClearFirstRecord()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum), EnumHelper.EnumDropdownBindingType.ClearFirstRecord);
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(2, itemData.Count);
			Assert.AreEqual(string.Empty, itemData[0].DisplayValue);
			Assert.AreEqual("TestValue2", itemData[1].DisplayValue);
		}

		[Test]
		public void DataBind_AddEmptyFirstRecord()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum), EnumHelper.EnumDropdownBindingType.AddEmptyFirstRecord);
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(3, itemData.Count);
			Assert.AreEqual(string.Empty, itemData[0].DisplayValue);
			Assert.AreEqual("Test Value 1", itemData[1].DisplayValue);
			Assert.AreEqual("TestValue2", itemData[2].DisplayValue);
		}

		[Test]
		public void DataBind_AddEmptyFirstRecord_WithText()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			string firstRecordValue = Guid.NewGuid().ToString();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum), EnumHelper.EnumDropdownBindingType.AddEmptyFirstRecord, firstRecordValue);
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(3, itemData.Count);
			Assert.AreEqual(firstRecordValue, itemData[0].DisplayValue);
			Assert.AreEqual("Test Value 1", itemData[1].DisplayValue);
			Assert.AreEqual("TestValue2", itemData[2].DisplayValue);
		}

		[Test]
		public void DataBind_RemoveFirstRecord()
		{
			var ctrl = new Mock<System.Web.UI.WebControls.ListControl>();
			ctrl.SetupAllProperties();
			EnumHelper.DataBind(ctrl.Object, typeof(TestEnum), EnumHelper.EnumDropdownBindingType.RemoveFirstRecord);
			var itemData = (List<EnumItemData>)ctrl.Object.DataSource;
			Assert.IsNotNull(itemData);
			Assert.AreEqual("ID", ctrl.Object.DataValueField);
			Assert.AreEqual("DisplayValue", ctrl.Object.DataTextField);
			Assert.AreEqual(1, itemData.Count);
			Assert.AreEqual("TestValue2", itemData[0].DisplayValue);
		}

		[Test]
		public void GetNullableDisplayValue_ValidValue_ReturnsDisplayValue()
		{
			var result = EnumHelper.GetNullableDisplayValue(TestEnum.TestValue1);
			Assert.AreEqual("Test Value 1", result);
		}

		[Test]
		public void GetNullableDisplayValue_Null_ReturnsNull()
		{
			var result = EnumHelper.GetNullableDisplayValue(null);
			Assert.IsNull(result);
		}

	}
}
