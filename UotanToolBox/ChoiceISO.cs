using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UotanToolBox
{
    public partial class ChoiceISO : Form
    {
        public ChoiceISO()
        {
            InitializeComponent();
        }

        string path = "";
        private void choice_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C:\\";
            fileDialog.Filter = "镜像文件|*.wim";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                path = fileDialog.FileName;
                winpath.Text = path;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (winpath.Text != "")
            {
                Global.wimpath = path;
                if (nodrv.Checked)
                {
                    Global.havedrv = false;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择Windows镜像！", "提示！");
            }
        }
    }
}
