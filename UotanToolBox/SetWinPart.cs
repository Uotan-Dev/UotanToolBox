using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UotanToolBox
{
    public partial class SetWinPart : Form
    {
        public SetWinPart()
        {
            InitializeComponent();
        }

        int maxsize = Global.datasize - 3;
        int minsize = 20;
        private void SetWinPart_Load(object sender, EventArgs e)
        {
            if (Global.datasizeunit != "GB")
            {
                MessageBox.Show("您的Data分区过小，无法安装Windows！", "警告！");
                this.Close();
            }
            else
            {
                datasize.Text = Global.datasize.ToString();
                string wineange = String.Format("20GB-{0}GB", maxsize);
                winsizerange.Text = wineange;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (makesharepart.Checked)
            {
                if (winpartsize.Text != "" || sharepartsizetxt.Text != "")
                {
                    int winsize = Mindows.Onlynum(winpartsize.Text);
                    int sharesize = Mindows.Onlynum(sharepartsizetxt.Text);
                    int totalsize = winsize + sharesize;
                    if (totalsize <= maxsize && totalsize >= minsize)
                    {
                        Global.winsize = winsize;
                        Global.sharepartsize = sharesize;
                        Global.mksharepart = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("您设定的分区大小不在范围内，请重新设定", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请输入Windows分区及共享分区大小", "提示！");
                }
            }
            else
            {
                if (winpartsize.Text != "")
                {
                    int winsize = Mindows.Onlynum(winpartsize.Text);
                    if (winsize <= maxsize && winsize >= minsize)
                    {
                        Global.winsize = winsize;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("您设定的分区大小不在范围内，请重新设定", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("请输入Windows分区大小", "提示！");
                }
            }
        }

        private void makesharepart_CheckedChanged(object sender, EventArgs e)
        {
            if (makesharepart.Checked)
            {
                sharepartsizetxt.Enabled = true;
            }
            else
            {
                sharepartsizetxt.Enabled = false;
            }
        }

        bool rbcheck = false;
        private void makesharepart_Click(object sender, EventArgs e)
        {
            if (rbcheck)
            {
                rbcheck = false;
                makesharepart.Checked = false;
            }
            else
            {
                makesharepart.Checked = true;
                rbcheck = true;
            }
        }
    }
}
