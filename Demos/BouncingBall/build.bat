IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
csc.exe /t:winexe /debug+ /optimize+ /out:.\BouncingBall.exe Form1.cs Ball.cs Container.cs Form1.Designer.cs Program.cs
) 
