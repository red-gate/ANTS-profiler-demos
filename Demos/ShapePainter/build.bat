IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
resgen Form1.resx ShapePainter.Form1.resources
csc.exe /t:winexe /debug+ /out:.\ShapePainter.exe DrawingBoard.cs Form1.cs Shapes.cs ShapesCollection.cs /resource:ShapePainter.Form1.resources
del ShapePainter.Form1.resources
)
