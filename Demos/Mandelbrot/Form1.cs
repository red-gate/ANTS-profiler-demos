using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		private Algorithm m_Algorithm;
		private Settings m_Settings;
		private Image m_MandelbrotImage;
		private System.Windows.Forms.Button cmdDraw;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.PictureBox m_PictureBox1;
		private bool m_Running = true;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_Algorithm = new Algorithm();
			m_Algorithm.MaxIterations = 32;
			m_Settings = new Settings(1, -2, 1.2, -1.2);
			m_MandelbrotImage = new Image(m_PictureBox1.Size.Width, m_PictureBox1.Size.Height);
			m_PictureBox1.Image = m_MandelbrotImage.m_Bitmap;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_PictureBox1 = new System.Windows.Forms.PictureBox();
			this.cmdDraw = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// m_PictureBox1
			// 
			this.m_PictureBox1.Location = new System.Drawing.Point(8, 36);
			this.m_PictureBox1.Name = "m_PictureBox1";
			this.m_PictureBox1.Size = new System.Drawing.Size(436, 264);
			this.m_PictureBox1.TabIndex = 1;
			this.m_PictureBox1.TabStop = false;
			// 
			// cmdDraw
			// 
			this.cmdDraw.Location = new System.Drawing.Point(8, 8);
			this.cmdDraw.Name = "cmdDraw";
			this.cmdDraw.Size = new System.Drawing.Size(128, 24);
			this.cmdDraw.TabIndex = 2;
			this.cmdDraw.Text = "&Draw Mandelbrot Set";
			this.cmdDraw.Click += new System.EventHandler(this.cmdDraw_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(160, 8);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 3;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Quick";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(288, 8);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 4;
			this.radioButton2.Text = "Slow";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(454, 308);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.radioButton2,
																		  this.radioButton1,
																		  this.cmdDraw,
																		  this.m_PictureBox1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Mandelbrot set";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/// <summary>
		/// This draws the complete Mandelbrot set.
		/// </summary>
		private void DrawMandelbrot()
		{
			double dx = m_Settings.Width / m_MandelbrotImage.Width;
			double dy = m_Settings.Height / m_MandelbrotImage.Height;

			double x = m_Settings.XMin;
			double y = m_Settings.YMin;

			for(int i = 0; i < m_MandelbrotImage.Width; i++)
			{
				for( int j = 0; j < m_MandelbrotImage.Height; j++)
				{
					int iterations = m_Algorithm.Evaluate(x, y);
					m_MandelbrotImage.SetPixelColor(i, j, iterations);
					y += dy;
				}

				if(!m_Running)
					return;

				y = m_Settings.YMin;
				x += dx;

				// redraw the picture box every 10 pixels
				if ((i % 10)==0)
				{
					m_PictureBox1.Refresh();
					Application.DoEvents();
				}

			}

			m_PictureBox1.Refresh();
		}

		/// <summary>
		/// Called when the Draw button is clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDraw_Click(object sender, System.EventArgs e)
		{
			Cursor.Current=Cursors.WaitCursor;
			m_MandelbrotImage.Clear();
			m_PictureBox1.Image = m_MandelbrotImage.m_Bitmap;
			m_PictureBox1.Refresh();
			DrawMandelbrot();
			Cursor.Current=Cursors.Default;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Algorithm.UseComplexNumbers = false;
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			m_Algorithm.UseComplexNumbers = true;
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_Running = false;
		
		}
	}
}
