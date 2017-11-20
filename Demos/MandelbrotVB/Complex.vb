Imports System
Namespace Mandelbrot

	Public Structure Complex
		Private m_X As Double
		Private m_Y As Double

		Public Sub New(ByVal c As Complex)
			m_X = c.X
			m_Y = c.Y
		End Sub

		Public Sub New(ByVal x As Double, ByVal y As Double)
			m_X = x
			m_Y = y
		End Sub

		Public Overloads Overrides Function ToString() As String
			Return (String.Format("{0} + {1}i", X, Y))
		End Function
		
		Public Shared Function Add(c1 As Complex, c2 As Complex) As Complex
			Return New Complex(c1.X + c2.X, c1.Y + c2.Y)
		End Function
		
		Public Shared Function Multiply(c1 As Complex, c2 As Complex) As Complex
			Return New Complex(c1.X * c2.X - c1.Y * c2.Y, c1.X * c2.Y + c1.Y * c2.X)
		End Function

		Public Property X() As Double
			Get
				Return m_X
			End Get
			Set
				m_X = value
			End Set
		End Property

		Public Property Y() As Double
			Get
				Return m_Y
			End Get
			Set
				m_Y = value
			End Set
		End Property

		Public ReadOnly Property ModSquared() As Double
			Get
				Return m_X * m_X + m_Y * m_Y
			End Get
		End Property
	End Structure 
End Namespace
