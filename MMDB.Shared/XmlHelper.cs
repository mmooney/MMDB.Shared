using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MMDB.Shared
{
	public static class XmlHelper
	{
		public static T Deserialize<T>(string xml)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using(StringReader reader = new StringReader(xml))
			{
				return (T)serializer.Deserialize(reader);
			}
		}

		public static T DeserializeFile<T>(string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (StreamReader reader = new StreamReader(filePath))
			{
				return (T)serializer.Deserialize(reader);
			}
		}

		public static string Serialize(object value)
		{
			XmlSerializer serializer = new XmlSerializer(value.GetType());
			using(StringWriter writer = new StringWriter())
			{
				serializer.Serialize(writer, value);
				return writer.ToString();
			}
		}
		
		public static void SerializeFile(object value, string filePath)
		{
			XmlSerializer serializer = new XmlSerializer(value.GetType());
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				serializer.Serialize(writer, value);
			}
		}
	}
}
