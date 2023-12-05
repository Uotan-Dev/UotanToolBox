@ECHO OFF
mode con cols=66
TITLE viQOO-Loading...

:RESTART
CLS
ECHO.Checking program...
cd /D %~dp0\bin
if not exist language\selected\main.bat COLOR 4F & ECHO. & ECHO.Language file not found ! Please unzip the program completely before run it ! & pause>nul & EXIT
ECHO.Loading language...
call language\selected\main.bat
ECHO.%others-p4%
for /f "tokens=2 delims= " %%i in ('findstr "@ECHO" chkconnect_syxz.bat') do set target=%%i
if not "%target%"=="OFF" COLOR 4F & ECHO. & ECHO.%others-p5% & pause>nul & EXIT
ECHO.%others-p6%
echo.%cd%>log\programpath.log
for /f "tokens=1 delims= " %%i in ('findstr "bin" log\programpath.log') do set programpath=%%i
del log\programpath.log 1>nul 2>nul
if not exist %programpath%\chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.%others-p7% & pause>nul & EXIT
CLS & type logo.txt
ECHO.%others-p8%
if not exist 7z.exe COLOR 4F & ECHO. & ECHO.%others-p9% & pause>nul & EXIT
if not exist adb.exe COLOR 4F & ECHO. & ECHO.%others-p10% & pause>nul & EXIT
if not exist aria2c.exe COLOR 4F & ECHO. & ECHO.%others-p11% & pause>nul & EXIT
if not exist fastboot.exe COLOR 4F & ECHO. & ECHO.%others-p12% & pause>nul & EXIT
if not exist fastboot_vivo.exe COLOR 4F & ECHO. & ECHO.%others-p13% & pause>nul & EXIT
if not exist blat.exe COLOR 4F & ECHO. & ECHO.%others-p14% & pause>nul & EXIT
if not exist 7z.dll COLOR 4F & ECHO. & ECHO.%others-p15% & pause>nul & EXIT
if not exist chkconnect_syxz.bat COLOR 4F & ECHO. & ECHO.%others-p16% & pause>nul & EXIT
if not exist viqoo_config.bat COLOR 4F & ECHO. & ECHO.%others-p17% & pause>nul & EXIT
CLS & type logo.txt
ECHO.%others-p18%
msg 1>nul 2>nul
if not "%errorlevel%"=="0" COLOR 0C & ECHO. & ECHO.%others-p19% & pause>nul
COLOR 0E
CLS & type logo.txt
ECHO.%others-p20%
if not exist log\model_sel.txt echo.blank>log\model_sel.txt
for /f %%i in (log\model_sel.txt) do set model=%%i>nul
call viqoo_config.bat
TITLE %others-p21% %program_ver% %others-p21.1%
CLS & type logo.txt
ECHO.%others-p22%
start chkupdate.vbs
goto START


:START
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%start-p1%{\n}
ECHOC {0E}                                                        %program_ver%{\n}
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%start-p2%{\n}
ECHO.
ECHOC {0F}%start-p3%
ECHO. 
ECHO. 
if not "%model%"=="blank" ECHOC {0F}  [{0E}%model%{0F}]{\n}
if "%model%"=="blank" ECHOC {0C}  %start-p4%{\n}
if not exist log\drvinst.log ECHO. & ECHOC {0C}  %start-p5%{\n}
ECHO.
ECHO.
ECHOC {0E} 1.{0F}%start-p6%   {0E}2.{0F}%start-p7%   {0E}3.{0F}%start-p8%{\n}
ECHO.
ECHO. 4.%start-p10%
ECHO.
ECHO.
ECHOC {0F} 5.%start-p9%   {0E}6.{0F}%start-p9.1%{\n}
ECHO.
ECHO.
ECHOC {0E} 7.{0F}%start-p11%{\n}
ECHO. 
ECHO. 
ECHOC {0E} 8.{0F}%start-p12%   9.%start-p13%   10.%start-p14%{\n}
ECHO.
ECHO. 
ECHO. 11.%start-p15%   12.%start-p16%   13.%start-p17%
ECHO. 
ECHO. 14.%start-p17.1%
ECHO. 
ECHO. 
ECHO. A.%start-p18%
ECHO.
ECHO.
ECHO.
ECHOC {0E}
set choice=0
set /p choice= %start-p19%
ECHOC {0F}
if "%choice%"=="1" goto UNLOCK
if "%choice%"=="2" set command=root& goto ROOT
if "%choice%"=="3" set command=unroot& goto ROOT
if "%choice%"=="4" ECHO. & ECHO.%start-p20% & pause>nul & goto START
if "%choice%"=="5" start https://share666-my.sharepoint.com/:f:/g/personal/share666_share666_onmicrosoft_com/EnxBAAYpQuFNqNvl_xho3XoBRe4lUGdZyrCS30V0NGFOFg?e=NxoiGi
if "%choice%"=="6" goto PATCHBOOT
if "%choice%"=="7" goto ROOTREC
if "%choice%"=="8" goto TOOLS
if "%choice%"=="9" goto FLASHIMG
if "%choice%"=="10" ECHO. & ECHO.%start-p21% & pause>nul & goto START
if "%choice%"=="11" goto CHKUPDATE
if "%choice%"=="12" goto CHOOSEDEV
if "%choice%"=="13" goto CLEAN
if "%choice%"=="14" start https://kdocs.cn/l/cfk5GysmStzX
if "%choice%"=="A" goto ABOUT
if "%choice%"=="a" goto ABOUT
goto START


