@ECHO OFF
mode con cols=66 lines=30
COLOR 0F
TITLE ά��ˢ����������³���
ECHO.
ECHO.������...
del bin\log\update.*
taskkill /f /im aria2c.exe
copy bin\aria2c.exe .\
call bin\viqoo_config.bat

:CHK
del bin\log\update.*
CLS
ECHO.
ECHO.���ڼ�����...
ECHO.����ڴ˴��޷��������£�����ʱ��õ�ַ��syxz.lanzoub.com/b01dogjih��716d��
ECHO.
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=bin\log %dlsource%/update.txt | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.������ʧ�ܣ�����������ԡ� & pause>nul & goto CHK
if not exist bin\log\update.txt ECHO.������ʧ�ܣ�����������ԡ� & pause>nul & goto CHK
find "path not found" "bin\log\update.txt" | find ":500,"
if "%errorlevel%"=="0" ECHO.�Ҳ����ƶ��ļ�������ϵ�����ߣ�QQ1330250642���� & pause>nul & EXIT
find "������" "bin\log\update.txt" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.������ʧ�ܣ�����������ԡ� & pause>nul & goto CHK

::������
for /f "tokens=2 delims= " %%i in ('findstr "������" bin\log\update.txt') do set newver=%%i
if "%program_ver%"=="%newver%" del aria2c.exe 1>nul & ECHO.�������Ѿ������°������´����������ɡ���������˳��� & pause>nul & del %0& EXIT
for /f "tokens=3 delims= " %%i in ('findstr "������" bin\log\update.txt') do set updatetime=%%i
for /f "tokens=4 delims= " %%i in ('findstr "������" bin\log\update.txt') do set updatelog=%%i
ECHO.���������°汾���� %program_ver% -- %newver%
ECHO.����ʱ�䣺%updatetime%
ECHO.�������ݣ�%updatelog%
ECHO.
ECHO.
ECHO.��ʾ������ǰ���Զ����ݵ�ǰ�����䡣����ʱ���������ADB��Fastboot���̡�
ECHO.
ECHO.��ر����й����䴰�ڣ�Ȼ���������ʼ���¡�
pause>nul
taskkill /f /im aria2c.exe
taskkill /f /im adb.exe
taskkill /f /im fastboot.exe
:BACKUP
copy bin\7z.exe .\
copy bin\7z.dll .\
copy bin\aria2c.exe .\
CLS
ECHO.
if exist ����-%program_ver%.zip ECHO.���е�ǰ�汾�ı����ļ�����������... & goto DL-PROGRAM
ECHO.�Զ�����...
ECHO.
7z.exe a ����-%program_ver%.zip -y
::https://zhuanlan.zhihu.com/p/488024718
:DL-PROGRAM
CLS
ECHO.
ECHO.���ع�����...
del viQOO.7z 1>nul 2>nul
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --file-allocation=none %dlsource%/viQOO.7z | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.����ʧ�ܣ��뱣���������ӡ�����������ԡ� & pause>nul & goto DL-PROGRAM
if not exist viQOO.7z ECHO.����ʧ�ܣ��뱣���������ӡ�����������ԡ� & pause>nul & goto DL-PROGRAM
find "path not found" "viQOO.7z" | find ":500,"
if "%errorlevel%"=="0" ECHO.�Ҳ����ƶ��ļ�������ϵ�����ߣ�QQ1330250642���� & pause>nul & EXIT
ECHO.��ѹ������...
7z.exe x "viQOO.7z" -y 1>nul
if not "%errorlevel%"=="0" ECHO.��ѹ��������������ԡ� & pause>nul & goto DL-PROGRAM
ECHO.�����ļ�...
del viQOO.7z 1>nul
goto FINISH

:FINISH
del 7z.exe 1>nul 2>nul
del 7z.dll 1>nul 2>nul
del aria2c.exe 1>nul 2>nul
msg %username% "������ɣ���ʼ�����°�ɣ�"
del %0
::https://jingyan.baidu.com/article/c843ea0bf687f877931e4aec.html
