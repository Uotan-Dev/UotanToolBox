namespace UotanToolBox
{
    partial class DeviceWarn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceWarn));
            this.ShowText = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowText
            // 
            this.ShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowText.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowText.ForeColor = System.Drawing.Color.Red;
            this.ShowText.Location = new System.Drawing.Point(30, 9);
            this.ShowText.Name = "ShowText";
            this.ShowText.Size = new System.Drawing.Size(728, 321);
            this.ShowText.TabIndex = 3;
            this.ShowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK.Location = new System.Drawing.Point(286, 358);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(196, 56);
            this.OK.TabIndex = 4;
            this.OK.Text = "我已知晓，继续下载";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // DeviceWarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.ShowText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeviceWarn";
            this.Text = "警告！";
            this.Load += new System.EventHandler(this.DeviceWarn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ShowText;
        private System.Windows.Forms.Button OK;
    }
}