:PATCHBOOT
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%patchboot-p1%
ECHO.                                                                                by affggh
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
if not "%PROCESSOR_ARCHITECTURE%"=="AMD64" ECHOC {0C}%patchboot-p2%{\n}& pause>nul & goto START
ECHOC {0E}%patchboot-p3%{\n}
ECHOC {0E}%patchboot-p4%{\n}
ECHOC {0E}%patchboot-p5%https://github.com/affggh/magiskboot_and_patch_win{\n}
if not exist MagiskPatcher goto PATCHBOOT-DL
ECHOC {0F} {\n}
ECHO. 1.%patchboot-p6%
ECHO. 2.%patchboot-p7%
ECHO. 3.%patchboot-p8%
ECHO. 
set choice=1
set /p choice= %patchboot-p9%
if "%choice%"=="2" cd MagiskPatcher & start MagiskPatcher.exe & cd .. & goto PATCHBOOT
if "%choice%"=="3" goto START
ECHO. 
ECHO.%patchboot-p10%
set /p filepath= 
if not exist %filepath% ECHOC {0C}%patchboot-p11%{\n}& pause>nul & goto PATCHBOOT
ECHOC {0E}%patchboot-p11.1%{\n}
ECHOC {07} {\n}
for %%i in ("%filepath%") do set filename=%%~ni
for %%i in ("%filepath%") do set filenamefull=%%~nxi
for %%i in ("%filepath%") do set filefolder=%%~dpi
del MagiskPatcher\boot.img 1>nul 2>nul
del MagiskPatcher\new-boot.img 1>nul 2>nul
del MagiskPatcher\%filenamefull% 1>nul 2>nul
copy %filepath% MagiskPatcher
ren MagiskPatcher\%filenamefull% boot.img
if not "%errorlevel%"=="0" ECHOC {0C}%patchboot-p12%{\n}& pause>nul & goto START
cd MagiskPatcher
call MagiskPatcher.bat patch -i boot.img -a arm64 -kv true -ke true -pv false -m prebuilt\MagiskAlpha-25101.apk
cd ..
if not exist MagiskPatcher\new-boot.img ECHO. & ECHOC {0C}%patchboot-p13%{\n}& goto PATCHBOOT
ren MagiskPatcher\new-boot.img %filename%-MagiskAlpha25101Patched.img
move MagiskPatcher\%filename%-MagiskAlpha25101Patched.img %filefolder%
start %filefolder%
ECHOC {0E} {\n}
ECHO.%patchboot-p14%
pause>nul
goto START
:PATCHBOOT-DL
ECHO.
ECHOC {0E}%patchboot-p15%{\n}
set /p choice= 
if "%choice%"=="1" goto START
ECHOC {0F}%patchboot-p15.1%{\n}
::set lanzoudl_link=https://syxz.lanzoub.com/iYC7n077ibba
::call lanzoudl_syxz.bat %lanzoudl_link%
::if not "%lanzoudl_result%"=="complete" ECHOC {0C}%patchboot-p16%{\n}& pause>nul & goto PATCHBOOT
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 %dlsource%/MagiskPatcher.7z | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%patchboot-p16%{\n}& pause>nul & goto PATCHBOOT
find "found" "MagiskPatcher.7z" | find ":500," 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%patchboot-p16.1%{\n}& pause>nul & goto PATCHBOOT
ECHO.%patchboot-p17%
7z.exe x "MagiskPatcher.7z" -y 1>nul
del MagiskPatcher.7z 1>nul 2>nul
if not exist MagiskPatcher\MagiskPatcher.bat ECHOC {0C}%patchboot-p18%{\n}& pause>nul & goto PATCHBOOT
goto PATCHBOOT


:ROOTREC
set project=recovery
set channel=official-root
rd/s/q "%project%" 1>nul 2>nul
md %project%
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%rootrec-p1%{\n}
ECHO.%rootrec-p2%
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHO.%rootrec-p3%
ECHOC {0E}%rootrec-p4%{\n}
ECHOC {0E}%rootrec-p5%{0F}%rootrec-p6%{\n}
ECHO.
ECHO.%rootrec-p7%
ECHO.
ECHO. 1.vivoY31S-t2  1.10.2
ECHO.
ECHO. 2.vivoY31S-t2  1.17.0
ECHO.
ECHO. A.%rootrec-p10%
ECHO.
set /p choice= %rootrec-p11%
ECHO.
if "%choice%"=="1" set model=vivoY31S-t2& set sysver=1.10.2
if "%choice%"=="2" set model=vivoY31S-t2& set sysver=1.17.0
if "%choice%"=="A" goto START
if "%choice%"=="a" goto START
ECHOC {0F}%rootrec-p12% [{0E}%model%{0F}]{0E}%sysver%{0F} %rootrec-p13%{\n}
start startdl.exe %project% %model% %channel% %sysver%
set tskname=aria2c.exe
call waittsk.exe
find "killed" "log\waittsk.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%rootrec-p14% & pause>nul & goto START
ECHO.
find "failed" "%project%\dlresult.txt" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%rootrec-p15%{\n}& pause>nul & goto ROOTREC
find "notfound" "%project%\dlresult.txt" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%rootrec-p16%{\n}& pause>nul & goto ROOTREC
ECHOC {0F}%rootrec-p17%{\n}
md %project%\%sysver% 1>nul 2>nul
ECHOC {0C}
move %project%\%sysver%.7z %project%\%sysver% 1>nul
copy 7z.exe %project%\%sysver% 1>nul
copy 7z.dll %project%\%sysver% 1>nul
cd %project%\%sysver%
7z.exe e "%sysver%.7z" 1>nul 2>nul
if not "%errorlevel%"=="0" cd /D %~dp0\bin & ECHOC {0C}%rootrec-p18%& pause>nul & goto ROOTREC
cd /D %~dp0\bin
ECHO.
ECHOC {0E}%rootrec-p19%{\n}
ECHOC {0F}%rootrec-p20%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.%rootrec-p21%
if "%result_syxz%"=="1" ECHOC {0C}%rootrec-p22%{\n}& pause>nul & goto ROOTREC
if "%result_syxz%"=="2" ECHOC {0C}%rootrec-p23%{\n}& pause>nul & goto ROOTREC
if "%result_syxz%"=="3" ECHOC {0C}%rootrec-p24%{\n}& pause>nul & goto ROOTREC
ECHOC {0F}%rootrec-p25%{\n}{\n}
fastboot.exe getvar all 1>nul 2>log\fbgetvar.log
find "bootloader" "log\fbgetvar.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%rootrec-p26%{\n}& pause>nul & goto START
find "unlocked:yes" "log\fbgetvar.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%rootrec-p27%{\n}& pause>nul & goto START
ECHOC {0F}%rootrec-p28%{\n}
if "%abdev%"=="n" fastboot.exe flash recovery %project%/%sysver%/recovery.img 1>nul 2>log\flashrec.log
find "FAILED" "log\flashrec.log" 1>nul 2>nul
if "%errorlevel%"=="0" start log\flashrec.log & ECHOC {0C}%rootrec-p29%{\n}& pause>nul & goto ROOTREC
ECHOC {0A}%rootrec-p30%{\n}
ECHOC {0E}%rootrec-p31%{\n}
fastboot reboot bootloader 1>nul 2>nul
TIMEOUT /T 1 /NOBREAK>nul
ECHOC {0E}%rootrec-p32%{\n}
ECHOC {0F}%rootrec-p33%{\n}
set choice_syxz=Recovery
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.%rootrec-p34%
if "%result_syxz%"=="1" ECHOC {0C}%rootrec-p35%{\n}& pause>nul & goto ROOTREC
if "%result_syxz%"=="2" ECHOC {0C}%rootrec-p36%{\n}& pause>nul & goto ROOTREC
if "%result_syxz%"=="3" ECHOC {0C}%rootrec-p37%{\n}& pause>nul & goto ROOTREC
ECHOC {0E}%rootrec-p38%{\n}
echo.blank>log\rectest.log
adb shell whoami 1>log\rectest.log
find "root" "log\rectest.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0A}%rootrec-p39%{\n}& pause>nul & goto START
find "shell" "log\rectest.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%rootrec-p40%{\n}& pause>nul & goto START
find "blank" "log\rectest.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%rootrec-p41%{\n}& pause>nul & goto START
ECHOC {0C}%rootrec-p42%{\n}
pause>nul
goto ROOTREC-1
:ROOTREC-1
rd/s/q "%project%" 1>nul 2>nul
md %project%
goto START


