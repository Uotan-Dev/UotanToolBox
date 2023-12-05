namespace UotanToolBox
{
    partial class MindowsInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MindowsInstall));
            this.shellshow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowText = new System.Windows.Forms.Label();
            this.tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shellshow
            // 
            this.shellshow.BackColor = System.Drawing.SystemColors.Control;
            this.shellshow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shellshow.Location = new System.Drawing.Point(14, 446);
            this.shellshow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.shellshow.Multiline = true;
            this.shellshow.Name = "shellshow";
            this.shellshow.ReadOnly = true;
            this.shellshow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellshow.Size = new System.Drawing.Size(898, 553);
            this.shellshow.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(283, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mindows一键安装";
            // 
            // ShowText
            // 
            this.ShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowText.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowText.Location = new System.Drawing.Point(14, 58);
            this.ShowText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ShowText.Name = "ShowText";
            this.ShowText.Size = new System.Drawing.Size(874, 346);
            this.ShowText.TabIndex = 2;
            this.ShowText.Text = "准备开始";
            this.ShowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tips
            // 
            this.tips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tips.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tips.ForeColor = System.Drawing.Color.Red;
            this.tips.Location = new System.Drawing.Point(14, 414);
            this.tips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tips.Name = "tips";
            this.tips.Size = new System.Drawing.Size(898, 31);
            this.tips.TabIndex = 3;
            this.tips.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MindowsInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(928, 1014);
            this.Controls.Add(this.tips);
            this.Controls.Add(this.ShowText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shellshow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MindowsInstall";
            this.Text = "Mindows一键安装";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MindowsInstall_FormClosing);
            this.Shown += new System.EventHandler(this.MindowsInstall_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shellshow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ShowText;
        private System.Windows.Forms.Label tips;
    }
}