using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// Set of tool functions.
	/// </summary>
	///
	/// <remarks>The class contains different utility functions.</remarks>
	public static class RMath
    {
        /// <summary>
        /// Calculates power of 2.
        /// </summary>
        ///
        /// <param name="power">Power to raise in.</param>
        ///
        /// <returns>Returns specified power of 2 in the case if power is in the range of
        /// [0, 30]. Otherwise returns 0.</returns>
        public static int Pow2(int power)
        {
            if (power < 0 || power > 30)
            {
                return 0;
            }
            return 1 << power;
        }
        /// <summary>
        /// Checks if the specified integer is power of 2.
        /// </summary>
        ///
        /// <param name="x">Integer number to check.</param>
        ///
        /// <returns>Returns <b>true</b> if the specified number is power of 2.
        /// Otherwise returns <b>false</b>.</returns>
        public static bool IsPowerOf2(int x)
        {
            return x > 0 && (x & x - 1) == 0;
        }
        /// <summary>
        /// Get base of binary logarithm.
        /// </summary>
        ///
        /// <param name="x">Source integer number.</param>
        ///
        /// <returns>Power of the number (base of binary logarithm).</returns>
        public static int Log2(int x)
        {
            if (x <= 65536)
            {
                if (x <= 256)
                {
                    if (x <= 16)
                    {
                        if (x <= 4)
                        {
                            if (x > 2)
                            {
                                return 2;
                            }
                            if (x <= 1)
                            {
                                return 0;
                            }
                            return 1;
                        }
                        else
                        {
                            if (x <= 8)
                            {
                                return 3;
                            }
                            return 4;
                        }
                    }
                    else if (x <= 64)
                    {
                        if (x <= 32)
                        {
                            return 5;
                        }
                        return 6;
                    }
                    else
                    {
                        if (x <= 128)
                        {
                            return 7;
                        }
                        return 8;
                    }
                }
                else if (x <= 4096)
                {
                    if (x <= 1024)
                    {
                        if (x <= 512)
                        {
                            return 9;
                        }
                        return 10;
                    }
                    else
                    {
                        if (x <= 2048)
                        {
                            return 11;
                        }
                        return 12;
                    }
                }
                else if (x <= 16384)
                {
                    if (x <= 8192)
                    {
                        return 13;
                    }
                    return 14;
                }
                else
                {
                    if (x <= 32768)
                    {
                        return 15;
                    }
                    return 16;
                }
            }
            else if (x <= 16777216)
            {
                if (x <= 1048576)
                {
                    if (x <= 262144)
                    {
                        if (x <= 131072)
                        {
                            return 17;
                        }
                        return 18;
                    }
                    else
                    {
                        if (x <= 524288)
                        {
                            return 19;
                        }
                        return 20;
                    }
                }
                else if (x <= 4194304)
                {
                    if (x <= 2097152)
                    {
                        return 21;
                    }
                    return 22;
                }
                else
                {
                    if (x <= 8388608)
                    {
                        return 23;
                    }
                    return 24;
                }
            }
            else if (x <= 268435456)
            {
                if (x <= 67108864)
                {
                    if (x <= 33554432)
                    {
                        return 25;
                    }
                    return 26;
                }
                else
                {
                    if (x <= 134217728)
                    {
                        return 27;
                    }
                    return 28;
                }
            }
            else
            {
                if (x > 1073741824)
                {
                    return 31;
                }
                if (x <= 536870912)
                {
                    return 29;
                }
                return 30;
            }
        }
        public static void svdcmp(double[,] a, out double[] w, out double[,] v)
        {
            int length = a.GetLength(0);
            int length2 = a.GetLength(1);
            if (length < length2)
            {
                throw new ArgumentException("Number of rows in A must be greater or equal to number of columns");
            }
            w = new double[length2];
            v = new double[length2, length2];
            int i = 0;
            int num = 0;
            double[] array = new double[length2];
            double num4;
            double num3;
            double num2 = num3 = (num4 = 0.0);
            for (int j = 0; j < length2; j++)
            {
                i = j + 1;
                array[j] = num2 * num3;
                double num5 = num3 = (num2 = 0.0);
                if (j < length)
                {
                    for (int k = j; k < length; k++)
                    {
                        num2 += Math.Abs(a[k, j]);
                    }
                    if (num2 != 0.0)
                    {
                        for (int k = j; k < length; k++)
                        {
                            a[k, j] /= num2;
                            num5 += a[k, j] * a[k, j];
                        }
                        double num6 = a[j, j];
                        num3 = -Sign(Math.Sqrt(num5), num6);
                        double num7 = num6 * num3 - num5;
                        a[j, j] = num6 - num3;
                        if (j != length2 - 1)
                        {
                            for (int l = i; l < length2; l++)
                            {
                                num5 = 0.0;
                                for (int k = j; k < length; k++)
                                {
                                    num5 += a[k, j] * a[k, l];
                                }
                                num6 = num5 / num7;
                                for (int k = j; k < length; k++)
                                {
                                    a[k, l] += num6 * a[k, j];
                                }
                            }
                        }
                        for (int k = j; k < length; k++)
                        {
                            a[k, j] *= num2;
                        }
                    }
                }
                w[j] = num2 * num3;
                num5 = (num3 = (num2 = 0.0));
                if (j < length && j != length2 - 1)
                {
                    for (int k = i; k < length2; k++)
                    {
                        num2 += Math.Abs(a[j, k]);
                    }
                    if (num2 != 0.0)
                    {
                        for (int k = i; k < length2; k++)
                        {
                            a[j, k] /= num2;
                            num5 += a[j, k] * a[j, k];
                        }
                        double num6 = a[j, i];
                        num3 = -Sign(Math.Sqrt(num5), num6);
                        double num7 = num6 * num3 - num5;
                        a[j, i] = num6 - num3;
                        for (int k = i; k < length2; k++)
                        {
                            array[k] = a[j, k] / num7;
                        }
                        if (j != length - 1)
                        {
                            for (int l = i; l < length; l++)
                            {
                                num5 = 0.0;
                                for (int k = i; k < length2; k++)
                                {
                                    num5 += a[l, k] * a[j, k];
                                }
                                for (int k = i; k < length2; k++)
                                {
                                    a[l, k] += num5 * array[k];
                                }
                            }
                        }
                        for (int k = i; k < length2; k++)
                        {
                            a[j, k] *= num2;
                        }
                    }
                }
                num4 = Math.Max(num4, Math.Abs(w[j]) + Math.Abs(array[j]));
            }
            for (int j = length2 - 1; j >= 0; j--)
            {
                if (j < length2 - 1)
                {
                    if (num3 != 0.0)
                    {
                        for (int l = i; l < length2; l++)
                        {
                            v[l, j] = a[j, l] / a[j, i] / num3;
                        }
                        for (int l = i; l < length2; l++)
                        {
                            double num5 = 0.0;
                            for (int k = i; k < length2; k++)
                            {
                                num5 += a[j, k] * v[k, l];
                            }
                            for (int k = i; k < length2; k++)
                            {
                                v[k, l] += num5 * v[k, j];
                            }
                        }
                    }
                    for (int l = i; l < length2; l++)
                    {
                        v[j, l] = (v[l, j] = 0.0);
                    }
                }
                v[j, j] = 1.0;
                num3 = array[j];
                i = j;
            }
            for (int j = length2 - 1; j >= 0; j--)
            {
                i = j + 1;
                num3 = w[j];
                if (j < length2 - 1)
                {
                    for (int l = i; l < length2; l++)
                    {
                        a[j, l] = 0.0;
                    }
                }
                if (num3 != 0.0)
                {
                    num3 = 1.0 / num3;
                    if (j != length2 - 1)
                    {
                        for (int l = i; l < length2; l++)
                        {
                            double num5 = 0.0;
                            for (int k = i; k < length; k++)
                            {
                                num5 += a[k, j] * a[k, l];
                            }
                            double num6 = num5 / a[j, j] * num3;
                            for (int k = j; k < length; k++)
                            {
                                a[k, l] += num6 * a[k, j];
                            }
                        }
                    }
                    for (int l = j; l < length; l++)
                    {
                        a[l, j] *= num3;
                    }
                }
                else
                {
                    for (int l = j; l < length; l++)
                    {
                        a[l, j] = 0.0;
                    }
                }
                a[j, j] += 1.0;
            }
            for (int k = length2 - 1; k >= 0; k--)
            {
                int m = 1;
                while (m <= 30)
                {
                    int num8 = 1;
                    for (i = k; i >= 0; i--)
                    {
                        num = i - 1;
                        if (Math.Abs(array[i]) + num4 == num4)
                        {
                            num8 = 0;
                            break;
                        }
                        if (Math.Abs(w[num]) + num4 == num4)
                        {
                            break;
                        }
                    }
                    double num11;
                    if (num8 != 0)
                    {
                        double num5 = 1.0;
                        for (int j = i; j <= k; j++)
                        {
                            double num6 = num5 * array[j];
                            if (Math.Abs(num6) + num4 != num4)
                            {
                                num3 = w[j];
                                double num7 = Pythag(num6, num3);
                                w[j] = num7;
                                num7 = 1.0 / num7;
                                double num9 = num3 * num7;
                                num5 = -num6 * num7;
                                for (int l = 1; l <= length; l++)
                                {
                                    double num10 = a[l, num];
                                    num11 = a[l, j];
                                    a[l, num] = num10 * num9 + num11 * num5;
                                    a[l, j] = num11 * num9 - num10 * num5;
                                }
                            }
                        }
                    }
                    num11 = w[k];
                    if (i == k)
                    {
                        if (num11 < 0.0)
                        {
                            w[k] = -num11;
                            for (int l = 0; l < length2; l++)
                            {
                                v[l, k] = -v[l, k];
                            }
                            break;
                        }
                        break;
                    }
                    else
                    {
                        if (m == 30)
                        {
                            throw new ApplicationException("No convergence in 30 svdcmp iterations");
                        }
                        double num12 = w[i];
                        num = k - 1;
                        double num10 = w[num];
                        num3 = array[num];
                        double num7 = array[k];
                        double num6 = ((num10 - num11) * (num10 + num11) + (num3 - num7) * (num3 + num7)) / (2.0 * num7 * num10);
                        num3 = Pythag(num6, 1.0);
                        num6 = ((num12 - num11) * (num12 + num11) + num7 * (num10 / (num6 + Sign(num3, num6)) - num7)) / num12;
                        double num9;
                        double num5 = num9 = 1.0;
                        for (int l = i; l <= num; l++)
                        {
                            int j = l + 1;
                            num3 = array[j];
                            num10 = w[j];
                            num7 = num5 * num3;
                            num3 = num9 * num3;
                            num11 = Pythag(num6, num7);
                            array[l] = num11;
                            num9 = num6 / num11;
                            num5 = num7 / num11;
                            num6 = num12 * num9 + num3 * num5;
                            num3 = num3 * num9 - num12 * num5;
                            num7 = num10 * num5;
                            num10 *= num9;
                            for (int n = 0; n < length2; n++)
                            {
                                num12 = v[n, l];
                                num11 = v[n, j];
                                v[n, l] = num12 * num9 + num11 * num5;
                                v[n, j] = num11 * num9 - num12 * num5;
                            }
                            num11 = Pythag(num6, num7);
                            w[l] = num11;
                            if (num11 != 0.0)
                            {
                                num11 = 1.0 / num11;
                                num9 = num6 * num11;
                                num5 = num7 * num11;
                            }
                            num6 = num9 * num3 + num5 * num10;
                            num12 = num9 * num10 - num5 * num3;
                            for (int n = 0; n < length; n++)
                            {
                                num10 = a[n, l];
                                num11 = a[n, j];
                                a[n, l] = num10 * num9 + num11 * num5;
                                a[n, j] = num11 * num9 - num10 * num5;
                            }
                        }
                        array[i] = 0.0;
                        array[k] = num6;
                        w[k] = num12;
                        m++;
                    }
                }
            }
        }
        private static double Sign(double a, double b)
        {
            if (b < 0.0)
            {
                return -Math.Abs(a);
            }
            return Math.Abs(a);
        }
        private static double Pythag(double a, double b)
        {
            double num = Math.Abs(a);
            double num2 = Math.Abs(b);
            double result;
            if (num > num2)
            {
                double num3 = num2 / num;
                result = num * Math.Sqrt(1.0 + num3 * num3);
            }
            else if (num2 > 0.0)
            {
                double num3 = num / num2;
                result = num2 * Math.Sqrt(1.0 + num3 * num3);
            }
            else
            {
                result = 0.0;
            }
            return result;
        }
    }
}
