@ECHO OFF

::set "%tsktype%"=="%1"
set "%tskname%"=="%1"
call language\selected\waittsk.bat
echo.blank>log\waittsk.log

:::WAITTSK_START
set choice=0
set /p choice= %others-p1%
::if not "%choice%"=="1" goto WAITTSK_START
pause>nul
::taskkill /f /im aria2c.exe 1>nul 2>nul
taskkill /f /im %tskname% 1>nul 2>nul
echo.killed>log\waittsk.log
goto :eof
