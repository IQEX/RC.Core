// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System;
using System.Reflection;

namespace Rc.Framework.Native.Runtime.Shadow
{
    /// <summary>
    /// Shadow attribute used to associate a COM callbackable interface to its Shadow implementation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    internal class ShadowAttribute : Attribute
    {
        private Type type;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public Type Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ShadowAttribute"/> class.
        /// </summary>
        /// <param name="typeOfTheAssociatedShadow">Type of the associated shadow</param>
        public ShadowAttribute(Type typeOfTheAssociatedShadow)
        {
            type = typeOfTheAssociatedShadow;
        }

        /// <summary>
        /// Get ShadowAttribute from type.
        /// </summary>
        /// <param name="type">Type to get shadow attribute</param>
        /// <returns>The associated shadow attribute or null if no shadow attribute were found</returns>
        public static ShadowAttribute Get(Type type)
        {
            return type.GetTypeInfo().GetCustomAttribute<ShadowAttribute>();
        }
    }
}
