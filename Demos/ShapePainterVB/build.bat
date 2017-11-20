IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
resgen Form1.resx ShapePainter.Form1.resources
vbc.exe /t:winexe /debug+ /out:.\ShapePainterVB.exe Form1.vb DrawingBoard.vb Shapes.vb ShapesCollection.vb /res:ShapePainter.Form1.resources /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.dll /r:System.Data.dll
del ShapePainter.Form1.resources
) 
