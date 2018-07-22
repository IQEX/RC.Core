// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2014  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
namespace RC.Framework.Collections.Generic
{
    /// <summary>
    /// Класс методов сортировки
    /// </summary>
    public class SortMode
    {
        /// <summary>
        /// Меняет местами значения в массиве по индексу.
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <param name="items">Массив</param>
        /// <param name="left">Левый индекс</param>
        /// <param name="right">Правый индекс</param>
        public void Swap<T>(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }
    }
}
