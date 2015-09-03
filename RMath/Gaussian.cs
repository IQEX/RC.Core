using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// Gaussian function.
	/// </summary>
	///
	/// <remarks><para>The class is used to calculate 1D and 2D Gaussian functions for
	/// specified <see cref="P:AForge.Math.Gaussian.Sigma" /> (s) value:</para>
	///
	/// <code lang="none">
	/// 1-D: f(x) = exp( x * x / ( -2 * s * s ) ) / ( s * sqrt( 2 * PI ) )
	///
	/// 2-D: f(x, y) = exp( x * x + y * y / ( -2 * s * s ) ) / ( s * s * 2 * PI )
	/// </code>
	///
	/// </remarks>
	public class Gaussian
    {
        private double sigma = 1.0;
        private double sqrSigma = 1.0;
        /// <summary>
        /// Sigma value.
        /// </summary>
        ///
        /// <remarks><para>Sigma property of Gaussian function.</para>
        ///
        /// <para>Default value is set to <b>1</b>. Minimum allowed value is <b>0.00000001</b>.</para>
        /// </remarks>
        public double Sigma
        {
            get
            {
                return this.sigma;
            }
            set
            {
                this.sigma = Math.Max(1E-08, value);
                this.sqrSigma = this.sigma * this.sigma;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AForge.Math.Gaussian" /> class.
        /// </summary>
        public Gaussian()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AForge.Math.Gaussian" /> class.
        /// </summary>
        ///
        /// <param name="sigma">Sigma value.</param>
        public Gaussian(double sigma)
        {
            this.Sigma = sigma;
        }
        /// <summary>
        /// 1-D Gaussian function.
        /// </summary>
        ///
        /// <param name="x">x value.</param>
        ///
        /// <returns>Returns function's value at point <paramref name="x" />.</returns>
        ///
        /// <remarks><para>The function calculates 1-D Gaussian function:</para>
        ///
        /// <code lang="none">
        /// f(x) = exp( x * x / ( -2 * s * s ) ) / ( s * sqrt( 2 * PI ) )
        /// </code>
        /// </remarks>
        public double Function(double x)
        {
            return Math.Exp(x * x / (-2.0 * this.sqrSigma)) / (Math.Sqrt(6.2831853071795862) * this.sigma);
        }
        /// <summary>
        /// 2-D Gaussian function.
        /// </summary>
        ///
        /// <param name="x">x value.</param>
        /// <param name="y">y value.</param>
        ///
        /// <returns>Returns function's value at point (<paramref name="x" />, <paramref name="y" />).</returns>
        ///
        /// <remarks><para>The function calculates 2-D Gaussian function:</para>
        ///
        /// <code lang="none">
        /// f(x, y) = exp( x * x + y * y / ( -2 * s * s ) ) / ( s * s * 2 * PI )
        /// </code>
        /// </remarks>
        public double Function2D(double x, double y)
        {
            return Math.Exp((x * x + y * y) / (-2.0 * this.sqrSigma)) / (6.2831853071795862 * this.sqrSigma);
        }
        /// <summary>
        /// 1-D Gaussian kernel.
        /// </summary>
        ///
        /// <param name="size">Kernel size (should be odd), [3, 101].</param>
        ///
        /// <returns>Returns 1-D Gaussian kernel of the specified size.</returns>
        ///
        /// <remarks><para>The function calculates 1-D Gaussian kernel, which is array
        /// of Gaussian function's values in the [-r, r] range of x value, where
        /// r=floor(<paramref name="size" />/2).
        /// </para></remarks>
        ///
        /// <exception cref="T:System.ArgumentException">Wrong kernel size.</exception>
        public double[] Kernel(int size)
        {
            if (size % 2 == 0 || size < 3 || size > 101)
            {
                throw new ArgumentException("Wrong kernal size.");
            }
            int num = size / 2;
            double[] array = new double[size];
            int num2 = -num;
            for (int i = 0; i < size; i++)
            {
                array[i] = this.Function((double)num2);
                num2++;
            }
            return array;
        }
        /// <summary>
        /// 2-D Gaussian kernel.
        /// </summary>
        ///
        /// <param name="size">Kernel size (should be odd), [3, 101].</param>
        ///
        /// <returns>Returns 2-D Gaussian kernel of specified size.</returns>
        ///
        /// <remarks><para>The function calculates 2-D Gaussian kernel, which is array
        /// of Gaussian function's values in the [-r, r] range of x,y values, where
        /// r=floor(<paramref name="size" />/2).
        /// </para></remarks>
        ///
        /// <exception cref="T:System.ArgumentException">Wrong kernel size.</exception>
        public double[,] Kernel2D(int size)
        {
            if (size % 2 == 0 || size < 3 || size > 101)
            {
                throw new ArgumentException("Wrong kernal size.");
            }
            int num = size / 2;
            double[,] array = new double[size, size];
            int num2 = -num;
            for (int i = 0; i < size; i++)
            {
                int num3 = -num;
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = this.Function2D((double)num3, (double)num2);
                    num3++;
                }
                num2++;
            }
            return array;
        }
    }
}
