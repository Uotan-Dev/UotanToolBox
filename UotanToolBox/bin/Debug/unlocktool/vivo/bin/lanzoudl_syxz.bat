@ECHO OFF
::�ű����ߣ��ᰲ@ĳ��
::����ʱ�䣺2022.6.9
::�ر��л ������ �������ƽ���API�� http://blog.dzzui.com/162.html
::
::ʹ��˵����
::�˽ű��ʺ�������bat�ű�����ã�ֱ���������������ӡ�
::�������Զ�����������Ȼ����ýű���
::call��startģʽ���÷�����
::  set lanzoudl_link=����������
::  call��start lanzoudl_syxz.bat %lanzoudl_link%
::�����ѡ��callģʽ�������ʹ�����ؽ������%lanzoudl_result%��ֵΪcompleteΪ�ɹ���failedΪ���س���blankΪδ֪���󣨺ܿ����ǽű�����������⣩��
::��������ģʽֱ��˫����lanzoudl_syxz.bat���ɡ�


::�������Զ���������
::
::��������ģʽ����������������independent��call����call��start����start
set lanzoudl_startupmode=call
::log�ļ���λ�ã�ע������治Ҫ��\��
set lanzoudl_logpath=log


::�����������Ӳ���������call��startģʽ��
set "%lanzoudl_link%"=="%1"
::������
if not exist %lanzoudl_logpath% ECHO.ָ��logĿ¼�����ڣ�log���洢�ڵ�ǰĿ¼��log�ļ��С�������������� & md log & set lanzoudl_logpath=log& pause>nul
del *.aria2 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_directlink.log 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_dlerror.log 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_dlinfo.log 1>nul 2>nul
set lanzoudl_result=blank

::ѡ������ģʽ
if "%lanzoudl_startupmode%"=="independent" goto LANZOUDL_INDEPENDENT
if "%lanzoudl_startupmode%"=="call" goto LANZOUDL_CALL
if "%lanzoudl_startupmode%"=="start" goto LANZOUDL_START


:LANZOUDL_START
ECHO.
curl.exe "http://api.dzzui.com/api/lanzoujx?url=%lanzoudl_link%&type=txt" 1>%lanzoudl_logpath%\lanzoudl_directlink.log 2>nul
for /f %%i in (%lanzoudl_logpath%\lanzoudl_directlink.log) do set lanzoudl_directlink=%%i>nul
ECHO.��ȡ��ֱ����"%lanzoudl_directlink%"
ECHO.
ECHO.��ʼ����...
ECHO.
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 "%lanzoudl_directlink%"
if "%errorlevel%"=="0" goto :eof
ECHO.���س�����������رա�
pause>nul

:LANZOUDL_CALL
curl.exe "http://api.dzzui.com/api/lanzoujx?url=%lanzoudl_link%&type=txt" 1>%lanzoudl_logpath%\lanzoudl_directlink.log 2>nul
for /f %%i in (%lanzoudl_logpath%\lanzoudl_directlink.log) do set lanzoudl_directlink=%%i>nul
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 "%lanzoudl_directlink%" 1>%lanzoudl_logpath%\lanzoudl_dlinfo.log 2>%lanzoudl_logpath%\lanzoudl_dlerror.log
find "completed." "%lanzoudl_logpath%\lanzoudl_dlinfo.log" 1>nul 2>nul
if "%errorlevel%"=="0" set lanzoudl_result=complete& goto :eof
set lanzoudl_result=failed& goto :eof

:LANZOUDL_INDEPENDENT
CLS
ECHO.
set lanzoudl_link=blank
set /p lanzoudl_link= �������������ӣ����Ը��ƺ��Ҽ�ճ������
if "%lanzoudl_link%"=="blank" goto LANZOUDL_INDEPENDENT
curl.exe "http://api.dzzui.com/api/lanzoujx?url=%lanzoudl_link%&type=txt" 1>%lanzoudl_logpath%\lanzoudl_directlink.log 2>nul
for /f %%i in (%lanzoudl_logpath%\lanzoudl_directlink.log) do set lanzoudl_directlink=%%i>nul
ECHO.
ECHO.��ȡ��ֱ����"%lanzoudl_directlink%"
ECHO.
ECHO.��ʼ����...
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 "%lanzoudl_directlink%"
ECHO.
ECHO.������ϣ�����������ء�
pause>nul
goto LANZOUDL_INDEPENDENT
