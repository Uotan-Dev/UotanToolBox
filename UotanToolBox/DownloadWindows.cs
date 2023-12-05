using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UotanToolBox
{
    public partial class DownloadWindows : Form
    {
        public DownloadWindows()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserRead from = new UserRead();
            from.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mindows.OpenDefaultBrowserUrl("https://www.123pan.com/s/8eP9-BkTGA");
        }
    }
}
