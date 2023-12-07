@ECHO OFF
mode con cols=72 lines=15

TITLE viQOO������-����׼������...
set "%project%"=="%1"
set "%model%"=="%2"
set "%channel%"=="%3"
set "%sysver%"=="%4"
call viqoo_config.bat
if not exist %project% md %project%
echo.blank>%project%\dlresult.txt
del %project%\*.aria2

:START
CLS
TITLE viQOO������-�������أ����������ں�ɫ����...
if not "%channel%"=="blank" aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=%project% %dlsource%/%project%/%model%/%channel%/%sysver%.7z
if "%channel%"=="blank" aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=%project% %dlsource%/%project%/%model%/%sysver%.7z

TITLE viQOO������-���ڼ��...
if exist *.aria2 goto UNFINISHED
if not exist %project%\%sysver%.7z goto FAILED
find "found" "%project%\%sysver%.7z" | find ":500," 1>nul 2>nul
if "%errorlevel%"=="0" goto NOTFOUND
::���سɹ�
taskkill /f /im waittsk.exe 1>nul
EXIT


:FAILED
TITLE viQOO������-����ʧ��
echo.failed>%project%\dlresult.txt
taskkill /f /im waittsk.exe 1>nul
ECHOC {0C}����ʧ�ܣ���������رմ��ڡ�
pause>nul
EXIT

:NOTFOUND
echo.notfound>%project%\dlresult.txt
taskkill /f /im waittsk.exe 1>nul
EXIT

:UNFINISHED
echo.unfinished>%project%\dlresult.txt
EXIT