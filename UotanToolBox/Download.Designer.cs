namespace UotanToolBox
{
    partial class Download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Download));
            this.schedule = new System.Windows.Forms.Label();
            this.schedulebar = new System.Windows.Forms.ProgressBar();
            this.show = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // schedule
            // 
            this.schedule.AutoSize = true;
            this.schedule.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.schedule.Location = new System.Drawing.Point(92, 110);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(0, 20);
            this.schedule.TabIndex = 0;
            // 
            // schedulebar
            // 
            this.schedulebar.Location = new System.Drawing.Point(95, 135);
            this.schedulebar.Name = "schedulebar";
            this.schedulebar.Size = new System.Drawing.Size(592, 23);
            this.schedulebar.TabIndex = 1;
            // 
            // show
            // 
            this.show.AutoSize = true;
            this.show.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.show.Location = new System.Drawing.Point(89, 44);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(127, 36);
            this.show.TabIndex = 2;
            this.show.Text = "准备下载";
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 188);
            this.Controls.Add(this.show);
            this.Controls.Add(this.schedulebar);
            this.Controls.Add(this.schedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Download";
            this.Text = "Mindows工具箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Download_FormClosing);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label schedule;
        private System.Windows.Forms.ProgressBar schedulebar;
        private System.Windows.Forms.Label show;
    }
}