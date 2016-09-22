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
namespace firstwork
{
    public partial class QAWF : Form
    {
        public QAWF(TreeNodeCollection layer)
        {
            InitializeComponent();
            if (layer.Count > 0)
            {
                for (int i = 1; i < layer.Count; i++)
                {
                    datacomboBox.Items.Add(layer[i].Name);
                }
            }
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
        public  void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
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
                AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public  void AppendText(string text)
        {
          
          MessageBox.Show(text);

          label5.Text = text;
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
        private void okbt_Click(object sender, EventArgs e)
        {
            
            string[] str=new string[4];
            str[0]="E:\\wangxc20160912\\cqa_data\\tqa2008.tif";
            str[1]="E:\\wangxc20160912\\cndvi_data\\tndvi2008.tif";
            str[2]="-3000";
            str[3]="E:\\wangxc20160912\\fcndvidata\\ftndvi2008.tif";
            RunPythonScript("qa_choice.py","",str);
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
