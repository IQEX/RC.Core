using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Windows.Win32
{
    /// <summary>Задает тип печати, разрешенной для выполнения кодом.</summary>
	[Serializable]
    internal enum PrintingPermissionLevel
    {
        /// <summary>Prevents access to printers.<see cref="F:System.Drawing.Printing.PrintingPermissionLevel.NoPrinting" /> is a subset of <see cref="F:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting" />.</summary>
        NoPrinting,
        /// <summary>Provides printing only from a restricted dialog box.<see cref="F:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting" /> is a subset of <see cref="F:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting" />.</summary>
        SafePrinting,
        /// <summary>Provides printing programmatically to the default printer, along with safe printing through semirestricted dialog box.<see cref="F:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting" /> is a subset of <see cref="F:System.Drawing.Printing.PrintingPermissionLevel.AllPrinting" />.</summary>
        DefaultPrinting,
        /// <summary>Обеспечивает полный доступ ко всем принтерам.</summary>
        AllPrinting
    }
    /// <summary>Управляет доступом к принтерам.Этот класс не наследуется.</summary>
	[Serializable]
    internal sealed class PrintingPermission : CodeAccessPermission, IUnrestrictedPermission
    {
        private PrintingPermissionLevel printingLevel;
        /// <summary>Получает или задает уровень кода доступа к печати.</summary>
        /// <returns>Одно из значений <see cref="T:System.Drawing.Printing.PrintingPermissionLevel" />.</returns>
        public PrintingPermissionLevel Level
        {
            get
            {
                return this.printingLevel;
            }
            set
            {
                PrintingPermission.VerifyPrintingLevel(value);
                this.printingLevel = value;
            }
        }
        /// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Printing.PrintingPermission" /> class with either fully restricted or unrestricted access, as specified.</summary>
        /// <param name="state">Одно из значений <see cref="T:System.Security.Permissions.PermissionState" />. </param>
        /// <exception cref="T:System.ArgumentException">Значение параметра <paramref name="state" /> не является допустимым типом <see cref="T:System.Security.Permissions.PermissionState" />. </exception>
        public PrintingPermission(PermissionState state)
        {
            if (state == PermissionState.Unrestricted)
            {
                this.printingLevel = PrintingPermissionLevel.AllPrinting;
                return;
            }
            if (state == PermissionState.None)
            {
                this.printingLevel = PrintingPermissionLevel.NoPrinting;
                return;
            }
            throw new ArgumentException("InvalidPermissionState");
        }
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Drawing.Printing.PrintingPermission" /> с указанным уровнем доступа к печати.</summary>
        /// <param name="printingLevel">Одно из значений <see cref="T:System.Drawing.Printing.PrintingPermissionLevel" />. </param>
        public PrintingPermission(PrintingPermissionLevel printingLevel)
        {
            PrintingPermission.VerifyPrintingLevel(printingLevel);
            this.printingLevel = printingLevel;
        }
        private static void VerifyPrintingLevel(PrintingPermissionLevel level)
        {
            if (level < PrintingPermissionLevel.NoPrinting || level > PrintingPermissionLevel.AllPrinting)
            {
                throw new ArgumentException("InvalidPermissionLevel");
            }
        }
        /// <summary>Получает значение, указывающее, является ли текущее разрешение неограниченным.</summary>
        /// <returns>true, если текущее разрешение является неограниченным; в противном случае — false.</returns>
        public bool IsUnrestricted()
        {
            return this.printingLevel == PrintingPermissionLevel.AllPrinting;
        }
        /// <summary>Определяет, является ли текущее разрешение подмножеством заданного разрешения.</summary>
        /// <returns>Значение равно true, если текущий объект разрешения является подмножеством <paramref name="target" />; в противном случае — false.</returns>
        /// <param name="target">Объект разрешения, для которого требуется проверить соотношение подмножеств.Этот объект должен относиться к тому же типу, что и текущий объект разрешения.</param>
        /// <exception cref="T:System.ArgumentException">Параметр <paramref name="target" /> является объектом, тип которого отличается от текущего объекта разрешения. </exception>
        public override bool IsSubsetOf(IPermission target)
        {
            if (target == null)
            {
                return this.printingLevel == PrintingPermissionLevel.NoPrinting;
            }
            PrintingPermission printingPermission = target as PrintingPermission;
            if (printingPermission == null)
            {
                throw new ArgumentException("TargetNotPrintingPermission");
            }
            return this.printingLevel <= printingPermission.printingLevel;
        }
        /// <summary>Создает и возвращает разрешение, представляющее собой пересечение текущего и целевого объектов разрешения.</summary>
        /// <returns>Новый объект разрешения, представляющий собой пересечение текущего и заданного целевого объектов.Если пересечение пусто, этот объект имеет значение null.</returns>
        /// <param name="target">Разрешение относится к тому же типу, что и текущее разрешение. </param>
        /// <exception cref="T:System.ArgumentException">Параметр <paramref name="target" /> является объектом, тип которого отличается от текущего объекта разрешения. </exception>
        public override IPermission Intersect(IPermission target)
        {
            if (target == null)
            {
                return null;
            }
            PrintingPermission printingPermission = target as PrintingPermission;
            if (printingPermission == null)
            {
                throw new ArgumentException("TargetNotPrintingPermission");
            }
            PrintingPermissionLevel printingPermissionLevel = (this.printingLevel < printingPermission.printingLevel) ? this.printingLevel : printingPermission.printingLevel;
            if (printingPermissionLevel == PrintingPermissionLevel.NoPrinting)
            {
                return null;
            }
            return new PrintingPermission(printingPermissionLevel);
        }
        /// <summary>Создает разрешение, объединяющее объект разрешения и целевой объект разрешения.</summary>
        /// <returns>Новый объект разрешения, представляющий собой объединение текущего и заданного объектов разрешений.</returns>
        /// <param name="target">Разрешение относится к тому же типу, что и текущее разрешение. </param>
        /// <exception cref="T:System.ArgumentException">Параметр <paramref name="target" /> является объектом, тип которого отличается от текущего объекта разрешения. </exception>
        public override IPermission Union(IPermission target)
        {
            if (target == null)
            {
                return this.Copy();
            }
            PrintingPermission printingPermission = target as PrintingPermission;
            if (printingPermission == null)
            {
                throw new ArgumentException("TargetNotPrintingPermission");
            }
            PrintingPermissionLevel printingPermissionLevel = (this.printingLevel > printingPermission.printingLevel) ? this.printingLevel : printingPermission.printingLevel;
            if (printingPermissionLevel == PrintingPermissionLevel.NoPrinting)
            {
                return null;
            }
            return new PrintingPermission(printingPermissionLevel);
        }
        /// <summary>Creates and returns an identical copy of the current permission object.</summary>
        /// <returns>Копия текущего объекта разрешения.</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        /// </PermissionSet>
        public override IPermission Copy()
        {
            return new PrintingPermission(this.printingLevel);
        }
        /// <summary>Создает кодировку XML для объекта безопасности и его текущего состояния.</summary>
        /// <returns>Кодировка XML для объекта безопасности, включая все сведения о состоянии.</returns>
        public override SecurityElement ToXml()
        {
            SecurityElement securityElement = new SecurityElement("IPermission");
            securityElement.AddAttribute("class", base.GetType().FullName + ", " + base.GetType().Module.Assembly.FullName.Replace('"', '\''));
            securityElement.AddAttribute("version", "1");
            if (!this.IsUnrestricted())
            {
                securityElement.AddAttribute("Level", Enum.GetName(typeof(PrintingPermissionLevel), this.printingLevel));
            }
            else
            {
                securityElement.AddAttribute("Unrestricted", "true");
            }
            return securityElement;
        }
        /// <summary>Восстанавливает объект безопасности с определенным состоянием из кодировки XML.</summary>
        /// <param name="esd">Кодировка XML, используемая для восстановления объекта безопасности. </param>
        public override void FromXml(SecurityElement esd)
        {
            if (esd == null)
            {
                throw new ArgumentNullException("esd");
            }
            string text = esd.Attribute("class");
            if (text == null || text.IndexOf(base.GetType().FullName) == -1)
            {
                throw new ArgumentException("InvalidClassName");
            }
            string text2 = esd.Attribute("Unrestricted");
            if (text2 != null && string.Equals(text2, "true", StringComparison.OrdinalIgnoreCase))
            {
                this.printingLevel = PrintingPermissionLevel.AllPrinting;
                return;
            }
            this.printingLevel = PrintingPermissionLevel.NoPrinting;
            string text3 = esd.Attribute("Level");
            if (text3 != null)
            {
                this.printingLevel = (PrintingPermissionLevel)Enum.Parse(typeof(PrintingPermissionLevel), text3);
            }
        }
    }
}
