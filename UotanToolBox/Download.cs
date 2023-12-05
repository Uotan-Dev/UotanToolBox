using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UotanToolBox
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }

        Thread t1;
        
        private void Form2_Shown(object sender, EventArgs e)
        {
            Mindows.Disdevice();
            t1 = new Thread(delegate ()
            {
                string link = "";
                if (Global.havedrv)
                {
                    show.Text = "正在获取下载链接";
                    link = Mindows.GetLink(Global.drivelink1);
                    if (link != "")
                    {
                        show.Text = "正在下载驱动程序";
                        Mindows.DownloadFile(link, @"data\mindows\driver.7z.001", schedulebar, schedule);
                    }
                    else
                    {
                        MessageBox.Show("获取下载链接失败", "提示！");
                        this.Close();
                    }
                }
                if (Global.drivelink2 != "")
                {
                    show.Text = "正在获取下载链接";
                    link = Mindows.GetLink(Global.drivelink2);
                    if (link != "")
                    {
                        show.Text = "正在下载驱动程序②";
                        Mindows.DownloadFile(link, @"data\mindows\driver.7z.002", schedulebar, schedule);
                    }
                    else
                    {
                        MessageBox.Show("获取下载链接失败", "提示！");
                        this.Close();
                    }
                }
                if (Global.drivelink3 != "")
                {
                    show.Text = "正在获取下载链接";
                    link = Mindows.GetLink(Global.drivelink3);
                    if (link != "")
                    {
                        show.Text = "正在下载驱动程序③";
                        Mindows.DownloadFile(link, @"data\mindows\driver.7z.003", schedulebar, schedule);
                    }
                    else
                    {
                        MessageBox.Show("获取下载链接失败", "提示！");
                        this.Close();
                    }
                }
                if (Global.imglink != "")
                {
                    show.Text = "正在获取下载链接";
                    link = Mindows.GetLink(Global.imglink);
                    if (link != "")
                    {
                        show.Text = "正在下载镜像文件";
                        Mindows.DownloadFile(link, @"data\mindows\img.7z.001", schedulebar, schedule);
                    }
                    else
                    {
                        MessageBox.Show("获取下载链接失败", "提示！");
                        this.Close();
                    }
                }
                show.Text = "正在解压资源";
                int unzipcheck2 = Mindows.Unzip(new DirectoryInfo(@"data\mindows"), "").IndexOf("Ok");
                if (unzipcheck2 != -1)
                {
                    File.Delete(@"data\mindows\driver.7z.001");
                    File.Delete(@"data\mindows\driver.7z.002");
                    File.Delete(@"data\mindows\driver.7z.003");
                    File.Delete(@"data\mindows\img.7z.001");
                    show.Text = "下载完成，您可以关闭本窗口！";
                }
                else
                {
                    MessageBox.Show("资源解压失败", "提示！");
                    show.Text = "资源解压失败";
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void Download_FormClosing(object sender, FormClosingEventArgs e)
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
