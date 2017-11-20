Imports System
Namespace Mandelbrot

	Public Structure Settings

		Public Sub New(ByVal xMax As Double, ByVal xMin As Double, ByVal yMax As Double, ByVal yMin As Double)
			m_XMax = xMax
			m_XMin = xMin
			m_YMax = yMax
			m_YMin = yMin
		End Sub

		Public ReadOnly Property XMax() As Double
			Get
				Return m_XMax
			End Get
		End Property

		Public ReadOnly Property XMin() As Double
			Get
				Return m_XMin
			End Get
		End Property

		Public ReadOnly Property YMax() As Double
			Get
				Return m_YMax
			End Get
		End Property

		Public ReadOnly Property YMin() As Double
			Get
				Return m_YMin
			End Get
		End Property

		Public ReadOnly Property Width() As Double
			Get
				Return m_XMax - m_XMin
			End Get
		End Property

		Public ReadOnly Property Height() As Double
			Get
				Return m_YMax - m_YMin
			End Get
		End Property
		Private m_XMax As Double
		Private m_XMin As Double
		Private m_YMax As Double
		Private m_YMin As Double
	End Structure 
End Namespace
