namespace HentaiDownloader.Forms
{
    partial class DownloadForm
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
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.PageName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(222, 75);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(100, 23);
            this.DownloadProgressBar.TabIndex = 0;
            // 
            // PageName
            // 
            this.PageName.AutoSize = true;
            this.PageName.Location = new System.Drawing.Point(62, 75);
            this.PageName.Name = "PageName";
            this.PageName.Size = new System.Drawing.Size(35, 13);
            this.PageName.TabIndex = 1;
            this.PageName.Text = "label1";
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 121);
            this.Controls.Add(this.PageName);
            this.Controls.Add(this.DownloadProgressBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadForm";
            this.Text = "DownloadForm";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Label PageName;
    }
}