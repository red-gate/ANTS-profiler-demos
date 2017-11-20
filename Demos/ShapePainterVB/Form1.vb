Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Namespace ShapePainter

	Public Class Form1
	Inherits System.Windows.Forms.Form
		Private m_Shapes As Shapes = New Shapes
		Private m_ClipBoard As Shapes = New Shapes
		Private m_Random As Random = New Random(CInt(DateTime.Now.Ticks Mod System.Int32.MaxValue))
		Private m_MaxRectangleSize As Size = New Size(150, 150)
		Private m_MaxEllipseSize As Size = New Size(150, 150)
		Private m_MaxTriangleSize As Size = New Size(200, 200)
        Private drawingBoard As ShapePainter.DrawingBoard
		Private toolbarIcons As System.Windows.Forms.ImageList
		Private quit As System.Windows.Forms.MenuItem
		Private menue As System.Windows.Forms.MainMenu
		Private me_file As System.Windows.Forms.MenuItem
		Private me_shapes As System.Windows.Forms.MenuItem
		Private me_addRectangles As System.Windows.Forms.MenuItem
		Private me_seperator1 As System.Windows.Forms.MenuItem
		Private toolBar As System.Windows.Forms.ToolBar
		Private me_addEllipses As System.Windows.Forms.MenuItem
		Private me_addTriangles As System.Windows.Forms.MenuItem
		Private tb_addRectangles As System.Windows.Forms.ToolBarButton
		Private tb_addEllipses As System.Windows.Forms.ToolBarButton
		Private tb_addTriangles As System.Windows.Forms.ToolBarButton
		Private me_seperator2 As System.Windows.Forms.MenuItem
		Private statusBar As System.Windows.Forms.StatusBar
		Private me_deleteRectangles As System.Windows.Forms.MenuItem
		Private tb_deleteRectangles As System.Windows.Forms.ToolBarButton
		Private tb_deleteEllipses As System.Windows.Forms.ToolBarButton
		Private tb_deleteTriangles As System.Windows.Forms.ToolBarButton
		Private me_deleteEllipses As System.Windows.Forms.MenuItem
		Private me_deleteTriangles As System.Windows.Forms.MenuItem
		Private tb_separator1 As System.Windows.Forms.ToolBarButton
		Private tb_separator2 As System.Windows.Forms.ToolBarButton
		Private tb_separator3 As System.Windows.Forms.ToolBarButton
		Private tb_undo As System.Windows.Forms.ToolBarButton
		Private menuItem1 As System.Windows.Forms.MenuItem
		Private me_undo As System.Windows.Forms.MenuItem
		Private menuItem3 As System.Windows.Forms.MenuItem
		Private menuItem4 As System.Windows.Forms.MenuItem
		Private components As System.ComponentModel.IContainer

		Public Sub New()
			InitializeComponent
			Me.drawingBoard.Shapes = Me.m_Shapes
		End Sub

		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
			Me.menue = New System.Windows.Forms.MainMenu
			Me.me_file = New System.Windows.Forms.MenuItem
			Me.menuItem3 = New System.Windows.Forms.MenuItem
			Me.menuItem4 = New System.Windows.Forms.MenuItem
			Me.quit = New System.Windows.Forms.MenuItem
			Me.menuItem1 = New System.Windows.Forms.MenuItem
			Me.me_undo = New System.Windows.Forms.MenuItem
			Me.me_shapes = New System.Windows.Forms.MenuItem
			Me.me_addRectangles = New System.Windows.Forms.MenuItem
			Me.me_deleteRectangles = New System.Windows.Forms.MenuItem
			Me.me_seperator1 = New System.Windows.Forms.MenuItem
			Me.me_addEllipses = New System.Windows.Forms.MenuItem
			Me.me_deleteEllipses = New System.Windows.Forms.MenuItem
			Me.me_seperator2 = New System.Windows.Forms.MenuItem
			Me.me_addTriangles = New System.Windows.Forms.MenuItem
			Me.me_deleteTriangles = New System.Windows.Forms.MenuItem
			Me.toolBar = New System.Windows.Forms.ToolBar
			Me.tb_addRectangles = New System.Windows.Forms.ToolBarButton
			Me.tb_deleteRectangles = New System.Windows.Forms.ToolBarButton
			Me.tb_separator1 = New System.Windows.Forms.ToolBarButton
			Me.tb_addEllipses = New System.Windows.Forms.ToolBarButton
			Me.tb_deleteEllipses = New System.Windows.Forms.ToolBarButton
			Me.tb_separator2 = New System.Windows.Forms.ToolBarButton
			Me.tb_addTriangles = New System.Windows.Forms.ToolBarButton
			Me.tb_deleteTriangles = New System.Windows.Forms.ToolBarButton
			Me.tb_separator3 = New System.Windows.Forms.ToolBarButton
			Me.tb_undo = New System.Windows.Forms.ToolBarButton
			Me.toolbarIcons = New System.Windows.Forms.ImageList(Me.components)
			Me.drawingBoard = New ShapePainter.DrawingBoard
			Me.statusBar = New System.Windows.Forms.StatusBar
			Me.SuspendLayout
			Me.menue.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.me_file, Me.menuItem1, Me.me_shapes})
			Me.me_file.Index = 0
			Me.me_file.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem3, Me.menuItem4, Me.quit})
			Me.me_file.Text = "File"
			Me.menuItem3.Index = 0
			Me.menuItem3.Text = "New"
			AddHandler Me.menuItem3.Click, AddressOf Me.menuItem3_Click
			Me.menuItem4.Index = 1
			Me.menuItem4.Text = "-"
			Me.quit.Index = 2
			Me.quit.Text = "Exit"
			AddHandler Me.quit.Click, AddressOf Me.menuItem2_Click
			Me.menuItem1.Index = 1
			Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.me_undo})
			Me.menuItem1.Text = "Edit"
			Me.me_undo.Enabled = False
			Me.me_undo.Index = 0
			Me.me_undo.Text = "Undo Delete"
			AddHandler Me.me_undo.Click, AddressOf Me.me_undo_Click
			Me.me_shapes.Index = 2
			Me.me_shapes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.me_addRectangles, Me.me_deleteRectangles, Me.me_seperator1, Me.me_addEllipses, Me.me_deleteEllipses, Me.me_seperator2, Me.me_addTriangles, Me.me_deleteTriangles})
			Me.me_shapes.Text = "Shapes"
			Me.me_addRectangles.Index = 0
			Me.me_addRectangles.Text = "Add Rectangles"
			AddHandler Me.me_addRectangles.Click, AddressOf Me.menuItem4_Click
			Me.me_deleteRectangles.Index = 1
			Me.me_deleteRectangles.Text = "Delete Rectangles"
			AddHandler Me.me_deleteRectangles.Click, AddressOf Me.menuItem5_Click
			Me.me_seperator1.Enabled = False
			Me.me_seperator1.Index = 2
			Me.me_seperator1.Text = "-"
			Me.me_addEllipses.Index = 3
			Me.me_addEllipses.Text = "Add Ellipses"
			AddHandler Me.me_addEllipses.Click, AddressOf Me.menuItem7_Click
			Me.me_deleteEllipses.Index = 4
			Me.me_deleteEllipses.Text = "Delete Ellipses"
			AddHandler Me.me_deleteEllipses.Click, AddressOf Me.menuItem8_Click
			Me.me_seperator2.Index = 5
			Me.me_seperator2.Text = "-"
			Me.me_addTriangles.Index = 6
			Me.me_addTriangles.Text = "Add Triangles"
			AddHandler Me.me_addTriangles.Click, AddressOf Me.me_addTriangles_Click
			Me.me_deleteTriangles.Index = 7
			Me.me_deleteTriangles.Text = "Delete Triangles"
			AddHandler Me.me_deleteTriangles.Click, AddressOf Me.me_removeTriangles_Click
			Me.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
			Me.toolBar.AutoSize = False
			Me.toolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tb_addRectangles, Me.tb_deleteRectangles, Me.tb_separator1, Me.tb_addEllipses, Me.tb_deleteEllipses, Me.tb_separator2, Me.tb_addTriangles, Me.tb_deleteTriangles, Me.tb_separator3, Me.tb_undo})
			Me.toolBar.ButtonSize = New System.Drawing.Size(24, 24)
			Me.toolBar.DropDownArrows = True
			Me.toolBar.ImageList = Me.toolbarIcons
			Me.toolBar.Name = "toolBar"
			Me.toolBar.ShowToolTips = True
			Me.toolBar.Size = New System.Drawing.Size(824, 32)
			Me.toolBar.TabIndex = 0
			AddHandler Me.toolBar.ButtonClick, AddressOf Me.toolBar1_ButtonClick
			Me.tb_addRectangles.ImageIndex = 1
			Me.tb_deleteRectangles.ImageIndex = 6
			Me.tb_separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
			Me.tb_addEllipses.ImageIndex = 0
			Me.tb_deleteEllipses.ImageIndex = 3
			Me.tb_separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
			Me.tb_addTriangles.ImageIndex = 2
			Me.tb_deleteTriangles.ImageIndex = 4
			Me.tb_separator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
			Me.tb_undo.Enabled = False
			Me.tb_undo.ImageIndex = 5
			Me.toolbarIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
			Me.toolbarIcons.ImageSize = New System.Drawing.Size(24, 24)
			Me.toolbarIcons.ImageStream = CType((resources.GetObject("toolbarIcons.ImageStream")), System.Windows.Forms.ImageListStreamer)
			Me.toolbarIcons.TransparentColor = System.Drawing.Color.White
			Me.drawingBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.drawingBoard.Dock = System.Windows.Forms.DockStyle.Fill
			Me.drawingBoard.ForeColor = System.Drawing.SystemColors.ControlText
			Me.drawingBoard.Location = New System.Drawing.Point(0, 32)
			Me.drawingBoard.Name = "drawingBoard"
			Me.drawingBoard.Shapes = Nothing
			Me.drawingBoard.Size = New System.Drawing.Size(824, 439)
			Me.drawingBoard.TabIndex = 1
			Me.statusBar.Location = New System.Drawing.Point(0, 471)
			Me.statusBar.Name = "statusBar"
			Me.statusBar.Size = New System.Drawing.Size(824, 22)
			Me.statusBar.TabIndex = 0
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(824, 493)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.drawingBoard, Me.statusBar, Me.toolBar})
			Me.ForeColor = System.Drawing.SystemColors.Control
			Me.Menu = Me.menue
			Me.Name = "Form"
			Me.Text = "Shape Painter"
			Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
			AddHandler Me.Load, AddressOf Me.Form_Load
			Me.ResumeLayout(False)
		End Sub

		<STAThread()> _
		Shared Sub Main()
			Application.Run(New Form1)
		End Sub

		Private Sub UpdateStatusBar()
			Dim totalShapes As Integer = Me.m_Shapes.Count
			Dim noOfRectangles As Integer = 0
			Dim noOfEllipses As Integer = 0
            Dim noOfTriangles As Integer = 0
            Dim MyShape As Shape
            For Each MyShape In Me.m_Shapes
                Select Case MyShape.Type
                    Case ShapeType.Rectangle
                        System.Math.Min(System.Threading.Interlocked.Increment(noOfRectangles), noOfRectangles - 1)
                    Case ShapeType.Ellipse
                        System.Math.Min(System.Threading.Interlocked.Increment(noOfEllipses), noOfEllipses - 1)
                    Case ShapeType.Triangle
                        System.Math.Min(System.Threading.Interlocked.Increment(noOfTriangles), noOfTriangles - 1)
                End Select
            Next
            Me.statusBar.Text = "Total Shapes: " + totalShapes.ToString + "" & Microsoft.VisualBasic.Chr(9) & " Rectangles: " + noOfRectangles.ToString + ", Ellipses: " + noOfEllipses.ToString + ", Triangles: " + noOfTriangles.ToString
		End Sub

		Private Sub CreateRandomShapes(ByVal n As Integer)
			Me.m_Shapes.Clear
            Dim i As Integer
            For i = 0 To n - 1
                Select Case Me.m_Random.Next(3)
                    Case 0
                        Me.m_Shapes.Add(RectangleShape.CreateFromRandom(Me.m_Random, Me.m_MaxRectangleSize, Me.drawingBoard.Size))
                    Case 1
                        Me.m_Shapes.Add(EllipseShape.CreateFromRandom(Me.m_Random, Me.m_MaxEllipseSize, Me.drawingBoard.Size))
                    Case 2
                        Me.m_Shapes.Add(TriangleShape.CreateFromRandom(Me.m_Random, Me.m_MaxTriangleSize, Me.drawingBoard.Size))
                End Select
            Next
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(1).Enabled = True
            Me.me_deleteRectangles.Enabled = True
            Me.toolBar.Buttons(4).Enabled = True
            Me.me_deleteEllipses.Enabled = True
            Me.toolBar.Buttons(7).Enabled = True
            Me.me_deleteTriangles.Enabled = True
		End Sub

		Private Sub CreateRandomRectangles(ByVal n As Integer)
			Dim drawingBoardSize As Size = Me.drawingBoard.Size
			Dim i As Integer
            For i = 0 To n - 1
                Me.m_Shapes.Add(RectangleShape.CreateFromRandom(m_Random, Me.m_MaxRectangleSize, Me.drawingBoard.Size))
            Next
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(1).Enabled = True
            Me.me_deleteRectangles.Enabled = True
		End Sub

		Private Sub RemoveRectangles()
			Me.m_ClipBoard.Clear
			Dim drawingBoardSize As Size = Me.drawingBoard.Size
            Dim i As Integer = 0
            While i < Me.m_Shapes.Count
                If m_Shapes(i).GetType Is GetType(RectangleShape) Then
                    Me.m_ClipBoard.Add(Me.m_Shapes(i))
                    Me.m_Shapes.RemoveAt(i)
                    i = i - 1
                End If
                i = i + 1
            End While
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(9).Enabled = True
            Me.me_undo.Enabled = True
            Me.toolBar.Buttons(1).Enabled = False
            Me.me_deleteRectangles.Enabled = False
        End Sub

        Private Sub CreateRandomEllipses(ByVal n As Integer)
            Dim drawingBoardSize As Size = Me.drawingBoard.Size
            Dim i As Integer
            For i = 0 To n - 1
                Me.m_Shapes.Add(EllipseShape.CreateFromRandom(m_Random, Me.m_MaxEllipseSize, Me.drawingBoard.Size))
            Next
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(4).Enabled = True
            Me.me_deleteEllipses.Enabled = True
        End Sub

        Private Sub RemoveEllipses()
            Me.m_ClipBoard.Clear()
            Dim drawingBoardSize As Size = Me.drawingBoard.Size
            Dim i As Integer = 0
            While i < Me.m_Shapes.Count
                If m_Shapes(i).GetType Is GetType(EllipseShape) Then
                    Me.m_ClipBoard.Add(Me.m_Shapes(i))
                    Me.m_Shapes.RemoveAt(i)
                    i = i - 1
                End If
                i = i + 1
            End While
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(9).Enabled = True
            Me.me_undo.Enabled = True
            Me.toolBar.Buttons(4).Enabled = False
            Me.me_deleteEllipses.Enabled = False
        End Sub

        Private Sub CreateRandomTriangles(ByVal n As Integer)
            Dim drawingBoardSize As Size = Me.drawingBoard.Size
            Dim i As Integer
            For i = 0 To n - 1
                Me.m_Shapes.Add(TriangleShape.CreateFromRandom(m_Random, Me.m_MaxTriangleSize, Me.drawingBoard.Size))
            Next
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.me_deleteTriangles.Enabled = True
            Me.toolBar.Buttons(7).Enabled = True
        End Sub

        Private Sub RemoveTriangles()
            Me.m_ClipBoard.Clear()
            Dim drawingBoardSize As Size = Me.drawingBoard.Size
            Dim i As Integer = 0
            While i < Me.m_Shapes.Count
                If m_Shapes(i).GetType Is GetType(TriangleShape) Then
                    Me.m_ClipBoard.Add(Me.m_Shapes(i))
                    Me.m_Shapes.RemoveAt(i)
                    i = i - 1
                End If
                i = i + 1
            End While
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(9).Enabled = True
            Me.me_undo.Enabled = True
            Me.toolBar.Buttons(7).Enabled = False
            Me.me_deleteTriangles.Enabled = False
        End Sub

        Private Sub Undo()
            Dim MyShape As Shape
            For Each MyShape In Me.m_ClipBoard
                Me.m_Shapes.Add(MyShape)
            Next
            Me.drawingBoard.Refresh()
            Me.UpdateStatusBar()
            Me.toolBar.Buttons(9).Enabled = False
            Me.me_undo.Enabled = False
            Select Case m_ClipBoard(0).Type
                Case ShapeType.Rectangle
                    Me.toolBar.Buttons(1).Enabled = True
                    Me.me_deleteRectangles.Enabled = True
                Case ShapeType.Ellipse
                    Me.toolBar.Buttons(4).Enabled = True
                    Me.me_deleteEllipses.Enabled = True
                Case ShapeType.Triangle
                    Me.toolBar.Buttons(7).Enabled = True
                    Me.me_deleteTriangles.Enabled = True
            End Select
            Me.m_ClipBoard.Clear()
        End Sub

        Private Sub toolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
            Select Case toolBar.Buttons.IndexOf(e.Button)
                Case 0
                    Me.CreateRandomRectangles(10)
                Case 1
                    Me.RemoveRectangles()
                Case 3
                    Me.CreateRandomEllipses(10)
                Case 4
                    Me.RemoveEllipses()
                Case 6
                    Me.CreateRandomTriangles(10)
                Case 7
                    Me.RemoveTriangles()
                Case 9
                    Me.Undo()
            End Select
        End Sub

        Private Sub menuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Application.Exit()
        End Sub

        Private Sub menuItem5_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.RemoveRectangles()
        End Sub

        Private Sub menuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateRandomRectangles(10)
        End Sub

        Private Sub menuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateRandomEllipses(10)
        End Sub

        Private Sub menuItem8_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.RemoveEllipses()
        End Sub

        Private Sub me_addTriangles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateRandomTriangles(10)
        End Sub

        Private Sub me_removeTriangles_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.RemoveTriangles()
        End Sub

        Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateRandomShapes(200)
        End Sub

        Private Sub me_undo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.Undo()
        End Sub

        Private Sub menuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.CreateRandomShapes(200)
        End Sub
    End Class
End Namespace
