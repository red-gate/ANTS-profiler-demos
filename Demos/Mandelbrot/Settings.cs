using System;

namespace Mandelbrot
{
	public struct Settings
	{
		public Settings(double xMax, double xMin, double yMax, double yMin)
		{
			m_XMax = xMax;
			m_XMin = xMin;
			m_YMax = yMax;
			m_YMin = yMin;
		}

		public double XMax
		{
			get
			{
				return m_XMax;
			}
		}

		public double XMin
		{
			get
			{
				return m_XMin;
			}
		}

		public double YMax
		{
			get
			{
				return m_YMax;
			}
		}

		public double YMin
		{
			get
			{
				return m_YMin;
			}
		}

		public double Width
		{
			get
			{
				return m_XMax - m_XMin;
			}
		}

		public double Height
		{
			get
			{ 
				return m_YMax - m_YMin;
			}
		}

		double m_XMax;
		double m_XMin;
		double m_YMax;
		double m_YMin;
	}
}