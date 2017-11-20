Imports System
Imports System.Drawing
Namespace Mandelbrot

	Public Class Image

		Public Sub New(ByVal width As Integer, ByVal height As Integer)
			m_Width = width
			m_Height = height
			m_Bitmap = New Bitmap(m_Width, m_Height)
		End Sub

		Public Sub SetPixelColor(ByVal i As Integer, ByVal j As Integer, ByVal iterations As Integer)
			m_Bitmap.SetPixel(i, m_Height - j - 1, ColorScheme.ColorFromIterations(iterations))
		End Sub

		Public ReadOnly Property Width() As Integer
			Get
				Return m_Width
			End Get
		End Property

		Public ReadOnly Property Height() As Integer
			Get
				Return m_Height
			End Get
		End Property

		Public Sub Clear()
			m_Bitmap = New Bitmap(m_Width, m_Height)
		End Sub
		Public m_Bitmap As Bitmap
		Private m_Width As Integer
		Private m_Height As Integer
	End Class 
End Namespace
