// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxReader.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="3.2"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    /// <summary>
    /// Интерфейс считывания с "коробки"
    /// </summary>
    public interface IArchByteBoxReader
    {
        /// <summary>
        /// Считывает <see cref="System.Array"/> of <see cref="System.Byte"/>
        /// </summary>
        /// <returns><see cref="System.Array"/> of <see cref="System.Byte"/></returns>
        byte[] rByte();
        /// <summary>
        /// Считывает <see cref="System.String"/>
        /// </summary>
        /// <returns><see cref="System.String"/></returns>
        string rString();
        /// <summary>
        /// Считывает <see cref="System.Int16"/>
        /// </summary>
        /// <returns><see cref="System.Int16"/></returns>
        short rShort();
        /// <summary>
        /// Считывает <see cref="System.Single"/>
        /// </summary>
        /// <returns><see cref="System.Single"/></returns>
        float rFloat();
        /// <summary>
        /// Считывает <see cref="System.Int32"/>
        /// </summary>
        /// <returns><see cref="System.Int32"/></returns>
        int rInt();
        /// <summary>
        /// Считывает <see cref="System.Int64"/>
        /// </summary>
        /// <returns><see cref="System.Int64"/></returns>
        long rLong();
        /// <summary>
        /// Считывает <see cref="System.Boolean"/>
        /// </summary>
        /// <returns><see cref="System.Boolean"/></returns>
        bool rBool();
        /// <summary>
        /// Считывает <see cref="System.UInt64"/>
        /// </summary>
        /// <returns><see cref="System.UInt64"/></returns>
        ulong rULong();
        /// <summary>
        /// Считывает <see cref="System.UInt16"/>
        /// </summary>
        /// <returns><see cref="System.UInt16"/></returns>
        ushort rUShort();
        /// <summary>
        /// Считывает <see cref="System.UInt32"/>
        /// </summary>
        /// <returns><see cref="System.UInt32"/></returns>
        uint rUInt();
        /// <summary>
        /// Считывает <see cref="RMath.IntRange"/>
        /// </summary>
        /// <returns><see cref="RMath.IntRange"/></returns>
        RMath.IntRange rIRange();
        /// <summary>
        /// Считывает <see cref="RMath.Range"/>
        /// </summary>
        /// <returns><see cref="RMath.Range"/></returns>
        RMath.Range rFRange();
        /// <summary>
        /// Считывает <see cref="System.DateTime.Ticks"/>
        /// </summary>
        /// <returns><see cref="System.DateTime"/></returns>
        System.DateTime rDateTime();
        /// <summary>
        /// Считывает <see cref="System.Guid"/>
        /// </summary>
        /// <returns><see cref="System.Guid"/></returns>
        System.Guid rGUID();
        /// <summary>
        /// Создает неполную копию текущего объекта
        /// </summary>
        /// <returns>Неполная копия</returns>
        IArchByteBoxReader Clone();
    }
}