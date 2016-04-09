// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Net
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
        byte[] toArray();
        /// <summary>
        /// Запись массива байтов
        /// </summary>
        /// <param name="value"></param>
        void wB(byte[] value);
        /// <summary>
        /// Запись массива байтов
        /// </summary>
        /// <param name="value"></param>
        void wNB(byte[] value);
        /// <summary>
        /// Запись строки
        /// </summary>
        /// <param name="value"></param>
        void wSt(string value);
        /// <summary>
        /// Запись <see cref="System.Int16"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int16"/></param>
        void wS(short value);
        /// <summary>
        /// Запись <see cref="System.Single"/>
        /// </summary>
        /// <param name="value"><see cref="System.Single"/></param>
        void wF(float value);
        /// <summary>
        /// Запись <see cref="System.Int64"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int64"/></param>
        void wL(long value);
        /// <summary>
        /// Запись <see cref="System.Int32"/>
        /// </summary>
        /// <param name="value"><see cref="System.Int32"/></param>
        void wI(int value);
        /// <summary>
        /// Запись <see cref="System.UInt64"/>
        /// </summary>
        /// <param name="value"><see cref="System.UInt64"/></param>
        void wUl(ulong value);
        /// <summary>
        /// Запись <see cref="System.UInt32"/>
        /// </summary>
        /// <param name="value"><see cref="System.UInt32"/></param>
        void wUI(uint value);
        /// <summary>
        /// Запись <see cref="ushort"/>
        /// </summary>
        /// <param name="value"><see cref="ushort"/></param>
        void wUS(ushort value);
        /// <summary>
        /// Запись <see cref="bool"/>
        /// </summary>
        /// <param name="value"><see cref="bool"/></param>
        void wB(bool value);
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