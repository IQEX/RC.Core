using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Native.Win32
{
    /// <summary>
    /// Class of BIOS
    /// </summary>
    public class Win32_BIOS
    {
        public UInt16[] BiosCharacteristics;
        public string[] BIOSVersion;
        public string BuildNumber;
        public string Caption;
        public string CodeSet;
        public string CurrentLanguage;
        public string Description;
        public string IdentificationCode;
        public UInt16 InstallableLanguages;
        public DateTime InstallDate;
        public string LanguageEdition;
        public String[] ListOfLanguages;
        public string Manufacturer;
        public string Name;
        public string OtherTargetOS;
        public bool PrimaryBIOS;
        public DateTime ReleaseDate;
        public string SerialNumber;
        public string SMBIOSBIOSVersion;
        public UInt16 SMBIOSMajorVersion;
        public UInt16 SMBIOSMinorVersion;
        public bool SMBIOSPresent;
        public string SoftwareElementID;
        public UInt16 SoftwareElementState;
        public string Status;
        public UInt16 TargetOperatingSystem;
        public string Version;
    };
}
