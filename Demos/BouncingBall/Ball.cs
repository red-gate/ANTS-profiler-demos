using System;
using System.Drawing;

namespace PracticeApp1
{
    internal class Ball
    {
        private static readonly Random s_Random = new Random();
        private const int MaxSpeed = 15, BallSize = 8;

        public Ball(Rectangle bounds)
        {
            Bounds = bounds;
            Velocity = new Size(s_Random.Next(
                -MaxSpeed, MaxSpeed), s_Random.Next(-MaxSpeed, MaxSpeed));
        }

        public Ball(Point pos)
            : this(new Rectangle(pos, new Size(BallSize, BallSize)))
        {
        }

        public void Paint(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.FromArgb(205, 8, 9)), Bounds);
        }

        public Rectangle Bounds { get; set; }

        public Size Velocity { get; set; }
    }
}