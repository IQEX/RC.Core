using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Framework.Native.Win32
{
    public class Win32_CDROMDrive
    {
        public UInt16 Availability;
        public UInt16[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string CompressionMethod;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public UInt64 DefaultBlockSize;
        public string Description;
        public string DeviceID;
        public string Drive;
        public bool DriveIntegrity;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public UInt16 FileSystemFlags;
        public UInt32 FileSystemFlagsEx;
        public string Id;
        public DateTime InstallDate;
        public UInt32 LastErrorCode;
        public string Manufacturer;
        public UInt64 MaxBlockSize;
        public UInt32 MaximumComponentLength;
        public UInt64 MaxMediaSize;
        public bool MediaLoaded;
        public string MediaType;
        public string MfrAssignedRevisionLevel;
        public UInt64 MinBlockSize;
        public string Name;
        public bool NeedsCleaning;
        public UInt32 NumberOfMediaSupported;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string RevisionLevel;
        public UInt32 SCSIBus;
        public UInt16 SCSILogicalUnit;
        public UInt16 SCSIPort;
        public UInt16 SCSITargetId;
        public UInt16 SerialNumber;
        public UInt64 Size;
        public string Status;
        public UInt16 StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public Int64 TransferRate;
        public string VolumeName;
        public string VolumeSerialNumber;
    };
}
