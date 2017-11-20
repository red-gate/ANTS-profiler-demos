using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Utility class for converting the number of mandelbrot
	/// itrations to a color.
	/// </summary>
	public class ColorScheme
	{
		public static Color ColorFromIterations(int iterations)
		{
			if(iterations == 32)
				return Color.White;
			int mod5 = iterations % 5;
			int mod13 = iterations % 13;
			int mod17 = iterations % 17;

			return Color.FromArgb(mod5*50, mod17 * 15, mod13 * 19);
		}
	}
}
