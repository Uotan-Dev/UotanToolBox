# UotanToolBox-柚坛搞机工具箱

## 前言
1.本工具箱为本人爱好所作，从初学C#开发至今，因此在早期开发过程中写下了不少屎山后期也未进行优化，望大佬轻喷。<br/>
2.在近两年的开发中柚坛搞机工具箱从简单的Recovery刷入工具变成了几乎具备所有刷机功能的完整工具箱，这其中也少不了机圈中很多大佬的支持。<br/>
3.接下来该版本的工具箱也不再会有重大更新，仅会有Bug修复，未来工具箱将迁移到其他框架，WinForm在UI上的限制太多了，同时也不支持跨平台。<br/>

## 项目介绍
#### 集合了各种刷机需要使用的工具，并打造了一个GUI界面，方便玩机用户进行刷机，大多数功能为直接调用软件执行命令，部分功能进行了一定的特殊处理：<br/>
1.线刷ROM可以根据一个列有需要刷入镜像的分区的TXT文件进行连续刷入，TXT文件仅需一行写一个分区，将镜像文件（必须为.img）储存在TXT目录下的images文件夹中即可。flash_fastboot.txt填写非动态相关分区， flash_fastbootd.txt填写动态相关分区，同时使用可以自动重启至对应的模式，在刷入动态相关分区时，为确保刷入成功率，会自动删除用于备份的COW分区，也会自动删除非活动槽位的分区，同时还会将要刷入的分区删除重建再刷入需要刷入的镜像。<br/>
2.Mindows工具箱部分由某贼大佬的早期Mindows工具箱Bat版改造而来能够为部分手机快捷的刷入Windows系统，同时也涵盖了各种刷入Windows后相关的维护功能，由于功能太多，在此不详细介绍。<br/>
3.提取分区支持提取虚拟分区，即Super内的相关分区，虽然实现不难，但是似乎有些少见。<br/>
4.修改分区使用了表格的形式显示了分区，不算完美但因内置了命令能够快速读取还是比较实用的。<br/>
5.ADBHelper类，早期开发工具箱时在网络上完全搜索不到调用ADB相关程序的方法，根据调用CMD终端的方法进行了大量尝试，但依然遇到了种种问题，因此仿照当时学习的DBHelper类封装了ADBHelper类，最终完美的解决了各种问题。<br/>
6.Mindows类，开发Mindows工具箱时封装的各种方法，本意为Mindows工具箱部分所需方法的类文件，但后期由于偷懒将各种方法均写到了此处。<br/>
7.RegistryHelper类，网络搜索了解到的修改注册表相关的类文件，进行了一定的优化后应用到了Mindows工具箱中。<br/>
#### 下面为部分界面截图
![](https://github.com/Uotan-Dev/UotanToolBox/blob/main/PNG/UnlockBootloader.png)
![](https://github.com/Uotan-Dev/UotanToolBox/blob/main/PNG/Recovery&Reboot.png)
![](https://github.com/Uotan-Dev/UotanToolBox/blob/main/PNG/MindowsToolBox.png)
![](https://github.com/Uotan-Dev/UotanToolBox/blob/main/PNG/MakePart.png)

## 项目外部调用的程序
1.[7-Zip](https://7-zip.org/)<br/>
2.[ADB](https://developer.android.google.cn/studio/releases/platform-tools?hl=zh-cn)<br/>
3.DISM (小白之家)<br/>
4.[DriverUpdater](https://github.com/WOA-Project/DriverUpdater)<br/>
5.fh_loader.exe & QSaharaServer.exe<br/>
6.demsetup [mkfs.f2fs](https://git.kernel.org/pub/scm/linux/kernel/git/jaegeuk/f2fs-tools.git/) [mkntfs](https://github.com/AlbertGoma/ntfs-3g) [parted](https://git.savannah.gnu.org/cgit/parted.git) sgdsik<br/>
7.[NSudo](https://github.com/M2TeamArchived/NSudo)<br/>
8.QCNTool (终不似曾尘世闲游)<br/>
9.[curl](https://curl.se/windows/)<br/>
10.[Devcon](https://learn.microsoft.com/zh-cn/windows-hardware/drivers/devtest/devcon)<br/>
11.小米解锁工具（皓洋）<br/>
12.维酷工具箱（某贼）<br/>

## 特别鸣谢
1.[Renegade Project](https://github.com/edk2-porting/)<br/>
2.[woa-msmnile](https://github.com/woa-msmnile)<br/>
3.[WOA-Project](https://github.com/WOA-Project)<br/>
4.[Kancy Joe](https://github.com/sunflower2333)<br/>
5.[qaz6750 Lzy](https://github.com/qaz6750)<br/>
6.[赵紫菜](https://github.com/13584452567)<br/>
7.[MollySophia](https://github.com/MollySophia)<br/>
8.错过<br/>
9.闲游此生<br/>
10.某贼<br/>