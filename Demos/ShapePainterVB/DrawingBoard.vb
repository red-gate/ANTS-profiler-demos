Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms
Namespace ShapePainter

	Public Class DrawingBoard
	Inherits Panel
		Private m_Shapes As Shapes

		Public Property Shapes() As Shapes
			Get
				Return m_Shapes
			End Get
			Set
				m_Shapes = value
			End Set
		End Property

		Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			If Not (Me.m_Shapes Is Nothing) Then
                Dim g As Graphics = e.Graphics
                Dim MyShape As Shape
                For Each MyShape In Me.m_Shapes
                    MyShape.draw(g)
                Next
            End If
		End Sub
	End Class 
End Namespace
