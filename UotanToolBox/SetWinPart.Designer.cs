namespace UotanToolBox
{
    partial class SetWinPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetWinPart));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datasize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.winsizerange = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.winpartsize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.makesharepart = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.sharepartsizetxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(149, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "为Windows分配空间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(59, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "您的Data分区可用空间约为";
            // 
            // datasize
            // 
            this.datasize.AutoSize = true;
            this.datasize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datasize.Location = new System.Drawing.Point(258, 67);
            this.datasize.Name = "datasize";
            this.datasize.Size = new System.Drawing.Size(0, 20);
            this.datasize.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(291, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "GB。请在下面输入你想分配给";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(42, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Windows的空间大小。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(33, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "注意：您设置的空间总和需要在";
            // 
            // winsizerange
            // 
            this.winsizerange.AutoSize = true;
            this.winsizerange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.winsizerange.ForeColor = System.Drawing.Color.Red;
            this.winsizerange.Location = new System.Drawing.Point(253, 115);
            this.winsizerange.Name = "winsizerange";
            this.winsizerange.Size = new System.Drawing.Size(0, 20);
            this.winsizerange.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(359, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "范围内,且不能有小数！";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(101, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Windows分区大小：";
            // 
            // winpartsize
            // 
            this.winpartsize.Location = new System.Drawing.Point(258, 165);
            this.winpartsize.Name = "winpartsize";
            this.winpartsize.Size = new System.Drawing.Size(132, 25);
            this.winpartsize.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(396, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "GB";
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK.Location = new System.Drawing.Point(219, 323);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(94, 37);
            this.OK.TabIndex = 11;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // makesharepart
            // 
            this.makesharepart.AutoSize = true;
            this.makesharepart.Location = new System.Drawing.Point(209, 205);
            this.makesharepart.Name = "makesharepart";
            this.makesharepart.Size = new System.Drawing.Size(118, 19);
            this.makesharepart.TabIndex = 12;
            this.makesharepart.TabStop = true;
            this.makesharepart.Text = "创建共享分区";
            this.makesharepart.UseVisualStyleBackColor = true;
            this.makesharepart.CheckedChanged += new System.EventHandler(this.makesharepart_CheckedChanged);
            this.makesharepart.Click += new System.EventHandler(this.makesharepart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(387, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "GB";
            // 
            // sharepartsizetxt
            // 
            this.sharepartsizetxt.Enabled = false;
            this.sharepartsizetxt.Location = new System.Drawing.Point(249, 235);
            this.sharepartsizetxt.Name = "sharepartsizetxt";
            this.sharepartsizetxt.Size = new System.Drawing.Size(132, 25);
            this.sharepartsizetxt.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(129, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "共享分区大小：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(118, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(316, 40);
            this.label12.TabIndex = 17;
            this.label12.Text = "共享分区可同时在Windows和安卓访问\r\n（安卓需要使用Mindows安卓助手进行挂载）\r\n";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(169, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Windows分区不得小于20GB";
            // 
            // SetWinPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(542, 372);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sharepartsizetxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.makesharepart);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.winpartsize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.winsizerange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datasize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetWinPart";
            this.Text = "设定Windows分区";
            this.Load += new System.EventHandler(this.SetWinPart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label datasize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label winsizerange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox winpartsize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.RadioButton makesharepart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sharepartsizetxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}