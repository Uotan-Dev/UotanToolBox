using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UotanToolBox
{
    public partial class MindowsTools : Form
    {
        private static Mindows myObj;
        public MindowsTools()
        {
            InitializeComponent();
            myObj = new Mindows(this);
        }

        string exepath = System.IO.Directory.GetCurrentDirectory();//获取工具运行路径
        string output;//输出
        public Process process = null;
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

        public void Reg(string fb)
        {
            string cmd = @"reg.exe";
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

        public void DriverUpdater(string fb)
        {
            string cmd = @"bin\DriverUpdater\DriverUpdater.exe";
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
                id = "ebd0a0a2-b9e5-4433-87c0-68b6b72699c7";
            }
            else
            {
                id = "c12a7328-f81f-11d2-ba4b-00a0c93ec93b";
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

        public void Moreability()
        {
            if (Global.moreability == "formatesp")
            {
                warntext.Visible = false;
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                Mindows.Disdevice();//区分机型
                if (Global.sdanum == 0)
                {
                    ShowText.Text = "正在查找Sda磁盘";
                    if (Global.issda)
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = Findsda();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                    else
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = FindLinux();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                }
                ShowText.Text = "正在格式化UEFI分区";
                string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                Diskpart(shell);
                WriteShow();
                if (output.IndexOf("系统") != -1 || output.IndexOf("System") != -1)
                {
                    int uefisum = Mindows.FindUEFI(output);
                    shellshow.Text = "";
                    Setid(true, Global.sdanum, uefisum);
                    Formatdisk(Global.sdanum, uefisum, "fat32");
                    Setid(false, Global.sdanum, uefisum);
                    ShowText.Text = "完成！";
                    MessageBox.Show("格式化完成！", "提示！");
                }
                else
                {
                    MessageBox.Show("未找到UEFI分区！", "提示");
                }
            }
            else if (Global.moreability == "formatwin")
            {
                warntext.Visible = false;
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                Mindows.Disdevice();//区分机型
                if (Global.sdanum == 0)
                {
                    ShowText.Text = "正在查找Sda磁盘";
                    if (Global.issda)
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = Findsda();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                    else
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = FindLinux();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                }
                ShowText.Text = "正在格式化Windows分区";
                string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                Diskpart(shell);
                WriteShow();
                if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                {
                    int winsum = Mindows.FindWin(output);
                    shellshow.Text = "";
                    Formatdisk(Global.sdanum, winsum, "ntfs");
                    ShowText.Text = "完成！";
                    MessageBox.Show("格式化完成！", "提示！");
                }
                else
                {
                    MessageBox.Show("未找到Windows分区！", "提示");
                }
            }
            else if (Global.moreability == "fixesp")
            {
                warntext.Visible = false;
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                Mindows.Disdevice();//区分机型
                if (Global.sdanum == 0)
                {
                    ShowText.Text = "正在查找Sda磁盘";
                    if (Global.issda)
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = Findsda();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                    else
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = FindLinux();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                }
                ShowText.Text = "正在修复启动引导";
                if (Global.winletter == "C" || Global.uefisum == 0)
                {
                    string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
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
                        int winsum = Mindows.FindWin(output);
                        Global.uefisum = Mindows.FindUEFI(output);
                        shellshow.Text = "";
                        Global.winletter = Setletter(Global.sdanum, winsum);
                    }
                    else
                    {
                        MessageBox.Show("未找到Windows或UEFI分区！", "提示");
                    }
                }
                if (Global.winletter != "C" && Global.uefisum != 0)
                {
                    Setid(true, Global.sdanum, Global.uefisum);
                    string uefiletter = Setletter(Global.sdanum, Global.uefisum);
                    if (uefiletter != "C")
                    {
                        shellshow.Text = "";
                        string shell = String.Format(@"{0}:\Windows /s {1}: /f UEFI /l zh-cn", Global.winletter, uefiletter);
                        Bcdboot(shell);
                        WriteShow();
                        Setid(false, Global.sdanum, Global.uefisum);
                        if (output.IndexOf("successfully") != -1)
                        {
                            MessageBox.Show("修复成功！", "提示！");
                        }
                        else
                        {
                            MessageBox.Show("修复失败！", "提示！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                }
            }
            else if (Global.moreability == "disdsv")
            {
                warntext.Visible = false;
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                Mindows.Disdevice();//区分机型
                if (Global.sdanum == 0)
                {
                    ShowText.Text = "正在查找Sda磁盘";
                    if (Global.issda)
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = Findsda();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                    else
                    {
                        for (Global.sdanum = 0; ;)
                        {
                            Global.sdanum = FindLinux();
                            if (Global.sdanum != 0)
                                break;
                        }
                    }
                }
                ShowText.Text = "正在禁用驱动签名";
                if (Global.uefisum == 0)
                {
                    string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                    Diskpart(shell);
                    WriteShow();
                    if (output.IndexOf("系统") != -1 || output.IndexOf("System") != -1)
                    {
                        Global.uefisum = Mindows.FindUEFI(output);
                    }
                    else
                    {
                        MessageBox.Show("未找到UEFI分区！", "提示");
                    }
                }
                if (Global.uefisum != 0)
                {
                    Setid(true, Global.sdanum, Global.uefisum);
                    string uefiletter = Setletter(Global.sdanum, Global.uefisum);
                    if (uefiletter != "C")
                    {
                        string shell = String.Format(@"/store {0}:\efi\microsoft\boot\bcd /set {{Default}} testsigning on", uefiletter);
                        Bcdedit(shell);
                        shell = String.Format(@"/store {0}:\efi\microsoft\boot\bcd /set {{Default}} nointegritychecks on", uefiletter);
                        Bcdedit(shell);
                        Setid(false, Global.sdanum, Global.uefisum);
                        ShowText.Text = "完成！";
                    }
                    else
                    {
                        MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                }
            }
            else if (Global.moreability == "installdrive")
            {
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                string drvpath1 = String.Format(@"{0}\data\mindows\driver", exepath);
                if (Directory.Exists(drvpath1))
                {
                    warntext.Text = "当前路径为默认驱动路径，理论上已在安装Windows时安装";
                    drvpath.Text = drvpath1;
                }
                else
                {
                    warntext.Text = "未找到默认驱动，请指定路径！";
                }
            }
            else if (Global.moreability == "removedrive")
            {
                drvpath.Visible = false;
                choicedrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                ShowText.Text = "删除驱动";
                installdrv.Text = "开始";
                warntext.Text = "此操作将删除已安装的全部驱动！";
            }
            else if (Global.moreability == "repart")
            {
                warntext.Visible = false;
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                Mindows.Disdevice();//区分机型
                ShowText.Text = "正在检查分区表";
                ADBHelper.ADB("shell twrp unmount data");
                ADBHelper.ADB("push bin/linux/parted /tmp/");
                ADBHelper.ADB("shell chmod +x /tmp/parted");
                string parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                shellshow.Text = parttable;
                string shell = "";//ADB命令
                string part = "";//分区名称
                string sdxx = "";//sdx磁盘
                string partnum = "";//分区序号
                if (parttable.IndexOf("userdata") != -1 && parttable.IndexOf("win") != -1 && parttable.IndexOf("esp") != -1)
                {
                    part = "userdata";
                    int datano = Mindows.Onlynum(Mindows.Partno(parttable, part));
                    string datastart = Mindows.Partstart(parttable, part);
                    part = "esp";
                    int espno = Mindows.Onlynum(Mindows.Partno(parttable, part));
                    part = "win";
                    int winno = Mindows.Onlynum(Mindows.Partno(parttable, part));
                    string dataend = Mindows.Endpartend(parttable);
                    if (parttable.IndexOf("sharedspace") != -1)
                    {
                        part = "sharedspace";
                        int sharedspaceno = Mindows.Onlynum(Mindows.Partno(parttable, part));
                        shell = String.Format("shell /tmp/parted /dev/block/sda rm {0}", sharedspaceno);
                        ADBHelper.ADB(shell);
                    }
                    shell = String.Format("shell /tmp/parted /dev/block/sda rm {0}", espno);
                    ADBHelper.ADB(shell);
                    shell = String.Format("shell /tmp/parted /dev/block/sda rm {0}", winno);
                    ADBHelper.ADB(shell);
                    ADBHelper.ADB("shell twrp unmount data");
                    shell = String.Format("shell /tmp/parted /dev/block/sda rm {0}", datano);
                    ADBHelper.ADB(shell);
                    shell = String.Format("shell /tmp/parted /dev/block/sda mkpart userdata ext4 {0} {1}", datastart, dataend);
                    ADBHelper.ADB(shell);
                    parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                    shellshow.Text = parttable;
                    if (parttable.IndexOf("userdata") != -1)
                    {
                        ShowText.Text = "正在重启Rec并格式化Data分区";
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
                        ADBHelper.ADB("shell twrp unmount data");
                        part = "userdata";
                        sdxx = Mindows.FindDisk(part);
                        if (sdxx != "")
                        {
                            partnum = Mindows.Partno(Mindows.FindPart(part), part);
                            shell = String.Format("shell mke2fs -t ext4 /dev/block/{0}{1}", sdxx, partnum);
                            ADB(shell);
                        }
                        ShowText.Text = "恢复完成！";
                        MessageBox.Show("恢复完成！", "提示！");
                    }
                    else
                    {
                        ShowText.Text = "恢复分区出现错误！";
                        MessageBox.Show("恢复分区出现错误！", "提示！");
                    }
                }
                else
                {
                    ShowText.Text = "未找到需要删除的分区！";
                    MessageBox.Show("未找到需要删除的分区！", "提示！");
                }
            }
            else if (Global.moreability == "installwin")
            {
                warntext.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                choicedrv.Text = "选择文件";
                ShowText.Text = "请选择要安装的Windows镜像";
            }
            else if (Global.moreability == "noweboobe")
            {
                drvpath.Visible = false;
                choicedrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                installdrv.Text = "开始";
                warntext.Text = "尝试跳过Windows开机向导的联网登录";
            }
            else if (Global.moreability == "usbmode")
            {
                drvpath.Visible = false;
                choicedrv.Visible = false;
                installdrv.Text = "开始";
                warntext.Text = "修改USB模式，修复某些设备USB无法连接的问题";
            }
            else if (Global.moreability == "oobeerror")
            {
                drvpath.Visible = false;
                choicedrv.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                installdrv.Text = "开始";
                warntext.Text = "尝试解决Windows开机出现弹窗无法进入系统的问题";
            }
            else if (Global.moreability == "loadreg")
            {
                warntext.Visible = false;
                set1.Visible = false;
                set3.Visible = false;
                set6.Visible = false;
                installdrv.Text = "挂载";
                choicedrv.Text = "选择文件";
                ShowText.Text = "请选择要挂载的注册表";
            }
            else
            {
                MessageBox.Show("未设定执行内容！", "提示！");
            }
        }

        //线程
        Thread t1;

        private void MinodwsTools_Shown(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Moreability();
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicedrv_Click(object sender, EventArgs e)
        {
            if (Global.moreability == "installwin")
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = "C:\\";
                fileDialog.Filter = "镜像文件|*.wim";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    drvpath.Text = fileDialog.FileName;
                }
            }
            else if (Global.moreability == "installdrive")
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.Description = "请选择驱动程序所在目录";
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    drvpath.Text = folderBrowser.SelectedPath;
                }
            }
            else if (Global.moreability == "loadreg")
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    drvpath.Text = fileDialog.FileName;
                }
            }
            else
            {
                MessageBox.Show("未设定执行内容！", "提示！");
            }
        }

        private void installdrv_Click(object sender, EventArgs e)
        {
            if (Global.moreability == "installwin")
            {
                t1 = new Thread(delegate ()
                {
                    Mindows.Disdevice();//区分机型
                    string wimpath = drvpath.Text;
                    if (wimpath != "")
                    {
                        installdrv.Enabled = false;
                        if (Global.sdanum == 0)
                        {
                            ShowText.Text = "正在查找Sda磁盘";
                            if (Global.issda)
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = Findsda();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                            else
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = FindLinux();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                        }
                        ShowText.Text = "正在查找Windows分区";
                        string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
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
                            int winsum = Mindows.FindWin(output);
                            Global.uefisum = Mindows.FindUEFI(output);
                            shellshow.Text = "";
                            Global.winletter = Setletter(Global.sdanum, winsum);
                            Setid(true, Global.sdanum, Global.uefisum);
                            string uefiletter = Setletter(Global.sdanum, Global.uefisum);
                            if (Global.winletter != "C" && uefiletter != "C")
                            {
                                ShowText.Text = "正在安装Windows";
                                shell = String.Format("/Apply-Image /ImageFile:\"{0}\" /index:1 /ApplyDir:{1}:\\", wimpath, Global.winletter);
                                Dism(shell);
                                shellshow.Text = "";
                                shell = String.Format(@"{0}:\Windows /s {1}: /f UEFI /l zh-cn", Global.winletter, uefiletter);
                                Bcdboot(shell);
                                WriteShow();
                                Setid(false, Global.sdanum, Global.uefisum);
                                if (output.IndexOf("successfully") != -1)
                                {
                                    ShowText.Text = "完成！";
                                }
                                else
                                {
                                    MessageBox.Show("启动引导建立失败！", "提示！");
                                    ShowText.Text = "启动引导建立失败！";
                                }
                            }
                            else
                            {
                                MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("未找到Windows或UEFI分区！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择Windows镜像！", "提示！");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "installdrive")
            {
                t1 = new Thread(delegate ()
                {
                    Mindows.Disdevice();//区分机型
                    string drvpath1 = drvpath.Text;
                    if (drvpath1 != "")
                    {
                        installdrv.Enabled = false;
                        if (Global.sdanum == 0)
                        {
                            ShowText.Text = "正在查找Sda磁盘";
                            if (Global.issda)
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = Findsda();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                            else
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = FindLinux();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                        }
                        if (Global.winletter == "C")
                        {
                            string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                            Diskpart(shell);
                            WriteShow();
                            if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                            {
                                int winsum = Mindows.FindWin(output);
                                shellshow.Text = "";
                                Global.winletter = Setletter(Global.sdanum, winsum);
                            }
                            else
                            {
                                MessageBox.Show("未找到Windows分区！", "提示");
                            }
                        }
                        if (Global.winletter != "C")
                        {
                            ShowText.Text = "正在安装驱动程序";
                            shellshow.Text = "";
                            string filepath = String.Format(@"{0}\dulist.txt", drvpath1);
                            if (File.Exists(filepath))
                            {
                                string shell = String.Format("-d {0} -r {1} -p {2}:\\", filepath, drvpath1, Global.winletter);
                                DriverUpdater(shell);
                                output = shellshow.Text;
                                Mindows.Write(@"log\driverupdate.txt", output);
                            }
                            else
                            {
                                string shell = String.Format("/Image:{0}:\\ /Add-Driver /Driver:\"{1}\" /Recurse /ForceUnsigned", Global.winletter, drvpath1);
                                Dism(shell);
                                output = shellshow.Text;
                                Mindows.Write(@"log\dism.txt", output);
                            }
                            ShowText.Text = "完成！";
                        }
                        else
                        {
                            MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择驱动文件路径！", "提示！");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "removedrive")
            {
                t1 = new Thread(delegate ()
                {
                    Mindows.Disdevice();//区分机型
                    installdrv.Enabled = false;
                    if (Global.sdanum == 0)
                    {
                        ShowText.Text = "正在查找Sda磁盘";
                        if (Global.issda)
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = Findsda();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                        else
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = FindLinux();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                    }
                    if (Global.winletter == "C")
                    {
                        string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                        Diskpart(shell);
                        WriteShow();
                        if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                        {
                            int winsum = Mindows.FindWin(output);
                            shellshow.Text = "";
                            Global.winletter = Setletter(Global.sdanum, winsum);
                        }
                        else
                        {
                            MessageBox.Show("未找到Windows分区！", "提示");
                        }
                    }
                    ShowText.Text = "正在搜索驱动程序";
                    if (Global.winletter != "C")
                    {
                        shellshow.Text = "";
                        string shell = String.Format("/Image:{0}:\\ /Get-Drivers /English", Global.winletter);
                        Dism(shell);
                        output = shellshow.Text;
                        Mindows.Write(@"log\dism.txt", output);
                        if (output.IndexOf("Published Name") != -1)
                        {
                            shellshow.Text = "";
                            ShowText.Text = "正在删除驱动程序";
                            string delete = Mindows.FindDriver(output);
                            shell = String.Format("/Image:{0}:\\ /Remove-Driver{1} /English", Global.winletter, delete);
                            Dism(shell);
                            output = shellshow.Text;
                            Mindows.Write(@"log\dism.txt", output);
                            ShowText.Text = "完成！";
                        }
                        else
                        {
                            MessageBox.Show("未找到驱动程序！", "提示！");
                            ShowText.Text = "未找到驱动程序！";
                        }
                    }
                    else
                    {
                        MessageBox.Show("磁盘符出现问题，操作失败！", "提示！");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "noweboobe")
            {
                t1 = new Thread(delegate ()
                {
                    installdrv.Enabled = false;
                    Mindows.Disdevice();//区分机型
                    if (Global.sdanum == 0)
                    {
                        ShowText.Text = "正在查找Sda磁盘";
                        if (Global.issda)
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = Findsda();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                        else
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = FindLinux();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                    }
                    ShowText.Text = "正在分配磁盘符";
                    string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                    Diskpart(shell);
                    WriteShow();
                    if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                    {
                        int winsum = Mindows.FindWin(output);
                        shellshow.Text = "";
                        Global.winletter = Setletter(Global.sdanum, winsum);
                        ShowText.Text = "正在修改注册表";
                        string patch = String.Format(@"load HKEY_LOCAL_MACHINE\Mindows {0}:\Windows\System32\config\SOFTWARE", Global.winletter);
                        Reg(patch);
                        if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                        {
                            shellshow.Text = "";
                            RegistryHelper.EditRegedit(@"BypassNRO", 1, @"Microsoft\Windows\CurrentVersion\OOBE");
                            shellshow.Text += RegistryHelper.GetRegistData(@"BypassNRO", @"Microsoft\Windows\CurrentVersion\OOBE");
                            if (shellshow.Text.IndexOf("1") != -1)
                            {
                                int i;
                                for (i = 0; i < 1000; i++)
                                {
                                    Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                                    if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                    {
                                        break;
                                    }
                                }
                                if (i == 1000)
                                {
                                    MessageBox.Show("卸载注册表失败，请重启程序尝试直接卸载！", "提示！");
                                }
                                else
                                {
                                    ShowText.Text = "完成！";
                                    MessageBox.Show("完成！", "提示！");
                                }
                            }
                            else
                            {
                                ShowText.Text = "未找到项，尝试直接添加";
                                RegistryHelper.WTRegedit(@"BypassNRO", 1, @"Microsoft\Windows\CurrentVersion\OOBE");
                                shellshow.Text += RegistryHelper.GetRegistData(@"BypassNRO", @"Microsoft\Windows\CurrentVersion\OOBE");
                                if (shellshow.Text.IndexOf("1") != -1)
                                {
                                    int i;
                                    for (i = 0; i < 1000; i++)
                                    {
                                        Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                                        if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                        {
                                            break;
                                        }
                                    }
                                    if (i == 1000)
                                    {
                                        MessageBox.Show("卸载注册表失败，请重启程序尝试直接卸载！", "提示！");
                                    }
                                    else
                                    {
                                        ShowText.Text = "完成！";
                                        MessageBox.Show("完成！", "提示！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("修改失败！", "提示");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("加载注册表失败！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("未找到Windows分区！", "提示");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "usbmode")
            {
                t1 = new Thread(delegate ()
                {
                    int mode = 0;
                    if (set1.Checked)
                        mode = 1;
                    if (set3.Checked)
                        mode = 3;
                    if (set6.Checked)
                        mode = 6;
                    if (mode != 0)
                    {
                        installdrv.Enabled = false;
                        Mindows.Disdevice();//区分机型
                        if (Global.sdanum == 0)
                        {
                            ShowText.Text = "正在查找Sda磁盘";
                            if (Global.issda)
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = Findsda();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                            else
                            {
                                for (Global.sdanum = 0; ;)
                                {
                                    Global.sdanum = FindLinux();
                                    if (Global.sdanum != 0)
                                        break;
                                }
                            }
                        }
                        ShowText.Text = "正在分配磁盘符";
                        string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                        Diskpart(shell);
                        WriteShow();
                        if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                        {
                            int winsum = Mindows.FindWin(output);
                            shellshow.Text = "";
                            Global.winletter = Setletter(Global.sdanum, winsum);
                            ShowText.Text = "正在修改注册表";
                            string patch = String.Format(@"load HKEY_LOCAL_MACHINE\Mindows {0}:\Windows\System32\config\SYSTEM", Global.winletter);
                            Reg(patch);
                            if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                            {
                                shellshow.Text = "";
                                RegistryHelper.EditRegedit(@"OsDefaultRoleSwitchMode", mode, @"ControlSet001\Control\USB");
                                shellshow.Text += RegistryHelper.GetRegistData(@"OsDefaultRoleSwitchMode", @"ControlSet001\Control\USB");
                                if (shellshow.Text.IndexOf(mode.ToString()) != -1)
                                {
                                    int i;
                                    for (i = 0; i < 1000; i++)
                                    {
                                        Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                                        if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                        {
                                            break;
                                        }
                                    }
                                    if (i == 1000)
                                    {
                                        MessageBox.Show("卸载注册表失败，请重启程序尝试直接卸载！", "提示！");
                                    }
                                    else
                                    {
                                        ShowText.Text = "完成！";
                                        MessageBox.Show("完成！", "提示！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("修改失败！", "提示");
                                }
                            }
                            else
                            {
                                MessageBox.Show("加载注册表失败！", "提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("未找到Windows分区！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择要为USB模式设置的值！", "提示");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "oobeerror")
            {
                t1 = new Thread(delegate ()
                {
                    installdrv.Enabled = false;
                    Mindows.Disdevice();//区分机型
                    if (Global.sdanum == 0)
                    {
                        ShowText.Text = "正在查找Sda磁盘";
                        if (Global.issda)
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = Findsda();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                        else
                        {
                            for (Global.sdanum = 0; ;)
                            {
                                Global.sdanum = FindLinux();
                                if (Global.sdanum != 0)
                                    break;
                            }
                        }
                    }
                    ShowText.Text = "正在分配磁盘符";
                    string shell = String.Format("select disk {0} \r\nlist part \r\nexit", Global.sdanum);
                    Diskpart(shell);
                    WriteShow();
                    if (output.IndexOf("主要") != -1 || output.IndexOf("Primary") != -1)
                    {
                        int winsum = Mindows.FindWin(output);
                        shellshow.Text = "";
                        Global.winletter = Setletter(Global.sdanum, winsum);
                        ShowText.Text = "正在修改注册表";
                        string patch = String.Format(@"load HKEY_LOCAL_MACHINE\Mindows {0}:\Windows\System32\config\SYSTEM", Global.winletter);
                        Reg(patch);
                        if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                        {
                            shellshow.Text = "";
                            bool reg = false;
                            reg = RegistryHelper.EditRegedit(@"OOBEInProgress", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"Respecialize", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"RestartSetup", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"SetupPhase", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"SetupSupported", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"SetupType", 0, @"Setup");
                            reg = RegistryHelper.EditRegedit(@"SystemSetupInProgress", 0, @"Setup");
                            if (reg)
                            {
                                ShowText.Text = "正在卸载注册表";
                                int j;
                                for (j = 0; j < 1000; j++)
                                {
                                    Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                                    if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                    {
                                        break;
                                    }
                                }
                                if (j == 1000)
                                {
                                    MessageBox.Show("卸载注册表失败，请重启程序尝试直接卸载！", "提示！");
                                }
                                else
                                {
                                    ShowText.Text = "正在修改注册表";
                                    patch = String.Format(@"load HKEY_LOCAL_MACHINE\Mindows {0}:\Windows\System32\config\SAM", Global.winletter);
                                    Reg(patch);
                                    if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                    {
                                        shellshow.Text = "";
                                        byte[] b = Mindows.Object2Bytes(RegistryHelper.GetRegistData(@"F", @"SAM\Domains\Account\Users\000001F4"));
                                        if (b[83].ToString("X2") == "11" || b[83].ToString("X2") == "10")
                                        {
                                            byte[] c = new byte[80];
                                            for (int i = 27; i <= 106; i++)
                                            {
                                                c[i - 27] = b[i];
                                            }
                                            c[56] = 16;
                                            RegistryHelper.EditRegedit(@"F", c, @"SAM\Domains\Account\Users\000001F4");
                                            byte[] a = Mindows.Object2Bytes(RegistryHelper.GetRegistData(@"F", @"SAM\Domains\Account\Users\000001F4"));
                                            if (a[83].ToString("X2") == "10")
                                            {
                                                ShowText.Text = "正在卸载注册表";
                                                int i;
                                                for (i = 0; i < 1000; i++)
                                                {
                                                    Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                                                    if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (i == 1000)
                                                {
                                                    MessageBox.Show("卸载注册表失败，请重启程序尝试直接卸载！", "提示！");
                                                }
                                                else
                                                {
                                                    ShowText.Text = "完成！";
                                                    MessageBox.Show("完成！", "提示！");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("修改失败！", "提示");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("当前用户数值有误，请检查注册表！", "提示");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("加载注册表失败！", "提示");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("修改失败！", "提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("加载注册表失败！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("未找到Windows分区！", "提示");
                    }
                    installdrv.Enabled = true;
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else if (Global.moreability == "loadreg")
            {
                t1 = new Thread(delegate ()
                {
                    string regpath = drvpath.Text;
                    if (regpath != "")
                    {
                        installdrv.Enabled = false;
                        ShowText.Text = "正在挂载注册表";
                        string patch = String.Format(@"load HKEY_LOCAL_MACHINE\Mindows {0}", regpath);
                        Reg(patch);
                        if (shellshow.Text.IndexOf("操作成功完成") != -1 || shellshow.Text.IndexOf("operation completed successfully") != -1)
                        {
                            shellshow.Text = @"已将注册表挂载至“HKEY_LOCAL_MACHINE\Mindows”";
                            Mindows.NSudoLC(@"-U:S -P:E -M:S regedit.exe");
                            ShowText.Text = "完成！";
                            MessageBox.Show("完成！", "提示！");
                        }
                        else
                        {
                            MessageBox.Show("加载注册表失败！", "提示");
                        }
                        installdrv.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择需要挂载的注册表！", "提示");
                    }
                });
                t1.IsBackground = true;
                t1.Start();
            }
            else
            {
                MessageBox.Show("未设定执行内容！", "提示！");
            }
        }

        private void MindowsTools_FormClosing(object sender, FormClosingEventArgs e)
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
