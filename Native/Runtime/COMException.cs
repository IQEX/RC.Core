using System;
using System.Globalization;
namespace Rc.Framework.Native.Runtime
{
    /// <summary>
    ///   The base class for errors that occur in COM.
    /// </summary>
    public class COMException : Exception
    {
        private ResultDescriptor descriptor;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "COMException" /> class.
        /// </summary>
        public COMException() : base("A COM exception occurred.")
        {
            this.descriptor = ResultDescriptor.Find(Result.Fail);
            HResult = (int)Result.Fail;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "COMException" /> class.
        /// </summary>
        /// <param name = "result">The result code that caused this exception.</param>
        public COMException(Result result) : this(ResultDescriptor.Find(result))
        {
            HResult = (int)result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="COMException"/> class.
        /// </summary>
        /// <param name="descriptor">The result descriptor.</param>
        public COMException(ResultDescriptor descriptor) : base(descriptor.ToString())
        {
            this.descriptor = descriptor;
            HResult = (int)descriptor.Result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="COMException"/> class.
        /// </summary>
        /// <param name="result">The error result code.</param>
        /// <param name="message">The message describing the exception.</param>
        public COMException(Result result, string message) : base(message)
        {
            this.descriptor = ResultDescriptor.Find(result);
            HResult = (int)result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="COMException"/> class.
        /// </summary>
        /// <param name="result">The error result code.</param>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="args">formatting arguments</param>
        public COMException(Result result, string message, params object[] args) : base(string.Format(CultureInfo.InvariantCulture, message, args))
        {
            this.descriptor = ResultDescriptor.Find(result);
            HResult = (int)result;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "COMException" /> class.
        /// </summary>
        /// <param name = "message">The message describing the exception.</param>
        /// <param name="args">formatting arguments</param>
        public COMException(string message, params object[] args) : this(Result.Fail, message, args)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "COMException" /> class.
        /// </summary>
        /// <param name = "message">The message describing the exception.</param>
        /// <param name = "innerException">The exception that caused this exception.</param>
        /// <param name="args">formatting arguments</param>
        public COMException(string message, Exception innerException, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
        {
            this.descriptor = ResultDescriptor.Find(Result.Fail);
            HResult = (int)Result.Fail;
        }

        /// <summary>
        ///   Gets the <see cref = "Result">Result code</see> for the exception. This value indicates
        ///   the specific type of failure that occurred within SharpDX.
        /// </summary>
        public Result ResultCode
        {
            get { return this.descriptor.Result; }
        }

        /// <summary>
        ///   Gets the <see cref = "Result">Result code</see> for the exception. This value indicates
        ///   the specific type of failure that occurred within SharpDX.
        /// </summary>
        public ResultDescriptor Descriptor
        {
            get { return this.descriptor; }
        }
    }
}
