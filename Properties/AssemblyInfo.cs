using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("RC.Core")]
[assembly: AssemblyDescription("Rc.Framework")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("AGT-Soul")]
[assembly: AssemblyProduct("RC.Core")]
[assembly: AssemblyCopyright("Copyright © Yuuki Wesp 2015")]
[assembly: AssemblyTrademark("RC Soul")]
[assembly: AssemblyCulture("")]

// Параметр ComVisible со значением FALSE делает типы в сборке невидимыми 
// для COM-компонентов.  Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("35a23b54-4d7b-43a0-8fa5-133feedc8c6a")]

// Сведения о версии сборки состоят из следующих четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии 
//   Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("7.7.2466.0")]
[assembly: AssemblyFileVersion("7.7.0.0")]
[assembly: InternalsVisibleTo("AppUnitTest, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Vox.Core, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Spell.Core, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Spell.Logical, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("GameBase, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Archvation, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Constructor, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("SpellLauncher, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Qurd, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Launcher, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Xml.Tree.Packages, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("VirtualOS, PublicKey=002400000480000094000000060200000024000052534131000400000100010039e50bf6193da3" +
                                                  "93d5cf03d6abd2363f45f1488a851109ff0a9185e3a83d7fce98c133945e4775877e0c48a7c9ce" +
                                                  "3fde4b0d2480aa60d65ab2c1247c2e3c37aab23b72ea9f386a83fe364f3c43c46f34abc2939420" +
                                                  "5a14b0fca6952bfdebc242198fc1520fee30e62e7c4fde6c2355736fa0ea8da90dfe7d5e087f1c" +
                                                  "3f36fd9f")]
[assembly: InternalsVisibleTo("Internals.Rc.Core.dll")]