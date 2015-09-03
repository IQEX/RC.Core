using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// Perlin noise function.
	/// </summary>
	///
	/// <remarks><para>The class implements 1-D and 2-D Perlin noise functions, which represent
	/// sum of several smooth noise functions with different frequency and amplitude. The description
	/// of Perlin noise function and its calculation may be found on
	/// <a href="http://freespace.virgin.net/hugo.elias/models/m_perlin.htm" target="_blank">Hugo Elias's page</a>.
	/// </para>
	///
	/// <para>The number of noise functions, which comprise the resulting Perlin noise function, is
	/// set by <see cref="P:AForge.Math.PerlinNoise.Octaves" /> property. Amplitude and frequency values for each octave
	/// start from values, which are set by <see cref="P:AForge.Math.PerlinNoise.InitFrequency" /> and <see cref="P:AForge.Math.PerlinNoise.InitAmplitude" />
	/// properties.</para>
	///
	/// <para>Sample usage (clouds effect):</para>
	/// <code>
	/// // create Perlin noise function
	/// PerlinNoise noise = new PerlinNoise( 8, 0.5, 1.0 / 32 );
	/// // generate clouds effect
	/// float[,] texture = new float[height, width];
	///
	/// for ( int y = 0; y &lt; height; y++ )
	/// {
	/// 	for ( int x = 0; x &lt; width; x++ )
	/// 	{
	/// 		texture[y, x] = 
	/// 			Math.Max( 0.0f, Math.Min( 1.0f,
	/// 				(float) noise.Function2D( x, y ) * 0.5f + 0.5f
	/// 			) );
	/// 	}
	/// }
	/// </code>
	/// </remarks>
	public class PerlinNoise
    {
        private double initFrequency = 1.0;
        private double initAmplitude = 1.0;
        private double persistence = 0.65;
        private int octaves = 4;
        /// <summary>
        /// Initial frequency.
        /// </summary>
        ///
        /// <remarks><para>The property sets initial frequency of the first octave. Frequencies for
        /// next octaves are calculated using the next equation:<br />
        /// frequency<sub>i</sub> = <see cref="P:AForge.Math.PerlinNoise.InitFrequency" /> * 2<sup>i</sup>,
        /// where i = [0, <see cref="P:AForge.Math.PerlinNoise.Octaves" />).
        /// </para>
        ///
        /// <para>Default value is set to <b>1</b>.</para>
        /// </remarks>
        public double InitFrequency
        {
            get
            {
                return this.initFrequency;
            }
            set
            {
                this.initFrequency = value;
            }
        }
        /// <summary>
        /// Initial amplitude.
        /// </summary>
        ///
        /// <remarks><para>The property sets initial amplitude of the first octave. Amplitudes for
        /// next octaves are calculated using the next equation:<br />
        /// amplitude<sub>i</sub> = <see cref="P:AForge.Math.PerlinNoise.InitAmplitude" /> * <see cref="P:AForge.Math.PerlinNoise.Persistence" /><sup>i</sup>,
        /// where i = [0, <see cref="P:AForge.Math.PerlinNoise.Octaves" />).
        /// </para>
        ///
        /// <para>Default value is set to <b>1</b>.</para>
        /// </remarks>
        public double InitAmplitude
        {
            get
            {
                return this.initAmplitude;
            }
            set
            {
                this.initAmplitude = value;
            }
        }
        /// <summary>
        /// Persistence value.
        /// </summary>
        ///
        /// <remarks><para>The property sets so called persistence value, which controls the way
        /// how <see cref="P:AForge.Math.PerlinNoise.InitAmplitude">amplitude</see> is calculated for each octave comprising
        /// the Perlin noise function.</para>
        ///
        /// <para>Default value is set to <b>0.65</b>.</para>
        /// </remarks>
        public double Persistence
        {
            get
            {
                return this.persistence;
            }
            set
            {
                this.persistence = value;
            }
        }
        /// <summary>
        /// Number of octaves, [1, 32].
        /// </summary>
        ///
        /// <remarks><para>The property sets the number of noise functions, which sum up the resulting
        /// Perlin noise function.</para>
        ///
        /// <para>Default value is set to <b>4</b>.</para>
        /// </remarks>
        public int Octaves
        {
            get
            {
                return this.octaves;
            }
            set
            {
                this.octaves = Math.Max(1, Math.Min(32, value));
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AForge.Math.PerlinNoise" /> class.
        /// </summary>
        public PerlinNoise()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AForge.Math.PerlinNoise" /> class.
        /// </summary>
        ///
        /// <param name="octaves">Number of octaves (see <see cref="P:AForge.Math.PerlinNoise.Octaves" /> property).</param>
        /// <param name="persistence">Persistence value (see <see cref="P:AForge.Math.PerlinNoise.Persistence" /> property).</param>
        public PerlinNoise(int octaves, double persistence)
        {
            this.octaves = octaves;
            this.persistence = persistence;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AForge.Math.PerlinNoise" /> class.
        /// </summary>
        ///
        /// <param name="octaves">Number of octaves (see <see cref="P:AForge.Math.PerlinNoise.Octaves" /> property).</param>
        /// <param name="persistence">Persistence value (see <see cref="P:AForge.Math.PerlinNoise.Persistence" /> property).</param>
        /// <param name="initFrequency">Initial frequency (see <see cref="P:AForge.Math.PerlinNoise.InitFrequency" /> property).</param>
        /// <param name="initAmplitude">Initial amplitude (see <see cref="P:AForge.Math.PerlinNoise.InitAmplitude" /> property).</param>
        public PerlinNoise(int octaves, double persistence, double initFrequency, double initAmplitude)
        {
            this.octaves = octaves;
            this.persistence = persistence;
            this.initFrequency = initFrequency;
            this.initAmplitude = initAmplitude;
        }
        /// <summary>
        /// 1-D Perlin noise function.
        /// </summary>
        ///
        /// <param name="x">x value.</param>
        ///
        /// <returns>Returns function's value at point <paramref name="x" />.</returns>
        public double Function(double x)
        {
            double num = this.initFrequency;
            double num2 = this.initAmplitude;
            double num3 = 0.0;
            for (int i = 0; i < this.octaves; i++)
            {
                num3 += this.SmoothedNoise(x * num) * num2;
                num *= 2.0;
                num2 *= this.persistence;
            }
            return num3;
        }
        /// <summary>
        /// 2-D Perlin noise function.
        /// </summary>
        ///
        /// <param name="x">x value.</param>
        /// <param name="y">y value.</param>
        ///
        /// <returns>Returns function's value at point (<paramref name="x" />, <paramref name="y" />).</returns>
        public double Function2D(double x, double y)
        {
            double num = this.initFrequency;
            double num2 = this.initAmplitude;
            double num3 = 0.0;
            for (int i = 0; i < this.octaves; i++)
            {
                num3 += this.SmoothedNoise(x * num, y * num) * num2;
                num *= 2.0;
                num2 *= this.persistence;
            }
            return num3;
        }
        /// <summary>
        /// Ordinary noise function
        /// </summary>
        private double Noise(int x)
        {
            int num = x << 13 ^ x;
            return 1.0 - (double)(num * (num * num * 15731 + 789221) + 1376312589 & 2147483647) / 1073741824.0;
        }
        private double Noise(int x, int y)
        {
            int num = x + y * 57;
            num = (num << 13 ^ num);
            return 1.0 - (double)(num * (num * num * 15731 + 789221) + 1376312589 & 2147483647) / 1073741824.0;
        }
        /// <summary>
        /// Smoothed noise.
        /// </summary>
        private double SmoothedNoise(double x)
        {
            int num = (int)x;
            double a = x - (double)num;
            return this.CosineInterpolate(this.Noise(num), this.Noise(num + 1), a);
        }
        private double SmoothedNoise(double x, double y)
        {
            int num = (int)x;
            int num2 = (int)y;
            double a = x - (double)num;
            double a2 = y - (double)num2;
            double x2 = this.Noise(num, num2);
            double x3 = this.Noise(num + 1, num2);
            double x4 = this.Noise(num, num2 + 1);
            double x5 = this.Noise(num + 1, num2 + 1);
            double x6 = this.CosineInterpolate(x2, x3, a);
            double x7 = this.CosineInterpolate(x4, x5, a);
            return this.CosineInterpolate(x6, x7, a2);
        }
        /// <summary>
        /// Cosine interpolation.
        /// </summary>
        private double CosineInterpolate(double x1, double x2, double a)
        {
            double num = (1.0 - Math.Cos(a * 3.1415926535897931)) * 0.5;
            return x1 * (1.0 - num) + x2 * num;
        }
    }
}
