@ECHO OFF
::setlocal EnableDelayedExpansion
::�˽ű����ߣ��ᰲ@ĳ��

::ʹ�÷�����
::�������Զ�����������������á�
::Ȼ������bat�� choice_syxz ֵ��Ϊ System��Fastboot��Recovery �� ADBSideload����Ϊѡ������Ŀ��
::Ȼ���� call chkconnect_syxz.bat %choice_syxz% ��ʽ���ô�bat���ָ������Ŀ��
::��bat�ʺ��ڷǹ���Աģʽ�����С������Ҫ�ڹ���Աģʽ�����У��������޸ġ�
::bat֮�������ͨ��Ϊ�˱�����ң��ű��еı���������Ӻ�׺��
::�����Ҫ����bat��ʹ�ü��������ʹ�� result_syxz ������ֵΪ1Ϊ�ɹ���0Ϊʧ�ܡ�


::�Զ�����
::log.txt·��
set logpath_syxz=log/chkconnect_log.txt
::������Դ���
set maxretries_syxz=9999
::ÿ��������֮��ĵȴ�ʱ�䣨�룩
set wait_syxz=1


::
::�����ǽű�
::
set "%choice_syxz%"=="%1"
set times_syxz=0
set result_syxz=3
set devnum_syxz=0
set keyword_syxz=blank
echo.blank>"%logpath_syxz%"
:CHKCONNECT_PRE
if "%choice_syxz%"=="System" set keyword_syxz=	device
::deviceǰ����һ��С���ţ�ǧ��Ҫ�޸ģ��������ϵͳ״̬���жϻ����
if "%choice_syxz%"=="Fastboot" set keyword_syxz=fastboot
if "%choice_syxz%"=="Recovery" set keyword_syxz=recovery
if "%choice_syxz%"=="ADBSideload" set keyword_syxz=sideload
if not "%keyword_syxz%"=="blank" goto CHKCONNECT_START
set /p choice_syxz=Please enter test items first(System��Fastboot��Recovery or ADBSideload):
goto CHKCONNECT_PRE

:CHKCONNECT_START
if "%keyword_syxz%"=="	device" adb devices>"%logpath_syxz%"
::deviceǰ����һ��С���ţ�ǧ��Ҫ�޸ģ��������ϵͳ״̬���жϻ����
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
