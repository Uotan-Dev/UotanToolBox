@ECHO OFF
mode con cols=66 lines=35
TITLE viQOO工具箱-反馈

ECHO.检查程序定位是否正确...
cd /D %~dp0\bin
if not exist chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.程序定位错误！请将程序完全解压后运行！ & pause>nul & EXIT
ECHO.检查路径...
echo.%cd%>log\programpath.log
for /f "tokens=1 delims= " %%i in ('findstr "bin" log\programpath.log') do set programpath=%%i
del log\programpath.log 1>nul 2>nul
if not exist %programpath%\chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.工具箱路径中有特殊字符（如空格、英文括号等）。请将工具箱放置在没有特殊字符的路径中，否则无法正常运行。 & pause>nul & EXIT

:FEEDBACK
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}                          viQOO工具箱反馈{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}请写下你的问题，然后按Enter提交开发者。{\n}
ECHO.
ECHOC {07}注：工具箱日志会一并上传，不要换行，尽量不要使用英文标点。{\n}
ECHOC {07}    内容应该包括：问题描述，机型，版本号，出现场景等。{\n}
ECHOC {0F}
ECHO.
set feedback=blank
set /p feedback=请讲：
if "%feedback%"=="blank" goto FEEDBACK
::if "%feedback%"=="1" goto START
echo.%feedback%>log\feedback.txt
:FEEDBACK-2
ECHO.
ECHOC {0E}你的反馈正在快马加鞭发送...{\n}
start feedback.vbs
ECHO.
:FEEDBACK-1
TIMEOUT /T 1 /NOBREAK>nul
if not exist log\feedback.log goto FEEDBACK-1
find "failed" "log\feedback.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}发送失败！按任意键重试。{\n} & pause>nul & goto FEEDBACK-2
find "success" "log\feedback.log" 1>nul 2>nul
if "%errorlevel%"=="0" goto FEEDBACK-3
ECHOC {0C}发送失败（未知错误）！按任意键重试。{\n}
pause>nul
goto FEEDBACK-2
:FEEDBACK-3
ECHOC {0A}反馈已送达！感谢你对开发工作的支持。后续你可以在工具箱“常见问题解答”页面中查看开发者对于反馈的回答。
pause>nul
EXIT