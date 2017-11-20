Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Namespace Mandelbrot

	Public Class Form1
	    Inherits System.Windows.Forms.Form
		Private m_Algorithm As Algorithm
		Private m_Settings As Settings
		Private m_MandelbrotImage As Image
		Private cmdDraw As System.Windows.Forms.Button
		Private components As System.ComponentModel.Container = Nothing
		Private radioButton1 As System.Windows.Forms.RadioButton
		Private radioButton2 As System.Windows.Forms.RadioButton
		Private m_PictureBox1 As System.Windows.Forms.PictureBox
		Private m_Running As Boolean = True

		Public Sub New()
			InitializeComponent
			m_Algorithm = New Algorithm
			m_Algorithm.MaxIterations = 32
			m_Settings = New Settings(1, -2, 1.2, -1.2)
			m_MandelbrotImage = New Image(m_PictureBox1.Size.Width, m_PictureBox1.Size.Height)
			m_PictureBox1.Image = m_MandelbrotImage.m_Bitmap
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
			Me.m_PictureBox1 = New System.Windows.Forms.PictureBox
			Me.cmdDraw = New System.Windows.Forms.Button
			Me.radioButton1 = New System.Windows.Forms.RadioButton
			Me.radioButton2 = New System.Windows.Forms.RadioButton
			Me.SuspendLayout
			Me.m_PictureBox1.Location = New System.Drawing.Point(8, 36)
			Me.m_PictureBox1.Name = "m_PictureBox1"
			Me.m_PictureBox1.Size = New System.Drawing.Size(436, 264)
			Me.m_PictureBox1.TabIndex = 1
			Me.m_PictureBox1.TabStop = False
			Me.cmdDraw.Location = New System.Drawing.Point(8, 8)
			Me.cmdDraw.Name = "cmdDraw"
			Me.cmdDraw.Size = New System.Drawing.Size(128, 24)
			Me.cmdDraw.TabIndex = 2
			Me.cmdDraw.Text = "&Draw Mandelbrot Set"
			AddHandler Me.cmdDraw.Click, AddressOf Me.cmdDraw_Click
			Me.radioButton1.Checked = True
			Me.radioButton1.Location = New System.Drawing.Point(160, 8)
			Me.radioButton1.Name = "radioButton1"
			Me.radioButton1.TabIndex = 3
			Me.radioButton1.TabStop = True
			Me.radioButton1.Text = "Quick"
			AddHandler Me.radioButton1.CheckedChanged, AddressOf Me.radioButton1_CheckedChanged
			Me.radioButton2.Location = New System.Drawing.Point(288, 8)
			Me.radioButton2.Name = "radioButton2"
			Me.radioButton2.TabIndex = 4
			Me.radioButton2.Text = "Slow"
			AddHandler Me.radioButton2.CheckedChanged, AddressOf Me.radioButton2_CheckedChanged
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
			Me.ClientSize = New System.Drawing.Size(454, 308)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioButton2, Me.radioButton1, Me.cmdDraw, Me.m_PictureBox1})
			Me.Font = New System.Drawing.Font("Tahoma", 8.25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType((0), System.Byte))
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.Text = "Mandelbrot set"
			AddHandler Me.Closing, AddressOf Me.Form1_Closing
			Me.ResumeLayout(False)
		End Sub

		<STAThread()> _
		Shared Sub Main()
			Application.Run(New Form1)
		End Sub

		Private Sub DrawMandelbrot()
			Dim dx As Double = m_Settings.Width / m_MandelbrotImage.Width
			Dim dy As Double = m_Settings.Height / m_MandelbrotImage.Height
			Dim x As Double = m_Settings.XMin
            Dim y As Double = m_Settings.YMin
            Dim i As Integer
            For i = 0 To m_MandelbrotImage.Width - 1
                Dim j As Integer
                For j = 0 To m_MandelbrotImage.Height - 1
                    Dim iterations As Integer = m_Algorithm.Evaluate(x, y)
                    m_MandelbrotImage.SetPixelColor(i, j, iterations)
                    y += dy
                Next
                If Not m_Running Then
                    Return
                End If
                y = m_Settings.YMin
                x += dx
                If (i Mod 10) = 0 Then
                    m_PictureBox1.Refresh()
                    Application.DoEvents()
                End If
            Next
            m_PictureBox1.Refresh()
        End Sub

        Private Sub cmdDraw_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Cursor.Current = Cursors.WaitCursor
            m_MandelbrotImage.Clear()
            m_PictureBox1.Image = m_MandelbrotImage.m_Bitmap
            m_PictureBox1.Refresh()
            DrawMandelbrot()
            Cursor.Current = Cursors.Default
        End Sub

        Private Sub radioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            m_Algorithm.UseComplexNumbers = False
        End Sub

        Private Sub radioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            m_Algorithm.UseComplexNumbers = True
        End Sub

        Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            m_Running = False
        End Sub
    End Class
End Namespace
