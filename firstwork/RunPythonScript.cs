using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
   public class RunPythonScript
    {
       private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       public readonly Form1 frm;     //主窗体
       public readonly string taskname; //任务名称

       public string pythonscript;  //执行脚本
       public string temp;  //不知道的参数，为“”
       public string[] index; //输入参数
       public RunPythonScript(Form1 frm,string taskname)
       {
           this.frm = frm;
           this.taskname = taskname;
       }
       private string toUnicode(string str)
       {
           string outStr = "";
           if (!string.IsNullOrEmpty(str))
           {
               for (int i = 0; i < str.Length; i++)
               {
                   //将中文字符转为10进制整数，然后转为16进制unicode字符  
                   outStr += "//u" + ((int)str[i]).ToString("x");
               }
           }
           return outStr;
       }
        public void RunPythonScriptFunction()
        {
            string sArgName=pythonscript;
            string args = temp;
            string[] teps=index;
            Control.CheckForIllegalCrossThreadCalls = false;
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径
            p.StartInfo.FileName = @"C:\Python27\python.exe";
            string sArguments = path;
            if (teps.Length > 0)
            {
                foreach (string sigstr in teps)
                {
                    //sArguments += " " + "u"+"'"+sigstr+"'";//传递参数
                    sArguments += " " + (sigstr);//传递参数
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
            
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived); //监听获得cmd中的输出信息
            p.EnableRaisingEvents = true;//程序退出引发事件
            //p.Exited += new EventHandler(robotOpenProcess_Exited);
            //Console.ReadLine();
            p.WaitForExit();
            //Subfrm.Close();

        }
        delegate void AddTaskListdelegate(string staskstatus); //定义委托类型
       /// <summary>
       /// 定义添加treeview的方法
       /// </summary>
       /// <param name="taskstatus">任务状态</param>
        private void AddTaskList(string taskstatus)
        {
            //状态子节点
            TreeNode result2 = new TreeNode();
            result2.Text = taskstatus;
            //sb.AppendLine(e.Data).ToString();
            //result.Nodes.Add(result2);
            int tempint = 0;
            foreach (TreeNode item in frm.tasklist.Nodes)
            {
                if (item.Text == taskname)
                    break;
                tempint++;
            }
            //Monitor.Enter(objLock);  
            if (frm.tasklist.InvokeRequired)//如果调用控件的线程和创建控件的线程不是同一个则为true
            {
                while (!frm.tasklist.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄”的异常
                    if (frm.tasklist.Disposing || frm.tasklist.IsDisposed)
                        return;
                }
                AddTaskListdelegate d = new AddTaskListdelegate(AddTaskList);
                frm.tasklist.Invoke(d, new object[] { taskstatus });
            }
            else
            {
                frm.tasklist.Nodes[tempint].Nodes[2].Text = "状态";
                frm.tasklist.Nodes[tempint].Nodes[2].Nodes.Add(result2);
            }
            if(taskstatus=="ok")
            {
                
            }
        }
    
     
       void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                //Thread thread = new Thread(AddTaskStart);
                //thread.Start(e.Data + Environment.NewLine);
                //StringBuilder sb = new StringBuilder(frm.textBox1.Text);
                //frm.textBox1.Text = sb.AppendLine(e.Data).ToString();
                //TreeNode result = new TreeNode();
                //result.Text = "状态";
                log.Info(e.Data);
                AddTaskList(e.Data);
                //TreeNode result2 = new TreeNode();
                //result2.Text = e.Data + Environment.NewLine;//sb.AppendLine(e.Data).ToString();
                //frm.tasklist.Invoke(new AddTaskNodedelegate(AddTaskNode), new object[] { result2 });
                //AddTaskListdelegate dl = AddTaskList;
                //IAsyncResult ar = dl.BeginInvoke(e.Data + Environment.NewLine, null, null);
                //while(!ar.IsCompleted)
                //{
                //    AddTaskList(e.Data + Environment.NewLine);
                //}
                //while
                //frm.textBox1.SelectionStart = frm.textBox1.Text.Length;
                //frm.textBox1.ScrollToCaret();
                //frm.tasklist
                //AppendText(e.Data + Environment.NewLine);
            }
        }
       

        public delegate void AppendTextCallback(string text);
        public void AppendText(string text)
        {
            Messages ms = new Messages();//要弹出的消息框 
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - ms.Width, Screen.PrimaryScreen.WorkingArea.Height);
            ms.PointToClient(p);
            ms.Location = p;
            ms.Show();
            ms.label1.Text = text;
            for (int i = 0; i < ms.Height; i++)
            {
                ms.Location = new Point(p.X, p.Y - i);
                System.Threading.Thread.Sleep(10);
            }
        }
        
    }
}
