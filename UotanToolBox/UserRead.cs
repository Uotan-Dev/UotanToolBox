using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UotanToolBox
{
    public partial class UserRead : Form
    {
        public UserRead()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (AgreeBottun.Checked)
            {
                MindowsInstall form2 = new MindowsInstall();
                form2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("请仔细阅读并同意以上内容！", "提示！");
            }
        }
    }
}
