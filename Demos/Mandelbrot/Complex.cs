using System;

namespace Mandelbrot
{
	/// <summary>
	/// A new value type for complex numbers.
	/// </summary>
	public struct Complex
	{
		private double m_X;
		private double m_Y;

		public Complex(Complex c)
		{
			m_X = c.X;
			m_Y = c.Y;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="x">real part.</param>
		/// <param name="y">imaginary part.</param>
		public Complex(double x, double y)
		{
			m_X = x;
			m_Y = y;
		}

		public override string ToString()
		{
			return(String.Format("{0} + {1}i", X, Y));
		}

		public static Complex operator +(Complex c1, Complex c2) 
		{
			return new Complex(c1.X + c2.X, c1.Y + c2.Y);
		}

		public static Complex operator *(Complex c1, Complex c2) 
		{
			return new Complex(c1.X * c2.X - c1.Y * c2.Y, c1.X * c2.Y + c1.Y * c2.X);
		}

		/// <summary>
		/// Real part.
		/// </summary>
		public double X
		{
			get
			{
				return m_X;
			}

			set
			{
				m_X = value;
			}
		}

		/// <summary>
		/// Imaginary part.
		/// </summary>
		public double Y
		{
			get
			{
				return m_Y;
			}

			set
			{
				m_Y = value;
			}
		}

		/// <summary>
		/// The squared modulus of the complex number (X^2 + Y^2).
		/// </summary>
		public double ModSquared
		{
			get
			{
				return m_X*m_X + m_Y*m_Y;
			}
		}
	}
}