:ABOUT
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%about-p1%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}%about-p2%{\n}
ECHOC {0F}
ECHO.
ECHO.%about-p3%
ECHOC {07}%about-p4%{\n}
ECHO. 
ECHOC {0E}%about-p5%{\n}
ECHOC {0F}
ECHO.
type credits\developer.txt & ECHO.
ECHO.
ECHOC {0E}%about-p6%{\n}
ECHOC {0F}
ECHO. 
type credits\tester.txt & ECHO.
ECHO. 
ECHOC {0F}%about-p7%{07}%about-p8%{\n}
ECHOC {0F}%about-p9%{07}%about-p10%{\n}
ECHO.
ECHOC {0E}%about-p11%{\n}
ECHOC {0F}
ECHO.
ECHO. %about-p11.1% 753573255   %about-p11.1% 282202322
ECHO.
ECHOC {0F}%about-p11.2%{\n}
ECHOC {07}%about-p11.3%{\n}
ECHO.
ECHO.
ECHOC {0F}%about-p12%{\n}
pause>nul
goto START

:FLASHIMG
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%flashimg-p1%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHO. 1.%flashimg-p2%
ECHO.
ECHO. 2.%flashimg-p3%
ECHO.
ECHO. 3.%flashimg-p4%
ECHO.
ECHO. 4.%flashimg-p5%
ECHO.
ECHO. 5.%flashimg-p6%
ECHO.
ECHO. A.%flashimg-p7%
ECHO.
ECHO.
ECHOC {0E}
set choice=A
set /p choice= %flashimg-p8%
if "%choice%"=="A" goto START
if "%choice%"=="a" goto START
if "%choice%"=="1" set target=boot& goto FLASHIMG-START
if "%choice%"=="2" set target=recovery& goto FLASHIMG-START
if "%choice%"=="3" set target=system& goto FLASHIMG-START
if "%choice%"=="4" set target=vendor& goto FLASHIMG-START
if "%choice%"=="5" goto FLASHIMG-CUSTOM
goto FLASHIMG
:FLASHIMG-CUSTOM
ECHOC {0E}
ECHO.
set target=blank
set /p target= %flashimg-p9%
if "%target%"=="blank" goto FLASHIMG-CUSTOM
goto FLASHIMG-START
:FLASHIMG-START
ECHOC {0E}
ECHO.
set /p imgpath= %flashimg-p10%
echo.%imgpath%>log\pathchk.log
find ".img" "log\pathchk.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%flashimg-p11%{\n}& goto FLASHIMG-START
ECHO.
ECHOC {0E}%flashimg-p12%{\n}
ECHOC {0F}%flashimg-p13%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.%flashimg-p14%
if "%result_syxz%"=="1" ECHOC {0C}%flashimg-p15%{\n}& pause>nul & goto FLASHIMG
if "%result_syxz%"=="2" ECHOC {0C}%flashimg-p16%{\n}& pause>nul & goto FLASHIMG
if "%result_syxz%"=="3" ECHOC {0C}%flashimg-p17%{\n}& pause>nul & goto FLASHIMG
ECHOC {07}
fastboot.exe flash %target% %imgpath%
ECHO.
ECHOC {0E}%flashimg-p18%
pause>nul
goto START


:CHKUPDATE
ECHOC {07}
del log\update.txt
cd ..
copy bin\update.bat .\ 1>nul
start update.bat
cd /D %~dp0\bin
goto START
CLS


:TOOLS
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%tools-p1%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHO. %tools-p2%
ECHO.
ECHO.
ECHO. 1.%tools-p3%
ECHO.
ECHO. 2.%tools-p3.1%
ECHO.
ECHO. 3.%tools-p4%
ECHO.
ECHO. 4.%tools-p5%
ECHO.
ECHO. 5.%tools-p6%
ECHO. 
ECHO. 6.%tools-p7%
ECHO.
ECHO. 7.%tools-p8%
ECHO.
ECHO. 8.%tools-p9%
ECHO.
ECHO. 9.%tools-p10%
ECHO.
ECHO. A.%tools-p11%
ECHO.
ECHO.
ECHOC {0E}
set choice=
set /p choice= %tools-p12%
if "%choice%"=="1" start fs.exe pictures\qrcode\magiskalpha-24314.png
if "%choice%"=="2" start fs.exe pictures\qrcode\magiskalpha-25101.png
if "%choice%"=="3" start fs.exe pictures\qrcode\magisk24.3.png
if "%choice%"=="4" start fs.exe pictures\qrcode\magisk23suu.png
if "%choice%"=="5" start fs.exe pictures\qrcode\fingerprint_correction.png
if "%choice%"=="6" echo.installed>log\drvinst.log & start https://syxz.lanzoub.com/i10ZM07i64bc
if "%choice%"=="7" start https://share666-my.sharepoint.com/:f:/g/personal/share666_share666_onmicrosoft_com/EnycEZAcvEFPtvVqVf18PsYBMuf2NtQ7orqzmuKbh0N-LA?e=7t3ub7
if "%choice%"=="8" start https://share666-my.sharepoint.com/:f:/g/personal/share666_share666_onmicrosoft_com/EnycEZAcvEFPtvVqVf18PsYBMuf2NtQ7orqzmuKbh0N-LA?e=7t3ub7
if "%choice%"=="9" start https://share666-my.sharepoint.com/:f:/g/personal/share666_share666_onmicrosoft_com/EqSHj2l4SXNOjvhHcHs7WIcB7lWQyYfvsXtFQK6igeAd3A?e=1fEArt
if "%choice%"=="A" goto START
if "%choice%"=="a" goto START
goto TOOLS


