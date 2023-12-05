@ECHO OFF










set others-p4=检查电脑系统能否执行FINDSTR指令...

set others-p5=你的电脑系统不能执行FINDSTR指令，无法继续。
set others-p6=检查路径...



set others-p7=工具箱路径中有特殊字符（如空格、英文括号等）。请将工具箱放置在没有特殊字符的路径中，否则无法正常运行。

set others-p8=检查程序完整性...
set others-p9=7z.exe缺失！请重新下载完整程序。
set others-p10=adb.exe缺失！请重新下载完整程序。
set others-p11=aria2c.exe缺失！请重新下载完整程序。
set others-p12=fastboot.exe缺失！请重新下载完整程序。
set others-p13=fastboot_vivo.exe缺失！请重新下载完整程序。
set others-p14=blat.exe缺失！请重新下载完整程序。
set others-p15=7z.dll缺失！请重新下载完整程序。
set others-p16=chkconnect_syxz.bat缺失！请重新下载完整程序。
set others-p17=viqoo_config.bat缺失！请重新下载完整程序。

set others-p18=检查电脑系统能否执行MSG指令...

set others-p19=你的电脑系统不能执行MSG指令，这将导致你无法收到程序的部分通知，比如升级提示等。但你仍然可以使用工具箱。按任意键继续。


set others-p20=加载配置...



set others-p21=【永久免费】维酷刷机工具箱& set others-p21.1=by_酷安@某贼

set others-p22=启动后台检查更新...




::START



set start-p1=                   维酷刷机工具箱 by 酷安@某贼



set start-p2=    工具箱开源免费，禁止商用，禁止未经许可的二改、打包、加密。

set start-p3=              反馈问题请使用文件目录里的“反馈.bat”



set start-p4=建议先选择型号以获得最佳体验（不选型号不影响解锁功能）。
set start-p5=如果你尚未安装刷机驱动，请先选择“更多资源”功能安装驱动。


set start-p6=解锁BL锁& set start-p7=Root系统& set start-p8=取消Root/恢复官方Boot

set start-p10=为什么不提供上锁BL锁功能？


set start-p9=查看云端Boot库& set start-p9.1=修补Boot（制作Magisk-Boot）


set start-p11=原创首发：刷入带有Root权限的官方Recovery（实验性功能）


set start-p12=更多资源& set start-p13=刷入自定义分区& set start-p14=关闭AVB2.0校验(停止使用)


set start-p15=检查更新& set start-p16=选择/更改型号& set start-p17=清理使用记录

set start-p17.1=常见问题解答


set start-p18=关于我们（交流群，开发者列表）





set start-p19=输入序号按Enter继续：





set start-p20=上锁BL锁后，只有纯官方系统能够启动，且无法再通过Fastboot刷入分区。所以在已经解锁和修改系统（比如Root）的情况下上锁等于自杀。由于很难保证在上锁之前系统是完全官方状态，所以为了安全，不会提供上锁功能。按任意键返回主菜单。



set start-p21=经群友反馈，使用此功能存在无法开机的风险，故不提供。按任意键返回。










::PATCHBOOT



set patchboot-p1=                          制作Magisk-Boot




set patchboot-p2=此功能目前只能在64位电脑上使用。按任意键返回。
set patchboot-p3= 使用boot.img在电脑端修补打包Magisk-Boot。
set patchboot-p4= 相关软件，脚本及二进制文件由affggh开发，已授权使用。
set patchboot-p5= 开源地址：


set patchboot-p6=使用 MagiskAlpha-25101 版本修补Boot（默认）
set patchboot-p7=自定义修补方案
set patchboot-p8=回主菜单


set patchboot-p9=输入数字按Enter继续：



set patchboot-p10=请将boot.img拖入窗口中，然后按Enter继续：

set patchboot-p11=所选文件不存在！按任意键重试。
set patchboot-p11.1=正在准备修补，请稍候...









set patchboot-p12=文件未能复制到指定位置！建议所选文件路径中不要出现空格等特殊字符。按任意键返回。



set patchboot-p13=修补失败！按任意键返回。




set patchboot-p14=修补完成。输出位置为源文件所在文件夹。你可以使用“刷入自定义分区”-“刷入Boot”功能测试你修补的Boot。按任意键回主菜单。




