﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public static class StreamHelper
	{
		public static string ReadAll(Stream stream)
		{
			long oldPosition = stream.Position;
			stream.Position = 0;

			var reader = new StreamReader(stream);	//Do NOT dispose this reader, because it will dispose the stream?
			string returnValue = reader.ReadToEnd();

			stream.Position = oldPosition;

			return returnValue;
		}

		public static void WriteAll(Stream stream, string data)
		{
			var writer = new StreamWriter(stream);
			writer.Write(data);
			writer.Flush();
		}
	}
}
