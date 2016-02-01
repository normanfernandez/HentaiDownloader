using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using HentaiDownloader.Model;
using HentaiDownloader.Utils;

namespace HentaiDownloader.Forms
{
    public partial class DownloadForm : Form
    {
        private Doujin doujin;

        public DownloadForm(Doujin d)
        {
            InitializeComponent();
            this.doujin = d;
            this.Text = "Downloading - " + doujin.Name;
            this.PageName.Text = d.PageList.First().Name;
            PageDownloader.webClient.DownloadProgressChanged += (s, e) => 
            {
                this.DownloadProgressBar.Value = e.ProgressPercentage;
            };
            PageDownloader.webClient.DownloadFileCompleted += (s, e) =>
            {
                this.PageName.Text = PageDownloader.CurrentPage;
            };
            PageDownloader.OnDoujinDownloadFinished += (s, e) => 
            {
                MessageBox.Show("Finished downloading: " + d.Name);
                this.Dispose();
            };
        }

        private void StartDownload()
        {
                PageDownloader.DownloadDoujin(doujin);
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            StartDownload();
        }
    }
}
