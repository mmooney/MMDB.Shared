using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MMDB.Shared
{
    /// <summary>
    /// http://stackoverflow.com/a/1564727/203479
    /// </summary>
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
