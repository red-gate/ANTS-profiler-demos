SET TINYGET="C:\Program Files (x86)\IIS Resources\TinyGet\tinyget.exe"

start /b cmd /c %TINYGET% -srv:localhost -uri:/Home/Status -threads:1 -loop:501 -r:8013