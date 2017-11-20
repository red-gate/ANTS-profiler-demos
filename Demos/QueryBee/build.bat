IF NOT "%VS140COMNTOOLS%" == "" (
"%VS140COMNTOOLS%vsvars32.bat"
Resgen.exe /useSourcePath /r:.\RedGate.Profiler.UserEvents.dll /compile ConnectForm.resx,.\QueryBee.ConnectForm.resources Properties\Resources.resx,.\QueryBee.Properties.Resources.resources QueryForm.resx,.\QueryBee.QueryForm.resources
Csc.exe /nowarn:1701,1702 /errorreport:prompt /warn:4 /define:DEBUG;TRACE /reference:.\RedGate.Profiler.UserEvents.dll /debug+ /debug:full /optimize- /out:.\QueryBee.exe /resource:.\QueryBee.ConnectForm.resources /resource:.\QueryBee.Properties.Resources.resources /resource:.\QueryBee.QueryForm.resources /target:winexe ConnectForm.cs ConnectForm.Designer.cs Program.cs Properties\AssemblyInfo.cs Properties\Resources.Designer.cs Properties\Settings.Designer.cs QueryForm.cs QueryForm.Designer.cs SystemHotkey.cs Win32.cs
del .\QueryBee.ConnectForm.resources .\QueryBee.Properties.Resources.resources .\QueryBee.QueryForm.resources
) 
