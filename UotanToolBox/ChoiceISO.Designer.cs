namespace UotanToolBox
{
    partial class ChoiceISO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoiceISO));
            this.ShowText = new System.Windows.Forms.Label();
            this.winpath = new System.Windows.Forms.TextBox();
            this.choice = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nodrv = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ShowText
            // 
            this.ShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowText.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowText.Location = new System.Drawing.Point(12, 14);
            this.ShowText.Name = "ShowText";
            this.ShowText.Size = new System.Drawing.Size(634, 99);
            this.ShowText.TabIndex = 3;
            this.ShowText.Text = "请选择Windows镜像";
            this.ShowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winpath
            // 
            this.winpath.BackColor = System.Drawing.Color.White;
            this.winpath.Location = new System.Drawing.Point(118, 186);
            this.winpath.Name = "winpath";
            this.winpath.ReadOnly = true;
            this.winpath.Size = new System.Drawing.Size(330, 25);
            this.winpath.TabIndex = 4;
            // 
            // choice
            // 
            this.choice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.choice.Location = new System.Drawing.Point(454, 182);
            this.choice.Name = "choice";
            this.choice.Size = new System.Drawing.Size(90, 33);
            this.choice.TabIndex = 5;
            this.choice.Text = "选择文件";
            this.choice.UseVisualStyleBackColor = true;
            this.choice.Click += new System.EventHandler(this.choice_Click);
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ok.Location = new System.Drawing.Point(265, 257);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(119, 59);
            this.ok.TabIndex = 6;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(187, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "注意：路径及文件名不得存在空格！\r\n【内置驱动】镜像请选择“不安装驱动”";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodrv
            // 
            this.nodrv.AutoSize = true;
            this.nodrv.Location = new System.Drawing.Point(277, 223);
            this.nodrv.Name = "nodrv";
            this.nodrv.Size = new System.Drawing.Size(103, 19);
            this.nodrv.TabIndex = 9;
            this.nodrv.TabStop = true;
            this.nodrv.Text = "不安装驱动";
            this.nodrv.UseVisualStyleBackColor = true;
            // 
            // ChoiceISO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(658, 344);
            this.Controls.Add(this.nodrv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.choice);
            this.Controls.Add(this.winpath);
            this.Controls.Add(this.ShowText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoiceISO";
            this.Text = "选择镜像文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShowText;
        private System.Windows.Forms.TextBox winpath;
        private System.Windows.Forms.Button choice;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton nodrv;
    }
}