set patchboot-p15=你尚未下载MagiskPatcher组件。按Enter立即下载，输入1按Enter回主菜单


set patchboot-p15.1=正在下载，请稍候...


::set patchboot-p16=下载失败！按任意键按返回。

set patchboot-p16=下载失败！按任意键按返回。

set patchboot-p16.1=下载失败（找不到云端文件）！按任意键按返回。
set patchboot-p17=下载完成，正在解压...


set patchboot-p18=解压失败！按任意键返回。



::ROOTREC







set rootrec-p1=             原创首发：刷入带有Root权限的官方Recovery
set rootrec-p2=                                                   by 酷安@搞机吖



set rootrec-p3= 解锁BL后，在Fastboot模式刷入修改过的，开启 adb root 的官方        Recovery，然后使用adb指令执行你想执行的操作。
set rootrec-p4= 此功能需要解锁BL使用{0F}。
set rootrec-p5= 此功能并非Root系统& set rootrec-p6=，此功能只是开启Recovery的Root权限。开启后你可  以在官方恢复模式连接电脑，执行adb指令。

set rootrec-p7= 目前已适配Recovery较少，如需适配请提取你当前系统的Recovery分区    （用搞机助手手机版提取或从系统包里找），把img文件复制到工具箱的   bin\log文件夹中，然后使用反馈功能发送给开发者。注意一定要写明机   型和系统版本号。





set rootrec-p10=返回主菜单

set rootrec-p11=输入序号按Enter继续：





set rootrec-p12=正在联网获取& set rootrec-p13=版本的Root-Recovery...




set rootrec-p14=下载已停止，按任意键返回主菜单。


set rootrec-p15=下载失败！按任意键返回。

set rootrec-p16=云端库未收录该版本Recovery！按任意键返回。
set rootrec-p17=解压中...







set rootrec-p18=解压出错！按任意键返回。


set rootrec-p19=请将手机关机连接电脑，长按电源键和音量加进入Fastboot模式。
set rootrec-p20=检查Fastboot连接...


set rootrec-p21=设备已连接！
set rootrec-p22=检查设备连接失败！
set rootrec-p23=有多个设备连接！请断开其他设备！
set rootrec-p24=未知错误！
set rootrec-p25=检查解锁状态...


set rootrec-p26=Fastboot读取设备信息失败！请检查连接或进群反馈。

set rootrec-p27=你的设备尚未解锁！请先解锁再使用此功能。按任意键回主菜单。
set rootrec-p28=刷入Recovery...


set rootrec-p29=刷入失败！按任意键返回。
set rootrec-p30=刷入成功！
set rootrec-p31=重启Fastboot刷新状态...


set rootrec-p32=请手动重启到Recovery(通过Fastboot的重启选项或长按电源键和音量减)
set rootrec-p33=检查Recovery连接...


set rootrec-p34=设备已连接！
set rootrec-p35=检查设备连接失败！
set rootrec-p36=有多个设备连接！请断开其他设备！
set rootrec-p37=未知错误！
set rootrec-p38=检验结果



set rootrec-p39=成功开启Root！按任意键返回主菜单。

set rootrec-p40=未能开启Root！请使用反馈功能告知开发者。按任意键返回主菜单。

set rootrec-p41=指令未执行！请使用反馈功能告知开发者。按任意键返回主菜单。
set rootrec-p42=未知错误！请使用反馈功能告知开发者。按任意键返回主菜单。








::ABOUT



set about-p1=                             关于我们




set about-p2= 【工具箱简介】


set about-p3= viQOO工具箱是一款由 某贼 编写的，用于vivo和iQOO机型一键解锁Root的 工具。内置四种解锁方案，拥有云端Boot库，输入版本号即可在线下载刷  入。第一版发布于2022.5.26。
set about-p4= 注：解锁方案均来源于网络公开资源。

set about-p5= 【参与、帮助开发】




set about-p6= 【光荣的测试成员】




set about-p7= 简介：& set about-p8=viQOO从V2.0.1版本开始加入了测试版Boot通道，未经实测检验的   Boot将暂存在测试版通道中，经过测试可以使用才会转入稳定版通道。这  中间参与测试的机油会作为光荣的测试成员被记录在这里。
set about-p9= 如何成为测试成员：& set about-p10=1.刷入测试版通道的Boot 2.开机并检验Root权限是否 正常 3.无论成功与否，将结果告知开发者(可以加群或使用反馈功能)

