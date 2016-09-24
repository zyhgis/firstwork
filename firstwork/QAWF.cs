using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace firstwork
{
    public partial class QAWF : Form
    {
        Form1 mainform;
        public QAWF(Form1 frm)
        {
            this.mainform = frm;
            InitializeComponent();
            //okbt.DialogResult = DialogResult.OK;
            
        }

        private void QAWF_Load(object sender, EventArgs e)
        {

        }

        private void showhelpbt_Click(object sender, EventArgs e)
        {

            this.Size = new Size(556, 308);
            helptext.Visible = true;
            showhelpbt.Visible = false;
            hidehelpbt.Visible = true;
        }

        private void hidehelpbt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(395, 308);
            helptext.Visible = true;
            hidehelpbt.Visible = false;
            showhelpbt.Visible = true;

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

        private void concelbt_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径
            p.StartInfo.FileName = @"C:\Python27\python.exe";
            string sArguments = path;
            if (teps.Length > 0)
            {
                foreach (string sigstr in teps)
                {
                    sArguments += " " + sigstr;//传递参数
                }
            }
            if (args.Length > 0)
            {

                sArguments += " " + args;

            }

            p.StartInfo.Arguments = sArguments;

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            //Console.ReadLine();
            p.WaitForExit();
        }
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                StringBuilder sb = new StringBuilder(this.textBox1.Text);
                this.textBox1.Text = sb.AppendLine(e.Data).ToString();
                TreeNode result = new TreeNode();
                result.Text = "状态";
                TreeNode result2 = new TreeNode();
                result2.Text = sb.AppendLine(e.Data).ToString();
                result.Nodes.Add(result2);
                mainform.tasklist.Nodes.Add(result);
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
                //AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public void AppendText(string text)
        {
            MessageBox.Show(text);
        }
        private void run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Python27\python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
        public string getItem()
        {
            return "QA文件"+DateTime.Now;
        }
        private void okbt_Click(object sender, EventArgs e)
        {
            //List<string> str = new List<string>();
            string[] str=new string[4];
            string inputpath1 = datacomboBox.Text.Trim();
            string inputpath2 = selectcomboBox.Text.Trim();
            int invalidint = -3000;
            try
            {
                invalidint = Convert.ToInt32(invaliddata.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("无效值应为数字");
            }
            string outpath = resulttext.Text.Trim();
            str[0] = inputpath1;
            str[1] = inputpath2;
            str[2] = invalidint.ToString();
            str[3] = outpath;



            //str[0] = "e:\\work\\共享杯\\wangxc20160912\\cqa_data\\tqa2008.tif";
            //str[1] = "e:\\work\\共享杯\\wangxc20160912\\cndvi_data\\tndvi2008.tif";
            //str[2] = "-3000";
            //str[3] = "e:\\work\\共享杯\\wangxc20160912\\fcndvidata\\ftndvi2008.tif";


            //str[0] = "e:\\wangxc20160912\\cqa_data\\tqa2008.tif";
            //str[1] = "e:\\wangxc20160912\\cndvi_data\\tndvi2008.tif";
            //str[2] = "-3000";
            //str[3] = "e:\\wangxc20160912\\fcndvidata\\ftndvi2008.tif";

            string taskname = "QA文件" + DateTime.Now;
            TreeNode task=new TreeNode();
            task.Text = taskname;

            TreeNode input = new TreeNode();
            input.Text = "输入";
            TreeNode input1 = new TreeNode();
            input1.Text = str[0];
            TreeNode input2 = new TreeNode();
            input2.Text = str[1];
            TreeNode input3 = new TreeNode();
            input3.Text = str[2];


            TreeNode output = new TreeNode();
            output.Text = "输出";
            TreeNode output1 = new TreeNode();
            output1.Text = str[3];

            TreeNode result = new TreeNode();
            result.Text = "运行中";

            input.Nodes.Add(input1);
            input.Nodes.Add(input2);
            input.Nodes.Add(input3);
            output.Nodes.Add(output1);
            task.Nodes.Add(input);
            task.Nodes.Add(output);
            task.Nodes.Add(result);
            mainform.tasklist.Nodes.Add(task);//（）"QA文件"+DateTime.Now);

            //Form1 frm = new Form1();
            //frm.listBox1.Items.Add("ewew");
            //TaskList frm = new TaskList(str);
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            //frm.TopLevel = false;
            //frm.AllowDrop = true;
            //this.panel1.Controls.Clear();
            //this.Controls.Add(sAllPage);

            
            //frm.Show();
            
            RunPythonScript rps=new RunPythonScript(mainform,taskname);
            //QAClass inputqa = new QAClass();
            rps.pythonscript = "qa_choice.py";
            rps.temp = "";
            rps.index = str;
            Thread t = new Thread(new ThreadStart(rps.RunPythonScriptFunction));
            t.Start();
            this.Close();
            this.Dispose();
            //rps.RunPythonScriptFunction("qa_choice.py", "", str);
            //this.Close();
            //this.Close();
            //this.Dispose();
            //RunPythonScript("qa_choice.py","",str);
            //string inputpath1 = datacomboBox.Text.Trim();
            //string inputpath2 = selectcomboBox.Text.Trim();
            //int invalidint = -3000;
            //try
            //{
            //    invalidint = Convert.ToInt32(invaliddata.Text.Trim());
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("无效值应为数字");
            //}
            //string outpath = resulttext.Text.Trim();

            //ScriptRuntime pyRuntime = Python.CreateRuntime();
            //dynamic obj = pyRuntime.UseFile(Application.StartupPath + @"\python\qa_choice.py");
            //obj.qa_choice2(inputpath1, inputpath2, invalidint, outpath);

            //var engine = IronPython.Hosting.Python.CreateEngine();
            //var scope = engine.CreateScope();
            //var source = engine.CreateScriptSourceFromFile(Application.StartupPath + @"\python\qa_choice.py");
            //source.Execute(scope);

            ////var say_hello = scope.GetVariable<Func<object>>("qa_choice2");
            ////say_hello();
            
            ////var get_text = scope.GetVariable<Func<object>>("get_text");
            ////var text = get_text().ToString();
            ////Console.WriteLine(text);

            //var add = scope.GetVariable<Func<object, object, object, object, object>>("qa_choice2");
            //add(inputpath1, inputpath2, invalidint, outpath);
            

            ////var result2 = add("hello ", "world");
            ////Console.WriteLine(result2);

        }
    }
}
