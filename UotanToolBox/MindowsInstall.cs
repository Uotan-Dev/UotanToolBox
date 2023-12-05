using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace UotanToolBox
{
    public partial class MindowsInstall : Form
    {
        public MindowsInstall()
        {
            InitializeComponent();
        }
        public Process process = null;

        //调用程序并实时返回输出信息到TextBox
        public void Diskpart(string shell)//diakpart实时输出
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            process = new Process();
            process.StartInfo.FileName = "diskpart.exe";
            process.StartInfo.WorkingDirectory = ".";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();
            process.StandardInput.WriteLine(shell);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }

        public void Fastboot(string fb)//Fastboot实时输出
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void ADB(string fb)//ADB实时输出
        {
            string cmd = @"bin\adb\adb.exe";
            ProcessStartInfo adb = null;
            adb = new ProcessStartInfo(cmd, fb);
            adb.CreateNoWindow = true;
            adb.UseShellExecute = false;
            adb.RedirectStandardOutput = true;
            adb.RedirectStandardError = true;
            Process f = Process.Start(adb);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(this.shellshow.Text);
                this.shellshow.Text = sb.AppendLine(outLine.Data).ToString();
                this.shellshow.SelectionStart = this.shellshow.Text.Length;
                this.shellshow.ScrollToCaret();
            }
        }

        public void Dism(string fb)
        {
            string cmd = @"bin\dism\dism.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void DriverUpdater(string shell)
        {
            string cmd = @"bin\DriverUpdater\DriverUpdater.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, shell);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void Bcdboot(string fb)
        {
            string cmd = @"bin\bcd\bcdboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void Bcdedit(string fb)
        {
            string cmd = @"bin\bcd\bcdedit.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        //实时输出到此结束

        //一些全局变量
        string output;//输出


        //一些只能写在这的函数
        public void WriteShow()//将输出框的内容写入txt
        {
            output = shellshow.Text;
            Mindows.Write(@"log\disk.txt", output);
        }

        public int Findsda()//查找Sda
        {
            Diskpart("list disk \r\nexit");
            WriteShow();
            shellshow.Text = "";
            char[] charSeparators = new char[] { ' ' };
            string[] parts = output.Split('\n');
            if (parts.Length <= 4)
            {
                return 0;
            }
            else
            {
                int i = parts.Length - 4;
                string[] lastdisk = parts[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); ;
                string disknum = Regex.Replace(lastdisk[1], @"[^0-9]+", "");
                int num = int.Parse(disknum);
                int totaldisk = num + 1;
                int a;
                for (a = 0; a < totaldisk; a++)
                {
                    string shell = String.Format("select disk {0} \r\ndetail disk \r\nexit", a);
                    Diskpart(shell);
                    WriteShow();
                    int issda = output.IndexOf("sda");
                    if (issda != -1)
                    {
                        break;
                    }
                    shellshow.Text = "";
                }
                if (a == totaldisk)
                {
                    return 0;
                }
                else
                {
                    shellshow.Text = "";
                    return a;
                }
            }
        }

        public int FindLinux()
        {
            Diskpart("list disk\r\nexit");
            WriteShow();
            shellshow.Text = "";
            char[] charSeparators = new char[] { ' ' };
            string[] parts = output.Split('\n');
            if (parts.Length <= 4)
            {
                return 0;
            }
            else
            {
                int i = parts.Length - 4;
                string[] lastdisk = parts[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); ;
                string disknum = Regex.Replace(lastdisk[1], @"[^0-9]+", "");
                int num = int.Parse(disknum);
                int totaldisk = num + 1;
                int a;
                for (a = 0; a < totaldisk; a++)
                {
                    string shell = String.Format("select disk {0} \r\ndetail disk \r\nexit", a);
                    Diskpart(shell);
                    WriteShow();
                    int issda = output.IndexOf("Linux");
                    if (issda != -1)
                    {
                        break;
                    }
                    shellshow.Text = "";
                }
                if (a == totaldisk)
                {
                    return 0;
                }
                else
                {
                    shellshow.Text = "";
                    return a;
                }
            }
        }

        public string Setletter(int Disknum, int Partnum)//分配磁盘符
        {
            string letter = "C";
            int i;
            for (i = 65; i <= 90; i++)
            {
                char c = (char)i;
                letter = c.ToString();
                string shell = String.Format("select disk {0} \r\nselect part {1} \r\nassign letter={2} \r\nexit", Disknum, Partnum, letter);
                Diskpart(shell);
                WriteShow();
                int succ1 = output.IndexOf("成功地分配了驱动器号或装载点");
                int succ2 = output.IndexOf("successfully assigned the drive letter or mount point");
                shellshow.Text = "";
                if (succ1 != -1 || succ2 != -1)
                {
                    break;
                }
            }
            if (i == 91)
            {
                letter = "C";
            }
            return letter;
        }

        public bool Formatdisk(int Disknum, int Partnum, string Filesystem)//格式化磁盘
        {
            string shell = String.Format("select disk {0} \r\nselect part {1} \r\nformat quick fs={2} \r\nexit", Disknum, Partnum, Filesystem);
            Diskpart(shell);
            WriteShow();
            shellshow.Text = "";
            if (output.IndexOf("成功") != -1 || output.IndexOf("successfully") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Setid(bool Id, int Disknum, int Partnum)
        {
            string id;
            if (Id)
            {
                id = "ebd0a0a2-b9e5-4433-87c0-68b6b72699c7";//主要
            }
            else
            {
                id = "c12a7328-f81f-11d2-ba4b-00a0c93ec93b";//系统
            }
            string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Disknum);
            Diskpart(shell);
            WriteShow();
            shell = String.Format("select disk {0} \r\nselect part {1} \r\nset id='{2}' override\r\nexit", Disknum, Partnum, id);
            Diskpart(shell);
            WriteShow();
            if (output.IndexOf("成功") != -1 || output.IndexOf("successfully") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //定义设备状况
        string shell = "";//ADB命令
        string part = "";//分区名称
        string sdxx = "";//sdx磁盘
        string partnum = "";//分区序号
        int succ = 0;//一旦等于1即为分区出错！
        Thread t1;//窗体线程
        string exepath = System.IO.Directory.GetCurrentDirectory();//获取工具运行路径

        private void MindowsInstall_Shown(object sender, EventArgs e)
        {
            Mindows.Disdevice();//区分机型

            //程序开始
            t1 = new Thread(delegate ()
            {
                if (Global.devcfg)
                {
                    ShowText.Text = "正在刷入Devcfg";
                    Fastboot(@"flash devcfg_ab data\mindows\img\devcfg.img");
                }
                if (Global.vbmeta)
                {
                    ShowText.Text = "正在关闭AVB校验";
                    Fastboot(@"flash vbmeta bin/img/vbmeta.img");
                }
                if (Global.bootrec)
                {
                    string active = ADBHelper.Fastboot("getvar current-slot");
                    if (active.IndexOf("current-slot: b") != -1)
                    {
                        Global.boot = "boot_b";
                    }
                    ShowText.Text = "正在临时启动Recovery";
                    Fastboot(@"boot data\mindows\img\recovery.img");
                }
                else
                {
                    ShowText.Text = "正在刷入并启动Recovery";
                    Fastboot(@"flash recovery data\mindows\img\recovery.img");
                    Fastboot("oem reboot-recovery");
                }
                for (int i; ;)
                {
                    i = ADBHelper.ADB("devices").IndexOf("recovery");
                    if (i != -1)
                        break;
                }
                ADBHelper.ADB("shell twrp unmount data");
                ShowText.Text = "正在备份重要分区";
                Mindows.GetPartTable();
                part = Global.boot;
                Mindows.Backup(part);
                part = "fsc";
                Mindows.Backup(part);
                part = "fsg";
                Mindows.Backup(part);
                part = "modem";
                Mindows.Backup(part);
                part = "modemst1";
                Mindows.Backup(part);
                part = "modemst2";
                Mindows.Backup(part);
                ShowText.Text = "正在启动parted并备份分区表";
                ADBHelper.ADB("push bin/linux/parted /tmp/");
                ADBHelper.ADB("shell chmod +x /tmp/parted");
                string parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                shellshow.Text = parttable;
                Mindows.Write("backup/parts.txt", parttable);
                if (Mindows.Isdatalast(parttable))
                {
                    if (Global.removelimit)
                    {
                        ShowText.Text = "正在解除分区数量限制";
                        ADBHelper.ADB("push bin/linux/sgdisk /tmp/");
                        ADBHelper.ADB("shell chmod +x /tmp/sgdisk");
                        string limit = ADBHelper.ADB("shell /tmp/sgdisk --resize-table=128 /dev/block/sda");
                        if (limit.IndexOf ("completed successfully") == -1)
                        {
                            succ = 1;//该值一旦等于1即为出错
                        }
                        else
                        {
                            if (Global.bootrec)
                            {
                                ADBHelper.ADB("reboot bootloader");
                                for (; ; )
                                {
                                    if (ADBHelper.Fastboot("devices") != "")
                                        break;
                                }
                                Fastboot(@"boot data\mindows\img\recovery.img");
                            }
                            else
                            {
                                ADBHelper.ADB("reboot recovery");
                            }
                            for (int i; ;)
                            {
                                i = ADBHelper.ADB("devices").IndexOf("recovery");
                                if (i != -1)
                                    break;
                            }
                        }
                    }
                    if (succ == 0)
                    {
                        ADBHelper.ADB("shell twrp unmount data");
                        part = "userdata";
                        int datano = Mindows.Onlynum(Mindows.Partno(parttable, part));
                        Global.datastartunit = Mindows.Unit(Mindows.Partstart(parttable, part));
                        Global.dataendunit = Mindows.Unit(Mindows.Partend(parttable, part));
                        Global.datasizeunit = Mindows.Unit(Mindows.Partsize(parttable, part));
                        Global.datastart = Mindows.Onlynum(Mindows.Partstart(parttable, part));
                        string datastart2 = Mindows.Partstart(parttable, part);
                        Global.dataend = Mindows.Onlynum(Mindows.Partend(parttable, part));
                        Global.datasize = Mindows.Onlynum(Mindows.Partsize(parttable, part));
                        ShowText.Text = "正在为Windows分区";
                        Form setwinpart = new SetWinPart();
                        setwinpart.ShowDialog();
                        if (Global.winsize != 0)
                        {
                            ADBHelper.ADB("shell twrp unmount data");
                            ADBHelper.ADB("push bin/linux/parted /tmp/");
                            ADBHelper.ADB("shell chmod +x /tmp/parted");
                            shell = String.Format("shell /tmp/parted /dev/block/sda rm {0}", datano);
                            ADBHelper.ADB(shell);
                            int newdataend = Global.dataend - Global.winsize - Global.sharepartsize;
                            shell = String.Format("shell /tmp/parted /dev/block/sda mkpart userdata ext4 {0} {1}GB", datastart2, newdataend);
                            ADBHelper.ADB(shell);
                            int espstart = newdataend;
                            double espend = newdataend + 0.3;
                            shell = String.Format("shell /tmp/parted /dev/block/sda mkpart esp fat32 {0}GB {1}GB", espstart, espend);
                            ADBHelper.ADB(shell);
                            double winstart = espend;
                            int winend = Global.dataend - Global.sharepartsize;
                            shell = String.Format("shell /tmp/parted /dev/block/sda mkpart win ntfs {0}GB {1}GB", winstart, winend);
                            ADBHelper.ADB(shell);
                            if (Global.sharepartsize != 0 && Global.mksharepart)
                            {
                                int sharestar = winend;
                                int shareend = Global.dataend;
                                shell = String.Format("shell /tmp/parted /dev/block/sda mkpart sharedspace ext4 {0}GB {1}GB", sharestar, shareend);
                                ADBHelper.ADB(shell);
                            }
                            parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                            if (parttable.IndexOf("esp") != -1)
                            {
                                part = "esp";
                                int espno = Mindows.Onlynum(Mindows.Partno(parttable, part));
                                shell = String.Format("shell /tmp/parted /dev/block/sda set {0} esp on", espno);
                                ADBHelper.ADB(shell);
                            }
                            parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                            if (parttable.IndexOf("userdata") == -1 || parttable.IndexOf("win") == -1 || parttable.IndexOf("esp") == -1)
                            {
                                succ = 1;
                            }
                            shellshow.Text = parttable;
                            if (succ == 0)
                            {
                                ShowText.Text = "正在重启Recovery并格式化新建分区";
                                if (Global.bootrec)
                                {
                                    ADBHelper.ADB("reboot bootloader");
                                    for (; ; )
                                    {
                                        if (ADBHelper.Fastboot("devices") != "")
                                            break;
                                    }
                                    Fastboot(@"boot data\mindows\img\recovery.img");
                                }
                                else
                                {
                                    ADBHelper.ADB("reboot recovery");
                                }
                                for (int i; ;)
                                {
                                    i = ADBHelper.ADB("devices").IndexOf("recovery");
                                    if (i != -1)
                                        break;
                                }
                                ADBHelper.ADB("shell twrp unmount data");
                                Mindows.GetPartTable();
                                part = "esp";
                                sdxx = Mindows.FindDisk(part);
                                if (sdxx != "")
                                {
                                    partnum = Mindows.Partno(Mindows.FindPart(part), part);
                                    shell = String.Format("shell mkfs.fat -F32 -s1 /dev/block/{0}{1}", sdxx, partnum);
                                    ADB(shell);
                                }
                                ADBHelper.ADB("shell twrp unmount data");
                                part = "userdata";
                                sdxx = Mindows.FindDisk(part);
                                if (sdxx != "")
                                {
                                    partnum = Mindows.Partno(Mindows.FindPart(part), part);
                                    shell = String.Format("shell mke2fs -t ext4 /dev/block/{0}{1}", sdxx, partnum);
                                    ADB(shell);
                                }
                                if (Global.mksharepart)
                                {
                                    part = "sharedspace";
                                    sdxx = Mindows.FindDisk(part);
                                    if (sdxx != "")
                                    {
                                        partnum = Mindows.Partno(Mindows.FindPart(part), part);
                                        shell = String.Format("shell mkexfatfs -n exfat /dev/block/{0}{1}", sdxx, partnum);
                                        ADB(shell);
                                    }
                                }
                                ShowText.Text = "正在进入大容量模式";
                                tips.Text = "如等待较长时间无反应请将设备手动进入Fastboot模式！";
                                Thread.Sleep(2000);
                                ADBHelper.ADB("reboot bootloader");
                                for (; ; )
                                {
                                    if (ADBHelper.Fastboot("devices") != "")
                                        break;
                                }
                                Fastboot(@"flash boot data\mindows\img\automass.img");
                                Fastboot("reboot");
                                shellshow.Text = "";
                                ShowText.Text = "正在查找Sda磁盘";
                                tips.Text = "如系统提示是否格式化磁盘请一律选择否！";
                                int sdanum;
                                if (Global.issda)
                                {
                                    for (sdanum = 0; ;)
                                    {
                                        sdanum = Findsda();
                                        if (sdanum != 0)
                                            break;
                                    }
                                }
                                else
                                {
                                    for (sdanum = 0; ;)
                                    {
                                        sdanum = FindLinux();
                                        if (sdanum != 0)
                                            break;
                                    }
                                }
                                ShowText.Text = "正在查找Windows分区";
                                shell = String.Format("select disk {0} \r\nlist part \r\nexit", sdanum);
                                Diskpart(shell);
                                WriteShow();
                                bool diskstate = false;
                                if (output.IndexOf("系统") != -1 && output.IndexOf("主要") != -1)
                                {
                                    diskstate = true;
                                }
                                else if (output.IndexOf("System") != -1 && output.IndexOf("Primary") != -1)
                                {
                                    diskstate = true;
                                }
                                if (diskstate)
                                {
                                    bool setid = true;
                                    int winsum = Mindows.FindWin(output);
                                    int uefisum = Mindows.FindUEFI(output);
                                    shellshow.Text = "";
                                    ShowText.Text = "正在分配磁盘符";
                                    setid = Setid(true, sdanum, uefisum);
                                    string winletter = Setletter(sdanum, winsum);
                                    string uefiletter = Setletter(sdanum, uefisum);
                                    if (setid && winletter != "C" && uefiletter != "C")
                                    {
                                        ShowText.Text = "正在格式化Windows分区";
                                        Formatdisk(sdanum, winsum, "ntfs");
                                        Formatdisk(sdanum, uefisum, "fat32");
                                        ShowText.Text = "选择Windows镜像";
                                        Form choicewin = new ChoiceISO();
                                        choicewin.ShowDialog();
                                        if (Global.wimpath != "")
                                        {
                                            tips.Text = "";
                                            ShowText.Text = "正在安装Windows";
                                            string drvpath = String.Format(@"{0}\data\mindows\driver", exepath);
                                            shell = String.Format("/Apply-Image /ImageFile:\"{0}\" /index:1 /ApplyDir:{1}:\\", Global.wimpath, winletter);
                                            Dism(shell);
                                            output = shellshow.Text;
                                            Mindows.Write(@"log\dism.txt", output);
                                            if (Global.havedrv)
                                            {
                                                shellshow.Text = "";
                                                string filepath = String.Format(@"{0}\dulist.txt", drvpath);
                                                if (File.Exists(filepath))
                                                {
                                                    string shell = String.Format("-d {0} -r {1} -p {2}:\\", filepath, drvpath, winletter);
                                                    DriverUpdater(shell);
                                                    output = shellshow.Text;
                                                    Mindows.Write(@"log\driverupdate.txt", output);
                                                }
                                                else
                                                {
                                                    shell = String.Format("/Image:{0}:\\ /Add-Driver /Driver:\"{1}\" /Recurse /ForceUnsigned", winletter, drvpath);
                                                    Dism(shell);
                                                    output = shellshow.Text;
                                                    Mindows.Write(@"log\dism.txt", output);
                                                }
                                            }
                                            shellshow.Text = "";
                                            shell = String.Format(@"{0}:\Windows /s {1}: /f UEFI /l zh-cn", winletter, uefiletter);
                                            Bcdboot(shell);
                                            WriteShow();
                                            if (output.IndexOf("successfully") != -1)
                                            {
                                                shell = String.Format(@"/store {0}:\efi\microsoft\boot\bcd /set {{Default}} testsigning on", uefiletter);
                                                Bcdedit(shell);
                                                shell = String.Format(@"/store {0}:\efi\microsoft\boot\bcd /set {{Default}} nointegritychecks on", uefiletter);
                                                Bcdedit(shell);
                                                setid = Setid(false, sdanum, uefisum);
                                                ShowText.Text = "正在等待进入Fastboot";
                                                tips.Text = "长按电源键和音量减键将设备进入Fastoot模式";
                                                MessageBox.Show("Windows安装完成请将设备重启至Fastboot模式！", "提示！");
                                                for (; ; )
                                                {
                                                    if (ADBHelper.Fastboot("devices") != "")
                                                        break;
                                                }
                                                ShowText.Text = "正在刷入UEFI，并启动Windows";
                                                tips.Text = "";
                                                shell = String.Format(@"flash {0} data\mindows\img\uefi.img", Global.boot);
                                                Fastboot(shell);
                                                Fastboot("reboot");
                                                ShowText.Text = "完成！";
                                            }
                                            else
                                            {
                                                MessageBox.Show("启动引导建立失败！", "提示");
                                                ShowText.Text = "启动引导建立失败！";
                                                tips.Text = "请确定当前Windows版本允许释放目标版本Windows镜像";
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("未选择Windows镜像，程序结束", "提示");
                                            ShowText.Text = "未选择Windows镜像，程序结束";
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("分配磁盘符号或设置ID失败！", "提示");
                                        ShowText.Text = "分配磁盘符号或设置ID失败！";
                                        tips.Text = "请检查连接至电脑的磁盘数量并确保系统为Win10或更高版本";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("未能找到Windows或UEFI分区！", "提示");
                                    ShowText.Text = "未能找到Windows或UEFI分区！";
                                }
                            }
                            else
                            {
                                MessageBox.Show("分区出现错误！请检查分区！", "提示");
                                ShowText.Text = "分区出现错误！请检查分区！";
                            }
                        }
                        else
                        {
                            MessageBox.Show("您未设定Windows分区大小，程序结束", "提示");
                            ShowText.Text = "您未设定Windows分区大小，程序结束";
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("解除分区限制失败！", "提示");
                        ShowText.Text = "解除分区限制失败！";
                    }
                }
                else
                {
                    MessageBox.Show("Data分区不是最后一个分区，请检查分区表！", "提示");
                    ShowText.Text = "Data分区不是最后一个分区，请检查分区表！";
                    tips.Text = "如已刷过，请尝试恢复分区表后再试！";
                }
            });
            t1.SetApartmentState(ApartmentState.STA);
            t1.IsBackground = true;
            t1.Start();
        }

        private void MindowsInstall_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                t1.Abort();
            }
            catch
            {

            }
        }
    }
}