set about-p11= 【刷机交流反馈云湖群】


set about-p11.1=云湖ID

set about-p11.2= 注：云湖APP下载链接：www.yhchat.com
set about-p11.3= 由于QQ群不堪重负，今后我们将使用云湖APP交流刷机。云湖是一款新兴的 聊天软件，体积小，不限制群人数，全平台支持。目前软件处于内测阶段  ，正在逐步完善。


set about-p12= 让酷客酷起来。按任意键返回主菜单。



::FLASHIMG



set flashimg-p1=                          刷入自定义分区




set flashimg-p2=刷入Boot

set flashimg-p3=刷入Recovery

set flashimg-p4=刷入System

set flashimg-p5=刷入Vendor

set flashimg-p6=刷入其他

set flashimg-p7=返回主菜单（默认）




set flashimg-p8=输入序号按Enter继续：












set flashimg-p9=请输入你想刷入的分区名（必须准确）：





set flashimg-p10=请将分区img文件拖到此处，然后按Enter继续：


set flashimg-p11=你选择的不是img文件！

set flashimg-p12=请长按电源键和音量加，将手机进入Fastboot模式。
set flashimg-p13=检查Fastboot连接...


set flashimg-p14=设备已连接！
set flashimg-p15=检查设备连接失败！
set flashimg-p16=有多个设备连接！请断开其他设备！
set flashimg-p17=未知错误！



set flashimg-p18=刷入完成，请自行查验是否成功。按任意键回主菜单。















::TOOLS



set tools-p1=                             更多资源




set tools-p2=注：手机APP均为手机扫码下载。


set tools-p3=MagiskAlpha-24314 APP

set tools-p3.1=MagiskAlpha-25101 APP

set tools-p4=Magisk24.3 APP

set tools-p5=Magisk23.0suu专版（X9使用）

set tools-p6=校正指纹APP

set tools-p7=安装电脑刷机驱动

set tools-p8=AFTool 5.1.28、5.9.50（vivo售后刷机工具）

set tools-p9=vivo系统降级工具

set tools-p10=系统包（使用反馈功能留言你想要的9008包）

set tools-p11=回主菜单




set tools-p12=输入序号按Enter继续：














::ROOT










set root-p1=                             Root系统
set root-p2=                             移除Root




set root-p3= 请先选择型号再使用此功能。按任意键返回主菜单。
set root-p4= 刷入面具修补过的Boot.img以Root系统。
set root-p5= 刷入官方原版Boot.img以移除Root。

set root-p6= 你选择的型号为：

set root-p7= 当前为稳定版通道。如果找不到资源可以尝试更换测试版通道。
set root-p8= 当前为& set root-p9=测试版& set root-p10=通道。测试版不保证可用，甚至可能导致无法开机。


set root-p11= 请准确输入你的系统版本号，比如2.8.4。
set root-p12= 输入A更换Boot通道
set root-p13= 输入B返回主菜单



set root-p14=版本号：







set root-p15=正在联网获取& set root-p16=版本的Boot...




set root-p17=下载已停止，按任意键返回主菜单。


set root-p18=下载失败！按任意键返回。

set root-p19=云端库未收录该版本Boot！按任意键返回。
set root-p20=下载完毕，解压中...







set root-p21=解压出错！按任意键返回。



set root-p22=面具版本：
::ROOT-1

set root-p23=请将手机关机连接电脑，长按电源键和音量加进入Fastboot模式。
set root-p24=正在检查设备连接...


set root-p25=设备已连接！
set root-p26=检查设备连接失败！
set root-p27=有多个设备连接！请断开其他设备！
set root-p28=未知错误！
set root-p29=检查解锁状态...


set root-p30=Fastboot读取设备信息失败！请检查连接或进群反馈。

set root-p31=你的设备尚未解锁！请先解锁再使用此功能。按任意键回主菜单。
set root-p32=AB分区识别（实验性）




set root-p33=刷入Boot...



