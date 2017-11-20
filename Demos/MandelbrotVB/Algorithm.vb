Imports System

Namespace Mandelbrot

	Public Class Algorithm
		Private m_MaxIterations As Integer

		Public Sub New()
			m_MaxIterations = 128
		End Sub
		Public UseComplexNumbers As Boolean = False

		Public Property MaxIterations() As Integer
			Get
				Return m_MaxIterations
			End Get
			Set
				m_MaxIterations = value
			End Set
		End Property

		Public Function Evaluate(ByVal x As Double, ByVal y As Double) As Integer
			If UseComplexNumbers Then
				Return EvaluateUsingComplexNumbers(x, y)
			Else
				Return EvaluateUsingDoubles(x, y)
			End If
		End Function

		Function EvaluateUsingComplexNumbers(ByVal x As Double, ByVal y As Double) As Integer
			Dim iterations As Integer = 0
			Dim z As Complex = New Complex(x, y)
			Dim z0 As Complex = New Complex(z)
            While iterations < m_MaxIterations AndAlso z.ModSquared < 4
                z = Complex.Multiply(z, z)
                z = Complex.Add(z, z0)
                iterations = iterations + 1
            End While
            Return iterations
		End Function

		Function EvaluateUsingDoubles(ByVal x As Double, ByVal y As Double) As Integer
			Dim x0 As Double = x
			Dim y0 As Double = y
			Dim ysquared As Double = y0 * y0
			Dim xsquared As Double = x0 * x0
			Dim iterations As Integer = 0
			While (iterations < m_MaxIterations) AndAlso (x0 * x0 + y0 * y0 < 4)
				ysquared = y0 * y0
				xsquared = x0 * x0
				y0 = 2 * y0 * x0 + y
                x0 = xsquared - ysquared + x
                iterations = iterations + 1
            End While
            Return iterations
		End Function
	End Class 
End Namespace
