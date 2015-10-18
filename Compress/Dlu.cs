using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Compress
{
    /// <summary>
    /// null
    /// </summary>
    [Obsolete("", true)]
    public class Dlu : Zip
    {
        internal Dlu(CompressionLevel level = CompressionLevel.Level0, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            this.compress = level;
            this.Encod = encoding;
        }
        public bool Assembly(string sourse, string relese)
        {
            return this.CoralisPacked(sourse, relese);
        }
    }
}
