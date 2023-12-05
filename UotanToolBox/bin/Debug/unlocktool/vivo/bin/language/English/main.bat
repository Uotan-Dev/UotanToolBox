@ECHO OFF










set others-p4=Check whether the system can execute the FINDSTR command...

set others-p5=Your computer system cannot execute the FINDSTR command and cannot continue.
set others-p6=Check paths...



set others-p7=There are special characters (such as spaces, English brackets, etc.) in the toolbox path. Please place the toolbox in a path without special characters, otherwise it will not work properly.

set others-p8=Check program integrity...
set others-p9=7z.exe is missing! Please download the full program again.
set others-p10=adb.exe is missing! Please download the full program again.
set others-p11=aria2c.exe is missing! Please download the full program again.
set others-p12=fastboot.exe is missing! Please download the full program again.
set others-p13=fastboot_vivo.exe is missing! Please download the full program again.
set others-p14=blat.exe is missing! Please download the full program again.
set others-p15=7z.dll is missing! Please download the full program again.
set others-p16=chkconnect_syxz.bat is missing! Please download the full program again.
set others-p17=viqoo_config.bat is missing! Please download the full program again.

set others-p18=Check whether the system can execute the MSG command...

set others-p19=Your system cannot execute MSG instructions, which will prevent you from receiving some notifications of the program, such as upgrade prompts, etc. But you can still use the toolbox. Press any key to continue.


set others-p20=Load configuration...



set others-p21=[permanently free] viQOO Toolbox& set others-p21.1=by SYXZ

set others-p22=Start background checking for updates...




::START



set start-p1=                       viQOO Toolbox by SYXZ



set start-p2=      Small / Free / OpenSource   Welcome to viQOO Toolbox!

set start-p3=             Use "feedback.bat" to e-mail developer.



