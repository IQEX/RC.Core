// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Rc.Core.CppModel
{
    /// <summary>
    /// A C++ module contains includes.
    /// </summary>
    public class CppModule : CppElement
    {
        internal const string NS = "urn:RC.Core.CppModel";
        /// <summary>
        ///     Gets the full name.
        /// </summary>
        /// <value>
        ///     The full name.
        /// </value>
        public override string FullName
        {
            get { return ""; }
        }
        /// <summary>
        ///     Gets the includes.
        /// </summary>
        /// <value>
        ///     The includes.
        /// </value>
        public IEnumerable<CppInclude> Includes
        {
            get { return Iterate<CppInclude>(); }
        }
        /// <summary>
        ///     Finds the include.
        /// </summary>
        /// <param name="includeName">
        ///     Name of the include.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public CppInclude FindInclude(string includeName)
        {
            return (from cppElement in Iterate<CppInclude>()
                    where cppElement.Name == includeName
                    select cppElement).FirstOrDefault();
        }
        /// <summary>
        ///     Reads the module from the specified file.
        /// </summary>
        /// <param name="file">
        ///     The file.
        /// </param>
        /// <returns>
        ///     A C++ module
        /// </returns>
        public static CppModule Read(string file)
        {
            var input = new FileStream(file, FileMode.Open);
            var result = Read(input);
            input.Close();
            return result;
        }
        /// <summary>
        ///     Reads the module from the specified input.
        /// </summary>
        /// <param name="input">
        ///     The input.
        /// </param>
        /// <returns>
        ///     A C++ module
        /// </returns>
        public static CppModule Read(Stream input)
        {
            var ds = new XmlSerializer(typeof (CppModule));

            CppModule module = null;
            using (XmlReader w = XmlReader.Create(input))
            {
                module = ds.Deserialize(w) as CppModule;
            }
            if (module != null)
                module.ResetParents();
            return module;
        }
        /// <summary>
        ///     Writes this instance to the specified file.
        /// </summary>
        /// <param name="file">
        ///     The file.
        /// </param>
        public void Write(string file)
        {
            var output = new FileStream(file, FileMode.Create);
            Write(output);
            output.Close();
        }
        /// <summary>
        ///     Writes this instance to the specified output.
        /// </summary>
        /// <param name="output">
        ///     The output.
        /// </param>
        public void Write(Stream output)
        {
            var ds = new XmlSerializer(typeof (CppModule));

            var settings = new XmlWriterSettings() {Indent = true};
            using (XmlWriter w = XmlWriter.Create(output, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", NS);
                ds.Serialize(w, this, ns);
            }
        }    
    }
}