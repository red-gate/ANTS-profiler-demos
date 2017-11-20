using System;

namespace Mandelbrot
{
	/// <summary>
	/// Provides two different ways of calculating the Mandelbrot set. 
	/// One uses Complex arithmetic, the other only real numbers.
	/// </summary>
	public class Algorithm
	{
		private int m_MaxIterations;

		public Algorithm()
		{
			m_MaxIterations = 128;
		}

		public bool UseComplexNumbers = false;

		public int MaxIterations
		{
			get
			{
				return m_MaxIterations;
			}

			set
			{
				m_MaxIterations = value;
			}
		}

		/// <summary>
		/// Calculates the number of Mandelbrot iterations. 
		/// </summary>
		/// <param name="x">real starting value</param>
		/// <param name="y">complex starting value</param>
		/// <returns></returns>
		public int Evaluate(double x, double y)
		{
			if(UseComplexNumbers)
				return EvaluateUsingComplexNumbers(x, y);
			else
				return EvaluateUsingDoubles(x, y);
		}

		/// <summary>
		/// Calculates the number of Mandelbrot iterations using complex numbers.
		/// </summary>
		/// <param name="x">real starting value</param>
		/// <param name="y">complex starting value</param>
		/// <returns></returns>
		int EvaluateUsingComplexNumbers(double x, double y)
		{
			int iterations = 0;
			Complex z = new Complex(x, y);
			Complex z0 = new Complex(z);
			while(iterations < m_MaxIterations && z.ModSquared < 4)
			{
				iterations++;
				// this is the Mandelbrot algorithm in complex form.
				z = z * z + z0;
			}

			return iterations;
		}

		/// <summary>
		/// Calculates the number of Mandelbrot iterations using only doubles
		/// </summary>
		/// <param name="x">real starting value</param>
		/// <param name="y">complex starting value</param>
		/// <returns></returns>
		int EvaluateUsingDoubles(double x, double y)
		{
			double x0 = x;
			double y0 = y;
			double ysquared = y0 * y0;
			double xsquared = x0 * x0;
			int iterations = 0;
			while( (iterations < m_MaxIterations) && (x0*x0 + y0*y0 < 4) )
			{
				// this is the Mandelbrot algorithm using doubles.
				ysquared = y0 * y0;
				xsquared = x0 * x0;
				y0 = 2 * y0 * x0 + y;
				x0 = xsquared - ysquared + x;
				iterations++;
			}

			return iterations;
		}
	}
}
