using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpMap.Forms;
using GeoAPI.Geometries;
using SharpMap.Layers;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace firstwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //SharpMap.Layers.GdiImageLayer sd = new SharpMap.Layers.GdiImageLayer("dsd", @"E:\company\firstWork\tiff\330225.tif");
           // mapBox1.Map.Layers.Add(sd);
            //var shpProvider = new SharpMap.Data.Providers.ShapeFile(@"D:\work\firstWork\states_ugl\states_ugl.shp", true);
            //VectorLayer vlay = new VectorLayer("Spain");
            //vlay.DataSource = shpProvider;
            //mapBox1.Map.ZoomToExtents();
            mapBox1.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
            mapBox1.Refresh();
            treeView1.SelectedNode = null;

        }
        private void mapBox1_Click(object sender, EventArgs e)
        {
            var pt = new PopupTool();
            pt.MapControl = mapBox1;
            pt.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("zhang");
        }
        public abstract class CustomMapTool
        {
            private MapBox _mapControl;
            private bool _enabled;

            /// <summary>
            /// Event raised when the <see cref="MapControl"/> is about to change.
            /// </summary>
            public event CancelEventHandler MapControlChanging;

            /// <summary>
            /// Event invoker for the <see cref="MapControlChanging"/> event
            /// </summary>
            /// <remarks>Override this method to unwire <see cref="MapBox"/>s events. Don't forget to call <c>base.OnMapControlChanging(cea);</c> to invoke the event.</remarks>
            /// <param name="cea">The cancel event arguments</param>
            protected virtual void OnMapControlChanging(CancelEventArgs cea)
            {
                var h = MapControlChanging;
                if (h != null) h(this, cea);
            }

            /// <summary>
            /// Event raised when the <see cref="MapControl"/> has changed.
            /// </summary>
            public event EventHandler MapControlChanged;

            /// <summary>
            /// The event invoker 
            /// </summary>
            /// <remarks>Override this method to wire to <see cref="MapBox"/>s events. Don't forget to call <c>base.OnMapControlChanged(e);</c> to invoke the event.</remarks>
            /// <param name="e">The event arguments</param>
            protected virtual void OnMapControlChanged(EventArgs e)
            {
                var h = MapControlChanged;
                if (h != null) h(this, e);
            }

            /// <summary>
            /// Gets or sets a value indicating the map control
            /// </summary>
            public MapBox MapControl
            {
                get { return _mapControl; }
                set
                {
                    if (value == _mapControl)
                        return;

                    var cea = new CancelEventArgs(false);
                    OnMapControlChanging(cea);
                    if (cea.Cancel) return;
                    _mapControl = value;
                    OnMapControlChanged(EventArgs.Empty);
                }
            }

            /// <summary>
            /// Event raised when <see cref="Enabled"/> changed.
            /// </summary>
            public event EventHandler EnabledChanged;

            /// <summary>
            /// Event invoker for the <see cref="EnabledChanged"/> event.
            /// </summary>
            /// <param name="e"></param>
            protected virtual void OnEnabledChanged(EventArgs e)
            {
                var h = EnabledChanged;
                if (h != null) h(this, e);
            }

            /// <summary>
            /// Gets or sets a value indicating if the tool is enabled or not
            /// </summary>
            public bool Enabled
            {
                get { return _mapControl != null && _enabled; }
                set
                {
                    if (value == _enabled)
                        return;
                    _enabled = value;
                    OnEnabledChanged(EventArgs.Empty);
                }
            }
        }
        public class PopupTool : CustomMapTool
        {
            protected override void OnMapControlChanging(CancelEventArgs cea)
            {
                base.OnMapControlChanging(cea);
                if (cea.Cancel) return;

                if (MapControl == null) return;
                MapControl.MouseDown -= HandleMouseDown;
            }

            protected override void OnMapControlChanged(EventArgs e)
            {
                base.OnMapControlChanged(e);
                if (MapControl == null) return;
                MapControl.MouseDown += HandleMouseDown;
            }

            private void HandleMouseDown(Coordinate worldpos, MouseEventArgs imagepos)
            {
                if (!Enabled)
                    return;

                MessageBox.Show(string.Format("You clicked at {0}!", worldpos));
                Enabled = false;
            }
        }
        private void tbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                int startindex = fd.FileName.LastIndexOf(@"\") + 1;
                int lenth = fd.FileName.LastIndexOf(@".") - startindex;
                SharpMap.Layers.GdiImageLayer sd = new SharpMap.Layers.GdiImageLayer(fd.FileName.Substring(startindex, lenth), fd.FileName);
                mapBox1.Map.Layers.Add(sd);
                mapBox1.Map.ZoomToExtents();
                //treeView1.CheckBoxes=true;
                treeView1.Nodes[0].Nodes.Add(sd.ImageFilename);
                treeView1.Nodes[0].LastNode.Checked = true;
                treeView1.Nodes[0].ExpandAll();
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //rightmenu.Show(Cursor.Position);
            //e.Node.Checked = true;
            //if(e.Node.Nodes.Count>0)
            //   MessageBox.Show(e.Node.Nodes[0].Name);
            //foreach (TreeNode item in treeView1.Nodes)
            //{
            //    item.Checked = true;
            //}
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
           // MessageBox.Show("aftercheck");
            if(e.Node.Nodes.Count>0)
            {
                if (e.Node.Checked)
                {
                   // MessageBox.Show("");
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = true;
                    }
                }
                else
                {
                    foreach (TreeNode item in e.Node.Nodes)
                    {
                        item.Checked = false;
                    }
                }
            }
            else
            {
                //if (e.Node.Checked)
                //{
                //    int temp = 0;
                //    foreach (TreeNode item in e.Node.Parent.Nodes)
                //    {
                //        if (item.Checked)
                //            temp++;
                //    }
                //    if (temp == e.Node.Parent.Nodes.Count)
                //    {
                //        e.Node.Parent.Checked = true;
                //    }
                //}
                //else
                //{
                //    int temp = 0;
                //    foreach (TreeNode item in e.Node.Parent.Nodes)
                //    {
                //        if (item.Checked==false)
                //            temp++;
                //    }
                //    if (temp == e.Node.Parent.Nodes.Count)
                //    {
                //        e.Node.Parent.Checked = false;
                //    }
                //}
            }
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
                //StringBuilder sb = new StringBuilder(this.textBox1.Text);
                //this.textBox1.Text = sb.AppendLine(e.Data).ToString();
                //this.textBox1.SelectionStart = this.textBox1.Text.Length;
                //this.textBox1.ScrollToCaret();
                AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public void AppendText(string text)
        {
            MessageBox.Show(text);
        }
       
        private void qA文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // TreeNode l=treeView1.
           // TreeNodeCollection layer = treeView1.Nodes;
            QAWF frm = new QAWF(this);
            frm.Show();
            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{
            //    tasklist.Items.Add(frm.getItem());
            //    string[] str = new string[4];
            //    //str[0] = "E:\\wangxc20160912\\cqa_data\\tqa2008.tif";
            //    //str[1] = "E:\\wangxc20160912\\cndvi_data\\tndvi2008.tif";
            //    //str[2] = "-3000";
            //    //str[3] = "E:\\wangxc20160912\\fcndvidata\\ftndvi2008.tif";
            //    string inputpath1 = frm.datacomboBox.Text.Trim();
            //    string inputpath2 = frm.selectcomboBox.Text.Trim();
            //    int invalidint = -3000;
            //    try
            //    {
            //        invalidint = Convert.ToInt32(frm.invaliddata.Text.Trim());
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("无效值应为数字");
            //    }
            //    string outpath = frm.resulttext.Text.Trim();
            //    str[0] = inputpath1;
            //    str[1] = inputpath2;
            //    str[2] = invalidint.ToString();
            //    str[3] = outpath;
            //    //RunPythonScript rps=new RunPythonScript();
            //    //rps.RunPythonScriptFunction("qa_choice.py", "", str);
            //    //this.Close();
            //    //this.Dispose();
            //    RunPythonScript("qa_choice.py", "", str);
            //}
            ////frm.Close();
            ////frm.Dispose();

        }

        private void 剔除异常值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removeerrorWF frm = new removeerrorWF();
            TCYCZ frm = new TCYCZ();
            frm.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp frm = new temp();
            frm.Show();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
             if (e.Button == MouseButtons.Right)//判断你点的是不是右键
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    //CurrentNode.ContextMenuStrip = rightmenu;
                    switch (CurrentNode.Name)//根据不同节点显示不同的右键菜单，当然你可以让它显示一样的菜单
                    {
                        case "Node0":
                            CurrentNode.ContextMenuStrip=mainmenu;
                            break;
                        default:
                            CurrentNode.ContextMenuStrip=rightmenu;
                            break;
                    }
                    treeView1.SelectedNode = CurrentNode;//选中这个节点
                }
            }
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
            foreach (Layer item in mapBox1.Map.Layers)
            {
                GdiImageLayer ly = item as GdiImageLayer;
                if(ly.ImageFilename==treeView1.SelectedNode.Text)
                {
                    mapBox1.Map.Layers.Remove(ly);
                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                    break;
                }
            }
            //GdiImageLayer ly = mapBox1.Map.Layers[0] as GdiImageLayer;
            //MessageBox.Show(ly.ImageFilename); 
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                int startindex = fd.FileName.LastIndexOf(@"\") + 1;
                int lenth = fd.FileName.LastIndexOf(@".") - startindex;
                SharpMap.Layers.GdiImageLayer sd = new SharpMap.Layers.GdiImageLayer(fd.FileName.Substring(startindex, lenth), fd.FileName);
                mapBox1.Map.Layers.Add(sd);
                mapBox1.Map.ZoomToExtents();
                //treeView1.CheckBoxes=true;
                treeView1.Nodes[0].Nodes.Add(sd.ImageFilename);
                treeView1.Nodes[0].LastNode.Checked = true;
                treeView1.Nodes[0].ExpandAll();
            }
        }

        private void 筛选参考值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SXCKZ frm = new SXCKZ();
            frm.Show();
        }

        private void 灾前参考值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZQCKZ frm = new ZQCKZ();
            frm.Show();
        }

        private void 正常波动范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZCBDFW frm = new ZCBDFW();
            frm.Show();
        }

        private void 灾后波动值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZHBDFW frm = new ZHBDFW();
            frm.Show();
        }

        private void 差值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CZF frm = new CZF();
            frm.Show();
        }

        private void nDVI阈值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NDVIYZ frm = new NDVIYZ();
            frm.Show();
        }

        private void 图像阈值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXYZF frm = new TXYZF();
            frm.Show();
        }

        private void 阈值比值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YZBZF frm = new YZBZF();
            frm.Show();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //splitContainer2.Panel2.
            Messages sAllPage = new Messages();
            //  sAllPage.FormBorderStyle = FormBorderStyle.None;
            // sAllPage.Dock = DockStyle.Fill;
            sAllPage.TopLevel = false;
            sAllPage.AllowDrop = true;
            //this.panel1.Controls.Clear();
            this.Controls.Add(sAllPage);
            //this.panel1.
            sAllPage.Show();
        }
    }
}