set root-p34=刷入失败！按任意键返回。
set root-p35=刷入成功！获取Root权限请开机后选择主菜单“更多资源”功能，扫码下载安装Alpha或普通版本Magisk APP。如果你使用的是测试版通道，无论成功与否，请务必使用反馈功能将结果告知开发者。按任意键返回主菜单。
set root-p36=刷入成功！开机后自行卸载Magisk软件即可彻底移除Root。按任意键返回主菜单。












::ROOT-X9
set root-x9-p1=vivoX9只有临时Root，重启即失效，无需此功能。



set root-x9-p2=                             Root系统





set root-x9-p3=缺少资源，正在下载...


::set root-x9-p4=下载失败！按任意键重试...

set root-x9-p4=下载失败！按任意键重试...

set root-x9-p4.1=下载失败（找不到云端文件）！按任意键重试...
set root-x9-p5=下载完成，正在解压...


set root-x9-p6=解压失败！按任意键重试...


set root-x9-p7= vivoX9目前只能临时启动Boot来Root或临时启动TWRP，重启即失效。

set root-x9-p8= TWRP只能启动，无读写权限，无法挂载存储。


set root-x9-p9= 1.临时启动 boot.img by TWRP小白2008

set root-x9-p10= 2.临时启动 boot.img by 秋水105

set root-x9-p11= 3.临时启动 TWRP Recovery by 秋水105

set root-x9-p12=回主菜单



set root-x9-p13=输入序号按Enter继续：



set root-x9-p14=请长按电源键和音量加，进入Fastboot模式。

set root-x9-p15=正在等待设备连接(Fastboot)...


set root-x9-p16=设备已连接！
set root-x9-p17=  检查设备连接失败！
set root-x9-p18=  有多个设备连接！请断开其他设备！
set root-x9-p19=  未知错误！





set root-x9-p20=完成。获取Root权限请开机后选择主菜单“更多资源”功能，扫码下载安装suu版本Magisk APP。
set root-x9-p21=adb shell获取Root权限的指令是：adb shell magisk suu
set root-x9-p22=临时启动重启失效，如果重启系统则会恢复未刷入的状态。
set root-x9-p23=按任意键返回主菜单。




::CHOOSEDEV







set choosedev-p1=                          选择/更改型号




set choosedev-p2=正在联网获取支持的型号列表...

set choosedev-p3=下载失败！按任意键返回主菜单。

set choosedev-p4=找不到云端文件！请使用反馈功能告知开发者。按任意键返回主菜单。



set choosedev-p5=                          选择/更改型号




set choosedev-p6= 注：不同型号使用的资源不同，请务必认真选择。
set choosedev-p6.1= 解锁与选择型号没有直接关系，不选择型号也可以去解锁。
set choosedev-p7= iQOONeo，Neo3，Neo5无法解锁。部分机型解锁后不能Root。


set choosedev-p8=序号           名称            代号  解锁方案


set choosedev-p9=保持现状& set choosedev-p10=并返回主菜单(默认)




set choosedev-p11=输入数字按Enter继续：



set choosedev-p12=此选项不存在，请重新输入。选择机型输入纯数字即可。





::UNLOCK



set unlock-p1=                             解锁BL锁




set unlock-p2=确定要解锁BL锁么？解锁刷机可能造成以下影响：

set unlock-p3=手机数据被清空
set unlock-p4=手机系统损坏无法开机
set unlock-p5=基带丢失
set unlock-p6=失去保修
set unlock-p7=光学指纹失效（可以售后校准恢复）
set unlock-p8=指纹支付不可用（好像可以通过模块修复）

set unlock-p9=自愿承担以上风险，请输入1按Enter继续，否则直接按Enter返回主菜单




set unlock-p10=解锁BL锁会清空手机内& set unlock-p11=所有数据
set unlock-p12=请确认数据已自行备份到手机之外！
set unlock-p13=请退出其他手机管理和刷机软件，然后按任意键开始...



set unlock-p13.1=请选择解锁方案：
set unlock-p14=新版高通xda方案：& set unlock-p15=如果你的设备是高通处理器且是近两年的新机，可     以尝试此方案。
set unlock-p16=MTKClient强解：& set unlock-p17=如果你的设备是联发科处理器，可以尝试此方案。
set unlock-p18=老机型旧版指令解锁：& set unlock-p19=如果你的设备是六七年前的老机器（官方系统安    卓5或5.1），可以尝试此方案。
set unlock-p20=9008修改分区解锁：& set unlock-p21=此方案已知适用于vivoX7系列，X9系列，Y66i。
set unlock-p22=输入序号按Enter键继续：









