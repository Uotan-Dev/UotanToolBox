@ECHO OFF
::setlocal EnableDelayedExpansion
::此脚本作者：酷安@某贼

::使用方法：
::首先在自定义区里设置相关配置。
::然后在主bat将 choice_syxz 值设为 System，Fastboot，Recovery 或 ADBSideload。此为选择检测项目。
::然后用 call chkconnect_syxz.bat %choice_syxz% 方式调用此bat检测指定的项目。
::此bat适合在非管理员模式下运行。如果需要在管理员模式下运行，请自行修改。
::bat之间变量互通，为了避免混乱，脚本中的变量均已添加后缀。
::如果需要在主bat中使用检测结果，请使用 result_syxz 变量。值为1为成功，0为失败。


::自定义区
::log.txt路径
set logpath_syxz=log/chkconnect_log.txt
::最大重试次数
set maxretries_syxz=9999
::每两次重试之间的等待时间（秒）
set wait_syxz=1


::
::以下是脚本
::
set "%choice_syxz%"=="%1"
set times_syxz=0
set result_syxz=3
set devnum_syxz=0
set keyword_syxz=blank
echo.blank>"%logpath_syxz%"
:CHKCONNECT_PRE
if "%choice_syxz%"=="System" set keyword_syxz=	device
::device前面有一个小符号，千万不要修改，否则对于系统状态的判断会出错！
if "%choice_syxz%"=="Fastboot" set keyword_syxz=fastboot
if "%choice_syxz%"=="Recovery" set keyword_syxz=recovery
if "%choice_syxz%"=="ADBSideload" set keyword_syxz=sideload
if not "%keyword_syxz%"=="blank" goto CHKCONNECT_START
set /p choice_syxz=Please enter test items first(System，Fastboot，Recovery or ADBSideload):
goto CHKCONNECT_PRE

:CHKCONNECT_START
if "%keyword_syxz%"=="	device" adb devices>"%logpath_syxz%"
::device前面有一个小符号，千万不要修改，否则对于系统状态的判断会出错！
if "%keyword_syxz%"=="fastboot" fastboot devices>"%logpath_syxz%"
if "%keyword_syxz%"=="recovery" adb devices>"%logpath_syxz%"
if "%keyword_syxz%"=="sideload" adb devices>"%logpath_syxz%"
for %%i in ("%logpath_syxz%") do (
	for /f %%a in ('type %%~si ^|find /c "%keyword_syxz%"')do (
	set devnum_syxz=%%a
	)
)
::https://www.cnblogs.com/pzy4447/articles/3127791.html
if "%devnum_syxz%"=="1" set result_syxz=0& goto :eof
set /a times_syxz+=1
if %times_syxz% GEQ %maxretries_syxz% goto CHKCONNECT_FAILED
TIMEOUT /T %wait_syxz% /NOBREAK>nul
if %times_syxz% LSS %maxretries_syxz% goto CHKCONNECT_START

:CHKCONNECT_FAILED
if "%devnum_syxz%"=="0" set result_syxz=1& goto :eof
if %devnum_syxz% GTR 1 set result_syxz=2& goto :eof
ECHO.Unknown error ! & set result_syxz=3& goto :eof
