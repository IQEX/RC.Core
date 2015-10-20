// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace Rc.Framework.Collections.Generic
{
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    /// <typeparam name="T3">Field Generic</typeparam>
    /// <typeparam name="T4">Field Generic</typeparam>
    public interface IBox<T1, T2, T3, T4>
    {
        /// <summary>
        /// Field Generic
        /// </summary>
        T1 t1 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T2 t2 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T3 t3 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T4 t4 { get; set; }
    }
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    /// <typeparam name="T3">Field Generic</typeparam>
    public interface IBox1<T1, T2, T3>
    {
        /// <summary>
        /// Field Generic
        /// </summary>
        T1 t1 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T2 t2 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T3 t3 { get; set; }
    }
    /// <summary>
    /// Box Type
    /// </summary>
    /// <typeparam name="T1">Field Generic</typeparam>
    /// <typeparam name="T2">Field Generic</typeparam>
    public interface IBox2<T1, T2>
    {
        /// <summary>
        /// Field Generic
        /// </summary>
        T1 t1 { get; set; }
        /// <summary>
        /// Field Generic
        /// </summary>
        T2 t2 { get; set; }
    }
}