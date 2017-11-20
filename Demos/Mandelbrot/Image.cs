using System;
using System.Drawing;

namespace Mandelbrot
{		
	/// <summary>
	/// A Mandelbrot Image.
	/// </summary>
	public class Image
	{
		public Image(int width, int height)
		{
			m_Width = width;
			m_Height = height;
			m_Bitmap = new Bitmap(m_Width, m_Height);
			//Clear();
		}

		public void SetPixelColor(int i, int j, int iterations)
		{
			m_Bitmap.SetPixel(i, m_Height - j -1, ColorScheme.ColorFromIterations(iterations));
		}

		/// <summary>
		/// The width of the image.
		/// </summary>
		public int Width
		{
			get
			{
				return m_Width;
			}
		}

		/// <summary>
		/// The height of the image.
		/// </summary>
		public int Height
		{
			get
			{
				return m_Height;
			}
		}

		/// <summary>
		/// Clear the image.
		/// </summary>
		public void Clear()
		{
			m_Bitmap = new Bitmap(m_Width, m_Height);
		}

		public Bitmap m_Bitmap;
		int m_Width;
		int m_Height;
	}
}