set unlock-p23=检查ADB能否运行


set unlock-p24=ADB无法正常运行！
set unlock-p25=检查Fastboot能否运行


set unlock-p26=Fastboot无法正常运行！
set unlock-p27=请按以下步骤操作：

set unlock-p28=请将手机开机并连接电脑，启用开发者选项
set unlock-p29=打开【OEM解锁】与【USB调试】开关
set unlock-p30=如果出现USB调试提示，请勾选一律允许并确认。
set unlock-p31=完成后按任意键继续...

set unlock-p32=检查设备连接
set unlock-p33=正在等待设备连接(系统)...


set unlock-p34=设备已连接！
set unlock-p35=检查设备连接失败！
set unlock-p36=有多个设备连接！请断开其他设备！
set unlock-p37=未知错误！

set unlock-p38=读取设备信息


set unlock-p39=型号：


set unlock-p40=安卓版本：



set unlock-p41=系统版本：

set unlock-p42=重启到Fastboot

set unlock-p43=重启设备失败！请关机后长按电源键和音量加，手动进入Fastboot。
set unlock-p44=检查设备连接
set unlock-p45=若设备管理器有设备但连不上，请使用反馈功能告知开发者。
set unlock-p46=正在等待设备连接(Fastboot)...


set unlock-p47=设备已连接！
set unlock-p48=检查设备连接失败！
set unlock-p49=有多个设备连接！请断开其他设备！
set unlock-p50=未知错误！

set unlock-p51=检查解锁状态


set unlock-p52=Fastboot读取设备信息失败（无信息）！按任意键继续...

set unlock-p53=你的设备已经解锁，无需重复解锁。按任意键回主菜单。

set unlock-p54=Fastboot读取解锁状态失败。

set unlock-p55=你的设备已经解锁，无需重复解锁。按任意键回主菜单。







set unlock-p56=不支持解锁！
set unlock-p57=找不到该机型信息！请使用反馈功能告知开发者。

::UNLOCK-DEVINFO
::set unlock-devinfo-p1=vivoX9安卓8不支持，请降级安卓7或以下版本。
set unlock-devinfo-p2=检查WMIC能否运行


set unlock-devinfo-p3=你的电脑系统不能执行WMIC指令！无法自动识别端口。
set unlock-devinfo-p4=请选择机型
set unlock-devinfo-p5=注意：以下机型除X9外，均未经过测试，不保证方案可用！







set unlock-devinfo-p5.1=自定义引导文件

set unlock-devinfo-p6=输入数字按Enter继续：







set unlock-devinfo-p6.1=请将引导文件拖入窗口中，然后按Enter继续：
set unlock-devinfo-p6.1=请将引导文件拖入窗口中，然后按Enter继续：
set unlock-devinfo-p7=选择错误！请重新选择。

set unlock-devinfo-p10=请按提示操作
set unlock-devinfo-p11=请保持连接电脑，同时按住手机音量加、减，然后按任意键继续。

set unlock-devinfo-p12=重启手机

set unlock-devinfo-p13=等待9008端口
set unlock-devinfo-p14=请输入9008端口号


set unlock-devinfo-p15=你的电脑系统无法执行WMIC指令，需要手动输入端口号。
set unlock-devinfo-p16=请展开设备管理器“端口”一项，找到Qualcomm 9008端口，
set unlock-devinfo-p17=然后输入COM后面的数字，比如30。请务必准确输入。


set unlock-devinfo-p18=端口号：












set unlock-devinfo-p19=已进入9008

set unlock-devinfo-p20=提取devinfo.img

set unlock-devinfo-p20.1=提取失败！请先将手机进入Fastboot模式，然后关机，然后按任意键重试。
set unlock-devinfo-p21=备份devinfo.img



set unlock-devinfo-p22=处理devinfo.img


set unlock-devinfo-p23=刷入devinfo.img

set unlock-devinfo-p24=请手动按键
set unlock-devinfo-p25=请长按电源键和音量加，进入Fastboot模式。
set unlock-devinfo-p26=正在等待设备连接(Fastboot)...


