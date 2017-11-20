Imports System
Imports System.Drawing
Namespace Mandelbrot

	Public Class ColorScheme

		Public Shared Function ColorFromIterations(ByVal iterations As Integer) As Color
			If iterations = 32 Then
				Return Color.White
			End If
			Dim mod5 As Integer = iterations Mod 5
			Dim mod13 As Integer = iterations Mod 13
			Dim mod17 As Integer = iterations Mod 17
			Return Color.FromArgb(mod5 * 50, mod17 * 15, mod13 * 19)
		End Function
	End Class 
End Namespace