set start-p4=Select model for best experience (it'll not affect unlock).
set start-p5=Use "More Resources" function to install necessary drivers.


set start-p6=Unlock BL& set start-p7=Root& set start-p8=Remove Root/Restore official Boot

set start-p10=Why not lock bootloader?


set start-p9=Open Magisk-Boot Repository& set start-p9.1=Patch Boot (make Magisk-Boot)


set start-p11=Flash official recovery with root permission (experimental)


set start-p12=More resources& set start-p13=Flash any partition& set start-p14=Disable AVB


set start-p15=Check update& set start-p16=Select model& set start-p17=Clear usage records


set start-p18=About us





set start-p19=Select and press Enter to continue:





set start-p20=After the bootloader is locked, only the official system can be started, and the partition cannot be flashed through Fastboot. So locking when the system has been unlocked and modified (such as Root) is suicide. Since it is difficult to guarantee that the system is fully official before it is locked, the locking function will not be provided for security reasons. Press any key to return to the main menu.



set start-p21=According to the feedback from group, there is a risk of not being able to boot using this function, so it is not provided. Press any key to return.









::PATCHBOOT



set patchboot-p1= Make Magisk-Boot




set patchboot-p2=This feature is currently only available on 64-bit computers. Press any key to return.
set patchboot-p3= Use boot.img to patch and package Magisk-Boot on the computer.
set patchboot-p4= Related software, scripts and binaries are developed by affggh and used under license.
set patchboot-p5= open source address:


set patchboot-p6=Patch Boot with MagiskAlpha-25101 version (default)
set patchboot-p7=custom patching scheme
set patchboot-p8=back to main menu


set patchboot-p9=Enter a number and press Enter to continue:



set patchboot-p10=Please drag boot.img into the window and press Enter to continue:

set patchboot-p11=The selected file does not exist! Press any key to try again.
set patchboot-p11.1=Preparing to patch, please wait...









set patchboot-p12=The file could not be copied to the specified location! It is recommended that special characters such as spaces do not appear in the selected file path. Press any key to return.



set patchboot-p13=Patch failed! Press any key to return.




set patchboot-p14=Patch done. The output location is the folder where the source files are located. You can test your patched Boot using the "Flash to Custom Partition" - "Flash to Boot" function. Press any key to return to the main menu.




set patchboot-p15=You have not downloaded the MagiskPatcher component. Press Enter to download immediately, enter 1 and press Enter to return to the main menu


set patchboot-p15.1=Downloading, please wait...


set patchboot-p16=Download failed! Press any key to return.
set patchboot-p17=Download complete, unzipping...


set patchboot-p18=Unzip failed! Press any key to return.



::ROOTREC







set rootrec-p1= Original first release: Brush into the official Recovery with Root permissions
set rootrec-p2=                                                   by coolapk@gaojiya



set rootrec-p3= After unlocking the bootloader, flash the modified version in Fastboot mode, open the official Recovery of adb root, and then use the adb command to perform the operation you want to perform.
set rootrec-p4= This feature requires unlocking the BL to use {0F}.
set rootrec-p5= This function is not a Root system& set rootrec-p6=, this function is only to enable the Root permission of Recovery. After it is turned on, you can connect to the computer in the official recovery mode and execute the adb command.

set rootrec-p7= At present, there are few Recovery adaptations. If you need adaptation, please extract the Recovery partition of your current system (extract it with the gaojizhushou or find it from the system package), and copy the img file to the bin\log folder of the toolbox, and then use the feedback function to send to the developer. Note that the model and system version number must be specified.





set rootrec-p10=Return to main menu

set rootrec-p11=Enter the serial number and press Enter to continue:





set rootrec-p12=Getting online & set rootrec-p13=Version of Root-Recovery...




set rootrec-p14=Download stopped, press any key to return to main menu.


set rootrec-p15=Download failed! Press any key to return.

set rootrec-p16=This version of Recovery is not included in the cloud repository! Press any key to return.
set rootrec-p17=Extracting...







set rootrec-p18=Unzip error! Press any key to return.


set rootrec-p19=Please turn off the phone and connect it to the computer, hold the power button and volume up to enter Fastboot mode.
set rootrec-p20=Check Fastboot connection...


set rootrec-p21=Device connected!
set rootrec-p22=Check device connection failed!
set rootrec-p23=There are multiple devices connected! Please disconnect other devices!
set rootrec-p24=Unknown error!
set rootrec-p25=Check unlock status...


set rootrec-p26=Fastboot failed to read device information! Please check the connection or enter the group feedback.

set rootrec-p27=Your device is not unlocked! Please unlock it before using this function. Press any key to return to the main menu.
set rootrec-p28=Flash Recovery...


set rootrec-p29=Failed to flash! Press any key to return.
set rootrec-p30=Flashing successfully!
set rootrec-p31=Restart Fastboot to refresh state...


set rootrec-p32=Please reboot to Recovery manually (use Fastboot's reboot option or hold power button and volume down)
set rootrec-p33=Check Recovery connection...


set rootrec-p34=Device connected!
set rootrec-p35=Check device connection failed!
set rootrec-p36=There are multiple devices connected! Please disconnect other devices!
set rootrec-p37=Unknown error!
set rootrec-p38=Test result



set rootrec-p39=Root successfully! Press any key to return to the main menu.

set rootrec-p40=Failed to root! Please use the feedback feature to inform the developer. Press any key to return to the main menu.

set rootrec-p41=Command not executed! Please use the feedback feature to inform the developer. Press any key to return to the main menu.
set rootrec-p42=Unknown error! Please use the feedback feature to inform the developer. Press any key to return to the main menu.








::ABOUT



set about-p1= About us




set about-p2= [Introduction to Toolbox]


set about-p3= viQOO toolbox is a tool written by mouzei, which is used to unlock the root of vivo and iQOO models with one click. There are four built-in unlocking schemes, and there is a cloud Boot library. Enter the version number to download and flash it online. The first version was released on 2022.5.26.
set about-p4= Note: The unlocking schemes are all derived from network public resources.

set about-p5= [Participate and help develop]




set about-p6= [Glorious test member]




set about-p7= Introduction: & set about-p8=viQOO has joined the beta Boot channel since V2.0.1, the Boot that has not been tested will be temporarily stored in the beta channel, and it will be transferred to stable after testing. version channel. Those who take part in the test will be recorded here as glorious test members.
set about-p9= How to become a test member: & set about-p10=1. Flashing the Boot of the beta channel 2. Turn on the phone and check the root permission 3. Whether it is successful or not, inform the developer of the result (you can join the group or use the feedback function)

set about-p11= [Yhchat feedback group]


set about-p11.1=yhchat ID

set about-p11.2= Note: Yhchat APP download link: www.yhchat.com
set about-p11.3= Since the QQ group is overwhelmed, we will use the Yhchat APP to communicate in the future. Yhchat is an emerging chat software with small size, unlimited group size, and full platform support. At present, the software is in the internal testing stage and is being gradually improved.


set about-p12=Press any key to return to the main menu.



::FLASHIMG



set flashimg-p1= Flashing custom partition





set flashimg-p2=Flashing Boot

set flashimg-p3=Flashing Recovery

set flashimg-p4=Flashing System

set flashimg-p5=Flashing Vendor

set flashimg-p6=Flashing other

set flashimg-p7=Return to main menu (default)




set flashimg-p8=Enter a number and press Enter to continue:












set flashimg-p9=Please enter the name of the partition you want to flash (must be accurate):





set flashimg-p10=Please drag the partition img file here and press Enter to continue:


set flashimg-p11=You have not selected an img file!

set flashimg-p12=Please hold the power button and volume up to put the phone into Fastboot mode.
set flashimg-p13=Check Fastboot connection...


set flashimg-p14=Device connected!
set flashimg-p15=Check device connection failed!
set flashimg-p16=There are multiple devices connected! Please disconnect other devices!
set flashimg-p17=Unknown error!



set flashimg-p18=The flashing is completed, please check whether it is successful. Press any key to return to the main menu.















::TOOLS



set tools-p1= more resources




set tools-p2=Note: The applications are all downloaded by scanning the code on the phone.


set tools-p3=MagiskAlpha-24314 APP

set tools-p3.1=MagiskAlpha-25101 APP

set tools-p4=Magisk24.3 APP

set tools-p5=Magisk23.0suu special edition (used by X9)

set tools-p6=Correction Fingerprint APP

set tools-p7=Install the computer flashing driver

set tools-p8=AFTool 5.1.28, 5.9.50 (vivo after-sales flashing tool)

set tools-p9=vivo system downgrade tool

set tools-p10=system package (use the feedback function to leave a message for the 9008 package you want)

set tools-p11=Back to main menu




set tools-p12=Enter a number and press Enter to continue:














::ROOT










set root-p1= Root system
set root-p2= Remove root




set root-p3= Please select a model before using this function. Press any key to return to the main menu.
set root-p4= Flash the magisk patched Boot.img to root the system.
set root-p5= Flash the official vanilla Boot.img to remove Root.

set root-p6= The model of your choice is:

set root-p7= is currently the stable channel. If you can't find the resource, you can try changing the beta channel.
set root-p8= currently & set root-p9=beta & set root-p10=channel. Beta versions are not guaranteed to be available and may even result in failure to boot.


set root-p11= Please enter your system version number exactly, such as 2.8.4.
set root-p12= Enter A to replace the Boot channel
set root-p13= Enter B to return to the main menu



set root-p14=version number:







set root-p15=Getting online & set root-p16=version of Boot...




set root-p17=The download has stopped, press any key to return to the main menu.


set root-p18=Download failed! Press any key to return.

set root-p19=This version of Boot is not included in the cloud repository! Press any key to return.
set root-p20=Download complete, unzipping...







set root-p21=Unzip error! Press any key to return.



set root-p22=magisk version:
::ROOT-1

set root-p23=Please turn off the phone and connect it to the computer, hold the power button and volume up to enter Fastboot mode.
set root-p24=Checking device connection...


set root-p25=Device connected!
set root-p26=Check device connection failed!
set root-p27=There are multiple devices connected! Please disconnect other devices!
set root-p28=Unknown error!
set root-p29=Check unlock status...


set root-p30=Fastboot failed to read device information! Please check the connection or enter the group feedback.

set root-p31=Your device is not unlocked! Please unlock it before using this function. Press any key to return to the main menu.
set root-p32=AB partition identification (experimental)




set root-p33=Flash Boot...



set root-p34=Failed to flash! Press any key to return.
set root-p35=Flashed successfully! To obtain root privileges, please select the "More Resources" function of the main menu after powering on, scan the code to download and install the Alpha or normal version of the Magisk APP. If you're using the beta channel, be sure to use the feedback feature to inform the developers of the results, regardless of success. Press any key to return to the main menu.
set root-p36=Flashed successfully! Uninstall the Magisk software after booting to completely remove Root. Press any key to return to the main menu.












::ROOT-X9
set root-x9-p1=vivoX9 only has a temporary root, and it will be fail after restarting. This function is not required.



set root-x9-p2= Root system





set root-x9-p3=Missing resource, downloading...


set root-x9-p4=Download failed! Press any key to try again...
set root-x9-p5=Download complete, unzipping...


set root-x9-p6=Unzip failed! Press any key to try again...


set root-x9-p7= vivoX9 can only temporarily start Boot to root or temporarily start TWRP, and it will be fail after restarting.

set root-x9-p8= TWRP can only be started, no read and write permissions, and cannot mount storage.


set root-x9-p9= 1. Temporarily start boot.img by TWRP Xiaobai 2008

set root-x9-p10= 2. Temporarily start boot.img by Qiushui 105

set root-x9-p11= 3. Temporarily start TWRP Recovery by Qiushui 105

set root-x9-p12=Back to main menu



set root-x9-p13=Enter a number and press Enter to continue:



set root-x9-p14=Please hold the power button and volume up to enter Fastboot mode.

set root-x9-p15=Waiting for device to connect (Fastboot)...


set root-x9-p16=Device connected!
set root-x9-p17= Check device connection failed!
set root-x9-p18= There are multiple devices connected! Please disconnect other devices!
set root-x9-p19= Unknown error!





set root-x9-p20=Done. To get Root permissions, please select the "More Resources" function in the main menu after powering on, and scan the code to download and install the suu version of the Magisk APP.
set root-x9-p21=adb shell command to get Root permission is: adb shell magisk suu
set root-x9-p22=Temporary startup and restart will fail. If you restart the system, it will restore the unflashed state.
set root-x9-p23=Press any key to return to the main menu.




::CHOOSEDEV







set choosedev-p1= choose/change model




set choosedev-p2=Networking for a list of supported models...

set choosedev-p3=Download failed! Press any key to return to the main menu.

set choosedev-p4=Cloud file not found! Please use the feedback feature to inform the developer. Press any key to return to the main menu.



set choosedev-p5= choose/change model




set choosedev-p6= Note: Different models use different resources, please choose carefully.
set choosedev-p6.1= Unlocking is not directly related to choosing a model, you can also unlock without choosing a model.
set choosedev-p7= iQOONeo, Neo3, Neo5 cannot be unlocked. Some models cannot be rooted after unlocking.


set choosedev-p8=No.	Name	Code	Unlocking scheme


set choosedev-p9=keep status & set choosedev-p10=and return to main menu (default)




set choosedev-p11=Enter a number and press Enter to continue:



set choosedev-p12=This option does not exist, please re-enter. Select the model and enter pure numbers.





::UNLOCK



set unlock-p1= unlock bootloader




set unlock-p2=Are you sure you want to unlock the bootloader? Unlocking and flashing may cause the following effects:

set unlock-p3=Phone data is cleared
set unlock-p4=The phone system is damaged and cannot be turned on
set unlock-p5=baseband lost
set unlock-p6=loss of warranty
set unlock-p7=Optical fingerprint is invalid (can be restored by after-sales calibration)
set unlock-p8=fingerprint payment not available (seems to be fixed by module)

set unlock-p9=voluntarily assume the above risks, please enter 1 and press Enter to continue, otherwise press Enter directly to return to the main menu




set unlock-p10=Unlocking the BL lock will clear the phone & set unlock-p11=All data
set unlock-p12=Please make sure the data has been backed up to the outside of the phone!
set unlock-p13=Please exit other phone management and flashing software, then press any key to start...



set unlock-p13.1=Please select an unlock scheme:
set unlock-p14=The new version of Qualcomm xda solution: & set unlock-p15=If your device is a Qualcomm processor and it is a new machine in the past two years, you can try this solution.
set unlock-p16=MTKClient forced solution: & set unlock-p17=If your device is a MediaTek processor, you can try this solution.
set unlock-p18=Unlock the old version of the old model: & set unlock-p19=If your device is an old machine six or seven years ago (official system Android 5 or 5.1), you can try this solution.
set unlock-p20=Unlock the modified partition for X9: & set unlock-p21=If your phone is vivoX9, you can use this solution to unlock.
set unlock-p22=Enter a number and press Enter to continue:









set unlock-p23=Check if ADB works


set unlock-p24=ADB does not work properly!
set unlock-p25=Check if Fastboot works


set unlock-p26=Fastboot does not work properly!
set unlock-p27=Please follow these steps:

set unlock-p28=Please power on your phone and connect it to your computer, enable developer options
set unlock-p29=Turn on the [OEM unlock] and [USB debugging] switches
set unlock-p30=If the USB debugging prompt appears, please tick Always allow and confirm.
set unlock-p31=Press any key to continue when done...

set unlock-p32=Check device connection
set unlock-p33=Waiting for device to connect (system)...


set unlock-p34=Device connected!
set unlock-p35=Check device connection failed!
set unlock-p36=There are multiple devices connected! Please disconnect other devices!

set unlock-p37=Unknown error!

set unlock-p38=Read device information


set unlock-p39=Model:


set unlock-p40=Android version:



set unlock-p41=system version:

set unlock-p42=Reboot to Fastboot

set unlock-p43=Failed to reboot device! Please press and hold the power button and volume up button after shutdown to manually enter Fastboot.
set unlock-p44=Check device connection
set unlock-p45=If the device manager has a device but cannot connect, please use the feedback function to let the developer know.
set unlock-p46=Waiting for device to connect (Fastboot)...


set unlock-p47=Device connected!
set unlock-p48=Check device connection failed!
set unlock-p49=There are multiple devices connected! Please disconnect other devices!
set unlock-p50=Unknown error!

set unlock-p51=Check unlock status


set unlock-p52=Fastboot failed to read device information (no information)! Press any key to continue...

set unlock-p53=Your device is already unlocked, no need to unlock it again. Press any key to return to the main menu.

set unlock-p54=Fastboot failed to read device information (information is incomplete)! Press any key to continue...

set unlock-p55=Your device is already unlocked, no need to unlock it again. Press any key to return to the main menu.







set unlock-p56=Unlock not supported!
set unlock-p57=The model information could not be found! Please use the feedback feature to inform the developer.

::UNLOCK-DEVINFO
set unlock-devinfo-p1=vivoX9 is not supported by Android 8, please downgrade to Android 7 or below.
set unlock-devinfo-p2=Check if WMIC works


set unlock-devinfo-p3=Your computer system cannot execute WMIC commands! The port is not automatically recognized.






set unlock-devinfo-p4=Download unlock resource
set unlock-devinfo-p5=Downloading unlock resource, please wait...


set unlock-devinfo-p6=Download failed! Press any key to try again...
set unlock-devinfo-p7=Unzip unlock resource
set unlock-devinfo-p8=Unzipping unlock resources, please wait...


set unlock-devinfo-p9=Unzip failed! Press any key to try again...

set unlock-devinfo-p10=Please follow the prompts
set unlock-devinfo-p11=Please keep connected to the computer, press and hold the phone volume up and down at the same time, then press any key to continue.

set unlock-devinfo-p12=Reboot phone

set unlock-devinfo-p13=Wait for port 9008
set unlock-devinfo-p14=Please enter 9008 port number


set unlock-devinfo-p15=Your computer system cannot execute the WMIC command, you need to enter the port number manually.
set unlock-devinfo-p16=Please expand the "Ports" item in the device manager and find the Qualcomm 9008 port,
set unlock-devinfo-p17=Then enter the number after COM, such as 30. Be sure to enter it exactly.


set unlock-devinfo-p18=Port number:












set unlock-devinfo-p19=Entered 9008


set unlock-devinfo-p20=Extract devinfo.img

set unlock-devinfo-p20.1=Failed to extract! Please put the phone into Fastboot mode first, then power off, and then press any key to try again.
set unlock-devinfo-p21=backup devinfo.img



set unlock-devinfo-p22=Process devinfo.img


set unlock-devinfo-p23=Flash devinfo.img

set unlock-devinfo-p24=Please press key manually
set unlock-devinfo-p25=Please hold the power button and volume up to enter Fastboot mode.
set unlock-devinfo-p26=Waiting for device to connect (Fastboot)...


set unlock-devinfo-p27=Device connected!
set unlock-devinfo-p28=Check device connection failed!
set unlock-devinfo-p29=There are multiple devices connected! Please disconnect other devices!
set unlock-devinfo-p30=Unknown error!

set unlock-devinfo-p31=Check unlock status


set unlock-devinfo-p32=Fastboot failed to read device info (no info)! Press any key to try again...



set unlock-devinfo-p32.1=Unlock failed! Press any key to return to the main menu.
set unlock-devinfo-p33=Fastboot failed to read device information! Press any key to try again...

set unlock-devinfo-p34=Clear data


set unlock-devinfo-p35=Congratulations, the unlock is successful!


set unlock-devinfo-p36=Because of clearing data, the first boot time will be longer, please wait patiently for about 5 minutes.
set unlock-devinfo-p37=It is normal that the system data space is damaged after booting.
set unlock-devinfo-p38=If you want to root, please go back to the main menu and select the Root function.
set unlock-devinfo-p39=Do not click the "Verify System" function in recovery mode, otherwise all data will be lost.
set unlock-devinfo-p40=The toolbox is made by mouzei, it is free forever, commercial use is prohibited. Press any key to return to the main menu.



::UNLOCK-NEWCMD
set unlock-newcmd-p1=Unzip Vendor
set unlock-newcmd-p2=Unzipping Vendor, please wait...

set unlock-newcmd-p3=Failed to extract Vendor! Press any key to try again...
set unlock-newcmd-p4=Flash into Vendor
set unlock-newcmd-p5=Vendor is flashing, this will take a while, please wait...



set unlock-newcmd-p6=Failed to flash. But this doesn't necessarily affect unlocking.

set unlock-newcmd-p7=Execute unlock command




set unlock-newcmd-p8=Unlock failed! This program is not suitable for your device or the system version is too high. Press any key to return to the main menu.
set unlock-newcmd-p9=Unlock failed! Press any key to try again...


set unlock-newcmd-p10=Congratulations, the unlock is successful!

set unlock-newcmd-p11=You will be prompted to boot later & set unlock-newcmd-p12=Clear data & set unlock-newcmd-p13=, just follow the prompt to clear. The first boot time after clearing is long.
set unlock-newcmd-p14=It is normal that the system data space is damaged after booting.
set unlock-newcmd-p15=If you want to root, please go back to the main menu and select the Root function.
set unlock-newcmd-p16=Do not click in recovery mode & set unlock-newcmd-p17=Verify system & set unlock-newcmd-p18=function, otherwise all data will be lost.
set unlock-newcmd-p19=Do not overclock & set unlock-newcmd-p20=, otherwise the system may not work properly.
set unlock-newcmd-p21=The toolbox is made by mouzei, it is free forever, commercial use is prohibited. Press any key to return to the main menu.



::UNLOCK-MTK


set unlock-mtk-p1=Download MTKClient
set unlock-mtk-p2=Downloading MTKClient, please wait...


set unlock-mtk-p3=Download failed! Press any key to try again...


set unlock-mtk-p4=Unzip MTKClient
set unlock-mtk-p5=Unzipping MTKClient, please wait...

set unlock-mtk-p6=Unzip failed! Press any key to try again...


set unlock-mtk-p7=Please press the key manually
set unlock-mtk-p8=Please hold volume up and down at the same time, stay connected, then press any key to continue...

set unlock-mtk-p9=Start MTKClient

set unlock-mtk-p10=The key can be released after four seconds.

set unlock-mtk-p11=Reboot phone

set unlock-mtk-p12=Pay attention to the MTKClient prompt. Press any key to return to the main menu.



::UNLOCK-OLDCMD
set unlock-oldcmd-p1=Execute unlock command


set unlock-oldcmd-p2=Unlock failed! Press any key to try again...

set unlock-oldcmd-p3=Congratulations, unlocked successfully!


set unlock-oldcmd-p4=You may be prompted to clear data after booting up later, just follow the prompt to clear it. The first boot time after clearing is long.
set unlock-oldcmd-p5=The toolbox is made by mouzei, it is free forever, commercial use is prohibited. Press any key to return to the main menu.




































goto :eof