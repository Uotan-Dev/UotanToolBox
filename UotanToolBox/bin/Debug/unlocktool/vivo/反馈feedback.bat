@ECHO OFF
mode con cols=66 lines=35
TITLE viQOO������-����

ECHO.������λ�Ƿ���ȷ...
cd /D %~dp0\bin
if not exist chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.����λ�����뽫������ȫ��ѹ�����У� & pause>nul & EXIT
ECHO.���·��...
echo.%cd%>log\programpath.log
for /f "tokens=1 delims= " %%i in ('findstr "bin" log\programpath.log') do set programpath=%%i
del log\programpath.log 1>nul 2>nul
if not exist %programpath%\chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.������·�����������ַ�����ո�Ӣ�����ŵȣ����뽫�����������û�������ַ���·���У������޷��������С� & pause>nul & EXIT

:FEEDBACK
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}                          viQOO�����䷴��{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}��д��������⣬Ȼ��Enter�ύ�����ߡ�{\n}
ECHO.
ECHOC {07}ע����������־��һ���ϴ�����Ҫ���У�������Ҫʹ��Ӣ�ı�㡣{\n}
ECHOC {07}    ����Ӧ�ð������������������ͣ��汾�ţ����ֳ����ȡ�{\n}
ECHOC {0F}
ECHO.
set feedback=blank
set /p feedback=�뽲��
if "%feedback%"=="blank" goto FEEDBACK
::if "%feedback%"=="1" goto START
echo.%feedback%>log\feedback.txt
:FEEDBACK-2
ECHO.
ECHOC {0E}��ķ������ڿ���ӱ޷���...{\n}
start feedback.vbs
ECHO.
:FEEDBACK-1
TIMEOUT /T 1 /NOBREAK>nul
if not exist log\feedback.log goto FEEDBACK-1
find "failed" "log\feedback.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}����ʧ�ܣ�����������ԡ�{\n} & pause>nul & goto FEEDBACK-2
find "success" "log\feedback.log" 1>nul 2>nul
if "%errorlevel%"=="0" goto FEEDBACK-3
ECHOC {0C}����ʧ�ܣ�δ֪���󣩣�����������ԡ�{\n}
pause>nul
goto FEEDBACK-2
:FEEDBACK-3
ECHOC {0A}�������ʹ��л��Կ���������֧�֡�����������ڹ����䡰����������ҳ���в鿴�����߶��ڷ����Ļش�
pause>nul
EXIT