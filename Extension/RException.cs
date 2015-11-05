using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Extension
{
    public class RException<TKey, TVal> : Exception
    {
        public static RException<TK, TV> Convert<TK, TV>(Exception ex, IDictionary<TK, TV> dic, [CallerFilePath] string file = "?")
        {
            //System.InvalidCastException
            //System.InvalidOperationException
            //System.NotSupportedException
            var w = new RException<TK, TV>(ex.Message, dic);
            w.source = Path.GetFileName(file);
            return w;
        }
        public static bool isConnectStackTrace = false;

        private IDictionary data;
        private string helpLink, message, source;
        public override IDictionary Data
        {
            get
            {
                return data;
            }
        }
        public override string HelpLink
        {
            get
            {
                return helpLink;
            }

            set
            {
                helpLink = value;
            }
        }
        public override string Message
        {
            get
            {
                return message;
            }
        }
        public override string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        public override string StackTrace
        {
            get
            {
                if (!isConnectStackTrace)
                    return base.StackTrace;
                else
                    return "";
            }
        }
        public RException(string message, IDictionary<TKey, TVal> dic)
        {
            this.data = (IDictionary)dic;
            this.message = message;
        }
    }
}
