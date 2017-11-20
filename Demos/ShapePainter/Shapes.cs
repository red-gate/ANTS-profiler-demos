using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShapePainter
{
	public enum ShapeType
	{
		Rectangle,
		Ellipse,
		Triangle,
		Quadrilateral
	}
	/// <summary>
	/// Summary description for Shape.
	/// </summary>
	public abstract class Shape
	{
		protected Color m_Color = Color.Empty;
		public abstract void draw(Graphics g);
		public abstract ShapeType Type
		{
			get;
		}
	}

	public class RectangleShape : Shape
	{
		private Rectangle m_Rectangle;

		public RectangleShape(int x, int y, int width, int height, Color color)
		{
			this.m_Rectangle = new Rectangle(x, y, width, height);
			this.m_Color = color;
		}

		public override ShapeType Type
		{
			get
			{
				return ShapeType.Rectangle;
			}
		}

		public static RectangleShape CreateFromRandom(Random random, Size size, Size drawingBoardSize)
		{
			int width = random.Next(10, size.Width);
			int height = random.Next(10, size.Height);
			int x = random.Next(Math.Max(0, drawingBoardSize.Width - width));
			int y = random.Next(Math.Max(0, drawingBoardSize.Height - height));
			Color color = Color.FromArgb(0, 0, random.Next(128, 255));
			RectangleShape rectangle = new RectangleShape(x, y, width - 5, height - 5, color);
			return rectangle;
		}
		
		public override void draw(Graphics g)
		{
			g.FillRectangle(new SolidBrush(this.m_Color), this.m_Rectangle);
		}
	}

	public class EllipseShape : Shape
	{
		private Rectangle m_Ellipse;

		public EllipseShape(int x, int y, int width, int height, Color color)
		{
			this.m_Ellipse = new Rectangle(x, y, width, height);
			this.m_Color = color;
		}

		public override ShapeType Type
		{
			get
			{
				return ShapeType.Ellipse;
			}
		}

		public static EllipseShape CreateFromRandom(Random random, Size size, Size drawingBoardSize)
		{
			int width = random.Next(10, size.Width);
			int height = random.Next(10, size.Height);
			int x = random.Next(Math.Max(0, drawingBoardSize.Width - width));
			int y = random.Next(Math.Max(0, drawingBoardSize.Height - height));
			Color color = Color.FromArgb(0, random.Next(128, 255), 0);
			return new EllipseShape(x, y, width - 5, height - 5, color);
		}

		public override void draw(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillEllipse(new SolidBrush(this.m_Color), this.m_Ellipse);
		}
	}

	public class TriangleShape : Shape
	{
		Point[] m_Triangle = new Point[3];

		public TriangleShape(Point[] triangle, Color color)
		{
			this.m_Triangle = triangle;
			this.m_Color = color;
		}

		public override ShapeType Type
		{
			get
			{
				return ShapeType.Triangle;
			}
		}

		public static TriangleShape CreateFromRandom(Random random, Size size, Size drawingBoardSize)
		{
			Point[] triangle = new Point[3];
			int x_offset = random.Next(Math.Max(0, drawingBoardSize.Width - size.Width));
			int y_offset = random.Next(Math.Max(0, drawingBoardSize.Height - size.Height));
			for (int i = 0; i < 3; i++)
			{
				triangle[i] = new Point(random.Next(1, size.Width) + x_offset, random.Next(1, size.Height) + y_offset);
			}

			Color color = Color.FromArgb(random.Next(128, 255), 0, 0);
			return new TriangleShape(triangle, color);
		}

		public override void draw(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillPolygon(new SolidBrush(this.m_Color), this.m_Triangle);
		}
	}
}
