﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class TXYZF : Form
    {
        Form1 mainfrm;
        public TXYZF(Form1 frm)
        {
            this.mainfrm = frm;
            InitializeComponent();
        }

        private void datafilebt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                datacomboBox.Text = fd.FileName;
            }
        }

        private void selfilebt_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                selectcomboBox.Text = fd.FileName;
            }
        }

        private void resfilebt_Click(object sender, EventArgs e)
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
            mainfrm.tasklist.Nodes.Add(task);//（）"QA文件"+DateTime.Now);
            return taskname;
        }
      
        private void okbt_Click(object sender, EventArgs e)
        {
            List<string> str = new List<string>();
            //string[] str=new string[4];
            string inputpath1 = datacomboBox.Text.Trim();
            string inputpath2 = selectcomboBox.Text.Trim();
            if (inputpath1 == "")
            {
                MessageBox.Show("数据文件不能为空");
                return;
            }
            if (inputpath2 == "")
            {
                MessageBox.Show("筛选文件不能为空");
                return;
            }
            int invalidint;
            try
            {
                invalidint = Convert.ToInt32(invaliddata.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("无效值应为数字");
                return;
            }
            int ignoreint;
            try
            {
                ignoreint = Convert.ToInt32(ignoredata.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("无效值应为数字");
                return;
            }
            string outpath = resulttext.Text.Trim();
            str.Add(inputpath1);
            str.Add(inputpath2);
            str.Add(ignoreint.ToString());
            str.Add(invalidint.ToString());
            str.Add(outpath);
            string taskname = AddToTaskList(str, "图像阈值法");
            RunPythonScript rps = new RunPythonScript(mainfrm, taskname);
            //QAClass inputqa = new QAClass();
            rps.pythonscript = "image_threshold.py";
            rps.temp = "";
            rps.index = str;
            Thread t = new Thread(new ThreadStart(rps.RunPythonScriptFunction));
            t.Start();
            this.Close();
            this.Dispose();
           
        }

        private void concelbt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hidehelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(381, this.Size.Height);
            helptext.Visible = false;
            hidehelpbt.Visible = false;
            showhelpbt.Visible = true;
        }

        private void showhelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(529, this.Size.Height);
            helptext.Visible = true;
            hidehelpbt.Visible = true;
            showhelpbt.Visible = false;
        }
    }
}
