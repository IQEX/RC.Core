#pragma warning disable CS1591
namespace RC.Framework.Extension
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    public class RException<TKey, TVal> : Exception
    {
        public static RException<TK, TV> Convert<TK, TV>(Exception ex, IDictionary<TK, TV> dic, [CallerFilePath] string file = "?")
        {
            //System.InvalidCastException
            //System.InvalidOperationException
            //System.NotSupportedException
            var w = new RException<TK, TV>(ex.Message, dic) {source = Path.GetFileName(file)};
            return w;
        }
        public static bool isConnectStackTrace = false;

        private string source;
        public override IDictionary Data { get; }
        public override string HelpLink { get; set; }
        public override string Message { get; }
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
        public override string StackTrace => !isConnectStackTrace ? base.StackTrace : "";
        public RException(string message, IDictionary<TKey, TVal> dic)
        {
            this.Data = (IDictionary)dic;
            this.Message = message;
        }
    }
}
