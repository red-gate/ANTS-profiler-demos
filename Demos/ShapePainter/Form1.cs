using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ShapePainter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Shapes m_Shapes = new Shapes();
		private Shapes m_ClipBoard = new Shapes();
		private Random m_Random = new Random((int)DateTime.Now.Ticks);
		private Size m_MaxRectangleSize = new Size(150, 150);
		private Size m_MaxEllipseSize = new Size(150, 150);
		private Size m_MaxTriangleSize = new Size(200, 200);

		private ShapePainter.DrawingBoard drawingBoard;
		private System.Windows.Forms.ImageList toolbarIcons;
		private System.Windows.Forms.MenuItem exit;
		private System.Windows.Forms.MainMenu menu;
		private System.Windows.Forms.MenuItem me_file;
		private System.Windows.Forms.MenuItem me_shapes;
		private System.Windows.Forms.MenuItem me_addRectangles;
		private System.Windows.Forms.MenuItem me_seperator1;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.MenuItem me_addEllipses;
		private System.Windows.Forms.MenuItem me_addTriangles;
		private System.Windows.Forms.ToolBarButton tb_addRectangles;
		private System.Windows.Forms.ToolBarButton tb_addEllipses;
		private System.Windows.Forms.ToolBarButton tb_addTriangles;
		private System.Windows.Forms.MenuItem me_seperator2;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem me_deleteRectangles;
		private System.Windows.Forms.ToolBarButton tb_deleteRectangles;
		private System.Windows.Forms.ToolBarButton tb_deleteEllipses;
		private System.Windows.Forms.ToolBarButton tb_deleteTriangles;
		private System.Windows.Forms.MenuItem me_deleteEllipses;
		private System.Windows.Forms.MenuItem me_deleteTriangles;
		private System.Windows.Forms.ToolBarButton tb_separator1;
		private System.Windows.Forms.ToolBarButton tb_separator2;
		private System.Windows.Forms.ToolBarButton tb_separator3;
		private System.Windows.Forms.ToolBarButton tb_undo;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem me_undo;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.drawingBoard.Shapes = this.m_Shapes;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.menu = new System.Windows.Forms.MainMenu();
			this.me_file = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.exit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.me_undo = new System.Windows.Forms.MenuItem();
			this.me_shapes = new System.Windows.Forms.MenuItem();
			this.me_addRectangles = new System.Windows.Forms.MenuItem();
			this.me_deleteRectangles = new System.Windows.Forms.MenuItem();
			this.me_seperator1 = new System.Windows.Forms.MenuItem();
			this.me_addEllipses = new System.Windows.Forms.MenuItem();
			this.me_deleteEllipses = new System.Windows.Forms.MenuItem();
			this.me_seperator2 = new System.Windows.Forms.MenuItem();
			this.me_addTriangles = new System.Windows.Forms.MenuItem();
			this.me_deleteTriangles = new System.Windows.Forms.MenuItem();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.tb_addRectangles = new System.Windows.Forms.ToolBarButton();
			this.tb_deleteRectangles = new System.Windows.Forms.ToolBarButton();
			this.tb_separator1 = new System.Windows.Forms.ToolBarButton();
			this.tb_addEllipses = new System.Windows.Forms.ToolBarButton();
			this.tb_deleteEllipses = new System.Windows.Forms.ToolBarButton();
			this.tb_separator2 = new System.Windows.Forms.ToolBarButton();
			this.tb_addTriangles = new System.Windows.Forms.ToolBarButton();
			this.tb_deleteTriangles = new System.Windows.Forms.ToolBarButton();
			this.tb_separator3 = new System.Windows.Forms.ToolBarButton();
			this.tb_undo = new System.Windows.Forms.ToolBarButton();
			this.toolbarIcons = new System.Windows.Forms.ImageList(this.components);
			this.drawingBoard = new ShapePainter.DrawingBoard();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.me_file,
																				 this.menuItem1,
																				 this.me_shapes});
			// 
			// me_file
			// 
			this.me_file.Index = 0;
			this.me_file.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem3,
																					this.menuItem4,
																					this.exit});
			this.me_file.Text = "File";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "New";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			// 
			// exit
			// 
			this.exit.Index = 2;
			this.exit.Text = "Exit";
			this.exit.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.me_undo});
			this.menuItem1.Text = "Edit";
			// 
			// me_undo
			// 
			this.me_undo.Enabled = false;
			this.me_undo.Index = 0;
			this.me_undo.Text = "Undo Delete";
			this.me_undo.Click += new System.EventHandler(this.me_undo_Click);
			// 
			// me_shapes
			// 
			this.me_shapes.Index = 2;
			this.me_shapes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.me_addRectangles,
																					  this.me_deleteRectangles,
																					  this.me_seperator1,
																					  this.me_addEllipses,
																					  this.me_deleteEllipses,
																					  this.me_seperator2,
																					  this.me_addTriangles,
																					  this.me_deleteTriangles});
			this.me_shapes.Text = "Shapes";
			// 
			// me_addRectangles
			// 
			this.me_addRectangles.Index = 0;
			this.me_addRectangles.Text = "Add Rectangles";
			this.me_addRectangles.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// me_deleteRectangles
			// 
			this.me_deleteRectangles.Index = 1;
			this.me_deleteRectangles.Text = "Delete Rectangles";
			this.me_deleteRectangles.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// me_seperator1
			// 
			this.me_seperator1.Enabled = false;
			this.me_seperator1.Index = 2;
			this.me_seperator1.Text = "-";
			// 
			// me_addEllipses
			// 
			this.me_addEllipses.Index = 3;
			this.me_addEllipses.Text = "Add Ellipses";
			this.me_addEllipses.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// me_deleteEllipses
			// 
			this.me_deleteEllipses.Index = 4;
			this.me_deleteEllipses.Text = "Delete Ellipses";
			this.me_deleteEllipses.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// me_seperator2
			// 
			this.me_seperator2.Index = 5;
			this.me_seperator2.Text = "-";
			// 
			// me_addTriangles
			// 
			this.me_addTriangles.Index = 6;
			this.me_addTriangles.Text = "Add Triangles";
			this.me_addTriangles.Click += new System.EventHandler(this.me_addTriangles_Click);
			// 
			// me_deleteTriangles
			// 
			this.me_deleteTriangles.Index = 7;
			this.me_deleteTriangles.Text = "Delete Triangles";
			this.me_deleteTriangles.Click += new System.EventHandler(this.me_removeTriangles_Click);
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.AutoSize = false;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.tb_addRectangles,
																					   this.tb_deleteRectangles,
																					   this.tb_separator1,
																					   this.tb_addEllipses,
																					   this.tb_deleteEllipses,
																					   this.tb_separator2,
																					   this.tb_addTriangles,
																					   this.tb_deleteTriangles,
																					   this.tb_separator3,
																					   this.tb_undo});
			this.toolBar.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.toolbarIcons;
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(824, 32);
			this.toolBar.TabIndex = 0;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tb_addRectangles
			// 
			this.tb_addRectangles.ImageIndex = 1;
			// 
			// tb_deleteRectangles
			// 
			this.tb_deleteRectangles.ImageIndex = 6;
			// 
			// tb_separator1
			// 
			this.tb_separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tb_addEllipses
			// 
			this.tb_addEllipses.ImageIndex = 0;
			// 
			// tb_deleteEllipses
			// 
			this.tb_deleteEllipses.ImageIndex = 3;
			// 
			// tb_separator2
			// 
			this.tb_separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tb_addTriangles
			// 
			this.tb_addTriangles.ImageIndex = 2;
			// 
			// tb_deleteTriangles
			// 
			this.tb_deleteTriangles.ImageIndex = 4;
			// 
			// tb_separator3
			// 
			this.tb_separator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tb_undo
			// 
			this.tb_undo.Enabled = false;
			this.tb_undo.ImageIndex = 5;
			// 
			// toolbarIcons
			// 
			this.toolbarIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.toolbarIcons.ImageSize = new System.Drawing.Size(24, 24);
			this.toolbarIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolbarIcons.ImageStream")));
			this.toolbarIcons.TransparentColor = System.Drawing.Color.White;
			// 
			// drawingBoard
			// 
			this.drawingBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.drawingBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawingBoard.ForeColor = System.Drawing.SystemColors.ControlText;
			this.drawingBoard.Location = new System.Drawing.Point(0, 32);
			this.drawingBoard.Name = "drawingBoard";
			this.drawingBoard.Shapes = null;
			this.drawingBoard.Size = new System.Drawing.Size(824, 439);
			this.drawingBoard.TabIndex = 1;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 471);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(824, 22);
			this.statusBar.TabIndex = 0;
			// 
			// Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(824, 493);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.drawingBoard,
																		  this.statusBar,
																		  this.toolBar});
			this.ForeColor = System.Drawing.SystemColors.Control;
			this.Menu = this.menu;
			this.Name = "Form1";
			this.Text = "Shape Painter";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form_Load);
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

		private void UpdateStatusBar()
		{
			int totalShapes = this.m_Shapes.Count;
			int noOfRectangles = 0;
			int noOfEllipses = 0;
			int noOfTriangles = 0;
			foreach(Shape shape in this.m_Shapes)
			{
				switch(shape.Type)
				{
					case ShapeType.Rectangle:
						noOfRectangles++;
						break;
					case ShapeType.Ellipse:
						noOfEllipses++;
						break;
					case ShapeType.Triangle:
						noOfTriangles++;
						break;
				}
			}
			this.statusBar.Text = "Total Shapes: " + totalShapes.ToString() + "\t Rectangles: " + noOfRectangles.ToString() + ", Ellipses: " + noOfEllipses.ToString() + ", Triangles: " + noOfTriangles.ToString();
		}

		private void CreateRandomShapes(uint n)
		{
			this.m_Shapes.Clear();
			for (int i = 0; i < n; i++)
			{
				switch(this.m_Random.Next(3))
				{
					case 0:
						this.m_Shapes.Add(RectangleShape.CreateFromRandom(this.m_Random, this.m_MaxRectangleSize, this.drawingBoard.Size));
						break;
					case 1:
						this.m_Shapes.Add(EllipseShape.CreateFromRandom(this.m_Random, this.m_MaxEllipseSize, this.drawingBoard.Size));
						break;
					case 2:
						this.m_Shapes.Add(TriangleShape.CreateFromRandom(this.m_Random, this.m_MaxTriangleSize, this.drawingBoard.Size));
						break;
				}
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[1].Enabled = true;
			this.me_deleteRectangles.Enabled = true;
			this.toolBar.Buttons[4].Enabled = true;
			this.me_deleteEllipses.Enabled = true;
			this.toolBar.Buttons[7].Enabled = true;
			this.me_deleteTriangles.Enabled = true;
		}

		private void CreateRandomRectangles(uint n)
		{
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < n; i++)
			{
				this.m_Shapes.Add(RectangleShape.CreateFromRandom(m_Random, this.m_MaxRectangleSize, this.drawingBoard.Size));
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[1].Enabled = true;
			this.me_deleteRectangles.Enabled = true;
		}

		private void RemoveRectangles()
		{
			this.m_ClipBoard.Clear();
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < this.m_Shapes.Count; i++)
			{
				if (m_Shapes[i].GetType() == typeof(RectangleShape))
				{
					this.m_ClipBoard.Add(this.m_Shapes[i]);
					this.m_Shapes.RemoveAt(i--);
				}
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[9].Enabled = true;
			this.me_undo.Enabled = true;
			this.toolBar.Buttons[1].Enabled = false;
			this.me_deleteRectangles.Enabled = false;
		}

		private void CreateRandomEllipses(uint n)
		{
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < n; i++)
			{
				this.m_Shapes.Add(EllipseShape.CreateFromRandom(m_Random, this.m_MaxEllipseSize, this.drawingBoard.Size));
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[4].Enabled = true;
			this.me_deleteEllipses.Enabled = true;
		}

		private void RemoveEllipses()
		{
			this.m_ClipBoard.Clear();
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < this.m_Shapes.Count; i++)
			{
				if (m_Shapes[i].GetType() == typeof(EllipseShape))
				{
					this.m_ClipBoard.Add(this.m_Shapes[i]);
					this.m_Shapes.RemoveAt(i--);
				}
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[9].Enabled = true;
			this.me_undo.Enabled = true;
			this.toolBar.Buttons[4].Enabled = false;
			this.me_deleteEllipses.Enabled = false;
	}

		private void CreateRandomTriangles(uint n)
		{
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < n; i++)
			{
				this.m_Shapes.Add(TriangleShape.CreateFromRandom(m_Random, this.m_MaxTriangleSize, this.drawingBoard.Size));
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.me_deleteTriangles.Enabled = true;
			this.toolBar.Buttons[7].Enabled = true;
		}

		private void RemoveTriangles()
		{
			this.m_ClipBoard.Clear();
			Size drawingBoardSize = this.drawingBoard.Size;
			for (int i = 0; i < this.m_Shapes.Count; i++)
			{
				if (m_Shapes[i].GetType() == typeof(TriangleShape))
				{
					this.m_ClipBoard.Add(this.m_Shapes[i]);
					this.m_Shapes.RemoveAt(i--);
				}
			}
			this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[9].Enabled = true;
			this.me_undo.Enabled = true;
			this.toolBar.Buttons[7].Enabled = false;
			this.me_deleteTriangles.Enabled = false;
		}

		private void Undo()
		{
			foreach(Shape shape in this.m_ClipBoard)
			{
				this.m_Shapes.Add(shape);
			}
            this.drawingBoard.Refresh();
			this.UpdateStatusBar();
			this.toolBar.Buttons[9].Enabled = false;
			this.me_undo.Enabled = false;
			switch(m_ClipBoard[0].Type)
			{
				case ShapeType.Rectangle:
					this.toolBar.Buttons[1].Enabled = true;
					this.me_deleteRectangles.Enabled = true;
					break;
				case ShapeType.Ellipse:
					this.toolBar.Buttons[4].Enabled = true;
					this.me_deleteEllipses.Enabled = true;
					break;
				case ShapeType.Triangle:
					this.toolBar.Buttons[7].Enabled = true;
					this.me_deleteTriangles.Enabled = true;
					break;
			}
			this.m_ClipBoard.Clear();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(toolBar.Buttons.IndexOf(e.Button))
			{
				case 0:
					this.CreateRandomRectangles(10);
					break;
				case 1:
					this.RemoveRectangles();
					break;
				case 3:
					this.CreateRandomEllipses(10);
					break;
				case 4:
					this.RemoveEllipses();
					break;
				case 6:
					this.CreateRandomTriangles(10);
					break;
				case 7:
					this.RemoveTriangles();
					break;
				case 9:
					this.Undo();
					break;
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.RemoveRectangles();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			this.CreateRandomRectangles(10);
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			this.CreateRandomEllipses(10);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			this.RemoveEllipses();
		}

		private void me_addTriangles_Click(object sender, System.EventArgs e)
		{
			this.CreateRandomTriangles(10);
		}

		private void me_removeTriangles_Click(object sender, System.EventArgs e)
		{
		    this.RemoveTriangles();
		}

		private void Form_Load(object sender, System.EventArgs e)
		{
			this.CreateRandomShapes(200);
		}

		private void me_undo_Click(object sender, System.EventArgs e)
		{
			this.Undo();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			this.CreateRandomShapes(200);
		}
	}
}
