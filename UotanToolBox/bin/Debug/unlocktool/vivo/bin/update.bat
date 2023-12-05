@ECHO OFF
mode con cols=66 lines=30
COLOR 0F
TITLE 维酷刷机工具箱更新程序
ECHO.
ECHO.清理环境...
del bin\log\update.*
taskkill /f /im aria2c.exe
copy bin\aria2c.exe .\
call bin\viqoo_config.bat

:CHK
del bin\log\update.*
CLS
ECHO.
ECHO.正在检查更新...
ECHO.如果在此处无法正常更新，请访问备用地址：syxz.lanzoub.com/b01dogjih（716d）
ECHO.
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=bin\log %dlsource%/update.txt | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.检查更新失败！按任意键重试。 & pause>nul & goto CHK
if not exist bin\log\update.txt ECHO.检查更新失败！按任意键重试。 & pause>nul & goto CHK
find "path not found" "bin\log\update.txt" | find ":500,"
if "%errorlevel%"=="0" ECHO.找不到云端文件！请联系开发者（QQ1330250642）。 & pause>nul & EXIT
find "工具箱" "bin\log\update.txt" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.检查更新失败！按任意键重试。 & pause>nul & goto CHK

::工具箱
for /f "tokens=2 delims= " %%i in ('findstr "工具箱" bin\log\update.txt') do set newver=%%i
if "%program_ver%"=="%newver%" del aria2c.exe 1>nul & ECHO.工具箱已经是最新版啦，下次再来看看吧。按任意键退出。 & pause>nul & del %0& EXIT
for /f "tokens=3 delims= " %%i in ('findstr "工具箱" bin\log\update.txt') do set updatetime=%%i
for /f "tokens=4 delims= " %%i in ('findstr "工具箱" bin\log\update.txt') do set updatelog=%%i
ECHO.工具箱有新版本啦！ %program_ver% -- %newver%
ECHO.更新时间：%updatetime%
ECHO.更新内容：%updatelog%
ECHO.
ECHO.
ECHO.提示：更新前会自动备份当前工具箱。更新时会结束所有ADB与Fastboot进程。
ECHO.
ECHO.请关闭所有工具箱窗口，然后按任意键开始更新。
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
if exist 备份-%program_ver%.zip ECHO.已有当前版本的备份文件，跳过备份... & goto DL-PROGRAM
ECHO.自动备份...
ECHO.
7z.exe a 备份-%program_ver%.zip -y
::https://zhuanlan.zhihu.com/p/488024718
:DL-PROGRAM
CLS
ECHO.
ECHO.下载工具箱...
del viQOO.7z 1>nul 2>nul
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --file-allocation=none %dlsource%/viQOO.7z | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHO.下载失败！请保持网络连接。按任意键重试。 & pause>nul & goto DL-PROGRAM
if not exist viQOO.7z ECHO.下载失败！请保持网络连接。按任意键重试。 & pause>nul & goto DL-PROGRAM
find "path not found" "viQOO.7z" | find ":500,"
if "%errorlevel%"=="0" ECHO.找不到云端文件！请联系开发者（QQ1330250642）。 & pause>nul & EXIT
ECHO.解压工具箱...
7z.exe x "viQOO.7z" -y 1>nul
if not "%errorlevel%"=="0" ECHO.解压出错！按任意键重试。 & pause>nul & goto DL-PROGRAM
ECHO.清理文件...
del viQOO.7z 1>nul
goto FINISH

:FINISH
del 7z.exe 1>nul 2>nul
del 7z.dll 1>nul 2>nul
del aria2c.exe 1>nul 2>nul
msg %username% "更新完成！开始体验新版吧！"
del %0
::https://jingyan.baidu.com/article/c843ea0bf687f877931e4aec.html
