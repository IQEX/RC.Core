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
        /// Info System Win32
        /// </summary>
        public const string QuerySystemWindows = "SELECT * FROM Win32_OperatingSystem";
        /// <summary>
        /// Info Base Board
        /// </summary>
        public const string QueryBaseBoard = "SELECT * FROM Win32_BaseBoard";
        /// <summary>
        /// Info Video Adapter
        /// </summary>
        public const string QueryVideoAdapter = "SELECT * FROM Win32_VideoController";
        /// <summary>
        /// Info Network Adapter
        /// </summary>
        public const string QueryVirtualNetworkAdapter = "SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = False";
        /// <summary>
        /// Info Network Adapter
        /// </summary>
        public const string QueryPhysicalNetworkAdapter = "SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True";
        /// <summary>
        /// Info Logical Disk
        /// </summary>
        public const string QueryLogicalDisk = "SELECT * FROM Win32_LogicalDisk WHERE NOT FileSystem = \"NTFS\"";
        /// <summary>
        /// Info Physical Disk
        /// </summary>
        public const string QueryPhysicalDisk = "SELECT * FROM Win32_LogicalDisk WHERE FileSystem = \"NTFS\"";
        /// <summary>
        /// Info Physical Memory
        /// </summary>
        public const string QueryPhysicalMemory = "SELECT * FROM Win32_PhysicalMemory";
        /// <summary>
        /// Query method
        /// </summary>
        /// <param name="qu">Query</param>
        /// <param name="xBase">result</param>
        /// <returns></returns>
        public bool Query(string qu, out List<Dictionary<String, String>> xBase)
        {
            xBase = new List<Dictionary<string, string>>();
            try
            {
                var mng = new ManagementObjectSearcher(qu);
                foreach (ManagementObject ob in mng.Get())
                {
                    xBase.Add(new Dictionary<string, string>());
                    foreach (PropertyData dta in ob.Properties)
                    {
                        xBase[xBase.Count - 1].Add(dta.Name, (string)dta.Value);
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
