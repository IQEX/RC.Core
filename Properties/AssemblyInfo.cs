/*
    Project include:
        .NET DiscUtils              (2008-2011, Kenneth Bell ) - https://discutils.codeplex.com
        DotNetZip                   (Ionic's Zip Library     ) - https://dotnetzip.codeplex.com
        YamlSerializer for .NET     (2009 Osamu TAKEUCHI     ) - https://yamlserializer.codeplex.com
        CommonWin32                 (2014 Yin-Chun Wang      ) - https://bitbucket.org/soukoku/commonwin32/
*/

[assembly: System.Reflection.AssemblyTitle          (RC.AssemblyRT.Product)]
[assembly: System.Reflection.AssemblyDescription    (RC.AssemblyRT.Description)]
[assembly: System.Reflection.AssemblyCompany        (RC.AssemblyRT.Company)]
[assembly: System.Reflection.AssemblyProduct        (RC.AssemblyRT.Product)]
[assembly: System.Reflection.AssemblyCopyright      (RC.AssemblyRT.Copyright)]
[assembly: System.Reflection.AssemblyTrademark      (RC.AssemblyRT.Trademark)]
[assembly: System.Runtime.InteropServices.ComVisible(true)]
[assembly: System.Runtime.InteropServices.Guid      (RC.AssemblyRT.GUID)]
[assembly: System.Reflection.AssemblyVersion("2017.11")]
[assembly: System.Reflection.AssemblyFileVersion("2017.11")]

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Vox.Core, "      + RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SAL, "   + RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Qurd, "          + RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DOF.Launcher, "      + RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Qu.Driver, "+ RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Qu.Core, "+ RC.AssemblyRT.PubKey)]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Emul.SQASM, "+ RC.AssemblyRT.PubKey)]

namespace RC
{
    public class AssemblyRT
    {
        public const string Description = "RC.Framework for .NET";
        public const string Company = "HoloVectoR Inc.";
        public const string Product = "RC.Core";
        public const string Copyright = "Copyright © Yuuki Wesp & Alice Wesp (Callada & Another) 2013-2017 and Author Project Include's";
        public const string Trademark = "Alfheim.CE";
        public const string GUID = "35a23b54-4d7b-43a0-8fa5-133feedc8c6a";
        public const string PubKey = "PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f";
    }
}