set unlock-devinfo-p27=设备已连接！
set unlock-devinfo-p28=检查设备连接失败！
set unlock-devinfo-p29=有多个设备连接！请断开其他设备！
set unlock-devinfo-p30=未知错误！
set unlock-devinfo-p31=检查解锁状态（实验性）



set unlock-devinfo-p32=检查失败！按任意键继续（清除数据）...

set unlock-devinfo-p32.1=解锁失败！按任意键返回主菜单。
set unlock-devinfo-p33=解锁状态未知！按任意键继续（清除数据）...

::set unlock-devinfo-p34=清除数据


set unlock-devinfo-p35=恭喜，解锁成功！请通过反馈告知开发者。


set unlock-devinfo-p36=由于清除数据，首次开机时间会较长，请耐心等待5分钟左右。
set unlock-devinfo-p37=开机后提示系统数据空间损坏属正常现象。
set unlock-devinfo-p38=如需Root请回主菜单选择Root功能。
set unlock-devinfo-p39=请勿点击恢复模式中“校验系统”功能，否则会丢失所有数据。
set unlock-devinfo-p40=工具箱由某贼制作，永久免费，禁止商用。


set unlock-devinfo-p34=清除数据

set unlock-devinfo-p41=完成，按任意键返回主菜单。



::UNLOCK-NEWCMD
set unlock-newcmd-p1=解压Vendor
set unlock-newcmd-p2=正在解压Vendor，请稍候...

set unlock-newcmd-p3=解压Vendor失败！按任意键重试...
set unlock-newcmd-p4=刷入Vendor
set unlock-newcmd-p5=正在刷入Vendor，这需要一段时间，请稍候...



set unlock-newcmd-p6=未能刷入。但这不一定影响解锁。

set unlock-newcmd-p7=执行解锁指令




set unlock-newcmd-p8=解锁失败！此方案不适合你的设备或系统版本过高。按任意键回主菜单。
set unlock-newcmd-p9=解锁失败！按任意键重试...


set unlock-newcmd-p10=恭喜，解锁成功！

set unlock-newcmd-p11=稍后开机会提示& set unlock-newcmd-p12=清除数据& set unlock-newcmd-p13=，按提示清除即可。清除后首次开机时间较长。
set unlock-newcmd-p14=开机后提示系统数据空间损坏属正常现象。
set unlock-newcmd-p15=如需Root请回主菜单选择Root功能。
set unlock-newcmd-p16=请勿点击恢复模式中& set unlock-newcmd-p17=校验系统& set unlock-newcmd-p18=功能，否则会丢失所有数据。
set unlock-newcmd-p19=请勿降压超频& set unlock-newcmd-p20=，否则可能导致系统无法正常使用。
set unlock-newcmd-p21=工具箱由某贼制作，永久免费，禁止商用。按任意键返回主菜单。



::UNLOCK-MTK


set unlock-mtk-p1=下载MTKClient
set unlock-mtk-p2=正在下载MTKClient，请稍候...


::set unlock-mtk-p3=下载失败！按任意键重试...

set unlock-mtk-p3=下载失败！按任意键重试...

set unlock-mtk-p3.1=下载失败（找不到云端文件）！按任意键重试...
set unlock-mtk-p4=解压MTKClient
set unlock-mtk-p5=正在解压MTKClient，请稍候...

set unlock-mtk-p6=解压失败！按任意键重试...


set unlock-mtk-p7=请手动按键
set unlock-mtk-p8=请同时按住音量加减，保持连接，然后按任意键继续...

set unlock-mtk-p9=启动MTKClient

set unlock-mtk-p10=四秒后可以松开按键。

set unlock-mtk-p11=重启手机

set unlock-mtk-p12=注意MTKClient提示即可。按任意键返回主菜单。



::UNLOCK-OLDCMD
set unlock-oldcmd-p1=执行解锁指令


set unlock-oldcmd-p2=解锁失败！按任意键重试...

set unlock-oldcmd-p3=恭喜，解锁成功！


set unlock-oldcmd-p4=稍后开机可能会提示清除数据，按提示清除即可。清除后首次开机时间较长。
set unlock-oldcmd-p5=工具箱由某贼制作，永久免费，禁止商用。按任意键返回主菜单。




































goto :eof