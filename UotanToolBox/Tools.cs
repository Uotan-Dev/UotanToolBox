using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UotanToolBox
{
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }

        //储存版本信息
        string version = "2.9.0";
        string webversion = "";

        //检查网络链接相关
        Ping pingSender = new Ping();
        PingReply reply = null;
        bool Iconnect = false;

        //机型资源下载链接储存
        string mix2simglink = "";
        string mix2sdrivelink = "";
        string mi8imglink = "";
        string mi8drivelink = "";
        string mix3imglink = "";
        string mix3drivelink = "";
        string pad5imglink = "";
        string pad5drivelink1 = "";
        string pad5drivelink2 = "";
        string mi9imglink = "";
        string mi9drivelink1 = "";
        string mi9drivelink2 = "";
        string mi9drivelink3 = "";
        string mi6imglink = "";
        string mi6drivelink = "";
        string k20pdrivelink1 = "";
        string k20pdrivelink2 = "";
        string k20pdrivelink3 = "";
        string k20pimglink = "";

        //储存获取的内容
        string[] mess;

        //更新日志存储
        string updatemess;

        //储存输出
        string output;

        //线程
        Thread t1;

        public void WebConnect(string url)
        {
            try
            {
                reply = pingSender.Send(url, 1000);//测试连接
            }
            catch (Exception)
            {
                Iconnect = false;
            }
            finally
            {
                try
                {
                    if (reply == null || (reply != null && reply.Status != IPStatus.Success))//网络连接失败
                    {
                        Iconnect = false;
                    }
                    else
                    {
                        if (reply.Status == IPStatus.Success)//网络正常
                            Iconnect = true;
                    }
                }
                catch
                {
                    Iconnect = false;
                }
            }
        }

        public void GetMessage()
        {
            WebConnect("cloud.mjwsjq.top");
            if (Iconnect)
            {
                string check = Mindows.WebRead("http://cloud.mjwsjq.top/uotantool2.txt");
                if (check != null && check.IndexOf("%") != -1)
                {
                    mess = check.Split('%');
                    if (mess.Length >= 2)
                    {
                        webversion = mess[0];
                        updatemess = mess[1];
                        CheckVersion();
                    }
                    if (mess.Length >= 22)
                    {
                        mix2sdrivelink = mess[3];
                        mix2simglink = mess[4];
                        mi8drivelink = mess[5];
                        mi8imglink = mess[6];
                        mix3drivelink = mess[7];
                        mix3imglink = mess[8];
                        pad5drivelink1 = mess[9];
                        pad5drivelink2 = mess[10];
                        pad5imglink = mess[11];
                        mi9imglink = mess[12];
                        mi9drivelink1 = mess[13];
                        mi9drivelink2 = mess[14];
                        mi9drivelink3= mess[15];
                        mi6imglink = mess[16];
                        mi6drivelink = mess[17];
                        k20pdrivelink1 = mess[18];
                        k20pdrivelink2 = mess[19];
                        k20pdrivelink3 = mess[20];
                        k20pimglink = mess[21];
                    }
                }
            }
            else
            {
                MessageBox.Show("网络异常，无法获取资源信息！", "提示！");
            }
        }

        public void CheckVersion()
        {
            if (version != webversion)
            {
                DialogResult result;
                string show = String.Format("检测到新版本是否前往下载？\n\r更新内容：{0}", updatemess);
                result = MessageBox.Show(show, "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Mindows.OpenDefaultBrowserUrl("https://www.uotan.cn/resources/");
                }
            }
        }

        string exepath = System.IO.Directory.GetCurrentDirectory();//获取工具运行路径
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            t1 = new Thread(delegate ()
            {
                string filepath1 = String.Format(@"{0}\bin\adb\adb.exe", exepath);
                string filepath2 = String.Format(@"{0}\bin\adb\fastboot.exe", exepath);
                if (File.Exists(filepath1) || File.Exists(filepath2))
                {
                    string uefipath = String.Format(@"{0}\data\mindows\img\uefi.img", exepath);
                    if (File.Exists(uefipath))
                    {
                        uefifilename.Text = uefipath;
                    }
                    else
                    {
                        tips.Visible = false;
                    }
                    string qcnfilepatch = String.Format(@"{0}\backup\00000.qcn", exepath);
                    if (File.Exists(qcnfilepatch))
                    {
                        qcnfilepatchtxt.Text = qcnfilepatch;
                    }
                    Checkcon();
                    GetMessage();
                }
                else
                {
                    MessageBox.Show("缺少程序运行的必须组件！", "警告！");
                    this.Close();
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        public void Checkcon()
        {
            if (ADBHelper.Fastboot("devices") != "")
            {
                conninfo.Text = "Fastboot";
            }
            else
            {
                conninfo.Text = "未连接";
            }
            int adbcheck = ADBHelper.ADB("devices").IndexOf("recovery");
            if (adbcheck != -1)
            {
                conninfo.Text = "Recovery";
            }
            int adbcheck2 = ADBHelper.ADB("devices").IndexOf("sideload");
            if (adbcheck2 != -1)
            {
                conninfo.Text = "Sideload";
            }
            int adbcheck3 = ADBHelper.ADB("devices").IndexOf("	device");
            if (adbcheck3 != -1)
            {
                conninfo.Text = "系统";
            }
            int check9008 = Mindows.Devcon("find usb*").IndexOf("QDLoader");
            if (check9008 != -1)
            {
                conninfo.Text = "9008";
            }
            int check901d = Mindows.Devcon("find usb*").IndexOf("901D (");
            if (check901d != -1)
            {
                conninfo.Text = "901D";
            }
            int check900e = Mindows.Devcon("find usb*").IndexOf("900E");
            if (check900e != -1)
            {
                conninfo.Text = "900E";
            }
            int check9091 = Mindows.Devcon("find usb*").IndexOf("9091 (");
            if (check9091 != -1)
            {
                conninfo.Text = "9091";
            }
            if (conninfo.Text == "Fastboot")
            {
                int unlocked = ADBHelper.Fastboot("getvar unlocked").IndexOf("yes");
                if (unlocked != -1)
                {
                    BLinfo.Text = "已解锁";
                }
                int locked = ADBHelper.Fastboot("getvar unlocked").IndexOf("no");
                if (locked != -1)
                {
                    BLinfo.Text = "未解锁";
                    MessageBox.Show("您的设备未解锁BootLoader！\n\r大部分功能将无法使用！", "警告！");
                }
                string productinfos = ADBHelper.Fastboot("getvar product");
                string product = Mindows.GetProductID(productinfos);
                if (product != null)
                {
                    productinfo.Text = product;
                }
                string active = ADBHelper.Fastboot("getvar current-slot");
                if (active.IndexOf("current-slot: a") != -1)
                {
                    VABinfo.Text = "A槽位";
                }
                else if (active.IndexOf("current-slot: b") != -1)
                {
                    VABinfo.Text = "B槽位";
                }
                else if (active.IndexOf("FAILED") != -1)
                {
                    VABinfo.Text = "A-Only设备";
                }
            }
            else if (conninfo.Text == "Recovery")
            {
                string active = ADBHelper.ADB("shell getprop ro.boot.slot_suffix");
                if (active.IndexOf("_a") != -1)
                {
                    VABinfo.Text = "A槽位";
                }
                else if (active.IndexOf("_b") != -1)
                {
                    VABinfo.Text = "B槽位";
                }
                else
                {
                    VABinfo.Text = "A-Only设备";
                }
            }
            else if (conninfo.Text == "系统")
            {
                string active = ADBHelper.ADB("shell getprop ro.boot.slot_suffix");
                if (active.IndexOf("_a") != -1)
                {
                    VABinfo.Text = "A槽位";
                }
                else if (active.IndexOf("_b") != -1)
                {
                    VABinfo.Text = "B槽位";
                }
                else
                {
                    VABinfo.Text = "A-Only设备";
                }
            }
            else
            {
                BLinfo.Text = "未知";
                VABinfo.Text = "未知";
                productinfo.Text = "未知";
            }
        }

        private void checkconn_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //Recovery

        private void frebootrec_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string output = ADBHelper.Fastboot("oem reboot-recovery");
                    if (output.IndexOf("unknown command") != -1)
                    {
                        ADBHelper.Fastboot("flash misc bin/img/misc.img");
                        ADBHelper.Fastboot("reboot");
                    }
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void frebootsystem_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    ADBHelper.Fastboot("reboot");
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void poweroff_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string output = ADBHelper.Fastboot("oem poweroff");
                    if (output.IndexOf("unknown command") != -1)
                    {
                        MessageBox.Show("当前设备不支持此命令！", "提示!");
                    }
                    else
                    {
                        MessageBox.Show("执行成功，拔出设备连接线即可关机！", "提示!");
                    }
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void frebootedl_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    ADBHelper.Fastboot("oem edl");
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void frebootfastbootd_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    ADBHelper.Fastboot("reboot-fastboot");
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void frebootbootloader_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    ADBHelper.Fastboot("reboot-bootloader");
                }
                else
                {
                    MessageBox.Show("设备连接状态错误！", "提示!");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void arebootrec_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot recovery");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void arebootsystem_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void arebootedl_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot edl");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void arebootfastbootd_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot fastboot");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void arebootbootloader_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot bootloader");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void rebootsideload_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("reboot sideload");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void twrprebootsideload_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                ADBHelper.ADB("shell twrp sideload");
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicerec_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filename.Text = fileDialog.FileName;
            }
        }

        private void flashrec_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("flash recovery \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        int sf1 = ADBHelper.Fastboot(shell).IndexOf("error");
                        if (sf == -1 && sf1 == -1)
                        {
                            DialogResult result;
                            result = MessageBox.Show("刷入成功！是否重启到Recovery？", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string output = ADBHelper.Fastboot("oem reboot-recovery");
                                if (output.IndexOf("unknown command") != -1)
                                {
                                    ADBHelper.Fastboot("flash misc bin/img/misc.img");
                                    ADBHelper.Fastboot("reboot");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择Recovery文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void falshreca_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("flash recovery_a \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            DialogResult result;
                            result = MessageBox.Show("刷入成功！是否重启到Recovery？", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string output = ADBHelper.Fastboot("oem reboot-recovery");
                                if (output.IndexOf("unknown command") != -1)
                                {
                                    ADBHelper.Fastboot("flash misc bin/img/misc.img");
                                    ADBHelper.Fastboot("reboot");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择Recovery文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashrecb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("flash recovery_b \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            DialogResult result;
                            result = MessageBox.Show("刷入成功！是否重启到Recovery？", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string output = ADBHelper.Fastboot("oem reboot-recovery");
                                if (output.IndexOf("unknown command") != -1)
                                {
                                    ADBHelper.Fastboot("flash misc bin/img/misc.img");
                                    ADBHelper.Fastboot("reboot");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择Recovery文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void bootimg_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("boot \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("Finished");
                        if (sf != -1)
                        {
                            MessageBox.Show("启动成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("启动失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择镜像文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashboota_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("flash boot_a \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            DialogResult result;
                            result = MessageBox.Show("刷入成功！是否重启到Recovery？", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string output = ADBHelper.Fastboot("oem reboot-recovery");
                                if (output.IndexOf("unknown command") != -1)
                                {
                                    ADBHelper.Fastboot("flash misc bin/img/misc.img");
                                    ADBHelper.Fastboot("reboot");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择Recovery文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashbootb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (filename.Text != "")
                    {
                        flashrec.Enabled = false;
                        flashreca.Enabled = false;
                        flashrecb.Enabled = false;
                        bootimg.Enabled = false;
                        flashboota.Enabled = false;
                        flashbootb.Enabled = false;
                        string file = filename.Text;
                        string shell = String.Format("flash boot_b \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            DialogResult result;
                            result = MessageBox.Show("刷入成功！是否重启到Recovery？", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                string output = ADBHelper.Fastboot("oem reboot-recovery");
                                if (output.IndexOf("unknown command") != -1)
                                {
                                    ADBHelper.Fastboot("flash misc bin/img/misc.img");
                                    ADBHelper.Fastboot("reboot");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashrec.Enabled = true;
                        flashreca.Enabled = true;
                        flashrecb.Enabled = true;
                        bootimg.Enabled = true;
                        flashboota.Enabled = true;
                        flashbootb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择Recovery文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void disableoffrec_Click(object sender, EventArgs e)//阻止恢复官方Rec
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    disableoffrec.Enabled = false;
                    flashmagisk.Enabled = false;
                    syncab.Enabled = false;
                    string shell = "push bin/DisableAutoRecovery.zip /tmp/";
                    string shell2 = "shell twrp install /tmp/DisableAutoRecovery.zip";
                    ADBHelper.ADB(shell);
                    ADBHelper.ADB(shell2);
                    MessageBox.Show("执行完成！", "提示");
                    disableoffrec.Enabled = true;
                    flashmagisk.Enabled = true;
                    syncab.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashmagisk_Click(object sender, EventArgs e)//刷入面具
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    disableoffrec.Enabled = false;
                    flashmagisk.Enabled = false;
                    syncab.Enabled = false;
                    string shell = "push bin/apk/Magisk.v26.3.apk /tmp/";
                    string shell2 = "shell twrp install /tmp/Magisk.v26.3.apk";
                    ADBHelper.ADB(shell);
                    ADBHelper.ADB(shell2);
                    MessageBox.Show("执行完成！", "提示");
                    disableoffrec.Enabled = true;
                    flashmagisk.Enabled = true;
                    syncab.Enabled = true;
                }
                else if (conninfo.Text == "系统")
                {
                    DialogResult result;
                    result = MessageBox.Show("检测到当前为系统模式，是否推送Magisk应用？", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ADBHelper.ADB("push bin/apk/Magisk.v26.3.apk /sdcard");
                        MessageBox.Show("已推送至根目录，请自行安装。", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void syncab_Click(object sender, EventArgs e)//同步AB分区
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    disableoffrec.Enabled = false;
                    flashmagisk.Enabled = false;
                    syncab.Enabled = false;
                    string shell = "push bin/copy-partitions.zip /tmp/";
                    string shell2 = "shell twrp install /tmp/copy-partitions.zip";
                    ADBHelper.ADB(shell);
                    ADBHelper.ADB(shell2);
                    MessageBox.Show("执行完成！", "提示");
                    disableoffrec.Enabled = true;
                    flashmagisk.Enabled = true;
                    syncab.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //BL锁

        private void oemunlock_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (unlockshell.Text != "")
                {
                    if (conninfo.Text == "Fastboot")
                    {
                        DialogResult result;
                        result = MessageBox.Show("该功能仅支持部分品牌设备！\n\r执行后您的设备应当出现确认解锁提示，\n\r若未出现则为您的设备不支持该操作。", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string shell = unlockshell.Text;
                            ADBHelper.Fastboot(shell);
                            MessageBox.Show("执行完成，请查看您的设备！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请进入Fastboot模式！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择解锁命令！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void fixusb_Click(object sender, EventArgs e)
        {
            string cmd = @"drive\USB3.bat";
            ProcessStartInfo cmdshell = null;
            cmdshell = new ProcessStartInfo(cmd);
            cmdshell.CreateNoWindow = true;
            cmdshell.UseShellExecute = false;
            Process f = Process.Start(cmdshell);
            MessageBox.Show("执行成功！", "提示");
        }

        private void installADB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"drive\adb.exe");
        }

        private void edldrv_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"drive\Qualcomm_HS-USB_Driver.exe");
        }

        private void openxiaomiunlock_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"unlocktool\xiaomi\batch_unlock.exe");
        }

        private void openweiku_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"unlocktool\vivo\1.启动工具箱.bat");
        }

        private void choesunlock_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                unlockfile.Text = fileDialog.FileName;
            }
        }

        private void unlock_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (unlockcode.Text != "" && unlockfile.Text != "")
                    {
                        MessageBox.Show("请勿同时填写两种方式！", "提示");
                    }
                    else if (unlockcode.Text != "" && unlockfile.Text == "")
                    {
                        string code = unlockcode.Text;
                        string shell = String.Format("oem unlock {0}", code);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("OKAY");
                        if (sf != -1)
                        {
                            MessageBox.Show("解锁成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("解锁失败！", "提示");
                        }
                    }
                    else if (unlockfile.Text != "" && unlockcode.Text == "")
                    {
                        string file = unlockfile.Text;
                        string shell = String.Format("flash unlock \"{0}\"", file);
                        string shell2 = "oem unlock-go";
                        ADBHelper.Fastboot(shell);
                        int sf = ADBHelper.Fastboot(shell2).IndexOf("OKAY");
                        if (sf != -1)
                        {
                            MessageBox.Show("解锁成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("解锁失败！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择解锁文件,或输入解锁码！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void locked_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string shell = "oem lock-go";
                    string shell2 = "flashing lock";
                    ADBHelper.Fastboot(shell);
                    int sf = ADBHelper.Fastboot(shell2).IndexOf("OKAY");
                    if (sf != -1)
                    {
                        MessageBox.Show("回锁成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("回锁失败！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //Mindows工具箱
        string Language = System.Globalization.CultureInfo.CurrentUICulture.Name;

        public void Setdevice()
        {
            if (devicename.Text == "小米MIX2S")
            {
                Global.device = "MIX2S";
                Global.drivelink1 = mix2sdrivelink;
                Global.imglink = mix2simglink;
            }
            if (devicename.Text == "小米8")
            {
                Global.device = "MI8";
                Global.drivelink1 = mi8drivelink;
                Global.imglink = mi8imglink;
            }
            if (devicename.Text == "小米MIX3")
            {
                Global.device = "MIX3";
                Global.drivelink1 = mix3drivelink;
                Global.imglink = mix3imglink;
            }
            if (devicename.Text == "小米平板5")
            {
                Global.device = "Pad5";
                Global.drivelink1 = pad5drivelink1;
                Global.drivelink2 = pad5drivelink2;
                Global.imglink = pad5imglink;
            }
            if (devicename.Text == "小米9")
            {
                Global.device = "MI9";
                Global.drivelink1 = mi9drivelink1;
                Global.drivelink2 = mi9drivelink2;
                Global.drivelink3 = mi9drivelink3;
                Global.imglink = mi9imglink;
            }
            if (devicename.Text == "Redmi K20 Pro")
            {
                Global.device = "K20Pro";
                Global.drivelink1 = k20pdrivelink1;
                Global.drivelink2 = k20pdrivelink2;
                Global.drivelink3 = k20pdrivelink3;
                Global.imglink = k20pimglink;
            }
            if (devicename.Text == "小米6")
            {
                Global.device = "MI6";
                Global.drivelink1 = mi6drivelink;
                Global.imglink = mi6imglink;
            }
            if (devicename.Text == "小米MIX2")
            {
                Global.device = "MIX2";
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            int isen = Language.IndexOf("en");
            if (Language == "zh-CN" || isen != -1)
            {
                Setdevice();
                Mindows.Disdevice();
                string mindowspath = String.Format(@"{0}\data\mindows", exepath);
                if (Directory.Exists(mindowspath))
                {
                    if (Global.device != "")
                    {
                        bool stardownload = true;
                        try
                        {
                            File.Delete(@"data\mindows\driver.7z.001");
                            File.Delete(@"data\mindows\driver.7z.002");
                            File.Delete(@"data\mindows\driver.7z.003");
                            File.Delete(@"data\mindows\img.7z.001");
                        }
                        catch
                        {
                            MessageBox.Show("删除临时文件失败，请重启应用后再尝试下载！", "提示！");
                            stardownload = false;
                        }
                        if (stardownload)
                        {
                            mindowspath = String.Format(@"{0}\data\mindows\img", exepath);
                            if (Global.drivelink1 != "" || Global.imglink != "")
                            {
                                if (!Directory.Exists(mindowspath))
                                {
                                    if (Global.warn)
                                    {
                                        DeviceWarn form2 = new DeviceWarn();
                                        form2.Show();
                                    }
                                    else
                                    {
                                        Download form2 = new Download();
                                        form2.Show();
                                    }
                                }
                                else
                                {
                                    DialogResult result;
                                    result = MessageBox.Show("您已下载资源！是否重新下载？", "提示", MessageBoxButtons.YesNo);
                                    if (result == DialogResult.Yes)
                                    {
                                        Mindows.DeleteFolder(@"data\mindows\driver");
                                        Mindows.DeleteFolder(@"data\mindows\img");
                                        if (Global.warn)
                                        {
                                            DeviceWarn form2 = new DeviceWarn();
                                            form2.Show();
                                        }
                                        else
                                        {
                                            Download form2 = new Download();
                                            form2.Show();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("未能获取下载链接，请确认网络正常并重启程序！", "提示！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择机型！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("文件夹丢失！", "提示！");
                }
            }
            else
            {
                MessageBox.Show("当前系统语言无法运行此功能，仅支持简体中文和英语！\n\rThe current system language cannot run this function, only Chinese and English are supported!", "提示");
            }
        }

        private void openmindows_Click(object sender, EventArgs e)
        {
            int isen = Language.IndexOf("en");
            if (Language == "zh-CN" || isen != -1)
            {
                Setdevice();
                Checkcon();
                Mindows.Disdevice();
                if (conninfo.Text == "Fastboot")
                {
                    string mindowspath1 = String.Format(@"{0}\data\mindows\img\uefi.img", exepath);
                    string mindowspath2 = String.Format(@"{0}\data\mindows\img\automass.img", exepath);
                    string mindowspath3 = String.Format(@"{0}\data\mindows\img\recovery.img", exepath);
                    if (File.Exists(mindowspath1) && File.Exists(mindowspath2) && File.Exists(mindowspath3))
                    {
                        if (Global.device != "")
                        {
                            DialogResult result;
                            result = MessageBox.Show("请确保设备已格式化Data分区！", "提示", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                DownloadWindows form2 = new DownloadWindows();
                                form2.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择机型！", "提示！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先下载资源！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            }
            else
            {
                MessageBox.Show("当前系统语言无法运行此功能，仅支持简体中文和英语！\n\rThe current system language cannot run this function, only Chinese and English are supported!", "提示");
            }
        }

        private void choseuefi_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                uefifilename.Text = fileDialog.FileName;
            }
        }

        private void flashuefiboot_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (uefifilename.Text != "")
                    {
                        flashuefiboot.Enabled = false;
                        flashuefiboota.Enabled = false;
                        flashuefibootb.Enabled = false;
                        flashuefirec.Enabled = false;
                        bootuefi.Enabled = false;
                        string file = uefifilename.Text;
                        string shell = String.Format("flash boot \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("刷入成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashuefiboot.Enabled = true;
                        flashuefiboota.Enabled = true;
                        flashuefibootb.Enabled = true;
                        flashuefirec.Enabled = true;
                        bootuefi.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择UEFI文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashuefiboota_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (uefifilename.Text != "")
                    {
                        flashuefiboot.Enabled = false;
                        flashuefiboota.Enabled = false;
                        flashuefibootb.Enabled = false;
                        flashuefirec.Enabled = false;
                        bootuefi.Enabled = false;
                        string file = uefifilename.Text;
                        string shell = String.Format("flash boot_a \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("刷入成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashuefiboot.Enabled = true;
                        flashuefiboota.Enabled = true;
                        flashuefibootb.Enabled = true;
                        flashuefirec.Enabled = true;
                        bootuefi.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择UEFI文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashuefibootb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (uefifilename.Text != "")
                    {
                        flashuefiboot.Enabled = false;
                        flashuefiboota.Enabled = false;
                        flashuefibootb.Enabled = false;
                        flashuefirec.Enabled = false;
                        bootuefi.Enabled = false;
                        string file = uefifilename.Text;
                        string shell = String.Format("flash boot_b \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("刷入成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashuefiboot.Enabled = true;
                        flashuefiboota.Enabled = true;
                        flashuefibootb.Enabled = true;
                        flashuefirec.Enabled = true;
                        bootuefi.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择UEFI文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashuefirec_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (uefifilename.Text != "")
                    {
                        flashuefiboot.Enabled = false;
                        flashuefiboota.Enabled = false;
                        flashuefibootb.Enabled = false;
                        flashuefirec.Enabled = false;
                        bootuefi.Enabled = false;
                        string file = uefifilename.Text;
                        string shell = String.Format("flash recovery \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("刷入成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashuefiboot.Enabled = true;
                        flashuefiboota.Enabled = true;
                        flashuefibootb.Enabled = true;
                        flashuefirec.Enabled = true;
                        bootuefi.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择UEFI文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void bootuefi_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (uefifilename.Text != "")
                    {
                        flashuefiboot.Enabled = false;
                        flashuefiboota.Enabled = false;
                        flashuefibootb.Enabled = false;
                        flashuefirec.Enabled = false;
                        bootuefi.Enabled = false;
                        string file = uefifilename.Text;
                        string shell = String.Format("boot \"{0}\"", file);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("启动成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("启动失败！", "提示");
                        }
                        flashuefiboot.Enabled = true;
                        flashuefiboota.Enabled = true;
                        flashuefibootb.Enabled = true;
                        flashuefirec.Enabled = true;
                        bootuefi.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择UEFI文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }


        private void reboot_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string filepath = "";
                    string filepath1 = String.Format(@"{0}\backup\boot.img", exepath);
                    string filepath2 = String.Format(@"{0}\backup\boot_a.img", exepath);
                    string filepath3 = String.Format(@"{0}\backup\boot_b.img", exepath);
                    if (File.Exists(filepath1))
                    {
                        filepath = filepath1;
                    }
                    else if (File.Exists(filepath2))
                    {
                        filepath = filepath2;
                    }
                    else if (File.Exists(filepath3))
                    {
                        filepath = filepath3;
                    }
                    if (filepath != "")
                    {
                        reboot.Enabled = false;
                        rebootb.Enabled = false;
                        reboota.Enabled = false;
                        string shell = String.Format("flash boot \"{0}\"", filepath);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("恢复成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("恢复失败！", "提示");
                        }
                        reboot.Enabled = true;
                        rebootb.Enabled = true;
                        reboota.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("未找到备份文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void rebootb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string filepath = "";
                    string filepath1 = String.Format(@"{0}\backup\boot.img", exepath);
                    string filepath2 = String.Format(@"{0}\backup\boot_a.img", exepath);
                    string filepath3 = String.Format(@"{0}\backup\boot_b.img", exepath);
                    if (File.Exists(filepath1))
                    {
                        filepath = filepath1;
                    }
                    else if (File.Exists(filepath2))
                    {
                        filepath = filepath2;
                    }
                    else if (File.Exists(filepath3))
                    {
                        filepath = filepath3;
                    }
                    if (filepath != "")
                    {
                        reboot.Enabled = false;
                        rebootb.Enabled = false;
                        reboota.Enabled = false;
                        string shell = String.Format("flash boot_b \"{0}\"", filepath);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("恢复成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("恢复失败！", "提示");
                        }
                        reboot.Enabled = true;
                        rebootb.Enabled = true;
                        reboota.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("未找到备份文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void reboota_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string filepath = "";
                    string filepath1 = String.Format(@"{0}\backup\boot.img", exepath);
                    string filepath2 = String.Format(@"{0}\backup\boot_a.img", exepath);
                    string filepath3 = String.Format(@"{0}\backup\boot_b.img", exepath);
                    if (File.Exists(filepath1))
                    {
                        filepath = filepath1;
                    }
                    else if (File.Exists(filepath2))
                    {
                        filepath = filepath2;
                    }
                    else if (File.Exists(filepath3))
                    {
                        filepath = filepath3;
                    }
                    if (filepath != "")
                    {
                        reboot.Enabled = false;
                        rebootb.Enabled = false;
                        reboota.Enabled = false;
                        string shell = String.Format("flash boot_a \"{0}\"", filepath);
                        int sf = ADBHelper.Fastboot(shell).IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("恢复成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("恢复失败！", "提示");
                        }
                        reboot.Enabled = true;
                        rebootb.Enabled = true;
                        reboota.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("未找到备份文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void formatesp_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "formatesp";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void formatwin_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "formatwin";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void installdrive_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "installdrive";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void repart_Click(object sender, EventArgs e)
        {
            Checkcon();
            if (conninfo.Text == "Recovery")
            {
                Setdevice();
                if (Global.device != "")
                {
                    string mindowspath = String.Format(@"{0}\data\mindows\img\recovery.img", exepath);
                    if (File.Exists(mindowspath))
                    {
                        DialogResult result;
                        result = MessageBox.Show("此操作将完全移除Windows部分！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Global.moreability = "repart";
                            Form form = new MindowsTools();
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("未下载资源！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("未选择机型！", "提示！");
                }
            }
            else
            {
                MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
            }
        }

        private void reinstall_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式，并确保已将ESP与Windows分区格式化！\r\n注意：此过程不会安装驱动程序及UEFI，也不会禁用驱动签名验证！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "installwin";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void fixdisk_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://jq.qq.com/?_wv=1027&k=xPu36sWg");
        }

        private void mindows_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://mindows.cn");
        }

        private void video_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://www.bilibili.com/video/BV14K411m7kh/?vd_source=59c579e6c375d28379745bc533788883");
        }

        private void ISO_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://www.123pan.com/s/8eP9-BkTGA");
        }

        private void ISOs_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://uupdump.cn/");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://flarecloud.cn/");
        }

        private void openbackup_Click(object sender, EventArgs e)
        {
            string filepath = String.Format(@"{0}\backup", exepath);
            Process.Start("Explorer.exe", filepath);
        }

        private void fixesp_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！\n\r注意：此过程不会禁用驱动签名验证！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "fixesp";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void disdsv_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "disdsv";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void esppon_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    ADBHelper.ADB("push bin/linux/parted /tmp/");
                    ADBHelper.ADB("shell chmod +x /tmp/parted");
                    string parttable = ADBHelper.ADB("shell /tmp/parted /dev/block/sda print");
                    if (parttable.IndexOf("esp") != -1)
                    {
                        int espno = Mindows.Onlynum(Mindows.Partno(parttable, "esp"));
                        string shell = String.Format("shell /tmp/parted /dev/block/sda set {0} esp on", espno);
                        ADBHelper.ADB(shell);
                        MessageBox.Show("执行完成！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("未找到ESP分区！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void flashdevcfg_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string filepath = String.Format(@"{0}\data\mindows\img\devcfg.img", exepath);
                    if (File.Exists(filepath))
                    {
                        flashdevcfg.Enabled = false;
                        int sf = ADBHelper.Fastboot(@"flash devcfg_ab data\mindows\img\devcfg.img").IndexOf("FAILED");
                        if (sf == -1)
                        {
                            MessageBox.Show("刷入成功！", "提示");
                        }
                        else
                        {
                            MessageBox.Show("刷入失败！", "提示");
                        }
                        flashdevcfg.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("你的设备无需刷入此文件或未下载资源！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void removedrive_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "removedrive";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void mass_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string filepath = String.Format(@"{0}\data\mindows\img\automass.img", exepath);
                    if (File.Exists(filepath))
                    {
                        DialogResult result;
                        result = MessageBox.Show("临时启动存在风险，请确保当前Boot为安卓Boot！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            mass.Enabled = false;
                            int sf = ADBHelper.Fastboot(@"boot data\mindows\img\automass.img").IndexOf("FAILED");
                            if (sf == -1)
                            {
                                MessageBox.Show("启动成功！", "提示");
                            }
                            else
                            {
                                MessageBox.Show("启动失败！", "提示");
                            }
                            mass.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("未下载资源！！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //注册表相关
        private void noweboobe_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "noweboobe";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void oobeerror_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(delegate ()
            {
                Setdevice();
                if (Global.device != "")
                {
                    if (Mindows.Whoami("").IndexOf("system") != -1)
                    {
                        DialogResult result;
                        result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            Global.moreability = "oobeerror";
                            Form form = new MindowsTools();
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show("当前运行权限不够，将自动重启应用并提升权限！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string shell = String.Format(@"-U:S -P:E -M:S -CurrentDirectory:{0} {1}\柚坛搞机工具箱.exe", exepath, exepath);
                            Mindows.NSudoLC(shell);
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未选择机型！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void usbmode_Click(object sender, EventArgs e)
        {
            Setdevice();
            if (Global.device != "")
            {
                DialogResult result;
                result = MessageBox.Show("请先将设备进入大容量模式！", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Global.moreability = "usbmode";
                    Form form = new MindowsTools();
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("未选择机型！", "提示！");
            }
        }

        private void unloadreg_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(delegate ()
            {
                string reg = Mindows.Reg(@"unload HKEY_LOCAL_MACHINE\Mindows");
                if (reg.IndexOf("参数错误") != -1 || reg.IndexOf("parameter is incorrect") != -1)
                {
                    DialogResult result;
                    result = MessageBox.Show("未找到挂载的注册表，是否进行挂载？", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Global.moreability = "loadreg";
                        Form form = new MindowsTools();
                        form.ShowDialog();
                    }
                }
                else if (reg.IndexOf("拒绝访问") != -1 || reg.IndexOf("Access is denied") != -1)
                {
                    MessageBox.Show("卸载注册表失败，请重启程序再尝试卸载！", "提示！");
                }
                else if (reg.IndexOf("操作成功完成") != -1 || reg.IndexOf("operation completed successfully") != -1)
                {
                    MessageBox.Show("卸载注册表成功！", "提示！");
                }
                else
                {
                    MessageBox.Show("未知错误，请联系开发：" + reg, "提示！");
                }
            });
            t1.SetApartmentState(ApartmentState.STA);
            t1.IsBackground = true;
            t1.Start();
        }

        //线刷专区

        //实时显示FastBoot输出的方法，两个都是！
        public void FBontime(string fb)
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void Bat(string batpatch, string exepatch)//调用Bat
        {
            string wkdir = String.Format(@"{0}\bin\adb", exepatch);
            Process process = null;
            process = new Process();
            process.StartInfo.FileName = batpatch;
            process.StartInfo.WorkingDirectory = wkdir;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }

        public void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(flashshow.Text);
                flashshow.Text = sb.AppendLine(outLine.Data).ToString();
                flashshow.SelectionStart = flashshow.Text.Length;
                flashshow.ScrollToCaret();
            }
        }

        private void choicefastboottxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "TXT文件|*fastboot.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fastboottxt.Text = fileDialog.FileName;
            }
        }

        private void choicefastbootdtxt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "TXT文件|*fastbootd.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fastbootdtxt.Text = fileDialog.FileName;
            }
        }

        private void choicebat_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "BAT文件|flash*.bat";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                battxt.Text = fileDialog.FileName;
            }
        }

        //一些只能写在这的函数
        public void WriteShow()//将输出框的内容写入txt
        {
            output = flashshow.Text;
            Mindows.Write(@"log\fastboot.txt", output);
        }

        //允许取消选择
        bool rbcheck = false;
        private void erasdata_Click(object sender, EventArgs e)
        {
            if (rbcheck)
            {
                rbcheck = false;
                erasdata.Checked = false;
            }
            else
            {
                erasdata.Checked = true;
                rbcheck = true;
            }
        }

        private void flashbat_Click(object sender, EventArgs e)
        {
            if (rbcheck)
            {
                rbcheck = false;
                flashbat.Checked = false;
            }
            else
            {
                flashbat.Checked = true;
                rbcheck = true;
            }
        }

        private void startflash_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                erasdata.Enabled = false;
                flashbat.Enabled = false;
                choicefastbootdtxt.Enabled = false;
                choicefastboottxt.Enabled = false;
                choicebat.Enabled = false;
                startflash.Enabled = false;
                seta.Enabled = false;
                setb.Enabled = false;
                flashshow.Text = "";
                bool succ = true;
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (flashbat.Checked)
                    {
                        if (battxt.Text != "")
                        {
                            Bat(battxt.Text, exepath);
                            erasdata.Enabled = true;
                            flashbat.Enabled = true;
                            choicefastbootdtxt.Enabled = true;
                            choicefastboottxt.Enabled = true;
                            choicebat.Enabled = true;
                            startflash.Enabled = true;
                            seta.Enabled = true;
                            setb.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("请选择刷机文件！", "提示");
                        }
                    }
                    else
                    {
                        if (fastbootdtxt.Text != "" || fastboottxt.Text != "")
                        {
                            string fbtxt = fastboottxt.Text;
                            string fbdtxt = fastbootdtxt.Text;
                            string imgpath;
                            if (fastboottxt.Text != "")
                            {
                                imgpath = fbtxt.Substring(0, fbtxt.LastIndexOf(@"\")) + @"\images";
                                string fbparts = Mindows.Readtxt(fbtxt);
                                char[] charSeparators = new char[] { '\r', '\n' };
                                string[] fbflashparts = fbparts.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                //机型识别
                                int c = 0;
                                if (fbflashparts[c].IndexOf("codename") !=  -1)
                                {
                                    string codename = productinfo.Text;
                                    string[] lines = fbflashparts[c].Split(':');
                                    string devicename = lines[1];
                                    c = 1;
                                    if (codename != devicename)
                                    {
                                        flashshow.Text = "机型错误！";
                                        MessageBox.Show("机型错误无法刷入！", "提示");
                                        succ = false;
                                        erasdata.Enabled = true;
                                        flashbat.Enabled = true;
                                        choicefastbootdtxt.Enabled = true;
                                        choicefastboottxt.Enabled = true;
                                        choicebat.Enabled = true;
                                        startflash.Enabled = true;
                                        seta.Enabled = true;
                                        setb.Enabled = true;
                                        return;
                                    }
                                }
                                for (int i = 0 + c; i < fbflashparts.Length; i++)
                                {
                                    string shell = String.Format("flash {0} \"{1}\\{2}.img\"", fbflashparts[i], imgpath, fbflashparts[i]);
                                    FBontime(shell);
                                    WriteShow();
                                    if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                    {
                                        succ = false;
                                        break;
                                    }
                                }
                            }
                            if (fastbootdtxt.Text != "" && succ)
                            {
                                FBontime("reboot fastboot");
                                WriteShow();
                                if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                {
                                    MessageBox.Show("未能重启到Fastbootd模式！无法继续刷入！", "提示");
                                    succ = false;
                                    erasdata.Enabled = true;
                                    flashbat.Enabled = true;
                                    choicefastbootdtxt.Enabled = true;
                                    choicefastboottxt.Enabled = true;
                                    choicebat.Enabled = true;
                                    startflash.Enabled = true;
                                    seta.Enabled = true;
                                    setb.Enabled = true;
                                    return;
                                }
                                imgpath = fbdtxt.Substring(0, fbdtxt.LastIndexOf(@"\")) + @"\images";
                                string fbdparts = Mindows.Readtxt(fbdtxt);
                                char[] charSeparators = new char[] { '\r', '\n' };
                                string[] fbdflashparts = fbdparts.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                int c = 0;
                                if (fbdflashparts[c].IndexOf("codename") != -1)
                                {
                                    string codename = productinfo.Text;
                                    string[] lines = fbdflashparts[c].Split(':');
                                    string devicename = lines[1];
                                    c = 1;
                                    if (codename != devicename)
                                    {
                                        flashshow.Text = "机型错误！";
                                        MessageBox.Show("机型错误无法刷入！", "提示");
                                        succ = false;
                                        erasdata.Enabled = true;
                                        flashbat.Enabled = true;
                                        choicefastbootdtxt.Enabled = true;
                                        choicefastboottxt.Enabled = true;
                                        choicebat.Enabled = true;
                                        startflash.Enabled = true;
                                        seta.Enabled = true;
                                        setb.Enabled = true;
                                        return;
                                    }
                                }
                                string slot = "";
                                string active = ADBHelper.Fastboot("getvar current-slot");
                                if (active.IndexOf("current-slot: a") != -1)
                                {
                                    slot = "_a";
                                }
                                else if (active.IndexOf("current-slot: b") != -1)
                                {
                                    slot = "_b";
                                }
                                else if (active.IndexOf("FAILED") != -1)
                                {
                                    slot = "";
                                }
                                string[] parts = new string[] {"odm", "system", "system_ext", "product", "vendor", "mi_ext"};
                                for (int i = 0; i < parts.Length; i++)
                                {
                                    string cowpart = String.Format("{0}{1}-cow", parts[i], slot);
                                    int cow = ADBHelper.Fastboot("getvar all").IndexOf(cowpart);
                                    if (cow != -1)
                                    {
                                        string shell = String.Format("delete-logical-partition {0}", cowpart);
                                        FBontime(shell);
                                    }
                                    WriteShow();
                                    if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                    {
                                        succ = false;
                                        break;
                                    }
                                }
                                if (slot != "")
                                {
                                    string deleteslot = "";
                                    if (slot == "_a")
                                    {
                                        deleteslot = "_b";
                                    }
                                    else if (slot == "_b")
                                    {
                                        deleteslot = "_a";
                                    }
                                    for (int i = 0; i < parts.Length; i++)
                                    {
                                        string deletepart = String.Format("{0}{1}", parts[i], deleteslot);
                                        string find = String.Format(":{0}:", deletepart);
                                        int part = ADBHelper.Fastboot("getvar all").IndexOf(find);
                                        if (part != -1)
                                        {
                                            string shell = String.Format("delete-logical-partition {0}", deletepart);
                                            FBontime(shell);
                                        }
                                        WriteShow();
                                        if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                        {
                                            succ = false;
                                            break;
                                        }
                                    }
                                }
                                for (int i = 0 + c; i < fbdflashparts.Length; i++)
                                {
                                    string deletepart = String.Format("{0}{1}", fbdflashparts[i], slot);
                                    string shell = String.Format("delete-logical-partition {0}", deletepart);
                                    FBontime(shell);
                                    WriteShow();
                                    if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                    {
                                        succ = false;
                                        break;
                                    }
                                }
                                for (int i = 0 + c; i < fbdflashparts.Length; i++)
                                {
                                    string makepart = String.Format("{0}{1}", fbdflashparts[i], slot);
                                    string shell = String.Format("create-logical-partition {0} 00", makepart);
                                    FBontime(shell);
                                    WriteShow();
                                    if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                    {
                                        succ = false;
                                        break;
                                    }
                                }
                                if (succ)
                                {
                                    for (int i = 0 + c; i < fbdflashparts.Length; i++)
                                    {
                                        string shell = String.Format("flash {0} \"{1}\\{2}.img\"", fbdflashparts[i], imgpath, fbdflashparts[i]);
                                        FBontime(shell);
                                        WriteShow();
                                        if (output.IndexOf("FAILED") != -1 || output.IndexOf("error") != -1)
                                        {
                                            succ = false;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (erasdata.Checked == true && succ)
                            {
                                FBontime("erase metadata");
                                FBontime("erase userdata");
                            }
                            if (succ)
                            {
                                DialogResult result;
                                result = MessageBox.Show("ROM刷入完成！是否重启到系统？", "提示", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    FBontime("reboot");
                                }
                            }
                            else
                            {
                                MessageBox.Show("刷入出现错误，请检查日志！", "提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择刷机文件！", "提示");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
                erasdata.Enabled = true;
                flashbat.Enabled = true;
                choicefastbootdtxt.Enabled = true;
                choicefastboottxt.Enabled = true;
                choicebat.Enabled = true;
                startflash.Enabled = true;
                seta.Enabled = true;
                setb.Enabled = true;
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void seta_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    FBontime("set_active a");
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void setb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    FBontime("set_active b");
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //更多线刷

        //Fastboot实时输出方法，两个都是，作用于自定义刷入的输入框，目前没有办法解决多个输出框的问题只能复用一遍。

        public void FBontime4(string fb)
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler3);
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
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void QSaharaServer(string fb)//QSaharaServer实时输出
        {
            string cmd = @"bin\9008\QSaharaServer.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void Fhloader(string fb)//Fhloader实时输出
        {
            string cmd = @"bin\9008\fh_loader.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler3);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void OutputHandler3(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(flashshow3.Text);
                flashshow3.Text = sb.AppendLine(outLine.Data).ToString();
                flashshow3.SelectionStart = flashshow3.Text.Length;
                flashshow3.ScrollToCaret();
            }
        }

        private void choicezip_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "刷机包|*.zip";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtadbflash.Text = fileDialog.FileName;
            }
        }

        private void adbflash_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Sideload")
                {
                    if (txtadbflash.Text != "")
                    {
                        adbflash.Enabled = false;
                        flashshow3.Text = "";
                        string shell = String.Format("sideload \"{0}\"",txtadbflash.Text);
                        ADB(shell);
                        MessageBox.Show("执行完成！", "提示");
                        adbflash.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择刷机包！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Sideload模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicefastbootzip_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "刷机包|*.zip";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtfastbootzip.Text = fileDialog.FileName;
            }
        }

        private void fastbootflashzip_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (txtfastbootzip.Text != "")
                    {
                        fastbootflashzip.Enabled = false;
                        flashshow3.Text = "";
                        string shell = String.Format("update \"{0}\"", txtfastbootzip.Text);
                        FBontime4(shell);
                        MessageBox.Show("执行完成！", "提示");
                        fastbootflashzip.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择刷机包！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Fastboot模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choiceelf_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "ELF文件|*firehose*.elf";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txt9008elf.Text = fileDialog.FileName;
            }
        }

        private void choicexml_Click(object sender, EventArgs e)
        {
            txtxmlfile.Text = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "选择RawProgram文件";
            fileDialog.Filter = "XML文件|rawprogram*.xml;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fileDialog.FileNames.Length; i++)
                {
                    if (i != fileDialog.FileNames.Length - 1)
                    {
                        txtxmlfile.Text += String.Format("{0},", Path.GetFileName(fileDialog.FileNames[i]));
                    }
                    else
                    {
                        txtxmlfile.Text += String.Format("{0}", Path.GetFileName(fileDialog.FileNames[i]));
                    }
                }
            }
            OpenFileDialog fileDialog2 = new OpenFileDialog();
            fileDialog2.Multiselect = true;
            fileDialog2.Title = "选择Patch文件";
            fileDialog2.Filter = "XML文件|patch*.xml";
            if (fileDialog2.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fileDialog2.FileNames.Length; i++)
                {
                    txtxmlfile.Text += String.Format(",{0}", Path.GetFileName(fileDialog2.FileNames[i]));
                }
            }
        }

        private void flash9008_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                if (txt9008elf.Text != "" && txtxmlfile.Text != "")
                {
                    ufs.Enabled = false;
                    emmc.Enabled = false;
                    flash9008.Enabled = false;
                    flashshow3.Text = "";
                    string storage = "";
                    if (ufs.Checked)
                        storage = "UFS";
                    if (emmc.Checked)
                        storage = "EMMC";
                    string usbdevices = Mindows.Devcon("find usb*");
                    if (usbdevices.IndexOf("QDLoader") != -1)
                    {
                        string com = Mindows.FindEDLCom(usbdevices);
                        string elf = txt9008elf.Text;
                        string imgdir = Path.GetDirectoryName(elf);
                        string xml = txtxmlfile.Text;
                        string shell = String.Format(@"-p \\.\{0} -s 13:{1}",com ,elf);
                        QSaharaServer(shell);
                        shell = String.Format(@"--port=\\.\{0} --search_path={1} --memoryname={2} --noprompt --sendxml={3} --zlpawarehost=1 --reset", com ,imgdir ,storage ,xml);
                        Fhloader(shell);
                    }
                    else
                    {
                        MessageBox.Show("请将设备进入9008模式！", "提示！");
                    }
                    ufs.Enabled = true;
                    emmc.Enabled = true;
                    flash9008.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请选择ELF和XML文件！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //自定义刷入

        //Fastboot实时输出方法，两个都是，作用于自定义刷入的输入框，目前没有办法解决多个输出框的问题只能复用一遍。
        public void FBontime2(string fb)
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler2);
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void OutputHandler2(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(flashshow2.Text);
                flashshow2.Text = sb.AppendLine(outLine.Data).ToString();
                flashshow2.SelectionStart = flashshow2.Text.Length;
                flashshow2.ScrollToCaret();
            }
        }
        private void choicesystem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                systemfile.Text = fileDialog.FileName;
            }
        }

        private void flashsystem_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (systemfile.Text != "")
                    {
                        choicesystem.Enabled = false;
                        flashsystem.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = systemfile.Text;
                        string shell = String.Format("flash system \"{0}\"", file);
                        FBontime2(shell);
                        choicesystem.Enabled = true;
                        flashsystem.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void chioceboot_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                bootfile.Text = fileDialog.FileName;
            }
        }

        private void flashboot_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (bootfile.Text != "")
                    {
                        choiceboot.Enabled = false;
                        flashboot.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = bootfile.Text;
                        string shell = String.Format("flash boot \"{0}\"", file);
                        FBontime2(shell);
                        choiceboot.Enabled = true;
                        flashboot.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicevendor_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                vendorfile.Text = fileDialog.FileName;
            }
        }

        private void flashvendor_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (vendorfile.Text != "")
                    {
                        choicevendor.Enabled = false;
                        flashvendor.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = vendorfile.Text;
                        string shell = String.Format("flash vendor \"{0}\"", file);
                        FBontime2(shell);
                        choicevendor.Enabled = true;
                        flashvendor.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicevendorboot_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                vendorbootfile.Text = fileDialog.FileName;
            }
        }

        private void flashvendorboot_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (vendorbootfile.Text != "")
                    {
                        choicevendorboot.Enabled = false;
                        flashvendorboot.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = vendorbootfile.Text;
                        string shell = String.Format("flash vendor_boot \"{0}\"", file);
                        FBontime2(shell);
                        choicevendorboot.Enabled = true;
                        flashvendorboot.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choicesystemext_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                systemextfile.Text = fileDialog.FileName;
            }
        }

        private void flashsystemext_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (systemextfile.Text != "")
                    {
                        choicesystemext.Enabled = false;
                        flashsystemext.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = systemextfile.Text;
                        string shell = String.Format("flash system_ext \"{0}\"", file);
                        FBontime2(shell);
                        choicesystemext.Enabled = true;
                        flashsystemext.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void chioceproduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                productfile.Text = fileDialog.FileName;
            }
        }

        private void flashproduct_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (productfile.Text != "")
                    {
                        chioceproduct.Enabled = false;
                        flashproduct.Enabled = false;
                        flashshow2.Text = "正在刷入......";
                        string file = productfile.Text;
                        string shell = String.Format("flash product \"{0}\"", file);
                        FBontime2(shell);
                        chioceproduct.Enabled = true;
                        flashproduct.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void choiceimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                imgfile.Text = fileDialog.FileName;
            }
        }

        private void flashimg_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (imgfile.Text != "")
                    {
                        if (parts.Text != "")
                        {
                            choiceimg.Enabled = false;
                            flashimg.Enabled = false;
                            flashshow2.Text = "正在刷入......";
                            string file = imgfile.Text;
                            string part = parts.Text;
                            string shell = String.Format("flash {0} \"{1}\"", part, file);
                            FBontime2(shell);
                            choiceimg.Enabled = true;
                            flashimg.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("请选指定分区！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void disablevbmeta_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    string shell = String.Format("flash vbmeta bin/img/vbmeta.img");
                    FBontime2(shell);
                }
                else if (conninfo.Text == "Recovery")
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
                else
                {
                    MessageBox.Show("设备未连接", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void setother_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    FBontime2("set_active other");
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //格式化分区

        public void ADB2(string fb)//ADB实时输出
        {
            string cmd = @"bin\adb\adb.exe";
            ProcessStartInfo adb = null;
            adb = new ProcessStartInfo(cmd, fb);
            adb.CreateNoWindow = true;
            adb.UseShellExecute = false;
            adb.RedirectStandardOutput = true;
            adb.RedirectStandardError = true;
            Process f = Process.Start(adb);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler4);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler4);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void FBontime3(string fb)
        {
            string cmd = @"bin\adb\fastboot.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler4);
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void OutputHandler4(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(flashshow4.Text);
                flashshow4.Text = sb.AppendLine(outLine.Data).ToString();
                flashshow4.SelectionStart = flashshow4.Text.Length;
                flashshow4.ScrollToCaret();
            }
        }

        private void format_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    if (txtformatpart.Text != "")
                    {
                        format.Enabled = false;
                        formatdata.Enabled = false;
                        twrpformatdata.Enabled = false;
                        fastbootformat.Enabled = false;
                        flashshow4.Text = "";
                        string formatsystem = "";
                        if (ext4.Checked)
                            formatsystem = "mke2fs -t ext4";
                        if (f2fs.Checked)
                            formatsystem = "/tmp/mkfs.f2fs";
                        if (fat32.Checked)
                            formatsystem = "mkfs.fat -F32 -s1";
                        if (ntfs.Checked)
                            formatsystem = "/tmp/mkntfs -f";
                        if (exfat.Checked)
                            formatsystem = "mkexfatfs -n exfat";
                        string partname = txtformatpart.Text;
                        Mindows.GetPartTable();
                        Mindows.PushMakefs();
                        string sdxx = Mindows.FindDisk(partname);
                        if (sdxx != "")
                        {
                            string partnum = Mindows.Partno(Mindows.FindPart(partname), partname);
                            string shell = String.Format("shell {0} /dev/block/{1}{2}", formatsystem, sdxx, partnum);
                            ADB2(shell);
                        }
                        else
                        {
                            flashshow4.Text = "未找到该分区！";
                        }
                        format.Enabled = true;
                        formatdata.Enabled = true;
                        twrpformatdata.Enabled = true;
                        fastbootformat.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要格式化的分区名称！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void formatdata_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    format.Enabled = false;
                    formatdata.Enabled = false;
                    twrpformatdata.Enabled = false;
                    fastbootformat.Enabled = false;
                    flashshow4.Text = "";
                    ADB2("shell recovery --wipe_data");
                    format.Enabled = true;
                    formatdata.Enabled = true;
                    twrpformatdata.Enabled = true;
                    fastbootformat.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void twrpformatdata_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    format.Enabled = false;
                    formatdata.Enabled = false;
                    twrpformatdata.Enabled = false;
                    fastbootformat.Enabled = false;
                    flashshow4.Text = "";
                    ADB2("shell twrp format data");
                    format.Enabled = true;
                    formatdata.Enabled = true;
                    twrpformatdata.Enabled = true;
                    fastbootformat.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void fastbootformatdata_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if(txtformatpart.Text != "")
                    {
                        format.Enabled = false;
                        formatdata.Enabled = false;
                        twrpformatdata.Enabled = false;
                        fastbootformat.Enabled = false;
                        flashshow4.Text = "";
                        string partname = txtformatpart.Text;
                        string shell = String.Format("erase {0}", partname);
                        FBontime3(shell);
                        format.Enabled = true;
                        formatdata.Enabled = true;
                        twrpformatdata.Enabled = true;
                        fastbootformat.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要格式化的分区！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Fastboot模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        public void WriteShow2()//将输出框的内容写入txt
        {
            output = flashshow4.Text;
            Mindows.Write(@"log\adb.txt", output);
        }

        private void extract_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    if (txtextractpart.Text != "")
                    {
                        extract.Enabled = false;
                        extractvm.Enabled = false;
                        flashshow4.Text = "";
                        string partname = txtextractpart.Text;
                        Mindows.GetPartTable();
                        string sdxx = Mindows.FindDisk(partname);
                        if (sdxx != "")
                        {
                            string partnum = Mindows.Partno(Mindows.FindPart(partname), partname);
                            string shell = String.Format(@"shell dd if=/dev/block/{0}{1} of={2}.img", sdxx, partnum, partname);
                            ADB2(shell);
                            WriteShow2();
                            if (output.IndexOf("No space left on device") != -1)
                            {
                                flashshow4.Text = "根目录空间不足，正在尝试使用Data分区...";
                                shell = String.Format(@"shell rm /{0}.img", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell dd if=/dev/block/{0}{1} of=/sdcard/{2}.img", sdxx, partnum, partname);
                                ADB2(shell);
                                shell = String.Format(@"pull /sdcard/{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell rm /sdcard/{0}.img", partname);
                                ADB2(shell);
                            }
                            else
                            {
                                shell = String.Format(@"pull /{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell rm /{0}.img", partname);
                                ADB2(shell);
                            }
                        }
                        else
                        {
                            flashshow4.Text = "未找到该分区!";
                        }
                        extract.Enabled = true;
                        extractvm.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要提取的分区名称！", "提示！");
                    }
                }
                else if (conninfo.Text == "系统")
                {
                    if (txtextractpart.Text != "")
                    {
                        DialogResult result;
                        result = MessageBox.Show("当前为系统模式，在系统下提取分区需要ROOT权限，\n\r请确保手机已ROOT，并在接下来的弹窗中授予 Shell ROOT权限！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            extract.Enabled = false;
                            extractvm.Enabled = false;
                            flashshow4.Text = "";
                            string partname = txtextractpart.Text;
                            Mindows.GetPartTableSystem();
                            string sdxx = Mindows.FindDisk(partname);
                            if (sdxx != "")
                            {
                                string partnum = Mindows.Partno(Mindows.FindPart(partname), partname);
                                string shell = String.Format("shell su -c \"dd if=/dev/block/{0}{1} of=/sdcard/{2}.img\"", sdxx, partnum, partname);
                                ADB2(shell);
                                shell = String.Format(@"pull /sdcard/{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format("shell su -c \"rm /sdcard/{0}.img\"", partname);
                                ADB2(shell);
                            }
                            else
                            {
                                flashshow4.Text = "未找到该分区!";
                            }
                            extract.Enabled = true;
                            extractvm.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入需要提取的分区名称！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式或系统后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void extractvm_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    if (txtextractpart.Text != "")
                    {
                        extract.Enabled = false;
                        extractvm.Enabled = false;
                        flashshow4.Text = "";
                        string partname = txtextractpart.Text;
                        string shell = String.Format("shell ls -l /dev/block/mapper/{0}", partname);
                        string vmpart = ADBHelper.ADB(shell);
                        if (vmpart.IndexOf("No such file or directory") == -1)
                        {
                            char[] charSeparators = new char[] { ' ', '\r', '\n' };
                            string[] line = vmpart.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                            string devicepoint = line[line.Length - 1];
                            shell = String.Format(@"shell dd if={0} of={1}.img", devicepoint, partname);
                            ADB2(shell);
                            WriteShow2();
                            if (output.IndexOf("No space left on device") != -1)
                            {
                                flashshow4.Text = "根目录空间不足，正在尝试使用Data分区...";
                                shell = String.Format(@"shell rm /{0}.img", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell dd if={0} of=/sdcard/{1}.img", devicepoint, partname);
                                ADB2(shell);
                                shell = String.Format(@"pull /sdcard/{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell rm /sdcard/{0}.img", partname);
                                ADB2(shell);
                            }
                            else
                            {
                                shell = String.Format(@"pull /{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format(@"shell rm /{0}.img", partname);
                                ADB2(shell);
                            }
                        }
                        else
                        {
                            flashshow4.Text = "未找到该分区!";
                        }
                        extract.Enabled = true;
                        extractvm.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要提取的分区名称！", "提示！");
                    }
                }
                else if (conninfo.Text == "系统")
                {
                    if (txtextractpart.Text != "")
                    {
                        DialogResult result;
                        result = MessageBox.Show("当前为系统模式，在系统下提取分区需要ROOT权限，\n\r请确保手机已ROOT，并在接下来的弹窗中授予 Shell ROOT权限！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            extract.Enabled = false;
                            extractvm.Enabled = false;
                            flashshow4.Text = "";
                            string partname = txtextractpart.Text;
                            string shell = String.Format("shell su -c \"ls -l /dev/block/mapper/{0}\"", partname);
                            string vmpart = ADBHelper.ADB(shell);
                            if (vmpart.IndexOf("No such file or directory") == -1)
                            {
                                char[] charSeparators = new char[] { ' ', '\r', '\n' };
                                string[] line = vmpart.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                string devicepoint = line[line.Length - 1];
                                shell = String.Format("shell su -c \"dd if={0} of=/sdcard/{1}.img\"", devicepoint, partname);
                                ADB2(shell);
                                shell = String.Format(@"pull /sdcard/{0}.img backup\", partname);
                                ADB2(shell);
                                shell = String.Format("shell su -c \"rm /sdcard/{0}.img\"", partname);
                                ADB2(shell);
                            }
                            else
                            {
                                flashshow4.Text = "未找到该分区!";
                            }
                            extract.Enabled = true;
                            extractvm.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入需要提取的分区名称！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式或系统后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            string filepath = String.Format(@"{0}\backup", exepath);
            Process.Start("Explorer.exe", filepath);
        }

        //修改分区表

        private void readpart_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery" || conninfo.Text == "系统")
                {
                    readpart.Enabled = false;
                    parttable.Items.Clear();
                    if (Global.sdatable == "" && conninfo.Text == "Recovery")
                    {
                        ADBHelper.ADB("shell twrp unmount data");
                    }
                    if (conninfo.Text == "系统")
                    {
                        DialogResult result;
                        result = MessageBox.Show("当前为系统模式，在系统下提取分区需要ROOT权限，\n\r请确保手机已ROOT，并在接下来的弹窗中授予 Shell ROOT权限！", "提示", MessageBoxButtons.YesNo);
                        if (result != DialogResult.Yes)
                        {
                            readpart.Enabled = true;
                            return;
                        }
                        Mindows.GetPartTableSystem();
                    }
                    else
                    {
                        Mindows.GetPartTable();
                    }
                    string choice = "";
                    if (sda.Checked)
                        choice = Global.sdatable;
                    if (sdb.Checked)
                        choice = Global.sdbtable;
                    if (sdc.Checked)
                        choice = Global.sdctable;
                    if (sdd.Checked)
                        choice = Global.sddtable;
                    if (sde.Checked)
                        choice = Global.sdetable;
                    if (sdf.Checked)
                        choice = Global.sdftable;
                    if (emmcrom.Checked)
                        choice = Global.emmcrom;
                    if (choice != "")
                    {
                        string[] parts = choice.Split('\n');
                        if (parts.Length >= 7)
                        {
                            string size = String.Format("磁盘总大小：{0}", Mindows.DiskSize(choice));
                            txtsize.Text = size;
                            for (int i = 7; i < parts.Length - 2; i++)
                            {
                                char[] charSeparators = new char[] { ' ' };
                                string[] items = parts[i].Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                                if (items.Length == 5)
                                {
                                    ListViewItem item = new ListViewItem(items[0]);
                                    item.SubItems.Add(items[1]);
                                    item.SubItems.Add(items[2]);
                                    item.SubItems.Add(items[3]);
                                    item.SubItems.Add("");
                                    item.SubItems.Add(items[4]);
                                    parttable.Items.Add(item);
                                }
                                else if (items.Length == 6)
                                {
                                    ListViewItem item = new ListViewItem(items[0]);
                                    item.SubItems.Add(items[1]);
                                    item.SubItems.Add(items[2]);
                                    item.SubItems.Add(items[3]);
                                    item.SubItems.Add(items[4]);
                                    item.SubItems.Add(items[5]);
                                    parttable.Items.Add(item);
                                }
                                else if (items.Length >= 7)
                                {
                                    ListViewItem item = new ListViewItem(items[0]);
                                    item.SubItems.Add(items[1]);
                                    item.SubItems.Add(items[2]);
                                    item.SubItems.Add(items[3]);
                                    item.SubItems.Add(items[4]);
                                    item.SubItems.Add(items[5]);
                                    item.SubItems.Add(items[6]);
                                    parttable.Items.Add(item);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("分区获取失败！", "提示！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选择需要读取的磁盘！", "提示！");
                    }
                    readpart.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式或系统后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void removepart_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    if (txtpartnum.Text != "")
                    {
                        removepart.Enabled = false;
                        sepon.Enabled = false;
                        string choice = "";
                        if (sda.Checked)
                            choice = "sda";
                        if (sdb.Checked)
                            choice = "sdb";
                        if (sdc.Checked)
                            choice = "sdc";
                        if (sdd.Checked)
                            choice = "sdd";
                        if (sde.Checked)
                            choice = "sde";
                        if (sdf.Checked)
                            choice = "sdf";
                        if (emmcrom.Checked)
                            choice = "mmcblk0";
                        if (choice != "")
                        {
                            Regex regex = new Regex("^(-?[0-9]*[.]*[0-9]{0,3})$");
                            if (regex.IsMatch(txtpartnum.Text))
                            {
                                int partnum = Mindows.Onlynum(txtpartnum.Text);
                                string shell = String.Format("shell /tmp/parted /dev/block/{0} rm {1}", choice, partnum);
                                ADBHelper.ADB(shell);
                                readpart_Click(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("请输入正确的分区序号！", "提示！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("请先选择需要读取的磁盘并读取分区表！", "提示！");
                        }
                        removepart.Enabled = true;
                        sepon.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要删除的分区序号！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void sepon_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    DialogResult result;
                    result = MessageBox.Show("该功能为标记EFI分区，请确认知晓其作用后继续！", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (txtpartnum.Text != "")
                        {
                            removepart.Enabled = false;
                            sepon.Enabled = false;
                            string choice = "";
                            if (sda.Checked)
                                choice = "sda";
                            if (sdb.Checked)
                                choice = "sdb";
                            if (sdc.Checked)
                                choice = "sdc";
                            if (sdd.Checked)
                                choice = "sdd";
                            if (sde.Checked)
                                choice = "sde";
                            if (sdf.Checked)
                                choice = "sdf";
                            if (emmcrom.Checked)
                                choice = "mmcblk0";
                            if (choice != "")
                            {
                                Regex regex = new Regex("^(-?[0-9]*[.]*[0-9]{0,3})$");
                                if (regex.IsMatch(txtpartnum.Text))
                                {
                                    ADBHelper.ADB("push bin/linux/parted /tmp/");
                                    ADBHelper.ADB("shell chmod +x /tmp/parted");
                                    int partnum = Mindows.Onlynum(txtpartnum.Text);
                                    string shell = String.Format("shell /tmp/parted /dev/block/{0} set {1} esp on", choice, partnum);
                                    ADBHelper.ADB(shell);
                                    MessageBox.Show("执行完成！", "提示！");
                                    readpart_Click(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show("请输入正确的分区序号！", "提示！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请先选择需要读取的磁盘并读取分区表！", "提示！");
                            }
                            removepart.Enabled = true;
                            sepon.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("请输入需要标记的分区序号！", "提示！");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void makepart_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    if (txtpartname.Text != "" && txtpartsystem.Text != "" && txtpartstart.Text != "" && txtpartend.Text != "")
                    {
                        makepart.Enabled = false;
                        string choice = "";
                        if (sda.Checked)
                            choice = "sda";
                        if (sdb.Checked)
                            choice = "sdb";
                        if (sdc.Checked)
                            choice = "sdc";
                        if (sdd.Checked)
                            choice = "sdd";
                        if (sde.Checked)
                            choice = "sde";
                        if (sdf.Checked)
                            choice = "sdf";
                        if (emmcrom.Checked)
                            choice = "mmcblk0";
                        if (choice != "")
                        {
                            string partname = txtpartname.Text;
                            string partsystem = txtpartsystem.Text;
                            string partstart = txtpartstart.Text;
                            string partend = txtpartend.Text;
                            string shell = String.Format("shell /tmp/parted /dev/block/{0} mkpart {1} {2} {3} {4}", choice, partname, partsystem, partstart, partend);
                            ADBHelper.ADB(shell);
                            readpart_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("请先选择需要读取的磁盘并读取分区表！", "提示！");
                        }
                        makepart.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入创建分区需要的参数！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void removelimitbutt_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Recovery")
                {
                    removelimitbutt.Enabled = false;
                    string choice = "";
                    if (sda.Checked)
                        choice = "sda";
                    if (sdb.Checked)
                        choice = "";
                    if (sdc.Checked)
                        choice = "sdc";
                    if (sdd.Checked)
                        choice = "sdd";
                    if (sde.Checked)
                        choice = "sde";
                    if (sdf.Checked)
                        choice = "sdf";
                    if (emmcrom.Checked)
                        choice = "mmcblk0";
                    if (choice != "")
                    {
                        DialogResult result;
                        result = MessageBox.Show("此操作会将该磁盘最大分区数量设置为128个\r\n执行成功后将重启Recovery！", "提示", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            ADBHelper.ADB("push bin/linux/sgdisk /tmp/");
                            ADBHelper.ADB("shell chmod +x /tmp/sgdisk");
                            string shell = String.Format("shell /tmp/sgdisk --resize-table=128 /dev/block/{0}", choice);
                            string limit = ADBHelper.ADB(shell);
                            if (limit.IndexOf("completed successfully") == -1)
                            {
                                MessageBox.Show("操作失败！", "提示！");
                            }
                            else
                            {
                                MessageBox.Show("操作成功！", "提示！");
                                ADBHelper.ADB("reboot recovery");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择正确的磁盘！\r\n注：sdb无法执行该指令！", "提示！");
                    }
                    removelimitbutt.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请将设备进入Recovery模式后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //高级功能

        public void QcnTool(string fb)
        {
            string cmd = @"bin\QCN\QCNTool.exe";
            ProcessStartInfo fastboot = null;
            fastboot = new ProcessStartInfo(cmd, fb);
            fastboot.CreateNoWindow = true;
            fastboot.UseShellExecute = false;
            fastboot.RedirectStandardOutput = true;
            fastboot.RedirectStandardError = true;
            Process f = Process.Start(fastboot);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler5);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler5);
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
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler5);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler5);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        public void ADB3(string fb)//ADB实时输出
        {
            string cmd = @"bin\adb\adb.exe";
            ProcessStartInfo adb = null;
            adb = new ProcessStartInfo(cmd, fb);
            adb.CreateNoWindow = true;
            adb.UseShellExecute = false;
            adb.RedirectStandardOutput = true;
            adb.RedirectStandardError = true;
            Process f = Process.Start(adb);
            f.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler5);
            f.OutputDataReceived += new DataReceivedEventHandler(OutputHandler5);
            f.BeginOutputReadLine();
            f.BeginErrorReadLine();
            f.WaitForExit();
            f.Close();
        }

        private void OutputHandler5(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                StringBuilder sb = new StringBuilder(this.shellshow5.Text);
                this.shellshow5.Text = sb.AppendLine(outLine.Data).ToString();
                this.shellshow5.SelectionStart = this.shellshow5.Text.Length;
                this.shellshow5.ScrollToCaret();
            }
        }

        private void choiceqcn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "QCN 文件|*.qcn;*.xqcn";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                qcnfilepatchtxt.Text = fileDialog.FileName;
            }
        }

        private void open901d_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "系统")
                {
                    DialogResult result;
                    result = MessageBox.Show("该操作需要ROOT权限，请确保手机已ROOT，\n\r并在接下来的弹窗中授予 Shell ROOT权限！", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ADBHelper.ADB("shell su -c \"setprop sys.usb.config diag,adb\"");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入系统后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void open9091_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "系统")
                {
                    DialogResult result;
                    result = MessageBox.Show("该操作仅限小米设备！其它设备将无法使用！", "提示", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ADBHelper.ADB("push bin/apk/mi_diag.apk /sdcard");
                        ADBHelper.ADB("shell \"am start -a miui.intent.action.OPEN\"");
                        MessageBox.Show("已将名为\"mi_diag.apk\"的文件推送至设备根目录，请安装完成后点击确定！");
                        ADBHelper.ADB("shell \"am start -n com.longcheertel.midtest/\"");
                        ADBHelper.ADB("shell \"am start -n com.longcheertel.midtest/com.longcheertel.midtest.Diag\"");
                    }
                }
                else
                {
                    MessageBox.Show("请将设备进入系统后执行！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void writeqcn_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "901D" || conninfo.Text == "9091")
                {
                    if (qcnfilepatchtxt.Text != "")
                    {
                        string qcnfilepatch = qcnfilepatchtxt.Text;
                        string usbdevices = Mindows.Devcon("find usb*");
                        if (usbdevices.IndexOf("901D (") != -1 || usbdevices.IndexOf("9091 (") != -1)
                        {
                            writeqcn.Enabled = false;
                            backupqcn.Enabled = false;
                            shellshow5.Text = "正在写入......";
                            int com = Mindows.FindDIAGCom(usbdevices);
                            string shell = String.Format("-w -p {0} -f \"{1}\"", com, qcnfilepatch);
                            QcnTool(shell);
                            shellshow5.Text += "执行完成";
                            writeqcn.Enabled = true;
                            backupqcn.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择QCN文件！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("请先开启901D/9091端口！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void backupqcn_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "901D" || conninfo.Text == "9091")
                {
                    string usbdevices = Mindows.Devcon("find usb*");
                    if (usbdevices.IndexOf("901D (") != -1 || usbdevices.IndexOf("9091 (") != -1)
                    {
                        writeqcn.Enabled = false;
                        backupqcn.Enabled = false;
                        shellshow5.Text = "正在读取......";
                        int com = Mindows.FindDIAGCom(usbdevices);
                        string shell = String.Format(@"-r -p {0} -f {1}\backup -n 00000.qcn", com, exepath);
                        QcnTool(shell);
                        shellshow5.Text += "执行完成";
                        writeqcn.Enabled = true;
                        backupqcn.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("请先开启901D/9091端口！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void openqcn_Click(object sender, EventArgs e)
        {
            string filepath = String.Format(@"{0}\backup", exepath);
            Process.Start("Explorer.exe", filepath);
        }

        private void emptyfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                emptyfilepatch.Text = fileDialog.FileName;
            }
        }

        private void flashempty_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (emptyfilepatch.Text != "")
                    {
                        emptyfile.Enabled = false;
                        flashempty.Enabled = false;
                        shellshow5.Text = "正在刷入......";
                        string file = emptyfilepatch.Text;
                        string shell = String.Format("wipe-super \"{0}\"", file);
                        Fastboot(shell);
                        emptyfile.Enabled = true;
                        flashempty.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请选择文件！", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请进入Fastboot模式！", "提示");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void runadb_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "901D" || conninfo.Text == "系统" || conninfo.Text == "Recovery")
                {
                    if (adbshell.Text != "")
                    {
                        runadb.Enabled = false;
                        shellshow5.Text = "";
                        string shell = adbshell.Text;
                        ADB3(shell);
                        runadb.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要执行的命令！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("当前设备状态无法执行ADB命令！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void runfastboot_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                Checkcon();
                if (conninfo.Text == "Fastboot")
                {
                    if (fastbootshell.Text != "")
                    {
                        runfastboot.Enabled = false;
                        shellshow5.Text = "";
                        string shell = fastbootshell.Text;
                        Fastboot(shell);
                        runfastboot.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("请输入需要执行的命令！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("当前设备状态无法执行Fastboot命令！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        //关于我们
        private void checkv_Click(object sender, EventArgs e)
        {
            t1 = new Thread(delegate ()
            {
                WebConnect("cloud.mjwsjq.top");
                if (Iconnect)
                {
                    GetMessage();
                    if (version == webversion)
                    {
                        MessageBox.Show("当前已是最新版本！", "提示！");
                    }
                }
                else
                {
                    MessageBox.Show("当前无网络连接，请连接网络后检查更新！", "提示！");
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void gouotan_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://www.uotan.cn/");
        }

        private void uotanbilibili_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://space.bilibili.com/522676659");
        }

        private void mjwbilibili_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://space.bilibili.com/620165086");
        }

        private void mjwgithub_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://github.com/mujianwu");
        }

        private void mzbilibili_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://space.bilibili.com/627979759");
        }

        private void rp_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://github.com/edk2-porting");
        }

        private void wm_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://github.com/woa-msmnile");
        }

        private void wp_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://github.com/WOA-Project");
        }

        private void Tools_FormClosing(object sender, FormClosingEventArgs e)
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
