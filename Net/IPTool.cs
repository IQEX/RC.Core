// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IPTool.cs"        //     Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>    //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="5.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Rc.Framework.Net
{
    public class IPTool
    {
        public static string MACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == string.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            return MACAddress;
        }
        /// <summary>
        /// Чертов костыль!
        /// </summary>
        /// <param name="ipend"></param>
        /// <returns></returns>
        public static string IPHash(IPEndPoint ipend)
        {
            return BitConverter.ToString(
                new MD5CryptoServiceProvider().ComputeHash(
                    new MD5CryptoServiceProvider().ComputeHash(
                        new MD5CryptoServiceProvider().ComputeHash(
                            new MD5CryptoServiceProvider().ComputeHash(
                                new MD5CryptoServiceProvider().ComputeHash(
                                    new MD5CryptoServiceProvider().ComputeHash(ipend.Address.GetAddressBytes())))))));
        }
    }
    
}
