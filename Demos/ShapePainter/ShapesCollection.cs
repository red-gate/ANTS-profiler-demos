using System;
using System.Collections;

namespace ShapePainter
{
	/// <summary>
	/// A collection of shapes, eg. rectangles, ellipses etc.
	/// </summary>
	public class Shapes : CollectionBase
	{
		public Shape this[int index]
		{
			get
			{
				return (Shape)this.List[index];
			}
		}

		public void Add(Shape shape)
		{
			this.List.Add(shape);
		}

		public void Remove(Shape shape)
		{
			int index = this.List.IndexOf(shape);
			if(index != -1)
				this.List.RemoveAt(index);
		}
	}
}
