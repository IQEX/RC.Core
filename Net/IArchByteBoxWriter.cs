// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Net\\IArchByteBoxWriter.cs"           Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="7.7"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
namespace Rc.Framework.Net
{
    /// <summary>
    /// Интерфейс записи в "коробку"
    /// </summary>
    public interface IArchByteBoxWriter
    {
        /// <summary>
        /// Получение массива байтов "коробки"
        /// </summary>
        /// <returns>Массив "коробки"</returns>
        byte[] GetAll();
        /// <summary>
        /// Запись массива байтов
        /// </summary>
        /// <param name="value"></param>
        void wByte(byte[] value);
        /// <summary>
        /// Запись строки
        /// </summary>
        /// <param name="value"></param>
        void wString(string value);
        /// <summary>
        /// Запись <see cref="System.Int16"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int16"/></param>
        void wShort(short value);
        /// <summary>
        /// Запись <see cref="System.Single"/>
        /// </summary>
        /// <param name="value"><see cref="System.Single"/></param>
        void wFloat(float value);
        /// <summary>
        /// Запись <see cref="System.Int64"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int64"/></param>
        void wLong(long value);
        /// <summary>
        /// Запись <see cref="System.Int32"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int32"/></param>
        void wInt(int value);
        /// <summary>
        /// Запись <see cref="System.UInt64"/>
        /// </summary>
        /// <param name="value"><see cref="System.UInt64"/></param>
        void wULong(ulong value);
        /// <summary>
        /// Запись <see cref="System.UInt32"/>
        /// </summary>
        /// <param name="value"><see cref="System.UInt32"/></param>
        void wUInt(uint value);
        /// <summary>
        /// Запись <see cref="ushort"/>
        /// </summary>
        /// <param name="value"><see cref="ushort"/></param>
        void wUShort(ushort value);
        /// <summary>
        /// Запись <see cref="bool"/>
        /// </summary>
        /// <param name="value"><see cref="bool"/></param>
        void wBool(bool value);
        /// <summary>
        /// Запись <see cref="System.Guid"/>
        /// </summary>
        /// <param name="value"><see cref="System.Guid"/></param>
        void wGUID(System.Guid value);
        /// <summary>
        /// Запись <see cref="System.DateTime"/>
        /// </summary>
        /// <param name="DT"><see cref="System.DateTime"/></param>
        /// <param name="isBinary">Бинарное?</param>
        void wDateTime(System.DateTime DT, bool isBinary = false);
        /// <summary>
        /// Запись <see cref="RMath.Range"/>
        /// </summary>
        /// <param name="value"><see cref="RMath.Range"/></param>
        void wFRange(RMath.Range value);
        /// <summary>
        /// Запись <see cref="RMath.IntRange"/>
        /// </summary>
        /// <param name="value"><see cref="RMath.IntRange"/></param>
        void wIRange(RMath.IntRange value);
        /// <summary>
        /// Создает неполную копию текущего объекта
        /// </summary>
        /// <returns></returns>
        IArchByteBoxWriter Clone();
    }
}