using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// Set of statistics functions.
	/// </summary>
	///
	/// <remarks>The class represents collection of simple functions used
	/// in statistics.</remarks>
	public static class Statistics
    {
        /// <summary>
        /// Calculate mean value.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        ///
        /// <returns>Returns mean value.</returns>
        ///
        /// <remarks><para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create histogram array
        /// int[] histogram = new int[] { 1, 1, 2, 3, 6, 8, 11, 12, 7, 3 };
        /// // calculate mean value
        /// double mean = Statistics.Mean( histogram );
        /// // output it (5.759)
        /// Console.WriteLine( "mean = " + mean.ToString( "F3" ) );
        /// </code>
        /// </remarks>
        public static double Mean(int[] values)
        {
            long num = 0L;
            double num2 = 0.0;
            int i = 0;
            int num3 = values.Length;
            while (i < num3)
            {
                int num4 = values[i];
                num2 += (double)(i * num4);
                num += (long)num4;
                i++;
            }
            if (num != 0L)
            {
                return num2 / (double)num;
            }
            return 0.0;
        }
        /// <summary>
        /// Calculate standard deviation.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        ///
        /// <returns>Returns value of standard deviation.</returns>
        ///
        /// <remarks><para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create histogram array
        /// int[] histogram = new int[] { 1, 1, 2, 3, 6, 8, 11, 12, 7, 3 };
        /// // calculate standard deviation value
        /// double stdDev = Statistics.StdDev( histogram );
        /// // output it (1.999)
        /// Console.WriteLine( "std.dev. = " + stdDev.ToString( "F3" ) );
        /// </code>
        /// </remarks>
        public static double StdDev(int[] values)
        {
            return Statistics.StdDev(values, Statistics.Mean(values));
        }
        /// <summary>
        /// Calculate standard deviation.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        /// <param name="mean">Mean value of the histogram.</param>
        ///
        /// <returns>Returns value of standard deviation.</returns>
        ///
        /// <remarks><para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para>The method is an equevalent to the <see cref="M:Rc.Framework.RMath.Math.Statistics.StdDev(System.Int32[])" /> method,
        /// but it relieas on the passed mean value, which is previously calculated
        /// using <see cref="M:Rc.Framework.RMath.Math.Statistics.Mean(System.Int32[])" /> method.</para>
        /// </remarks>
        public static double StdDev(int[] values, double mean)
        {
            double num = 0.0;
            int num2 = 0;
            int i = 0;
            int num3 = values.Length;
            while (i < num3)
            {
                int num4 = values[i];
                double num5 = (double)i - mean;
                num += num5 * num5 * (double)num4;
                num2 += num4;
                i++;
            }
            if (num2 != 0)
            {
                return Math.Sqrt(num / (double)num2);
            }
            return 0.0;
        }
        /// <summary>
        /// Calculate median value.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        ///
        /// <returns>Returns value of median.</returns>
        ///
        /// <remarks>
        /// <para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para><note>The median value is calculated accumulating histogram's
        /// values starting from the <b>left</b> point until the sum reaches 50% of
        /// histogram's sum.</note></para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create histogram array
        /// int[] histogram = new int[] { 1, 1, 2, 3, 6, 8, 11, 12, 7, 3 };
        /// // calculate median value
        /// int median = Statistics.Median( histogram );
        /// // output it (6)
        /// Console.WriteLine( "median = " + median );
        /// </code>
        /// </remarks>
        public static int Median(int[] values)
        {
            int num = 0;
            int num2 = values.Length;
            for (int i = 0; i < num2; i++)
            {
                num += values[i];
            }
            int num3 = num / 2;
            int j = 0;
            int num4 = 0;
            while (j < num2)
            {
                num4 += values[j];
                if (num4 >= num3)
                {
                    break;
                }
                j++;
            }
            return j;
        }
        /// <summary>
        /// Get range around median containing specified percentage of values.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        /// <param name="percent">Values percentage around median.</param>
        ///
        /// <returns>Returns the range which containes specifies percentage
        /// of values.</returns>
        ///
        /// <remarks>
        /// <para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para>The method calculates range of stochastic variable, which summary probability
        /// comprises the specified percentage of histogram's hits.</para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create histogram array
        /// int[] histogram = new int[] { 1, 1, 2, 3, 6, 8, 11, 12, 7, 3 };
        /// // get 75% range around median
        /// IntRange range = Statistics.GetRange( histogram, 0.75 );
        /// // output it ([4, 8])
        /// Console.WriteLine( "range = [" + range.Min + ", " + range.Max + "]" );
        /// </code>
        /// </remarks>
        public static IntRange GetRange(int[] values, double percent)
        {
            int num = 0;
            int num2 = values.Length;
            for (int i = 0; i < num2; i++)
            {
                num += values[i];
            }
            int num3 = (int)((double)num * (percent + (1.0 - percent) / 2.0));
            int j = 0;
            int num4 = num;
            while (j < num2)
            {
                num4 -= values[j];
                if (num4 < num3)
                {
                    break;
                }
                j++;
            }
            int k = num2 - 1;
            num4 = num;
            while (k >= 0)
            {
                num4 -= values[k];
                if (num4 < num3)
                {
                    break;
                }
                k--;
            }
            return new IntRange(j, k);
        }
        /// <summary>
        /// Calculate entropy value.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        ///
        /// <returns>Returns entropy value of the specified histagram array.</returns>
        ///
        /// <remarks><para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create histogram array with 2 values of equal probabilities
        /// int[] histogram1 = new int[2] { 3, 3 };
        /// // calculate entropy
        /// double entropy1 = Statistics.Entropy( histogram1 );
        /// // output it (1.000)
        /// Console.WriteLine( "entropy1 = " + entropy1.ToString( "F3" ) );
        ///
        /// // create histogram array with 4 values of equal probabilities
        /// int[] histogram2 = new int[4] { 1, 1, 1, 1 };
        /// // calculate entropy
        /// double entropy2 = Statistics.Entropy( histogram2 );
        /// // output it (2.000)
        /// Console.WriteLine( "entropy2 = " + entropy2.ToString( "F3" ) );
        ///
        /// // create histogram array with 4 values of different probabilities
        /// int[] histogram3 = new int[4] { 1, 2, 3, 4 };
        /// // calculate entropy
        /// double entropy3 = Statistics.Entropy( histogram3 );
        /// // output it (1.846)
        /// Console.WriteLine( "entropy3 = " + entropy3.ToString( "F3" ) );
        /// </code>
        /// </remarks>
        public static double Entropy(int[] values)
        {
            int num = values.Length;
            int num2 = 0;
            double num3 = 0.0;
            for (int i = 0; i < num; i++)
            {
                num2 += values[i];
            }
            if (num2 != 0)
            {
                for (int j = 0; j < num; j++)
                {
                    double num4 = (double)values[j] / (double)num2;
                    if (num4 != 0.0)
                    {
                        num3 += -num4 * Math.Log(num4, 2.0);
                    }
                }
            }
            return num3;
        }
        /// <summary>
        /// Calculate mode value.
        /// </summary>
        ///
        /// <param name="values">Histogram array.</param>
        ///
        /// <returns>Returns mode value of the histogram array.</returns>
        ///
        /// <remarks>
        /// <para>The input array is treated as histogram, i.e. its
        /// indexes are treated as values of stochastic function, but
        /// array values are treated as "probabilities" (total amount of
        /// hits).</para>
        ///
        /// <para><note>Returns the minimum mode value if the specified histogram is multimodal.</note></para>
        ///
        /// <para>Sample usage:</para>
        /// <code>
        /// // create array
        /// int[] values = new int[] { 1, 1, 2, 3, 6, 8, 11, 12, 7, 3 };
        /// // calculate mode value
        /// int mode = Statistics.Mode( values );
        /// // output it (7)
        /// Console.WriteLine( "mode = " + mode );
        /// </code>
        /// </remarks>
        public static int Mode(int[] values)
        {
            int result = 0;
            int num = 0;
            int i = 0;
            int num2 = values.Length;
            while (i < num2)
            {
                if (values[i] > num)
                {
                    num = values[i];
                    result = i;
                }
                i++;
            }
            return result;
        }
    }
}