:ROOT
if "%model%"=="vivoX9,X9I,X9L" goto ROOT-X9
set project=boot
rd/s/q "%project%" 1>nul 2>nul
md %project%
if not exist log\bootchannel.txt echo.stable>log\bootchannel.txt
for /f %%i in (log\bootchannel.txt) do set channel=%%i>nul
if "%command%"=="unroot" set channel=official
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
if "%command%"=="root" ECHOC {0E}%root-p1%{\n}
if "%command%"=="unroot" ECHOC {0E}%root-p2%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
if "%model%"=="blank" ECHOC {0C}%root-p3%{\n}& pause>nul & goto START
if "%command%"=="root" ECHOC {0E}%root-p4%{\n}
if "%command%"=="unroot" ECHOC {0E}%root-p5%{\n}
ECHO.
ECHOC {0F}%root-p6%[{0E}%model%{0F}]{\n}
if "%command%"=="unroot" goto ROOT-2
if not "%channel%"=="canary" ECHOC {07}%root-p7%{\n}
if "%channel%"=="canary" ECHOC {0F}%root-p8%{0E}%root-p9%{0F}%root-p10%{\n}
:ROOT-2
ECHO.
ECHOC {0F}%root-p11%{\n}
if "%command%"=="root" ECHOC {07}%root-p12%{\n}
ECHOC {07}%root-p13%{\n}
ECHO.
ECHOC {0E}
set sysver=blank
set /p sysver= %root-p14%
if "%sysver%"=="blank" goto ROOT
if "%sysver%"=="A" call :root-3 & goto ROOT
if "%sysver%"=="a" call :root-3 & goto ROOT
if "%sysver%"=="B" goto START
if "%sysver%"=="b" goto START
::if "%command%"=="unroot" set sysver=%sysver%-official
ECHO.
ECHOC {0F}%root-p15% [{0E}%model%{0F}]{0E}%sysver%{0F} %root-p16%{\n}
start startdl.exe %project% %model% %channel% %sysver%
set tskname=aria2c.exe
call waittsk.exe
find "killed" "log\waittsk.log" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%root-p17%{\n}& pause>nul & goto START
ECHO.
find "failed" "%project%\dlresult.txt" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%root-p18%{\n}& pause>nul & goto ROOT
find "notfound" "%project%\dlresult.txt" 1>nul 2>nul
if "%errorlevel%"=="0" ECHO. & ECHOC {0C}%root-p19%{\n}& pause>nul & goto ROOT
ECHOC {0F}%root-p20%{\n}
md %project%\%sysver% 1>nul 2>nul
ECHOC {0C}
move %project%\%sysver%.7z %project%\%sysver% 1>nul
copy 7z.exe %project%\%sysver% 1>nul
copy 7z.dll %project%\%sysver% 1>nul
cd %project%\%sysver%
7z.exe e "%sysver%.7z" 1>nul 2>nul
if not "%errorlevel%"=="0" cd /D %~dp0\bin & ECHOC {0C}%root-p21%{\n}& pause>nul & goto ROOT
cd /D %~dp0\bin
if "%command%"=="unroot" goto ROOT-1
for /f %%i in (%project%\%sysver%\magiskver.txt) do set magiskver=%%i>nul
if "%command%"=="root" ECHOC {0F}%root-p22%{0E}%magiskver%{0F}{\n}
:ROOT-1
ECHO.
ECHOC {0E}%root-p23%{\n}
ECHOC {0F}%root-p24%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.%root-p25%
if "%result_syxz%"=="1" ECHOC {0C}%root-p26%{\n}& pause>nul & goto ROOT
if "%result_syxz%"=="2" ECHOC {0C}%root-p27%{\n}& pause>nul & goto ROOT
if "%result_syxz%"=="3" ECHOC {0C}%root-p28%{\n}& pause>nul & goto ROOT
ECHOC {0F}%root-p29%{\n}
fastboot.exe getvar all 1>nul 2>log\fbgetvar.log
find "bootloader" "log\fbgetvar.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%root-p30%{\n}& pause>nul & goto START
find "unlocked:yes" "log\fbgetvar.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%root-p31%{\n}& pause>nul & goto START
ECHOC {0F}%root-p32%{\n}
set abdev=n
find "boot_a" "log\fbgetvar.log" 1>nul 2>nul
if "%errorlevel%"=="0" set abdev=y
ECHOC {0F}AB:%abdev% {\n}
ECHOC {0F}%root-p33%{\n}
if "%abdev%"=="n" fastboot.exe flash boot %project%/%sysver%/boot.img 1>nul 2>log\flashboot.log
if "%abdev%"=="y" fastboot.exe flash boot_ab %project%/%sysver%/boot.img 1>nul 2>log\flashboot.log
find "FAILED" "log\flashboot.log" 1>nul 2>nul
if "%errorlevel%"=="0" start log\flashboot.log & ECHOC {0C}%root-p34%{\n}& pause>nul & goto ROOT
if "%command%"=="root" ECHOC {0A}%root-p35%
if "%command%"=="unroot" ECHOC {0A}%root-p36%
pause>nul
rd/s/q "%project%" 1>nul 2>nul
md %project%
goto START

:root-3
for /f %%i in (log\bootchannel.txt) do set channel=%%i>nul
if not "%channel%"=="stable" echo.stable>log\bootchannel.txt
if "%channel%"=="stable" echo.canary>log\bootchannel.txt
goto :eof


