IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
vbc.exe /t:winexe /optimize+ /debug+ /out:.\MandelbrotVB.exe Form1.vb Algorithm.vb ColorScheme.vb Complex.vb Image.vb Settings.vb /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.dll /r:System.Data.dll
)
