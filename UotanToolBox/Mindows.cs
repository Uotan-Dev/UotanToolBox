using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace UotanToolBox
{
    public class Mindows
    {

        private static Form ParentForm;

        public Mindows(Form Form)
        {
            ParentForm = Form;
        }

        public static void Disdevice()//区分机型
        {
            string Language = System.Globalization.CultureInfo.CurrentUICulture.Name;
            int isen = Language.IndexOf("en");
            if (Language != "zh-CN" && isen == -1)
            {
                MessageBox.Show("当前系统语言无法运行此功能，仅支持简体中文和英语！\n\rThe current system language cannot run this function, only Chinese and English are supported!", "提示");
                ParentForm.Close();
            }
            if (Global.device == "MI6" || Global.device == "MIX2")
            {
                Global.warn = true;//机型警告
            }
            if (Global.device == "Pad5")
            {
                Global.boot = "boot_a";//boot
            }
            if (Global.device == "MI8" || Global.device == "MIX2S")
            {
                Global.devcfg = true;//需要刷入Devcfg
            }
            if (Global.device == "MIX3" || Global.device == "K20Pro" || Global.device == "MI9")
            {
                Global.vbmeta = true;//需要禁用Vbmeta
            }
            if (Global.device == "Pad5")
            {
                Global.bootrec = true;//是否为临时启动Rec
            }
            if (Global.device == "Pad5" || Global.device == "K20Pro" || Global.device == "MI9")
            {
                Global.removelimit = true;//是否需要解除分区数量限制
            }
            if (Global.device == "MIX2")
            {
                Global.havedrv = false;//是否有驱动
            }
            if (Global.device == "Pad5" || Global.device == "K20Pro" || Global.device == "MI9" || Global.device == "MI6" || Global.device == "MIX2")
            {
                Global.issda = false;//磁盘名称是否为Sda
            }
        }

        public static string GetProductID(string info)
        {
            if (info.IndexOf("FAILED") == -1)
            {
                char[] charSeparators = new char[] { ' ' };
                string[] infos = info.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] product = infos[0].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                return product[1];
            }
            else
            {
                return null;
            }
        }

        public static void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label label1)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);
                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = "下载进度" + percent.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                
            }
        }

        public static string Unzip(DirectoryInfo DirectInfo, string output)//解压缩
        {
            if (DirectInfo.Exists)
            {
                foreach (FileInfo fileInfo in DirectInfo.GetFiles("*.7z.001"))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = @"bin\7z\7z.exe";
                    process.StartInfo.Arguments = " x " + fileInfo.FullName + " -o" +fileInfo.FullName.Substring(0, fileInfo.FullName.LastIndexOf('\\')) + " -y";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    StreamReader reader = process.StandardOutput;
                    output = reader.ReadToEnd();
                }
            }
            return output;
        }

        public static void Write(string file, string text)//写入到txt文件
        {
            FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(text);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static string Partno(string parttable, string findpart)//分区号
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = parttable.Split(new char[2] {'\r','\n'}, StringSplitOptions.RemoveEmptyEntries);
            string partneed = "";
            string[] partno = null;
            for (int i = 6; i < parts.Length; i++)
            {
                partneed = parts[i];
                int find = partneed.IndexOf(findpart);
                if (find != -1)
                {
                    partno = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (partno.Length == 5)
                    {
                        if (partno[4] == findpart)
                            return partno[0];
                    }
                    else
                    {
                        if (partno[4] == findpart || partno[5] == findpart)
                            return partno[0];
                    }
                }
            }
            return null;
        }

        public static string Partstart(string part, string findpart)//分区开始位置
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = part.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string partneed = "";
            string[] parted = null;
            for (int i = 6; i < parts.Length; i++)
            {
                partneed = parts[i];
                int find = partneed.IndexOf(findpart);
                if (find != -1)
                {
                    parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (parted.Length == 5)
                    {
                        if (parted[4] == findpart)
                            return parted[1];
                    }
                    else
                    {
                        if (parted[4] == findpart || parted[5] == findpart)
                            return parted[1];
                    }
                }
            }
            return null;
        }

        public static string Partend(string part, string findpart)//分区结束位置
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = part.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string partneed = "";
            string[] parted = null;
            for (int i = 6; i < parts.Length; i++)
            {
                partneed = parts[i];
                int find = partneed.IndexOf(findpart);
                if (find != -1)
                {
                    parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (parted.Length == 5)
                    {
                        if (parted[4] == findpart)
                            return parted[2];
                    }
                    else
                    {
                        if (parted[4] == findpart || parted[5] == findpart)
                            return parted[2];
                    }
                }
            }
            return null;
        }

        public static string Partsize(string part, string findpart)//分区大小
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = part.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string partneed = "";
            string[] parted = null;
            for (int i = 6; i < parts.Length; i++)
            {
                partneed = parts[i];
                int find = partneed.IndexOf(findpart);
                if (find != -1)
                {
                    parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    if (parted.Length == 5)
                    {
                        if (parted[4] == findpart)
                            return parted[3];
                    }
                    else
                    {
                        if (parted[4] == findpart || parted[5] == findpart)
                            return parted[3];
                    }
                }
            }
            return null;
        }

        public static int Onlynum(string text)//只保留数字
        {
            string[] size = text.Split('.');
            string num = Regex.Replace(size[0], @"[^0-9]+", "");
            int numint = int.Parse(num);
            return numint;
        }

        public static string Unit(string size)//记录单位
        {
            string unit = "";
            if (size.IndexOf("kB") != -1)
                unit = "KB";
            if (size.IndexOf("MB") != -1)
                unit = "MB";
            if (size.IndexOf("GB") != -1)
                unit = "GB";
            return unit;
        }

        public static string Readtxt(string path)//读取txt文档
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadToEnd();
            sr.Close();
            return line;
        }

        public static void Backup(string part)//分区备份
        {
            string sdxx = Mindows.FindDisk(part);
            if (sdxx != "")
            {
                string partnum = Mindows.Partno(Mindows.FindPart(part), part);
                if (partnum != null)
                {
                    string bcka = String.Format(@"shell dd if=/dev/block/{0}{1} of={2}.img", sdxx, partnum, part);
                    string bckb = String.Format(@"pull /{0}.img backup\", part);
                    string bckc = String.Format(@"shell rm /{0}.img", part);
                    ADBHelper.ADB(bcka);
                    ADBHelper.ADB(bckb);
                    ADBHelper.ADB(bckc);
                }
            }
        }

        public static int FindUEFI(string part)//从Diskpart Part中获取UEFI分区号
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = part.Split('\n');
            string partneed = "";
            for (int i = 0; i < parts.Length; i++)
            {
                partneed = parts[i];
                if (partneed.IndexOf("系统") != -1 || partneed.IndexOf("System") != -1)
                    break;
            }
            string[] parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string partend = Regex.Replace(parted[1], @"[^0-9]+", "");
            int end = int.Parse(partend);
            return end;
        }

        public static int FindWin(string part)//从Diskpart Part中获取Win分区号
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = part.Split('\n');
            string partneed = "";
            for (int i = 0; i < parts.Length; i++)
            {
                partneed = parts[i];
                if (partneed.IndexOf("主要") != -1 || partneed.IndexOf("Primary") != -1)
                    break;
            }
            string[] parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string partend = Regex.Replace(parted[1], @"[^0-9]+", "");
            int end = int.Parse(partend);
            return end;
        }

        public static void OpenDefaultBrowserUrl(string url)//打开浏览器
        {
            // 方法1
            //从注册表中读取默认浏览器可执行文件路径
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            if (key != null)
            {
                string s = key.GetValue("").ToString();
                //s就是你的默认浏览器，不过后面带了参数，把它截去，不过需要注意的是：不同的浏览器后面的参数不一样！
                //"D:\Program Files (x86)\Google\Chrome\Application\chrome.exe" -- "%1"
                var lastIndex = s.IndexOf(".exe", StringComparison.Ordinal);
                if (lastIndex == -1)
                {
                    lastIndex = s.IndexOf(".EXE", StringComparison.Ordinal);
                }
                var path = s.Substring(1, lastIndex + 3);
                var exists = File.Exists(path);
                if (exists == true)
                {
                    //在win7向上的系统中，有时直接读取出来的路径是ie的默认路径，但是ie已经基本上寄了，用start会报找不到文件。
                    //（不过我这样直接加if是不是以后会成屎山......）
                    var result = Process.Start(path, url);
                    if (result == null)
                    {
                        // 方法2
                        // 调用系统默认的浏览器 
                        var result1 = Process.Start("explorer.exe", url);
                        if (result1 == null)
                        {
                            // 方法3
                            Process.Start(url);
                        }
                    }
                }
                else
                {
                    Process.Start(url);
                }
            }
            else
            {
                // 方法2
                // 调用系统默认的浏览器 
                var result1 = Process.Start("explorer.exe", url);
                if (result1 == null)
                {
                    // 方法3
                    Process.Start(url);
                }
            }
        }

        public static void DeleteFolder(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                foreach (string d in Directory.GetFileSystemEntries(dirPath))
                {
                    if (File.Exists(d))
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);//直接删除其中的文件   
                    }
                    else
                    {
                        DeleteFolder(d);//递归删除子文件夹   
                    }
                }
                Directory.Delete(dirPath);//删除已空文件夹   
            }
        }

        public static string Endpartend(string parttable)//最后一个分区的结束点
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = parttable.Split('\n');
            string partneed = parts[parts.Length - 3];
            string[] parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return parted[2];
        }

        public static string Endpartnum(string parttable)//最后一个分区的分区号
        {
            char[] charSeparators = new char[] { ' ' };
            string[] parts = parttable.Split('\n');
            string partneed = parts[parts.Length - 3];
            string[] parted = partneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            return parted[0];
        }

        public static bool Isdatalast(string parttable)
        {
            if (parttable.IndexOf("userdata") != -1)
            {
                string[] parts = parttable.Split('\n');
                string partneed = parts[parts.Length - 3];
                if (partneed.IndexOf("userdata") != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string Pnputil(string adb)
        {
            string cmd = @"pnputil.exe";
            ProcessStartInfo adbshell = null;
            adbshell = new ProcessStartInfo(cmd, adb);
            adbshell.CreateNoWindow = true;
            adbshell.UseShellExecute = false;
            adbshell.RedirectStandardOutput = true;
            adbshell.RedirectStandardError = true;
            Process a = Process.Start(adbshell);
            StreamReader reader = a.StandardOutput;
            StreamReader readererror = a.StandardError;
            string output = reader.ReadToEnd();
            if (output == "")
            {
                output = readererror.ReadToEnd();
            }
            return output;
        }

        public static string Devcon(string fb)//USB设备
        {
            string cmd = @"bin\devcon.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader readererror = f.StandardError;
            StreamReader reader = f.StandardOutput;
            string output = readererror.ReadToEnd();
            if (output == "")
            {
                output = reader.ReadToEnd();
            }
            return output;
        }

        public static string FindEDLCom(string usbdevice)//查找9008端口
        {
            char[] charSeparators = new char[] { ' ' };
            string[] devices = usbdevice.Split('\n');
            string deviceneed = "";
            for (int i = 0; i < devices.Length; i++)
            {
                deviceneed = devices[i];
                int find = deviceneed.IndexOf("QDLoader");
                if (find != -1)
                    break;
            }
            string[] device = deviceneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] dev = device[device.Length - 1].Split('(', ')');
            return dev[1];
        }

        public static int FindDIAGCom(string usbdevice)//查找901D端口
        {
            char[] charSeparators = new char[] { ' ' };
            string[] devices = usbdevice.Split('\n');
            string deviceneed = "";
            for (int i = 0; i < devices.Length; i++)
            {
                deviceneed = devices[i];
                int find = deviceneed.IndexOf("901D (");
                int find2 = deviceneed.IndexOf("9091 (");
                if (find != -1 || find2 != -1)
                    break;
            }
            string[] device = deviceneed.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string[] dev = device[device.Length - 1].Split('(', ')');
            int back = Onlynum(dev[1]);
            return back;
        }

        public static void PushMakefs()
        {
            ADBHelper.ADB("push bin/linux/mkfs.f2fs /tmp/");
            ADBHelper.ADB("shell chmod +x /tmp/mkfs.f2fs");
            ADBHelper.ADB("push bin/linux/mkntfs /tmp/");
            ADBHelper.ADB("shell chmod +x /tmp/mkntfs");
        }

        public static void GetPartTable()
        {
            ADBHelper.ADB("push bin/linux/parted /tmp/");
            ADBHelper.ADB("shell chmod +x /tmp/parted");
            Global.sdatable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
            Global.sdbtable = ADBHelper.ADB("shell /tmp/parted /dev/block/sdb print");
            Global.sdctable = ADBHelper.ADB("shell /tmp/parted /dev/block/sdc print");
            Global.sddtable = ADBHelper.ADB("shell /tmp/parted /dev/block/sdd print");
            Global.sdetable = ADBHelper.ADB("shell /tmp/parted /dev/block/sde print");
            Global.sdftable = ADBHelper.ADB("shell /tmp/parted /dev/block/sdf print");
            Global.emmcrom = ADBHelper.ADB("shell /tmp/parted /dev/block/mmcblk0 print");
        }

        public static void GetPartTableSystem()
        {
            ADBHelper.ADB("push bin/linux/parted /data/local/tmp/");
            ADBHelper.ADB("shell su -c \"chmod +x /data/local/tmp/parted\"");
            Global.sdatable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sda print\"");
            Global.sdbtable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sdb print\"");
            Global.sdctable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sdc print\"");
            Global.sddtable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sdd print\"");
            Global.sdetable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sde print\"");
            Global.sdftable = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/sdf print\"");
            Global.emmcrom = ADBHelper.ADB("shell su -c \"/data/local/tmp/parted /dev/block/mmcblk0 print\"");
        }

        public static string FindDisk(string Partname)
        {
            string sdxdisk = "";
            if (Global.sdatable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sdatable,Partname) != null)
                    sdxdisk = "sda";
            }
            if (Global.sdetable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sdetable, Partname) != null)
                    sdxdisk = "sde";
            }
            if (Global.sdbtable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sdbtable, Partname) != null)
                    sdxdisk = "sdb";
            }
            if (Global.sdctable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sdctable, Partname) != null)
                    sdxdisk = "sdc";
            }
            if (Global.sddtable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sddtable, Partname) != null)
                    sdxdisk = "sdd";
            }
            if (Global.sdftable.IndexOf(Partname) != -1)
            {
                if (Partno(Global.sdftable, Partname) != null)
                    sdxdisk = "sdf";
            }
            if (Global.emmcrom.IndexOf(Partname) != -1)
            {
                if (Partno(Global.emmcrom, Partname) != null)
                    sdxdisk = "mmcblk0p";
            }
            return sdxdisk;
        }

        public static string FindPart(string Partname)
        {
            string sdxdisk = "";
            if (Global.sdatable.IndexOf(Partname) != -1)
                sdxdisk = Global.sdatable;
            if (Global.sdetable.IndexOf(Partname) != -1)
                sdxdisk = Global.sdetable;
            if (Global.sdbtable.IndexOf(Partname) != -1)
                sdxdisk = Global.sdbtable;
            if (Global.sdctable.IndexOf(Partname) != -1)
                sdxdisk = Global.sdctable;
            if (Global.sddtable.IndexOf(Partname) != -1)
                sdxdisk = Global.sddtable;
            if (Global.sdftable.IndexOf(Partname) != -1)
                sdxdisk = Global.sdftable;
            if (Global.emmcrom.IndexOf(Partname) != -1)
                sdxdisk = Global.emmcrom;
            return sdxdisk;
        }

        public static string DiskSize(string PartTable)
        {
            string[] Lines = PartTable.Split('\n');
            char[] charSeparators = new char[] { ' ' };
            string[] NeedLine = Lines[1].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            string size = NeedLine[NeedLine.Length - 1];
            return size;
        }

        public static string WebRead(string url)
        {
            string read = "";
            HttpWebRequest request;
            HttpWebResponse response;
            TextReader tr;
            if (url != "")
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                tr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                read = tr.ReadToEnd();
                response.Close();
            }
            return read;
        }

        public static string Curl(string fb)
        {
            string cmd = @"bin\curl.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader reader = f.StandardOutput;
            string output = reader.ReadToEnd();
            return output;
        }

        public static string Addtp(string link)
        {
            string[] line = link.Split('/');
            string part = "";
            string outlink = "";
            for (int i = 0; i < line.Length; i++)
            {
                part = line[i];
                int find = part.IndexOf(".com");
                if (find != -1)
                {
                    outlink += String.Format("{0}/tp/", line[i]);
                }
                else
                {
                    outlink += String.Format("{0}/", line[i]);
                }
            }
            return outlink;
        }

        public static string GetDevLink(string html)
        {
            if (html != "")
            {
                string[] line = html.Split('\n');
                string need1 = "";
                string need2 = "";
                for (int i = 0; i < line.Length; i++)
                {
                    need1 = line[i];
                    int find = need1.IndexOf("var vkjxld ");
                    if (find != -1)
                        break;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    need2 = line[i];
                    int find = need2.IndexOf("var hyggid");
                    if (find != -1)
                        break;
                }
                string[] part1 = need1.Split('\'');
                string[] part2 = need2.Split('\'');
                string back = String.Format("{0}{1}", part1[1], part2[1]);
                return back;
            }
            else
            {
                return html;
            }
        }

        public static string GetDownloadLink(string html)
        {
            if (html != "")
            {
                char[] charSeparators = new char[] { ' ' };
                string[] line = html.Split('\n');
                string need = "";
                for (int i = 0; i < line.Length; i++)
                {
                    need = line[i];
                    int find = need.IndexOf("location:");
                    if (find != -1)
                        break;
                }
                string[] link = need.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                return link[1];
            }
            else
            {
                return html;
            }
        }

        public static string GetLink(string url)
        {
            string link = Addtp(url);
            string shell = String.Format("-k -A \"Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25\" {0}", link);
            string html = Curl(shell);
            string devlink = GetDevLink(html);
            string finddownloadlink = String.Format("curl -i -k -A \"Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25\" {0} --header \"Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8\" --header \"Accept-Encoding: gzip, deflate\" --header \"Accept-Language: zh-CN,zh;q=0.9\" --header \"Cache-Control: no-cache\" --header \"Connection: keep-alive\" --header \"Pragma: no-cache\" --header \"Upgrade-Insecure-Requests: 1\"", devlink);
            string html2 = Curl(finddownloadlink);
            return GetDownloadLink(html2);
        }

        public static string NSudoLC(string fb)
        {
            string cmd = @"bin\NSudo\NSudoLC.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader reader = f.StandardOutput;
            string output = reader.ReadToEnd();
            return output;
        }

        public static string Whoami(string fb)
        {
            string cmd = @"whoami.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader reader = f.StandardOutput;
            string output = reader.ReadToEnd();
            return output;
        }

        public static byte[] Object2Bytes(object obj)
        {
            byte[] buff;
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter iFormatter = new BinaryFormatter();
                iFormatter.Serialize(ms, obj);
                buff = ms.GetBuffer();
            }
            return buff;
        }

        public static string Reg(string fb)
        {
            string cmd = @"reg.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            StreamReader readererror = f.StandardError;
            StreamReader reader = f.StandardOutput;
            string output = reader.ReadToEnd();
            if (output == "")
            {
                output = readererror.ReadToEnd();
            }
            return output;
        }

        public static string FindDriver(string output)
        {
            char[] charSeparators = new char[] { ' ' };
            string[] line = output.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string delete = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].IndexOf("Published Name") != -1)
                {
                    string[] driver = line[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    delete += String.Format(" /Driver:{0}", driver[3]);
                }
            }
            return delete;
        }
    }
}
