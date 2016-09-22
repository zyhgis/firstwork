using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class removeerrorWF : Form
    {
        public removeerrorWF()
        {
            InitializeComponent();
        }

        private void hidehelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 357);
            helptext.Visible = false;
            showhelpbt.Visible = true;
            hidehelpbt.Visible = false;
        }

        private void showhelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(866, 357);
            helptext.Visible = true;
            showhelpbt.Visible = false;
            hidehelpbt.Visible = true;
        }

        private void concelbt_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void datafilebt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                filepathtextBox.Text = dilog.SelectedPath;
                DirectoryInfo theFolder = new DirectoryInfo(dilog.SelectedPath);

                // this.listBox1.Items.Add(NextFolder.Name);
                FileInfo[] fileInfo = theFolder.GetFiles();
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                    this.listBox1.Items.Add(NextFile.Name);

            }
        }
    }
}
