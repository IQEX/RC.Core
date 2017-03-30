using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rc.Framework.Screens
{
    public class FailConvertGroupToColorException : Exception
    {
        private readonly Group _group;
        private readonly Exception innerException;
        public FailConvertGroupToColorException(Group g, Exception inner = null)
        {
            this._group = g;
            this.innerException = inner;
        }

        public Group getGroup() => _group;
        public Exception getInnerException() => innerException;
    }
    public class CustomColorException : Exception
    {
        private readonly string _msg;

        public CustomColorException(string msg)
        {
            _msg = msg;
        }

        public override string ToString()
        {
            return $"[{nameof(CustomColorException)}] {_msg}.";
        }
    }
}
