Imports System
Imports System.Collections
Namespace ShapePainter

	Public Class Shapes
	Inherits CollectionBase

		Default Public ReadOnly Property Blubber(ByVal index As Integer) As Shape
			Get
				Return CType(Me.List(index), Shape)
			End Get
		End Property

		Public Sub Add(ByVal shape As Shape)
			Me.List.Add(shape)
		End Sub

		Public Sub Remove(ByVal shape As Shape)
			Dim index As Integer = Me.List.IndexOf(shape)
			If Not (index = -1) Then
				Me.List.RemoveAt(index)
			End If
		End Sub
	End Class 
End Namespace
