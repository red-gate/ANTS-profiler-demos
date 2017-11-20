Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Namespace ShapePainter

	Public Enum ShapeType
		Rectangle = 0
		Ellipse = 1
		Triangle = 2
		Quadrilateral = 3
	End Enum 

	Public MustInherit Class Shape
		Protected m_Color As Color = Color.Empty

		Public MustOverride Sub draw(ByVal g As Graphics)

		Public MustOverride ReadOnly Property Type() As ShapeType
	End Class 

	Public Class RectangleShape
	Inherits Shape
		Private m_Rectangle As Rectangle

		Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal color As Color)
			Me.m_Rectangle = New Rectangle(x, y, width, height)
			Me.m_Color = color
		End Sub

		Public Overloads Overrides ReadOnly Property Type() As ShapeType
			Get
				Return ShapeType.Rectangle
			End Get
		End Property

		Public Shared Function CreateFromRandom(ByVal random As Random, ByVal size As Size, ByVal drawingBoardSize As Size) As RectangleShape
            Dim width As Integer = random.Next(10, size.Width)
			Dim height As Integer = random.Next(10, size.Height)
            Dim x As Integer = random.Next(Math.Max(0, drawingBoardSize.Width - width))
            Dim y As Integer = random.Next(Math.Max(0, drawingBoardSize.Height - height))
            Dim color As Color = Drawing.Color.FromArgb(0, 0, random.Next(128, 255))
			Dim rectangle As RectangleShape = New RectangleShape(x, y, width - 5, height - 5, color)
			Return rectangle
		End Function

		Public Overloads Overrides Sub draw(ByVal g As Graphics)
			g.FillRectangle(New SolidBrush(Me.m_Color), Me.m_Rectangle)
		End Sub
	End Class 

	Public Class EllipseShape
	Inherits Shape
		Private m_Ellipse As Rectangle

		Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal color As Color)
			Me.m_Ellipse = New Rectangle(x, y, width, height)
			Me.m_Color = color
		End Sub

		Public Overloads Overrides ReadOnly Property Type() As ShapeType
			Get
				Return ShapeType.Ellipse
			End Get
		End Property

		Public Shared Function CreateFromRandom(ByVal random As Random, ByVal size As Size, ByVal drawingBoardSize As Size) As EllipseShape
			Dim width As Integer = random.Next(10, size.Width)
			Dim height As Integer = random.Next(10, size.Height)
            Dim x As Integer = random.Next(Math.Max(0, drawingBoardSize.Width - width))
            Dim y As Integer = random.Next(Math.Max(0, drawingBoardSize.Height - height))
            Dim color As Color = Drawing.Color.FromArgb(0, random.Next(128, 255), 0)
			Return New EllipseShape(x, y, width - 5, height - 5, color)
		End Function

		Public Overloads Overrides Sub draw(ByVal g As Graphics)
			g.SmoothingMode = SmoothingMode.AntiAlias
			g.FillEllipse(New SolidBrush(Me.m_Color), Me.m_Ellipse)
		End Sub
	End Class 

	Public Class TriangleShape
	Inherits Shape
		Private m_Triangle As Point() = New Point(3) {}

		Public Sub New(ByVal triangle As Point(), ByVal color As Color)
			Me.m_Triangle = triangle
			Me.m_Color = color
		End Sub

		Public Overloads Overrides ReadOnly Property Type() As ShapeType
			Get
				Return ShapeType.Triangle
			End Get
		End Property

		Public Shared Function CreateFromRandom(ByVal random As Random, ByVal size As Size, ByVal drawingBoardSize As Size) As TriangleShape
            Dim triangle(2) As Point
            Dim x_offset As Integer = random.Next(Math.Max(0, drawingBoardSize.Width - size.Width))
            Dim y_offset As Integer = random.Next(Math.Max(0, drawingBoardSize.Height - size.Height))
            Dim i As Integer
            For i = 0 To 2
                triangle(i) = New Point(random.Next(1, size.Width) + x_offset, random.Next(1, size.Height) + y_offset)
            Next
            Dim color As Color = Drawing.Color.FromArgb(random.Next(128, 255), 0, 0)
            Return New TriangleShape(triangle, color)
		End Function

		Public Overloads Overrides Sub draw(ByVal g As Graphics)
			g.SmoothingMode = SmoothingMode.AntiAlias
			g.FillPolygon(New SolidBrush(Me.m_Color), Me.m_Triangle)
		End Sub
	End Class 
End Namespace
