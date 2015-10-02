// =====================================//==============================================================//
//                                      //                                                              //
// Source="root\\Collection\\SortMode.cs"                 Copyright © Of Fire Twins Wesp 2015           //
// Author= {"Callada", "Another"}       //                                                              //
// Project="Rc.Framework"               //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                   //                                                              //
// License="root\\LICENSE"              //                                                              //
// LicenseType="MIT"                    //                                                              //
// =====================================//==============================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.Collections
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
