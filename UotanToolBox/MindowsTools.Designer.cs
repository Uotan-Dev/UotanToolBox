namespace UotanToolBox
{
    partial class MindowsTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MindowsTools));
            this.ShowText = new System.Windows.Forms.Label();
            this.drvpath = new System.Windows.Forms.TextBox();
            this.choicedrv = new System.Windows.Forms.Button();
            this.shellshow = new System.Windows.Forms.TextBox();
            this.warntext = new System.Windows.Forms.Label();
            this.installdrv = new System.Windows.Forms.Button();
            this.set1 = new System.Windows.Forms.RadioButton();
            this.set3 = new System.Windows.Forms.RadioButton();
            this.set6 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ShowText
            // 
            this.ShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowText.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowText.Location = new System.Drawing.Point(14, 11);
            this.ShowText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowText.Name = "ShowText";
            this.ShowText.Size = new System.Drawing.Size(884, 96);
            this.ShowText.TabIndex = 3;
            this.ShowText.Text = "Mindows";
            this.ShowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drvpath
            // 
            this.drvpath.Location = new System.Drawing.Point(171, 143);
            this.drvpath.Margin = new System.Windows.Forms.Padding(4);
            this.drvpath.Name = "drvpath";
            this.drvpath.Size = new System.Drawing.Size(424, 28);
            this.drvpath.TabIndex = 4;
            // 
            // choicedrv
            // 
            this.choicedrv.Location = new System.Drawing.Point(615, 138);
            this.choicedrv.Margin = new System.Windows.Forms.Padding(4);
            this.choicedrv.Name = "choicedrv";
            this.choicedrv.Size = new System.Drawing.Size(132, 37);
            this.choicedrv.TabIndex = 5;
            this.choicedrv.Text = "选择文件夹";
            this.choicedrv.UseVisualStyleBackColor = true;
            this.choicedrv.Click += new System.EventHandler(this.choicedrv_Click);
            // 
            // shellshow
            // 
            this.shellshow.BackColor = System.Drawing.SystemColors.Control;
            this.shellshow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shellshow.Location = new System.Drawing.Point(14, 223);
            this.shellshow.Margin = new System.Windows.Forms.Padding(4);
            this.shellshow.Multiline = true;
            this.shellshow.Name = "shellshow";
            this.shellshow.ReadOnly = true;
            this.shellshow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellshow.Size = new System.Drawing.Size(884, 399);
            this.shellshow.TabIndex = 6;
            // 
            // warntext
            // 
            this.warntext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warntext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.warntext.ForeColor = System.Drawing.Color.Red;
            this.warntext.Location = new System.Drawing.Point(26, 108);
            this.warntext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warntext.Name = "warntext";
            this.warntext.Size = new System.Drawing.Size(872, 24);
            this.warntext.TabIndex = 7;
            this.warntext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // installdrv
            // 
            this.installdrv.Location = new System.Drawing.Point(382, 178);
            this.installdrv.Margin = new System.Windows.Forms.Padding(4);
            this.installdrv.Name = "installdrv";
            this.installdrv.Size = new System.Drawing.Size(132, 37);
            this.installdrv.TabIndex = 8;
            this.installdrv.Text = "安装";
            this.installdrv.UseVisualStyleBackColor = true;
            this.installdrv.Click += new System.EventHandler(this.installdrv_Click);
            // 
            // set1
            // 
            this.set1.AutoSize = true;
            this.set1.Location = new System.Drawing.Point(14, 146);
            this.set1.Name = "set1";
            this.set1.Size = new System.Drawing.Size(276, 22);
            this.set1.TabIndex = 13;
            this.set1.TabStop = true;
            this.set1.Text = "设置为 1（尝试修复USB问题）";
            this.set1.UseVisualStyleBackColor = true;
            // 
            // set3
            // 
            this.set3.AutoSize = true;
            this.set3.Location = new System.Drawing.Point(296, 146);
            this.set3.Name = "set3";
            this.set3.Size = new System.Drawing.Size(312, 22);
            this.set3.TabIndex = 12;
            this.set3.TabStop = true;
            this.set3.Text = "设置为 3（小部分设备初始值为3）";
            this.set3.UseVisualStyleBackColor = true;
            // 
            // set6
            // 
            this.set6.AutoSize = true;
            this.set6.Location = new System.Drawing.Point(614, 146);
            this.set6.Name = "set6";
            this.set6.Size = new System.Drawing.Size(294, 22);
            this.set6.TabIndex = 11;
            this.set6.TabStop = true;
            this.set6.Text = "设置为 6（一般设备初始值为6）";
            this.set6.UseVisualStyleBackColor = true;
            // 
            // MindowsTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(912, 637);
            this.Controls.Add(this.set1);
            this.Controls.Add(this.set3);
            this.Controls.Add(this.set6);
            this.Controls.Add(this.installdrv);
            this.Controls.Add(this.warntext);
            this.Controls.Add(this.shellshow);
            this.Controls.Add(this.choicedrv);
            this.Controls.Add(this.drvpath);
            this.Controls.Add(this.ShowText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MindowsTools";
            this.Text = "Mindows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MindowsTools_FormClosing);
            this.Shown += new System.EventHandler(this.MinodwsTools_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShowText;
        private System.Windows.Forms.TextBox drvpath;
        private System.Windows.Forms.Button choicedrv;
        private System.Windows.Forms.TextBox shellshow;
        private System.Windows.Forms.Label warntext;
        private System.Windows.Forms.Button installdrv;
        private System.Windows.Forms.RadioButton set1;
        private System.Windows.Forms.RadioButton set3;
        private System.Windows.Forms.RadioButton set6;
    }
}