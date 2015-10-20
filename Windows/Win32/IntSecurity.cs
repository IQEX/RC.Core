
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace Rc.Framework.Windows.Win32
{
    internal static class IntSecurity
    {
        public static readonly TraceSwitch SecurityDemand = new TraceSwitch("SecurityDemand", "Trace when security demands occur.");
        private static CodeAccessPermission adjustCursorClip;
        private static CodeAccessPermission affectMachineState;
        private static CodeAccessPermission affectThreadBehavior;
        private static CodeAccessPermission allPrinting;
        private static PermissionSet allPrintingAndUnmanagedCode;
        private static CodeAccessPermission allWindows;
        private static CodeAccessPermission clipboardRead;
        private static CodeAccessPermission clipboardOwn;
        private static PermissionSet clipboardWrite;
        private static CodeAccessPermission changeWindowRegionForTopLevel;
        private static CodeAccessPermission controlFromHandleOrLocation;
        private static CodeAccessPermission createAnyWindow;
        private static CodeAccessPermission createGraphicsForControl;
        private static CodeAccessPermission defaultPrinting;
        private static CodeAccessPermission fileDialogCustomization;
        private static CodeAccessPermission fileDialogOpenFile;
        private static CodeAccessPermission fileDialogSaveFile;
        private static CodeAccessPermission getCapture;
        private static CodeAccessPermission getParent;
        private static CodeAccessPermission manipulateWndProcAndHandles;
        private static CodeAccessPermission modifyCursor;
        private static CodeAccessPermission modifyFocus;
        private static CodeAccessPermission objectFromWin32Handle;
        private static CodeAccessPermission safePrinting;
        private static CodeAccessPermission safeSubWindows;
        private static CodeAccessPermission safeTopLevelWindows;
        private static CodeAccessPermission sendMessages;
        private static CodeAccessPermission sensitiveSystemInformation;
        private static CodeAccessPermission transparentWindows;
        private static CodeAccessPermission topLevelWindow;
        private static CodeAccessPermission unmanagedCode;
        private static CodeAccessPermission unrestrictedWindows;
        private static CodeAccessPermission windowAdornmentModification;
        public static CodeAccessPermission AdjustCursorClip
        {
            get
            {
                if (IntSecurity.adjustCursorClip == null)
                {
                    IntSecurity.adjustCursorClip = IntSecurity.AllWindows;
                }
                return IntSecurity.adjustCursorClip;
            }
        }
        public static CodeAccessPermission AdjustCursorPosition
        {
            get
            {
                return IntSecurity.AllWindows;
            }
        }
        public static CodeAccessPermission AffectMachineState
        {
            get
            {
                if (IntSecurity.affectMachineState == null)
                {
                    IntSecurity.affectMachineState = IntSecurity.UnmanagedCode;
                }
                return IntSecurity.affectMachineState;
            }
        }
        public static CodeAccessPermission AffectThreadBehavior
        {
            get
            {
                if (IntSecurity.affectThreadBehavior == null)
                {
                    IntSecurity.affectThreadBehavior = IntSecurity.UnmanagedCode;
                }
                return IntSecurity.affectThreadBehavior;
            }
        }
        public static CodeAccessPermission AllPrinting
        {
            get
            {
                if (IntSecurity.allPrinting == null)
                {
                    IntSecurity.allPrinting = new PrintingPermission(PrintingPermissionLevel.AllPrinting);
                }
                return IntSecurity.allPrinting;
            }
        }
        public static PermissionSet AllPrintingAndUnmanagedCode
        {
            get
            {
                if (IntSecurity.allPrintingAndUnmanagedCode == null)
                {
                    PermissionSet expr_0D = new PermissionSet(PermissionState.None);
                    expr_0D.SetPermission(IntSecurity.UnmanagedCode);
                    expr_0D.SetPermission(IntSecurity.AllPrinting);
                    IntSecurity.allPrintingAndUnmanagedCode = expr_0D;
                }
                return IntSecurity.allPrintingAndUnmanagedCode;
            }
        }
        public static CodeAccessPermission AllWindows
        {
            get
            {
                if (IntSecurity.allWindows == null)
                {
                    IntSecurity.allWindows = new UIPermission(UIPermissionWindow.AllWindows);
                }
                return IntSecurity.allWindows;
            }
        }
        public static CodeAccessPermission ClipboardRead
        {
            get
            {
                if (IntSecurity.clipboardRead == null)
                {
                    IntSecurity.clipboardRead = new UIPermission(UIPermissionClipboard.AllClipboard);
                }
                return IntSecurity.clipboardRead;
            }
        }
        public static CodeAccessPermission ClipboardOwn
        {
            get
            {
                if (IntSecurity.clipboardOwn == null)
                {
                    IntSecurity.clipboardOwn = new UIPermission(UIPermissionClipboard.OwnClipboard);
                }
                return IntSecurity.clipboardOwn;
            }
        }
        public static PermissionSet ClipboardWrite
        {
            get
            {
                if (IntSecurity.clipboardWrite == null)
                {
                    IntSecurity.clipboardWrite = new PermissionSet(PermissionState.None);
                    IntSecurity.clipboardWrite.SetPermission(IntSecurity.UnmanagedCode);
                    IntSecurity.clipboardWrite.SetPermission(IntSecurity.ClipboardOwn);
                }
                return IntSecurity.clipboardWrite;
            }
        }
        public static CodeAccessPermission ChangeWindowRegionForTopLevel
        {
            get
            {
                if (IntSecurity.changeWindowRegionForTopLevel == null)
                {
                    IntSecurity.changeWindowRegionForTopLevel = IntSecurity.AllWindows;
                }
                return IntSecurity.changeWindowRegionForTopLevel;
            }
        }
        public static CodeAccessPermission ControlFromHandleOrLocation
        {
            get
            {
                if (IntSecurity.controlFromHandleOrLocation == null)
                {
                    IntSecurity.controlFromHandleOrLocation = IntSecurity.AllWindows;
                }
                return IntSecurity.controlFromHandleOrLocation;
            }
        }
        public static CodeAccessPermission CreateAnyWindow
        {
            get
            {
                if (IntSecurity.createAnyWindow == null)
                {
                    IntSecurity.createAnyWindow = IntSecurity.SafeSubWindows;
                }
                return IntSecurity.createAnyWindow;
            }
        }
        public static CodeAccessPermission CreateGraphicsForControl
        {
            get
            {
                if (IntSecurity.createGraphicsForControl == null)
                {
                    IntSecurity.createGraphicsForControl = IntSecurity.SafeSubWindows;
                }
                return IntSecurity.createGraphicsForControl;
            }
        }
        public static CodeAccessPermission DefaultPrinting
        {
            get
            {
                if (IntSecurity.defaultPrinting == null)
                {
                    IntSecurity.defaultPrinting = new PrintingPermission(PrintingPermissionLevel.DefaultPrinting);
                }
                return IntSecurity.defaultPrinting;
            }
        }
        public static CodeAccessPermission FileDialogCustomization
        {
            get
            {
                if (IntSecurity.fileDialogCustomization == null)
                {
                    IntSecurity.fileDialogCustomization = new FileIOPermission(PermissionState.Unrestricted);
                }
                return IntSecurity.fileDialogCustomization;
            }
        }
        public static CodeAccessPermission FileDialogOpenFile
        {
            get
            {
                if (IntSecurity.fileDialogOpenFile == null)
                {
                    IntSecurity.fileDialogOpenFile = new FileDialogPermission(FileDialogPermissionAccess.Open);
                }
                return IntSecurity.fileDialogOpenFile;
            }
        }
        public static CodeAccessPermission FileDialogSaveFile
        {
            get
            {
                if (IntSecurity.fileDialogSaveFile == null)
                {
                    IntSecurity.fileDialogSaveFile = new FileDialogPermission(FileDialogPermissionAccess.Save);
                }
                return IntSecurity.fileDialogSaveFile;
            }
        }
        public static CodeAccessPermission GetCapture
        {
            get
            {
                if (IntSecurity.getCapture == null)
                {
                    IntSecurity.getCapture = IntSecurity.AllWindows;
                }
                return IntSecurity.getCapture;
            }
        }
        public static CodeAccessPermission GetParent
        {
            get
            {
                if (IntSecurity.getParent == null)
                {
                    IntSecurity.getParent = IntSecurity.AllWindows;
                }
                return IntSecurity.getParent;
            }
        }
        public static CodeAccessPermission ManipulateWndProcAndHandles
        {
            get
            {
                if (IntSecurity.manipulateWndProcAndHandles == null)
                {
                    IntSecurity.manipulateWndProcAndHandles = IntSecurity.AllWindows;
                }
                return IntSecurity.manipulateWndProcAndHandles;
            }
        }
        public static CodeAccessPermission ModifyCursor
        {
            get
            {
                if (IntSecurity.modifyCursor == null)
                {
                    IntSecurity.modifyCursor = IntSecurity.SafeSubWindows;
                }
                return IntSecurity.modifyCursor;
            }
        }
        public static CodeAccessPermission ModifyFocus
        {
            get
            {
                if (IntSecurity.modifyFocus == null)
                {
                    IntSecurity.modifyFocus = IntSecurity.AllWindows;
                }
                return IntSecurity.modifyFocus;
            }
        }
        public static CodeAccessPermission ObjectFromWin32Handle
        {
            get
            {
                if (IntSecurity.objectFromWin32Handle == null)
                {
                    IntSecurity.objectFromWin32Handle = IntSecurity.UnmanagedCode;
                }
                return IntSecurity.objectFromWin32Handle;
            }
        }
        public static CodeAccessPermission SafePrinting
        {
            get
            {
                if (IntSecurity.safePrinting == null)
                {
                    IntSecurity.safePrinting = new PrintingPermission(PrintingPermissionLevel.SafePrinting);
                }
                return IntSecurity.safePrinting;
            }
        }
        public static CodeAccessPermission SafeSubWindows
        {
            get
            {
                if (IntSecurity.safeSubWindows == null)
                {
                    IntSecurity.safeSubWindows = new UIPermission(UIPermissionWindow.SafeSubWindows);
                }
                return IntSecurity.safeSubWindows;
            }
        }
        public static CodeAccessPermission SafeTopLevelWindows
        {
            get
            {
                if (IntSecurity.safeTopLevelWindows == null)
                {
                    IntSecurity.safeTopLevelWindows = new UIPermission(UIPermissionWindow.SafeTopLevelWindows);
                }
                return IntSecurity.safeTopLevelWindows;
            }
        }
        public static CodeAccessPermission SendMessages
        {
            get
            {
                if (IntSecurity.sendMessages == null)
                {
                    IntSecurity.sendMessages = IntSecurity.UnmanagedCode;
                }
                return IntSecurity.sendMessages;
            }
        }
        public static CodeAccessPermission SensitiveSystemInformation
        {
            get
            {
                if (IntSecurity.sensitiveSystemInformation == null)
                {
                    IntSecurity.sensitiveSystemInformation = new EnvironmentPermission(PermissionState.Unrestricted);
                }
                return IntSecurity.sensitiveSystemInformation;
            }
        }
        public static CodeAccessPermission TransparentWindows
        {
            get
            {
                if (IntSecurity.transparentWindows == null)
                {
                    IntSecurity.transparentWindows = IntSecurity.AllWindows;
                }
                return IntSecurity.transparentWindows;
            }
        }
        public static CodeAccessPermission TopLevelWindow
        {
            get
            {
                if (IntSecurity.topLevelWindow == null)
                {
                    IntSecurity.topLevelWindow = IntSecurity.SafeTopLevelWindows;
                }
                return IntSecurity.topLevelWindow;
            }
        }
        public static CodeAccessPermission UnmanagedCode
        {
            get
            {
                if (IntSecurity.unmanagedCode == null)
                {
                    IntSecurity.unmanagedCode = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
                }
                return IntSecurity.unmanagedCode;
            }
        }
        public static CodeAccessPermission UnrestrictedWindows
        {
            get
            {
                if (IntSecurity.unrestrictedWindows == null)
                {
                    IntSecurity.unrestrictedWindows = IntSecurity.AllWindows;
                }
                return IntSecurity.unrestrictedWindows;
            }
        }
        public static CodeAccessPermission WindowAdornmentModification
        {
            get
            {
                if (IntSecurity.windowAdornmentModification == null)
                {
                    IntSecurity.windowAdornmentModification = IntSecurity.AllWindows;
                }
                return IntSecurity.windowAdornmentModification;
            }
        }
        internal static string UnsafeGetFullPath(string fileName)
        {
            string result = fileName;
            new FileIOPermission(PermissionState.None)
            {
                AllFiles = FileIOPermissionAccess.PathDiscovery
            }.Assert();
            try
            {
                result = Path.GetFullPath(fileName);
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
            return result;
        }
        internal static void DemandFileIO(FileIOPermissionAccess access, string fileName)
        {
            new FileIOPermission(access, IntSecurity.UnsafeGetFullPath(fileName)).Demand();
        }
    }
}
