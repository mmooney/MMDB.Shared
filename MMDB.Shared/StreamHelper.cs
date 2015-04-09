using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
	public static class StreamHelper
	{
		/// <summary>
		/// Creates a new memory stream with the provided data.  The position will point to the end of the stream.  It is the caller's responsibility to dispose of the stream.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static MemoryStream CreateMemoryStream(string data)
		{
			MemoryStream stream = new MemoryStream(data.Length+10);
			StreamWriter writer = new StreamWriter(stream);
			writer.Write(data);
			writer.Flush();
			return stream;
		}

		/// <summary>
		/// Writes reads all the data in a stream, from beginning to end. Restores teh stream's previous position before returning
		/// </summary>
		public static string ReadAll(Stream stream)
		{
			long oldPosition = stream.Position;
			stream.Position = 0;

			var reader = new StreamReader(stream);	//Do NOT dispose this reader, because it will dispose the stream?
			string returnValue = reader.ReadToEnd();

			stream.Position = oldPosition;

			return returnValue;
		}


		/// <summary>
		/// Writes all of the provided data to the stream object.  The position is not overridden; it will write from the current position and the final position will be the end of the written data.
		/// </summary>
		public static Stream WriteAll(Stream stream, string data)
		{
			var writer = new StreamWriter(stream);
			writer.Write(data);
			writer.Flush();
			return stream;
		}

        //http://stackoverflow.com/questions/1080442/how-to-convert-an-stream-into-a-byte-in-c
        public static byte[] ReadAllBytes(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
