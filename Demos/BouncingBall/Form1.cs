using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticeApp1
{
    public partial class Form1 : Form
    {
        private readonly Container m_Container;
        private DateTime m_NextTime = DateTime.Now;
        private int m_Fps = 0, m_FramesThisSecond = 0;

        public Form1()
        {
            InitializeComponent();
            m_Container = new Container(new Rectangle(new Point(0, 0), Canvas.Size));
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Image buffer = new Bitmap(Canvas.Width, Canvas.Height);
            var g = Graphics.FromImage(buffer);
            g.Clear(Color.Black);

            //Render
            m_Container.Paint(g);
            
            e.Graphics.DrawImageUnscaled(buffer, 0, 0);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            m_Container.AddBall(new Point(e.X, e.Y));
            Canvas.Invalidate();
        }

        private void MPhysicsTick(object sender, EventArgs e)
        {
            DateTime thisTime = DateTime.Now;
            m_FramesThisSecond++;

            if (thisTime.CompareTo(m_NextTime) > 0)
            {
                m_Fps = m_FramesThisSecond;
                m_FramesThisSecond = 0;
                m_NextTime = thisTime.AddSeconds(1);
                m_fps.Text = "FPS: " + m_Fps;
            }

            m_Container.NextStep();
            Canvas.Invalidate();
        }

        private void AddnBalls(int n)
        {
            for (int i = 0; i < n; i++)
            {
                m_Container.AddBall();
            }
        }

        private void StartClick(object sender, EventArgs e)
        {
            m_Container.Clear();
            m_Container.Size = Canvas.Size;
            m_Physics.Enabled = true;
        }

        private void CreateLotsClick(object sender, EventArgs e)
        {
            AddnBalls(100);
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            m_Container.Size = Canvas.Size;
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            m_Physics.Enabled = false;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            m_Physics.Enabled = true;
        }
    }
}