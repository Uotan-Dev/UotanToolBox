@ECHO OFF
::脚本作者：酷安@某贼
::更新时间：2022.6.9
::特别感谢 独醉博客 的蓝奏云解析API！ http://blog.dzzui.com/162.html
::
::使用说明：
::此脚本适合内置在bat脚本里调用，直接下载蓝奏云链接。
::先设置自定义设置区，然后调用脚本。
::call或start模式调用方法：
::  set lanzoudl_link=蓝奏云链接
::  call或start lanzoudl_syxz.bat %lanzoudl_link%
::如果你选择call模式，则可以使用下载结果参数%lanzoudl_result%。值为complete为成功，failed为下载出错，blank为未知错误（很可能是脚本本身出现问题）。
::独立启动模式直接双击打开lanzoudl_syxz.bat即可。


::以下是自定义设置区
::
::采用哪种模式启动？独立启动：independent，call唤起：call，start唤起：start
set lanzoudl_startupmode=call
::log文件夹位置？注意最后面不要加\。
set lanzoudl_logpath=log


::接收下载链接参数（用于call或start模式）
set "%lanzoudl_link%"=="%1"
::清理环境
if not exist %lanzoudl_logpath% ECHO.指定log目录不存在！log将存储在当前目录的log文件夹。按任意键继续。 & md log & set lanzoudl_logpath=log& pause>nul
del *.aria2 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_directlink.log 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_dlerror.log 1>nul 2>nul
del %lanzoudl_logpath%\lanzoudl_dlinfo.log 1>nul 2>nul
set lanzoudl_result=blank

::选择启动模式
if "%lanzoudl_startupmode%"=="independent" goto LANZOUDL_INDEPENDENT
if "%lanzoudl_startupmode%"=="call" goto LANZOUDL_CALL
if "%lanzoudl_startupmode%"=="start" goto LANZOUDL_START


:LANZOUDL_START
ECHO.
curl.exe "http://api.dzzui.com/api/lanzoujx?url=%lanzoudl_link%&type=txt" 1>%lanzoudl_logpath%\lanzoudl_directlink.log 2>nul
for /f %%i in (%lanzoudl_logpath%\lanzoudl_directlink.log) do set lanzoudl_directlink=%%i>nul
ECHO.获取到直链："%lanzoudl_directlink%"
ECHO.
ECHO.开始下载...
ECHO.
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 "%lanzoudl_directlink%"
if "%errorlevel%"=="0" goto :eof
ECHO.下载出错！按任意键关闭。
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
set /p lanzoudl_link= 蓝奏云下载链接（可以复制后右键粘贴）：
if "%lanzoudl_link%"=="blank" goto LANZOUDL_INDEPENDENT
curl.exe "http://api.dzzui.com/api/lanzoujx?url=%lanzoudl_link%&type=txt" 1>%lanzoudl_logpath%\lanzoudl_directlink.log 2>nul
for /f %%i in (%lanzoudl_logpath%\lanzoudl_directlink.log) do set lanzoudl_directlink=%%i>nul
ECHO.
ECHO.获取到直链："%lanzoudl_directlink%"
ECHO.
ECHO.开始下载...
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 "%lanzoudl_directlink%"
ECHO.
ECHO.下载完毕，按任意键返回。
pause>nul
goto LANZOUDL_INDEPENDENT
