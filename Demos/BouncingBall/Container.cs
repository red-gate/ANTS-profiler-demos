using System;
using System.Collections.Generic;
using System.Drawing;

namespace PracticeApp1
{
    internal class Container
    {
        private static readonly Random s_Random = new Random();

        public Container(Rectangle bounds)
        {
            Bounds = bounds;
            Contained = new List<Ball>();
        }

        private Rectangle Bounds { get; set; }
        private List<Ball> Contained { get; set; }

        public Size Size
        {
            set
            {
                int numRemoved = 0;
                var toRemove = new List<Ball>();
                if (value.Width < Bounds.Width || value.Height < Bounds.Height)
                {
                    //Find balls to remove
                    foreach (Ball b in Contained)
                    {
                        if (!b.Bounds.IntersectsWith(Bounds))
                        {
                            toRemove.Add(b);
                            numRemoved++;
                        }
                    }

                    //Remove them
                    foreach (Ball b in toRemove) Contained.Remove(b);
                }

                Bounds = new Rectangle(Bounds.Location, value);

                for (int i = numRemoved; i > 0; i--)
                {
                    AddBall();
                }
            }
        }

        private static void CheckOneBall(Ball b, Ball c, Rectangle ballBounds, ref Size ballVelocity)
        {
            if (!b.Equals(c) && ballBounds.IntersectsWith(c.Bounds))
            {
                //Share some momentum on collision, there is some rounding error
                var newVel = new Size(
                    (c.Velocity.Width + ballVelocity.Width)/4,
                    (c.Velocity.Height + ballVelocity.Height)/4);

                c.Velocity = ReverseAVelocity(c.Velocity) + newVel;
                ballVelocity = ReverseAVelocity(ballVelocity) + newVel;

                //Keeps balls moving, no phsyical basis, just looks nicer
                if (ballVelocity.Width == 0) ballVelocity.Width = s_Random.Next(-1, 1);
                if (ballVelocity.Height == 0) ballVelocity.Height = s_Random.Next(-1, 1);
            }
        }

        /// <summary>
        /// Check intersection with every other ball
        /// This is a very inefficient collision detection method
        /// </summary>
        private void CheckAllBallIntersections(Ball b, Rectangle ballBounds, ref Size ballVelocity)
        {
            foreach (Ball c in Contained)
            {
                CheckOneBall(b, c, ballBounds, ref ballVelocity);
            }
        }

        public void NextStep()
        {
            foreach (Ball b in Contained)
            {
                var ballBounds = new Rectangle(
                    b.Bounds.Location + b.Velocity, b.Bounds.Size);
                Size ballVelocity = b.Velocity;

                //Bounce from side
                MaybeBounce(ref ballBounds, ref ballVelocity);

                CheckAllBallIntersections(b, ballBounds, ref ballVelocity);

                //Update actual ball
                b.Bounds = ballBounds;
                b.Velocity = ballVelocity;
            }
        }

        /// <summary>
        /// Bounce from container edge
        /// </summary>
        private void MaybeBounce(ref Rectangle ballB, ref Size ballV)
        {
            Rectangle ballBounds = ballB;
            Size ballVelocity = ballV;
            MaybeBounce(Bounds.Left, ballBounds.Left, ballVelocity.Width, newPos => ballBounds.X = newPos,
                        newSpeed => ballVelocity.Width = newSpeed);
            MaybeBounce(Bounds.Top, ballBounds.Top, ballVelocity.Height, newPos => ballBounds.Y = newPos,
                        newSpeed => ballVelocity.Height = newSpeed);
            MaybeBounce(-Bounds.Right, -ballBounds.Right, ballVelocity.Width,
                        newPos => ballBounds.X = -newPos - ballBounds.Width, newSpeed => ballVelocity.Width = newSpeed);
            MaybeBounce(-Bounds.Bottom, -ballBounds.Bottom, ballVelocity.Height,
                        newPos => ballBounds.Y = -newPos - ballBounds.Height, newSpeed => ballVelocity.Height = newSpeed);
            ballB = ballBounds;
            ballV = ballVelocity;
        }

        private static void MaybeBounce(int wallPos, int ballPos, int ballSpeed, Action<int> posSetter,
                                        Action<int> speedSetter)
        {
            if (ballPos < wallPos)
            {
                int rebound = wallPos - ballPos;
                posSetter(ballPos + rebound);
                speedSetter(-ballSpeed);
            }
        }

        public void AddBall(Point pos)
        {
            Contained.Add(new Ball(pos));
        }

        public void AddBall()
        {
            AddBall(new Point(s_Random.Next(Bounds.Left, Bounds.Right), s_Random.Next(Bounds.Top, Bounds.Bottom)));
        }

        public void Clear()
        {
            Contained.Clear();
        }

        private static Size ReverseAVelocity(Size velocity)
        {
            return new Size(-velocity.Width, -velocity.Height);
        }

        internal void Paint(Graphics g)
        {
            foreach (Ball b in Contained)
            {
                b.Paint(g);
            }
        }
    }
}