:ROOT-X9
if "%command%"=="unroot" msg %username% "%root-x9-p1%" & goto START
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%root-x9-p2%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
if exist boot-X9 goto ROOT-X9-1
ECHO.%root-x9-p3%
::set lanzoudl_link=https://syxz.lanzoub.com/iEtJ307a1h2d
::call lanzoudl_syxz.bat %lanzoudl_link%
::if not "%lanzoudl_result%"=="complete" ECHOC {0C}%root-x9-p4%{\n}& pause>nul & goto ROOT-X9
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 %dlsource%/boot-X9.7z | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%root-x9-p4%{\n}& pause>nul & goto ROOT-X9
find "found" "boot-X9.7z" | find ":500," 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%root-x9-p4.1%{\n}& pause>nul & goto ROOT-X9
ECHO.%root-x9-p5%
7z.exe x "boot-X9.7z" -y 1>nul
del boot-X9.7z 1>nul 2>nul
if not exist emmcdl.exe ECHOC {0C}%root-x9-p6%{\n}& pause>nul & goto ROOT-X9
goto ROOT-X9
:ROOT-X9-1
ECHO.%root-x9-p7%
ECHO.
ECHO.%root-x9-p8%
ECHO.
ECHO.
if exist boot-X9\boot-X9-1.img ECHO.%root-x9-p9%
ECHO.
if exist boot-X9\boot-X9-2.img ECHO.%root-x9-p10%
ECHO.
if exist boot-X9\TWRP-X9.img ECHO.%root-x9-p11%
ECHO.
ECHO. A.%root-x9-p12%
ECHO.
ECHO.
set choice=
set /p choice= %root-x9-p13%
if "%choice%"=="A" goto START
if "%choice%"=="a" goto START
ECHO.
ECHOC {0E}%root-x9-p14%{\n}
ECHO.
ECHOC {0F}%root-x9-p15%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.%root-x9-p16%
if "%result_syxz%"=="1" ECHOC {0C}%root-x9-p17%{\n}& pause>nul & goto START
if "%result_syxz%"=="2" ECHOC {0C}%root-x9-p18%{\n}& pause>nul & goto START
if "%result_syxz%"=="3" ECHOC {0C}%root-x9-p19%{\n}& pause>nul & goto START
ECHOC {07} {\n}
if "%choice%"=="1" fastboot boot boot-X9\boot-X9-1.img
if "%choice%"=="2" fastboot boot boot-X9\boot-X9-2.img
if "%choice%"=="3" fastboot boot boot-X9\TWRP-X9.img
ECHO.
ECHOC {0E}%root-x9-p20%{\n}
ECHO.%root-x9-p21%
ECHO.%root-x9-p22%
ECHO.%root-x9-p23%
pause>nul
goto START


:CHOOSEDEV
del log\model.*
del log\model_new.*
if not exist log\model_sel.txt echo.blank>log\model_sel.txt
for /f %%i in (log\model_sel.txt) do set model=%%i>nul
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%choosedev-p1%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}%choosedev-p2%{\n}
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 --dir=log %dlsource%/model_new.txt | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%choosedev-p3%{\n}& pause>nul & goto START
find "found" "log\model_new.txt" | find ":500," 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%choosedev-p4%{\n}& pause>nul & goto START
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%choosedev-p5%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}%choosedev-p6%{\n}
ECHOC {0E}%choosedev-p6.1%{\n}
ECHOC {0F}%choosedev-p7%{\n}
ECHO. 
ECHOC {0F}
ECHO.%choosedev-p8%
type log\model_new.txt & ECHO.
ECHO.
ECHOC {0F}A.%choosedev-p9%(%model%)%choosedev-p10%{\n}
ECHO.
:CHOOSEDEV-1
ECHOC {0E}
set choice=A
set /p choice= %choosedev-p11%
if "%choice%"=="A" goto START
if "%choice%"=="a" goto START
find "[%choice%." "log\model_new.txt" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%choosedev-p12%{\n}& goto CHOOSEDEV-1
for /f "tokens=2 delims= " %%i in ('findstr "[%choice%." log\model_new.txt') do set model=%%i
echo.%model%>log\model_sel.txt
goto START


