@ECHO OFF
call viqoo_config.bat
for /f %%i in (log\dlsource.txt) do set dlsource=%%i>nul

del log\update.txt

aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=log %dlsource%/update.txt | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" EXIT
if not exist log\update.txt EXIT
find "path not found" "log\update.txt" | find ":500,"
if "%errorlevel%"=="0" msg %username% "�Ҳ����ƶ��ļ�������ϵ�����ߣ�QQ1330250642����" & EXIT

for /f "tokens=2 delims= " %%i in ('findstr "������" log\update.txt') do set newver=%%i
if not "%program_ver%"=="%newver%" msg %username% "���������°汾��(%newver%)����ʹ�ù����䡰�����¡����ܲ鿴�ɣ�" & EXIT

