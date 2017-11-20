IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
csc.exe /t:winexe /debug+ /optimize+ /out:.\Mandelbrot.exe Form1.cs Algorithm.cs ColorScheme.cs Complex.cs Image.cs Settings.cs
) 