:UNLOCK
CLS
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHOC {0E}%unlock-p1%{\n}
ECHO.
ECHOC {0F}=---------------------------------------------------------------={\n}
ECHO.
ECHO.
ECHOC {0E}- %unlock-p2%{\n}
ECHOC {0F}
ECHO.  %unlock-p3%
ECHO.  %unlock-p4%
ECHO.  %unlock-p5%
ECHO.  %unlock-p6%
ECHO.  %unlock-p7%
ECHO.  %unlock-p8%
ECHO.  ...
ECHOC {0E}  %unlock-p9%{\n}
ECHOC {0F}
set choice=0
set /p choice=
if not "%choice%"=="1" goto START
ECHOC {0E}- %unlock-p10%{0C}%unlock-p11%{0E} ! ! !{\n}
ECHOC {0F}  %unlock-p12%{\n}
ECHOC {0E}  %unlock-p13%{\n}
pause>nul
:CHOOSEPLAN-TEMPORARY
ECHO.  
ECHOC {0E}- %unlock-p13.1%{\n}
ECHOC {0F}  1.%unlock-p14%{07}%unlock-p15%{\n}
ECHOC {0F}  2.%unlock-p16%{07}%unlock-p17%{\n}
ECHOC {0F}  3.%unlock-p18%{07}%unlock-p19%{\n}
ECHOC {0F}  4.%unlock-p20%{07}%unlock-p21%{\n}
ECHOC {0F}  %unlock-p22%
set choice=0
set /p choice=
set unlockplan=blank
if "%choice%"=="1" set unlockplan=newcmd
if "%choice%"=="2" set unlockplan=mtk
if "%choice%"=="3" set unlockplan=oldcmd
if "%choice%"=="4" set unlockplan=devinfo
if "%unlockplan%"=="blank" goto CHOOSEPLAN-TEMPORARY
:CHK
ECHOC {0E}- [%unlock-p23%]{\n}
adb.exe devices 1>log\adb.log 2>nul
find "attached" log\adb.log 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}  %unlock-p24%{\n}& pause>nul & goto START
ECHOC {0E}- [%unlock-p25%]{\n}
fastboot.exe 1>nul 2>log\fb.log
find "fastboot:" log\fb.log 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}  %unlock-p26%{\n}& pause>nul & goto START
ECHOC {0E}- %unlock-p27%{\n}
ECHOC {0F}
ECHO.  %unlock-p28%
ECHO.  %unlock-p29%
ECHO.  %unlock-p30%
ECHO.  %unlock-p31%
pause>nul
ECHOC {0E}- [%unlock-p32%]{\n}
ECHOC {0F}  %unlock-p33%{\n}
set choice_syxz=System
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.  %unlock-p34%
if "%result_syxz%"=="1" ECHOC {0C}  %unlock-p35%{\n}& pause>nul & goto START
if "%result_syxz%"=="2" ECHOC {0C}  %unlock-p36%{\n}& pause>nul & goto START
if "%result_syxz%"=="3" ECHOC {0C}  %unlock-p37%{\n}& pause>nul & goto START
TIMEOUT /T 1 /NOBREAK>nul
ECHOC {0E}- [%unlock-p38%]{\n}
adb shell getprop 1>log\adbgetprop.log
for /f "tokens=2 delims= " %%i in ('findstr "ro.product.device" log\adbgetprop.log') do set product_original=%%i
ECHOC {0F}  %unlock-p39%%product_original%{\n}
for /f "tokens=2 delims= " %%i in ('findstr "ro.build.version.sdk" log\adbgetprop.log') do set sdkver=%%i
call :sdktoandroidver
ECHOC {0F}  %unlock-p40%%androidver%{\n}
for /f "tokens=2 delims= " %%i in ('findstr "ro.build.version.bbk" log\adbgetprop.log') do set sysver=%%i
::ro.vivo.product.version
::ro.build.software.version
ECHOC {0F}  %unlock-p41%%sysver%{\n}
::自动选择方案后期再加
ECHOC {0E}- [%unlock-p42%]{\n}
adb.exe reboot bootloader 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}  %unlock-p43%{\n}
ECHOC {0E}- [%unlock-p44%]{\n}
ECHOC {07}  %unlock-p45%{\n}
ECHOC {0F}  %unlock-p46%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.  %unlock-p47%
if "%result_syxz%"=="1" ECHOC {0C}  %unlock-p48%{\n}& pause>nul & goto START
if "%result_syxz%"=="2" ECHOC {0C}  %unlock-p49%{\n}& pause>nul & goto START
if "%result_syxz%"=="3" ECHOC {0C}  %unlock-p50%{\n}& pause>nul & goto START
TIMEOUT /T 1 /NOBREAK>nul
ECHOC {0E}- [%unlock-p51%]{\n}
fastboot.exe getvar all 1>nul 2>log\fbgetvar.log
find "bootloader" "log\fbgetvar.log" 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}  %unlock-p52%{\n}& pause>nul & goto CHOOSEPLAN
for /f "tokens=2 delims= " %%i in ('findstr "unlocked:" log\fbgetvar.log') do set blinfo=%%i
if "%blinfo%"=="unlocked:yes" ECHOC {0A}  %unlock-p53%{\n}& pause>nul & goto START
if "%blinfo%"=="unlocked:no" goto CHOOSEPLAN
if not "%blinfo%"=="unlocked:" ECHOC {0C}  %unlock-p54%{\n}& goto CHOOSEPLAN
for /f "tokens=3 delims= " %%i in ('findstr "unlocked:" log\fbgetvar.log') do set blinfo=%%i
if "%blinfo%"=="yes" ECHOC {0A}  %unlock-p55%{\n}& pause>nul & goto START
if "%blinfo%"=="no" goto CHOOSEPLAN
:CHOOSEPLAN
::暂时不做自动识别
if "%unlockplan%"=="newcmd" goto UNLOCK-NEWCMD
if "%unlockplan%"=="mtk" goto UNLOCK-MTK
if "%unlockplan%"=="oldcmd" goto UNLOCK-OLDCMD
if "%unlockplan%"=="devinfo" goto UNLOCK-DEVINFO
if "%unlockplan%"=="notsupport" ECHO. & ECHOC {0C}  %model%%unlock-p56%{\n}& pause>nul & goto START
if "%unlockplan%"=="blank" ECHO. & ECHOC {0C}  %unlock-p57%{\n}& pause>nul & goto START

