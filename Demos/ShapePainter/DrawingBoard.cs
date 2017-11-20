using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ShapePainter
{
	/// <summary>
	/// A panel that draws shapes.
	/// </summary>
	public class DrawingBoard: Panel
	{
		Shapes m_Shapes;

		public Shapes Shapes
		{
			get
			{
				return m_Shapes;
			}
			set
			{
				m_Shapes = value;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.m_Shapes != null)
			{
				Graphics g = e.Graphics;
				foreach(Shape shape in this.m_Shapes)
				{
					shape.draw(g);
				}
			}
		}
	}
}
