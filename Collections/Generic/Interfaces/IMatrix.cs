// =====================================//==============================================================//
// License="root\\LICENSE"              //   Copyright © Of Fire Twins Wesp 2015  <ls-micro@ya.ru>      //
// LicenseType="MIT"                    //                  Alise Wesp & Yuuki Wesp                     //
// =====================================//==============================================================//
using System.Collections.Generic;

namespace RC.Framework.Collections.Generic
{
    /// <summary>
    ///     Matrix
    /// </summary>
    /// <typeparam name="T">
    ///     Matrix value
    /// </typeparam>
    public interface IMatrix<T> : IEnumerator<T>, IEnumerable<T>
    {
        /// <summary>
        /// Индексатор представляющий матрицу.
        /// </summary>
        T this[int x, int y] { get; set; }
        /// <summary>
        /// Размерность матрицы. X - количество строк, Y - количество столбцов(полей)
        /// </summary>
        SizeMatrix Size { get; }
        /// <summary>
        /// Возвращает транспонированную матрицу. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> Transpose { get; }
        /// <summary>
        /// Тип матрицы (квадратная, прямоугольная)
        /// </summary>
        TypeMatrix TypeM { get; }
        /// <summary>
        /// Создает копию матрицы
        /// </summary>
        Matrix<T> Clone();
        /// <summary>
        /// Возвращает матрицу без указанных строки и столбца. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> Exclude(int row, int column);
        /// <summary>
        /// Возвращает матрицу без указанного столбца. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> ExcludeColumn(params int[] column);
        /// <summary>
        /// Возвращает матрицу без указанной строки. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> ExcludeRow(params int[] row);
        /// <summary>
        /// Возвращает массив соответствующий указанному столбцу матрицы. Отсчет столбцов идет с 0.
        /// </summary>
        T[] GetColumn(int column);
        /// <summary>
        /// Возвращает индекс максимального элемента в указанном столбце.
        /// </summary>
        int GetMaxColumnIndex(int column);
        /// <summary>
        /// Возвращает позицию максимального элемента в матрице.
        /// </summary>
        Position GetMaxIndex();
        /// <summary>
        /// Возвращает индекс максимального элемента в указанной строке.
        /// </summary>
        int GetMaxRowIndex(int row);
        /// <summary>
        /// Возвращает индекс максимального элемента в указанном столбце.
        /// </summary>
        int GetMinColumnIndex(int column);
        /// <summary>
        /// Возвращает позицию минимального элемента в матрице.
        /// </summary>
        /// <returns></returns>
        Position GetMinIndex();
        /// <summary>
        /// Возвращает индекс минимального элемента в указанной строке.
        /// </summary>
        int GetMinRowIndex(int row);
        /// <summary>
        /// Возвращает массив соответствующий указанной строке матрицы. Отсчет строк идет с 0.
        /// </summary>
        T[] GetRow(int row);
        /// <summary>
        /// Инициализация матрицы. Вызывается при создании экземпляра класса. Ручной вызов нужен для изменения размера матрицы и заполнения значениями по-умолчанию.
        /// </summary>
        void InitMatrix(SizeMatrix size, TypeMatrix type);
        /// <summary>
        /// Меняет местами указанные столбцы. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> MoveColumn(int source, int target);
        /// <summary>
        /// Меняет указанные строки местами. Исходная матрица не изменяется.
        /// </summary>
        Matrix<T> MoveRow(int source, int target);
        /// <summary>
        /// Меняет местами диагонали матрицы. Исходная матрица не изменяется.
        /// </summary>
        /// <returns></returns>
        Matrix<T> ReversDiagonal();
        /// <summary>
        /// Заполняет матрицу из одномерного массива.
        /// </summary>
        void SetArray(T[] array);
        /// <summary>
        /// Заполняет указанный столбец значениями из массива. Если размеры столбца и массива не совпадают - столбец либо будет заполнен не полностью, либо "лишние" значения массива будут проигнорированы.
        /// </summary>
        void SetColumn(T[] columnValues, int column);
        /// <summary>
        /// Меняет указанные строки местами. Исходная матрица не изменяется.
        /// </summary>
        void SetRow(T[] rowValues, int row);
        /// <summary>
        /// Преобразует матрицу в одномерный массив.
        /// </summary>
        T[] ToArray();
        string ToString();
    }
}