:UNLOCK-DEVINFO
::if "%androidver%"=="8.0" ECHOC {0C}  %unlock-devinfo-p1%{\n}& pause>nul & goto START
ECHOC {0E}- [%unlock-devinfo-p2%]{\n}
set wmicusability=y
wmic Logicaldisk | find "Access" 1>nul 2>nul
if not "%errorlevel%"=="0" set wmicusability=n& ECHOC {0C}  %unlock-devinfo-p3%{\n}
ECHOC {0E}- [%unlock-devinfo-p4%]{\n}
ECHOC {0E}  %unlock-devinfo-p5%{\n}
ECHOC {0F}  1.vivoX7,X7L(MSM8976){\n}
ECHOC {0F}  2.vivoX7Plus,X7PlusL(MSM8976){\n}
ECHOC {0F}  3.vivoX9,X9I,X9L(MSM8953){\n}
ECHOC {0F}  4.vivoX9Plus,X9PlusL(MSM8976){\n}
::ECHOC {0F}  5.vivoX9S,X9SL(MSM){\n}
ECHOC {0F}  6.vivoXPlay5A(MSM8976){\n}
ECHOC {0F}  7.vivoY66i,Y66iA(MSM8917){\n}
ECHOC {0F}  A.%unlock-devinfo-p5.1%{\n}
set choice=blank&set FirehoseFile=blank
ECHOC {0F}  %unlock-devinfo-p6%&set /p choice=
if "%choice%"=="1" set FirehoseFile=firehose\prog_emmc_firehose_8976_ddr_X7,X7L.mbn
if "%choice%"=="2" set FirehoseFile=firehose\prog_emmc_firehose_8976_ddr_X7Plus,X7PlusL.mbn
if "%choice%"=="3" set FirehoseFile=firehose\prog_emmc_firehose_8953_ddr_X9,X9I,X9L.mbn
if "%choice%"=="4" set FirehoseFile=firehose\prog_emmc_firehose_8976_ddr_X9Plus,X9PlusL.mbn
::if "%choice%"=="5" set FirehoseFile=firehose\prog_emmc_firehose_8976_ddr_X9S,X9SL.mbn
if "%choice%"=="6" set FirehoseFile=firehose\prog_emmc_firehose_8976_ddr_XPlay5A.mbn
if "%choice%"=="7" set FirehoseFile=firehose\prog_emmc_firehose_8917_ddr_Y66i,Y66iA.mbn
if "%choice%"=="A" ECHOC {0F}  %unlock-devinfo-p6.1%&set /p FirehoseFile=
if "%choice%"=="a" ECHOC {0F}  %unlock-devinfo-p6.1%&set /p FirehoseFile=
if "%FirehoseFile%"=="blank" ECHOC {0C}  %unlock-devinfo-p7%{\n}& goto UNLOCK-DEVINFO
:UNLOCK-DEVINFO-START
ECHOC {0E}- [%unlock-devinfo-p10%]{\n}
ECHOC {0F}  %unlock-devinfo-p11%{\n}
pause>nul
ECHOC {0E}- [%unlock-devinfo-p12%]{\n}
fastboot reboot bootloader 1>nul 2>nul
if "%wmicusability%"=="y" ECHOC {0E}- [%unlock-devinfo-p13%]{\n}& goto UNLOCK-DEVINFO-START-2
ECHOC {0E}- [%unlock-devinfo-p14%]{\n}
tasklist | find /i "mmc.exe" 1>nul 2>nul
if not "%errorlevel%"=="0" start %windir%\system32\devmgmt.msc
ECHOC {0F}  %unlock-devinfo-p15%{\n}
ECHOC {07}  %unlock-devinfo-p16%{\n}
ECHOC {07}  %unlock-devinfo-p17%{\n}
set port=blank
:UNLOCK-DEVINFO-START-1
ECHOC {0F}  %unlock-devinfo-p18%&set /p port=
if "%port%"=="blank" goto UNLOCK-DEVINFO-START-1
set port=COM%port%
goto UNLOCK-DEVINFO-START-3
:UNLOCK-DEVINFO-START-2
wmic path win32_pnpentity get caption /format:table| find "COM">log\9008port.log
find "9008" "log\9008port.log" 1>nul 2>nul
if not "%errorlevel%"=="0" TIMEOUT /T 1 /NOBREAK>nul & goto UNLOCK-DEVINFO-START-2
for /f "tokens=5 delims= " %%i in ('findstr "9008" log\9008port.log') do set port=%%i
echo.%port%>log\9008port.log
for /f "tokens=1 delims=(" %%i in (log\9008port.log) do set port=%%i
echo.%port%>log\9008port.log
for /f "tokens=1 delims=)" %%i in (log\9008port.log) do set port=%%i
ECHOC {0F}  %unlock-devinfo-p19% (%port%){\n}
:UNLOCK-DEVINFO-START-3
ECHOC {0E}- [%unlock-devinfo-p20%]{\n}
emmcdl.exe -p %port% -f %FirehoseFile% -d devinfo -o devinfo.img 1>nul 2>log\extractdevinfo.log
if not exist devinfo.img start log\extractdevinfo.log & ECHOC {0C}  %unlock-devinfo-p20.1%{\n}& pause>nul & goto UNLOCK-DEVINFO-START-3
ECHOC {0E}- [%unlock-devinfo-p21%]{\n}
copy devinfo.img log 1>nul
ren log\devinfo.img devinfo_bak.img 1>nul
move log\devinfo_bak.img .\ 1>nul
ECHOC {0E}- [%unlock-devinfo-p22%]{\n}
HexTool.exe devinfo.img 00000016 09 FF00000000000000FF>log\hex.log
::http://www.bathome.net/thread-6484-1-1.html
ECHOC {0E}- [%unlock-devinfo-p23%]{\n}
emmcdl.exe -p %port% -f %FirehoseFile% -b devinfo devinfo.img 1>nul 2>log\extractdevinfo.log
ECHOC {0E}- [%unlock-devinfo-p24%]{\n}
ECHOC {0F}  %unlock-devinfo-p25%{\n}
ECHOC {0F}  %unlock-devinfo-p26%{\n}
set choice_syxz=Fastboot
call chkconnect_syxz.bat %choice_syxz%
if "%result_syxz%"=="0" ECHO.  %unlock-devinfo-p27%
if "%result_syxz%"=="1" ECHOC {0C}  %unlock-devinfo-p28%{\n}& pause>nul & goto START
if "%result_syxz%"=="2" ECHOC {0C}  %unlock-devinfo-p29%{\n}& pause>nul & goto START
if "%result_syxz%"=="3" ECHOC {0C}  %unlock-devinfo-p30%{\n}& pause>nul & goto START
ECHOC {0E}- [%unlock-devinfo-p31%]{\n}
set blunlocked=blank
fastboot.exe oem device-info 1>nul 2>log\blstate.log
for /f "tokens=4 delims= " %%i in ('findstr "unlocked:" log\blstate.log') do set blunlocked=%%i
if not "%errorlevel%"=="0" ECHOC {0C}  %unlock-devinfo-p32%{\n}& pause>nul & goto UNLOCK-DEVINFO-ERASE
if "%blunlocked%"=="true" goto UNLOCK-DEVINFO-SUCCESS
if "%blunlocked%"=="false" start log\extractdevinfo.log & ECHO. & ECHOC {0C}%unlock-devinfo-p32.1%{\n}& pause>nul & goto START
ECHOC {0C}  %unlock-devinfo-p33%{\n}& pause>nul & goto UNLOCK-DEVINFO-ERASE
:UNLOCK-DEVINFO-SUCCESS
::ECHOC {0E}- [%unlock-devinfo-p34%]{\n}
::fastboot erase userdata 1>nul 2>nul
ECHO.  
ECHOC {0A}  %unlock-devinfo-p35%{\n}
ECHOC {0F}
ECHO.
ECHO.  %unlock-devinfo-p36%
ECHO.  %unlock-devinfo-p37%
ECHO.  %unlock-devinfo-p38%
ECHO.  %unlock-devinfo-p39%
ECHO.  %unlock-devinfo-p40%
ECHO.
:UNLOCK-DEVINFO-ERASE
ECHOC {0E}- [%unlock-devinfo-p34%]{\n}
fastboot erase userdata 1>nul 2>nul
ECHOC {0F}  %unlock-devinfo-p41%
pause>nul
goto START

