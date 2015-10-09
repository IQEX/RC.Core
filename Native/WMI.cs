using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Native
{
    /// <summary>
    /// Windows Management Instrumentation
    /// </summary>
    public class WMI
    {
        /// <summary>
        /// Version Win32
        /// </summary>
        public const string SelectVersionWindows = "SELECT Version FROM Win32_OperatingSystem";
        /// <summary>
        /// Query method
        /// </summary>
        /// <param name="qu">Query</param>
        /// <param name="xBase">result</param>
        /// <returns></returns>
        public bool Query(string qu, out Dictionary<String, String> xBase)
        {
            xBase = new Dictionary<string, string>();
            try
            {

                var mng = new ManagementObjectSearcher(qu);
                foreach (ManagementObject ob in mng.Get())
                {
                    foreach(PropertyData dta in ob.Properties)
                    {
                        xBase.Add(dta.Name, (string)dta.Value);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
