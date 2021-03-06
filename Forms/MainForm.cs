﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HentaiDownloader.Utils;
using HentaiDownloader.Model;
using HentaiDownloader.Forms;

namespace HentaiDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            this.pathTxt.Text = fbd.SelectedPath;
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (pathTxt.Text.Equals("") || pathTxt.Text == null)
                    throw new Exception("Path is not Valid!");

                if(!Path.IsPathRooted(pathTxt.Text))
                    throw new Exception("Path is not Valid!");

                string [] lst = PageParser.ParsePagesList(urlTxt.Text);
                Doujin doujin = new Doujin(PageParser.ParseDoujinName(urlTxt.Text));
                string directory = Path.Combine(pathTxt.Text,doujin.Name);
                doujin.DownloadPath = directory;

                int i = 0;
                foreach (var url in lst) 
                {
                    string pageName = PageParser.ParsePageIndexName(i, lst.Length, url);
                    DoujinPage page = new DoujinPage(pageName, url);
                    doujin.AddPage(page);
                    i++;
                }
                Directory.CreateDirectory(directory);
                DownloadForm downloader = new DownloadForm(doujin);
                downloader.ShowDialog();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        
    }
}
