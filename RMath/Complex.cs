using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rc.Framework.RMath
{
    /// <summary>
	/// Complex number wrapper class.
	/// </summary>
	///
	/// <remarks><para>The class encapsulates complex number and provides
	/// set of different operators to manipulate it, lake adding, subtractio,
	/// multiplication, etc.</para>
	///
	/// <para>Sample usage:</para>
	/// <code>
	/// // define two complex numbers
	/// Complex c1 = new Complex( 3, 9 );
	/// Complex c2 = new Complex( 8, 3 );
	/// // sum
	/// Complex s1 = Complex.Add( c1, c2 );
	/// Complex s2 = c1 + c2;
	/// Complex s3 = c1 + 5;
	/// // difference
	/// Complex d1 = Complex.Subtract( c1, c2 );
	/// Complex d2 = c1 - c2;
	/// Complex d3 = c1 - 2;
	/// </code>
	/// </remarks>
	public struct Complex : ICloneable, ISerializable
    {
        /// <summary>
        /// Real part of the complex number.
        /// </summary>
        public double Re;
        /// <summary>
        /// Imaginary part of the complex number.
        /// </summary>
        public double Im;
        /// <summary>
        ///  A double-precision complex number that represents zero.
        /// </summary>
        public static readonly Complex Zero = new Complex(0.0, 0.0);
        /// <summary>
        ///  A double-precision complex number that represents one.
        /// </summary>
        public static readonly Complex One = new Complex(1.0, 0.0);
        /// <summary>
        ///  A double-precision complex number that represents the squere root of (-1).
        /// </summary>
        public static readonly Complex I = new Complex(0.0, 1.0);
        /// <summary>
        /// Magnitude value of the complex number.
        /// </summary>
        ///
        /// <remarks><para>Magnitude of the complex number, which equals to <b>Sqrt( Re * Re + Im * Im )</b>.</para></remarks>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(this.Re * this.Re + this.Im * this.Im);
            }
        }
        /// <summary>
        /// Phase value of the complex number.
        /// </summary>
        ///
        /// <remarks><para>Phase of the complex number, which equals to <b>Atan( Im / Re )</b>.</para></remarks>
        public double Phase
        {
            get
            {
                return Math.Atan2(this.Im, this.Re);
            }
        }
        /// <summary>
        /// Squared magnitude value of the complex number.
        /// </summary>
        public double SquaredMagnitude
        {
            get
            {
                return this.Re * this.Re + this.Im * this.Im;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Complex" /> class.
        /// </summary>
        ///
        /// <param name="re">Real part.</param>
        /// <param name="im">Imaginary part.</param>
        public Complex(double re, double im)
        {
            this.Re = re;
            this.Im = im;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Complex" /> class.
        /// </summary>
        ///
        /// <param name="c">Source complex number.</param>
        public Complex(Complex c)
        {
            this.Re = c.Re;
            this.Im = c.Im;
        }
        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the sum of specified
        /// complex numbers.</returns>
        public static Complex Add(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }
        /// <summary>
        /// Adds scalar value to a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the sum of specified
        /// complex number and scalar value.</returns>
        public static Complex Add(Complex a, double s)
        {
            return new Complex(a.Re + s, a.Im);
        }
        /// <summary>
        /// Adds two complex numbers and puts the result into the third complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Add(Complex a, Complex b, ref Complex result)
        {
            result.Re = a.Re + b.Re;
            result.Im = a.Im + b.Im;
        }
        /// <summary>
        /// Adds scalar value to a complex number and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Add(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re + s;
            result.Im = a.Im;
        }
        /// <summary>
        /// Subtracts one complex number from another.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance to subtract from.</param>
        /// <param name="b">A <see cref="Complex" /> instance to be subtracted.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the subtraction result (<b>a - b</b>).</returns>
        public static Complex Subtract(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }
        /// <summary>
        /// Subtracts a scalar from a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance to subtract from.</param>
        /// <param name="s">A scalar value to be subtracted.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the subtraction result (<b>a - s</b>).</returns>
        public static Complex Subtract(Complex a, double s)
        {
            return new Complex(a.Re - s, a.Im);
        }
        /// <summary>
        /// Subtracts a complex number from a scalar value.
        /// </summary>
        ///
        /// <param name="s">A scalar value to subtract from.</param>
        /// <param name="a">A <see cref="Complex" /> instance to be subtracted.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the subtraction result (<b>s - a</b>).</returns>
        public static Complex Subtract(double s, Complex a)
        {
            return new Complex(s - a.Re, a.Im);
        }
        /// <summary>
        /// Subtracts one complex number from another and puts the result in the third complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance to subtract from.</param>
        /// <param name="b">A <see cref="Complex" /> instance to be subtracted.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Subtract(Complex a, Complex b, ref Complex result)
        {
            result.Re = a.Re - b.Re;
            result.Im = a.Im - b.Im;
        }
        /// <summary>
        /// Subtracts a scalar value from a complex number and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance to subtract from.</param>
        /// <param name="s">A scalar value to be subtracted.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Subtract(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re - s;
            result.Im = a.Im;
        }
        /// <summary>
        /// Subtracts a complex number from a scalar value and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="s">A scalar value to subtract from.</param>
        /// <param name="a">A <see cref="Complex" /> instance to be subtracted.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Subtract(double s, Complex a, ref Complex result)
        {
            result.Re = s - a.Re;
            result.Im = a.Im;
        }
        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of multiplication.</returns>
        public static Complex Multiply(Complex a, Complex b)
        {
            double re = a.Re;
            double im = a.Im;
            double re2 = b.Re;
            double im2 = b.Im;
            return new Complex(re * re2 - im * im2, re * im2 + im * re2);
        }
        /// <summary>
        /// Multiplies a complex number by a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of multiplication.</returns>
        public static Complex Multiply(Complex a, double s)
        {
            return new Complex(a.Re * s, a.Im * s);
        }
        /// <summary>
        /// Multiplies two complex numbers and puts the result in a third complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Multiply(Complex a, Complex b, ref Complex result)
        {
            double re = a.Re;
            double im = a.Im;
            double re2 = b.Re;
            double im2 = b.Im;
            result.Re = re * re2 - im * im2;
            result.Im = re * im2 + im * re2;
        }
        /// <summary>
        /// Multiplies a complex number by a scalar value and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        public static void Multiply(Complex a, double s, ref Complex result)
        {
            result.Re = a.Re * s;
            result.Im = a.Im * s;
        }
        /// <summary>
        /// Divides one complex number by another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result.</returns>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static Complex Divide(Complex a, Complex b)
        {
            double re = a.Re;
            double im = a.Im;
            double re2 = b.Re;
            double im2 = b.Im;
            double num = re2 * re2 + im2 * im2;
            if (num == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            double num2 = 1.0 / num;
            return new Complex((re * re2 + im * im2) * num2, (im * re2 - re * im2) * num2);
        }
        /// <summary>
        /// Divides a complex number by a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result.</returns>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static Complex Divide(Complex a, double s)
        {
            if (s == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            return new Complex(a.Re / s, a.Im / s);
        }
        /// <summary>
        /// Divides a scalar value by a complex number.
        /// </summary>
        ///
        /// <param name="s">A scalar value.</param>
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result.</returns>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static Complex Divide(double s, Complex a)
        {
            if (a.Re == 0.0 || a.Im == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            return new Complex(s / a.Re, s / a.Im);
        }
        /// <summary>
        /// Divides one complex number by another complex number and puts the result in a third complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static void Divide(Complex a, Complex b, ref Complex result)
        {
            double re = a.Re;
            double im = a.Im;
            double re2 = b.Re;
            double im2 = b.Im;
            double num = re2 * re2 + im2 * im2;
            if (num == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            double num2 = 1.0 / num;
            result.Re = (re * re2 + im * im2) * num2;
            result.Im = (im * re2 - re * im2) * num2;
        }
        /// <summary>
        /// Divides a complex number by a scalar value and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static void Divide(Complex a, double s, ref Complex result)
        {
            if (s == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            result.Re = a.Re / s;
            result.Im = a.Im / s;
        }
        /// <summary>
        /// Divides a scalar value by a complex number and puts the result into another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        /// <param name="result">A <see cref="Complex" /> instance to hold the result.</param>
        ///
        /// <exception cref="T:System.DivideByZeroException">Can not divide by zero.</exception>
        public static void Divide(double s, Complex a, ref Complex result)
        {
            if (a.Re == 0.0 || a.Im == 0.0)
            {
                throw new DivideByZeroException("Can not divide by zero.");
            }
            result.Re = s / a.Re;
            result.Im = s / a.Im;
        }
        /// <summary>
        /// Negates a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the negated values.</returns>
        public static Complex Negate(Complex a)
        {
            return new Complex(-a.Re, -a.Im);
        }
        /// <summary>
        /// Tests whether two complex numbers are approximately equal using default tolerance value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Return <see langword="true" /> if the two vectors are approximately equal or <see langword="false" /> otherwise.</returns>
        ///
        /// <remarks><para>The default tolerance value, which is used for the test, equals to 8.8817841970012523233891E-16.</para></remarks>
        public static bool ApproxEqual(Complex a, Complex b)
        {
            return Complex.ApproxEqual(a, b, 8.8817841970012523E-16);
        }
        /// <summary>
        /// Tests whether two complex numbers are approximately equal given a tolerance value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        /// <param name="tolerance">The tolerance value used to test approximate equality.</param>
        ///
        /// <remarks><para>The default tolerance value, which is used for the test, equals to 8.8817841970012523233891E-16.</para></remarks>
        public static bool ApproxEqual(Complex a, Complex b, double tolerance)
        {
            return Math.Abs(a.Re - b.Re) <= tolerance && Math.Abs(a.Im - b.Im) <= tolerance;
        }
        /// <summary>
        /// Converts the specified string to its <see cref="Complex" /> equivalent.
        /// </summary>
        ///
        /// <param name="s">A string representation of a complex number.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance that represents the complex number
        /// specified by the <paramref name="s" /> parameter.</returns>
        ///
        /// <exception cref="T:System.FormatException">String representation of the complex number is not correctly formatted.</exception>
        public static Complex Parse(string s)
        {
            Regex regex = new Regex("\\((?<real>.*),(?<imaginary>.*)\\)", RegexOptions.None);
            Match match = regex.Match(s);
            if (match.Success)
            {
                return new Complex(double.Parse(match.Result("${real}")), double.Parse(match.Result("${imaginary}")));
            }
            throw new FormatException("String representation of the complex number is not correctly formatted.");
        }
        /// <summary>
        /// Try to convert the specified string to its <see cref="Complex" /> equivalent.
        /// </summary>
        ///
        /// <param name="s">A string representation of a complex number.</param>
        ///
        /// <param name="result"><see cref="Complex" /> instance to output the result to.</param>
        ///
        /// <returns>Returns boolean value that indicates if the parse was successful or not.</returns>
        public static bool TryParse(string s, out Complex result)
        {
            bool result2;
            try
            {
                Complex complex = Complex.Parse(s);
                result = complex;
                result2 = true;
            }
            catch (FormatException)
            {
                result = default(Complex);
                result2 = false;
            }
            return result2;
        }
        /// <summary>
        /// Calculates square root of a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the square root of the specified
        /// complex number.</returns>
        public static Complex Sqrt(Complex a)
        {
            Complex zero = Complex.Zero;
            if (a.Re == 0.0 && a.Im == 0.0)
            {
                return zero;
            }
            if (a.Im == 0.0)
            {
                zero.Re = ((a.Re > 0.0) ? Math.Sqrt(a.Re) : Math.Sqrt(-a.Re));
                zero.Im = 0.0;
            }
            else
            {
                double magnitude = a.Magnitude;
                zero.Re = Math.Sqrt(0.5 * (magnitude + a.Re));
                zero.Im = Math.Sqrt(0.5 * (magnitude - a.Re));
                if (a.Im < 0.0)
                {
                    zero.Im = -zero.Im;
                }
            }
            return zero;
        }
        /// <summary>
        /// Calculates natural (base <b>e</b>) logarithm of a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the natural logarithm of the specified
        /// complex number.</returns>
        public static Complex Log(Complex a)
        {
            Complex zero = Complex.Zero;
            if (a.Re > 0.0 && a.Im == 0.0)
            {
                zero.Re = Math.Log(a.Re);
                zero.Im = 0.0;
            }
            else if (a.Re == 0.0)
            {
                if (a.Im > 0.0)
                {
                    zero.Re = Math.Log(a.Im);
                    zero.Im = 1.5707963267948966;
                }
                else
                {
                    zero.Re = Math.Log(-a.Im);
                    zero.Im = -1.5707963267948966;
                }
            }
            else
            {
                zero.Re = Math.Log(a.Magnitude);
                zero.Im = Math.Atan2(a.Im, a.Re);
            }
            return zero;
        }
        /// <summary>
        /// Calculates exponent (<b>e</b> raised to the specified power) of a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the exponent of the specified
        /// complex number.</returns>
        public static Complex Exp(Complex a)
        {
            Complex zero = Complex.Zero;
            double num = Math.Exp(a.Re);
            zero.Re = num * Math.Cos(a.Im);
            zero.Im = num * Math.Sin(a.Im);
            return zero;
        }
        /// <summary>
        /// Calculates Sine value of the complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the Sine value of the specified
        /// complex number.</returns>
        public static Complex Sin(Complex a)
        {
            Complex zero = Complex.Zero;
            if (a.Im == 0.0)
            {
                zero.Re = Math.Sin(a.Re);
                zero.Im = 0.0;
            }
            else
            {
                zero.Re = Math.Sin(a.Re) * Math.Cosh(a.Im);
                zero.Im = Math.Cos(a.Re) * Math.Sinh(a.Im);
            }
            return zero;
        }
        /// <summary>
        /// Calculates Cosine value of the complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the Cosine value of the specified
        /// complex number.</returns>
        public static Complex Cos(Complex a)
        {
            Complex zero = Complex.Zero;
            if (a.Im == 0.0)
            {
                zero.Re = Math.Cos(a.Re);
                zero.Im = 0.0;
            }
            else
            {
                zero.Re = Math.Cos(a.Re) * Math.Cosh(a.Im);
                zero.Im = -Math.Sin(a.Re) * Math.Sinh(a.Im);
            }
            return zero;
        }
        /// <summary>
        /// Calculates Tangent value of the complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the Tangent value of the specified
        /// complex number.</returns>
        public static Complex Tan(Complex a)
        {
            Complex zero = Complex.Zero;
            if (a.Im == 0.0)
            {
                zero.Re = Math.Tan(a.Re);
                zero.Im = 0.0;
            }
            else
            {
                double num = 2.0 * a.Re;
                double value = 2.0 * a.Im;
                double num2 = Math.Cos(num) + Math.Cosh(num);
                zero.Re = Math.Sin(num) / num2;
                zero.Im = Math.Sinh(value) / num2;
            }
            return zero;
        }
        /// <summary>
        /// Returns the hashcode for this instance.
        /// </summary>
        ///
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.Re.GetHashCode() ^ this.Im.GetHashCode();
        }
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified object.
        /// </summary>
        ///
        /// <param name="obj">An object to compare to this instance.</param>
        ///
        /// <returns>Returns <see langword="true" /> if <paramref name="obj" /> is a <see cref="Complex" /> and has the same values as this instance or <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is Complex && this == (Complex)obj;
        }
        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        ///
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Re, this.Im);
        }
        /// <summary>
        /// Tests whether two specified complex numbers are equal.
        /// </summary>
        ///
        /// <param name="u">The left-hand complex number.</param>
        /// <param name="v">The right-hand complex number.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the two complex numbers are equal or <see langword="false" /> otherwise.</returns>
        public static bool operator ==(Complex u, Complex v)
        {
            return u.Re == v.Re && u.Im == v.Im;
        }
        /// <summary>
        /// Tests whether two specified complex numbers are not equal.
        /// </summary>
        ///
        /// <param name="u">The left-hand complex number.</param>
        /// <param name="v">The right-hand complex number.</param>
        ///
        /// <returns>Returns <see langword="true" /> if the two complex numbers are not equal or <see langword="false" /> otherwise.</returns>
        public static bool operator !=(Complex u, Complex v)
        {
            return !(u == v);
        }
        /// <summary>
        /// Negates the complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" />  instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the negated values.</returns>
        public static Complex operator -(Complex a)
        {
            return Complex.Negate(a);
        }
        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the sum.</returns>
        public static Complex operator +(Complex a, Complex b)
        {
            return Complex.Add(a, b);
        }
        /// <summary>
        /// Adds a complex number and a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the sum.</returns>
        public static Complex operator +(Complex a, double s)
        {
            return Complex.Add(a, s);
        }
        /// <summary>
        /// Adds a complex number and a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the sum.</returns>
        public static Complex operator +(double s, Complex a)
        {
            return Complex.Add(a, s);
        }
        /// <summary>
        /// Subtracts one complex number from another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the difference.</returns>
        public static Complex operator -(Complex a, Complex b)
        {
            return Complex.Subtract(a, b);
        }
        /// <summary>
        /// Subtracts a scalar value from a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the difference.</returns>
        public static Complex operator -(Complex a, double s)
        {
            return Complex.Subtract(a, s);
        }
        /// <summary>
        /// Subtracts a complex number from a scalar value.
        /// </summary>
        ///
        /// <param name="s">A scalar value.</param>
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the difference.</returns>
        public static Complex operator -(double s, Complex a)
        {
            return Complex.Subtract(s, a);
        }
        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of multiplication.</returns>
        public static Complex operator *(Complex a, Complex b)
        {
            return Complex.Multiply(a, b);
        }
        /// <summary>
        /// Multiplies a complex number by a scalar value.
        /// </summary>
        ///
        /// <param name="s">A scalar value.</param>
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of multiplication.</returns>
        public static Complex operator *(double s, Complex a)
        {
            return Complex.Multiply(a, s);
        }
        /// <summary>
        /// Multiplies a complex number by a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of multiplication.</returns>
        public static Complex operator *(Complex a, double s)
        {
            return Complex.Multiply(a, s);
        }
        /// <summary>
        /// Divides one complex number by another complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="b">A <see cref="Complex" /> instance.</param>
        ///
        /// <returns>A new Complex instance containing the result.</returns>
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of division.</returns>
        public static Complex operator /(Complex a, Complex b)
        {
            return Complex.Divide(a, b);
        }
        /// <summary>
        /// Divides a complex number by a scalar value.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of division.</returns>
        public static Complex operator /(Complex a, double s)
        {
            return Complex.Divide(a, s);
        }
        /// <summary>
        /// Divides a scalar value by a complex number.
        /// </summary>
        ///
        /// <param name="a">A <see cref="Complex" /> instance.</param>
        /// <param name="s">A scalar value.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing the result of division.</returns>
        public static Complex operator /(double s, Complex a)
        {
            return Complex.Divide(s, a);
        }
        /// <summary>
        /// Converts from a single-precision real number to a complex number. 
        /// </summary>
        ///
        /// <param name="value">Single-precision real number to convert to complex number.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing complex number with
        /// real part initialized to the specified value.</returns>
        public static explicit operator Complex(float value)
        {
            return new Complex((double)value, 0.0);
        }
        /// <summary>
        /// Converts from a double-precision real number to a complex number. 
        /// </summary>
        ///
        /// <param name="value">Double-precision real number to convert to complex number.</param>
        ///
        /// <returns>Returns new <see cref="Complex" /> instance containing complex number with
        /// real part initialized to the specified value.</returns>
        public static explicit operator Complex(double value)
        {
            return new Complex(value, 0.0);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="Complex" /> object.
        /// </summary>
        ///
        /// <returns>Returns clone of the complex number.</returns>
        object ICloneable.Clone()
        {
            return new Complex(this);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="Complex" /> object.
        /// </summary>
        ///
        /// <returns>Returns clone of the complex number.</returns>
        public Complex Clone()
        {
            return new Complex(this);
        }
        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.
        /// </summary>
        ///
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data. </param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Real", this.Re);
            info.AddValue("Imaginary", this.Im);
        }
    }
}