:UNLOCK-NEWCMD
ECHOC {0E}- %unlock-newcmd-p1%{\n}
ECHOC {0F}  %unlock-newcmd-p2%{\n}
7z.exe x "vendor.7z" -y 1>nul
if not exist vendor.img ECHOC {0C}  %unlock-newcmd-p3%{\n}& pause>nul & goto UNLOCK-NEWCMD
ECHOC {0E}- [%unlock-newcmd-p4%]{\n}
ECHOC {0F}  %unlock-newcmd-p5%{\n}
fastboot.exe flash vendor vendor.img 1>nul 2>log\flashvendor.log
find "FAILED" "log\flashvendor.log" 1>nul 2>nul
ECHOC {07}
if "%errorlevel%"=="0" type log\flashvendor.log & ECHOC {0C}  %unlock-newcmd-p6%{\n}
:UNLOCK-NEWCMD-1
ECHOC {0E}- [%unlock-newcmd-p7%]{\n}
fastboot_vivo.exe vivo_bsp unlock_vivo 1>nul 2>log\unlock.log
find "FAILED" "log\unlock.log" 1>nul 2>nul
if not "%errorlevel%"=="0" goto UNLOCK-NEWCMD-SUCCESS
find "Signature" "log\unlock.log" 1>nul 2>nul
if "%errorlevel%"=="0" start log\unlock.log & ECHOC {0C}  %unlock-newcmd-p8%{\n}& pause>nul & goto START
start log\unlock.log & ECHOC {0C}  %unlock-newcmd-p9%{\n}& pause>nul & goto UNLOCK-NEWCMD-1
:UNLOCK-NEWCMD-SUCCESS
ECHO.  
ECHOC {0A}  %unlock-newcmd-p10%{\n}
ECHO.
ECHOC {0F}  %unlock-newcmd-p11%{0E}%unlock-newcmd-p12%{0F}%unlock-newcmd-p13%{\n}
ECHO.  %unlock-newcmd-p14%
ECHO.  %unlock-newcmd-p15%
ECHOC {0F}  %unlock-newcmd-p16%{0E}%unlock-newcmd-p17%{0F}%unlock-newcmd-p18%{\n}
ECHOC {0E}  %unlock-newcmd-p19%{0F}%unlock-newcmd-p20%{\n}
ECHO.  %unlock-newcmd-p21%
pause>nul
goto START

:UNLOCK-MTK
if exist mtkclient-gui\start.bat goto UNLOCK-MTK-1
del mtkclient-gui.7z 1>nul 2>nul
ECHOC {0E}- [%unlock-mtk-p1%]{\n}
ECHOC {0F}  %unlock-mtk-p2%{\n}
::set lanzoudl_link=https://syxz.lanzoub.com/iiraT06p8yyd
::call lanzoudl_syxz.bat %lanzoudl_link%
::if not "%lanzoudl_result%"=="complete" ECHOC {0C}  %unlock-mtk-p3%{\n}& pause>nul & goto UNLOCK-MTK
aria2c.exe --max-concurrent-downloads=16 --max-connection-per-server=16 --split=16 %dlsource%/mtkclient-gui.7z | find "download completed." 1>nul 2>nul
if not "%errorlevel%"=="0" ECHOC {0C}%unlock-mtk-p3%{\n}& pause>nul & goto UNLOCK-MTK
find "found" "mtkclient-gui.7z" | find ":500," 1>nul 2>nul
if "%errorlevel%"=="0" ECHOC {0C}%unlock-mtk-p3.1%{\n}& pause>nul & goto UNLOCK-MTK
ECHOC {0E}- [%unlock-mtk-p4%]{\n}
ECHOC {0F}  %unlock-mtk-p5%{\n}
7z.exe x "mtkclient-gui.7z" -y 1>nul
if not exist mtkclient-gui\start.bat ECHOC {0C}  %unlock-mtk-p6%{\n}& pause>nul & goto UNLOCK-MTK
del mtkclient-gui.7z 1>nul 2>nul
:UNLOCK-MTK-1
ECHOC {0E}- [%unlock-mtk-p7%]{\n}
ECHOC {0F}  %unlock-mtk-p8%{\n}
pause>nul
ECHOC {0E}- [%unlock-mtk-p9%]{\n}
start mtkclient-gui\start.bat
ECHOC {0F}  %unlock-mtk-p10%{\n}
TIMEOUT /T 1 /NOBREAK>nul
ECHOC {0E}- [%unlock-mtk-p11%]{\n}
fastboot reboot bootloader 1>nul 2>nul
ECHOC {0F}  %unlock-mtk-p12%{\n}
pause>nul
goto START

:UNLOCK-OLDCMD
ECHOC {0E}- [%unlock-oldcmd-p1%]{\n}
fastboot_vivo.exe bbk unlock_vivo 1>nul 2>log\unlock.log
find "FAILED" "log\unlock.log" 1>nul 2>nul
if "%errorlevel%"=="0" start log\unlock.log & ECHOC {0C}  %unlock-oldcmd-p2%{\n}& pause>nul & goto UNLOCK-OLDCMD
ECHO.  
ECHOC {0A}  %unlock-oldcmd-p3%{\n}
ECHOC {0F}
ECHO.
ECHO.  %unlock-oldcmd-p4%
ECHO.  %unlock-oldcmd-p5%
pause>nul
goto START


:CLEAN
ECHOC {07}
taskkill /f /im 7z.exe 1>nul 2>nul
taskkill /f /im aria2c.exe 1>nul 2>nul
taskkill /f /im adb.exe 1>nul 2>nul
taskkill /f /im fastboot.exe 1>nul 2>nul
rd/s/q "boot" 1>nul 2>nul
md boot
rd/s/q "log" 1>nul 2>nul
md log
goto RESTART


:sdktoandroidver
set androidver=unknown
if "%sdkver%"=="[14]" set androidver=4.0
if "%sdkver%"=="[15]" set androidver=4.0
if "%sdkver%"=="[16]" set androidver=4.1
if "%sdkver%"=="[17]" set androidver=4.2
if "%sdkver%"=="[18]" set androidver=4.3
if "%sdkver%"=="[19]" set androidver=4.4
if "%sdkver%"=="[21]" set androidver=5.0
if "%sdkver%"=="[22]" set androidver=5.1
if "%sdkver%"=="[23]" set androidver=6.0
if "%sdkver%"=="[24]" set androidver=7.0
if "%sdkver%"=="[25]" set androidver=7.1
if "%sdkver%"=="[26]" set androidver=8.0
if "%sdkver%"=="[27]" set androidver=9.0
if "%sdkver%"=="[28]" set androidver=10.0
if "%sdkver%"=="[29]" set androidver=11.0
if "%sdkver%"=="[30]" set androidver=12.0
if "%sdkver%"=="[31]" set androidver=12.0
goto :eof
