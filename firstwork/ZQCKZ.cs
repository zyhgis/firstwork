using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class ZQCKZ : Form
    {
        Form1 mainForm;
        public ZQCKZ(Form1 frm)
        {
            this.mainForm = frm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            //fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                resulttext.Text = fd.FileName;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                this.listBox1.Items.Add(fd.FileName);
            }
        }

        private void delectbt_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private string AddToTaskList(List<string> str, string name)
        {
            string taskname = name + DateTime.Now;
            TreeNode task = new TreeNode();
            task.Text = taskname;

            TreeNode input = new TreeNode();
            input.Text = "输入";
            for (int i = 0; i < str.Count - 1; i++)
            {
                TreeNode input1 = new TreeNode();
                input1.Text = str[i];
                input.Nodes.Add(input1);
            }
            
            TreeNode output = new TreeNode();
            output.Text = "输出";
            TreeNode output1 = new TreeNode();
            output1.Text = str[str.Count - 1];

            TreeNode result = new TreeNode();
            result.Text = "运行中";

            output.Nodes.Add(output1);
            task.Nodes.Add(input);
            task.Nodes.Add(output);
            task.Nodes.Add(result);
            mainForm.tasklist.Nodes.Add(task);//（）"QA文件"+DateTime.Now);
            return taskname;
        }

        private void okbt_Click(object sender, EventArgs e)
        {
            List<string> filelist = new List<string>();//筛选文件列表
            foreach (string item in listBox1.Items)
            {
                if (item.IndexOf("\\") == -1)
                    filelist.Add(filepathtextBox.Text.Trim() + "\\" + item);
                else
                    filelist.Add(item);
            }
            filelist.Add(ignoretextBox.Text.Trim());
            filelist.Add(invaildtextBox.Text.Trim());
            filelist.Add(resulttext.Text.Trim());
            string taskname = AddToTaskList(filelist, "灾前参考值");
            RunPythonScript rps = new RunPythonScript(mainForm, taskname);
            //QAClass inputqa = new QAClass();
            rps.pythonscript = "ndvi_refer.py";
            rps.temp = "";
            rps.index = filelist;
            Thread t = new Thread(new ThreadStart(rps.RunPythonScriptFunction));
            t.Start();
            this.Close();
            this.Dispose();
        }

        private void hidehelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(394, this.Size.Height);
            helptext.Visible = false;
            hidehelpbt.Visible = false;
            showhelpbt.Visible = true;
        }

        private void showhelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(568, this.Size.Height);
            helptext.Visible = true;
            hidehelpbt.Visible = true;
            showhelpbt.Visible = false;
        }
       
    }
}
