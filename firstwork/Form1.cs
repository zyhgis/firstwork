using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoAPI.Geometries;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesRaster;
using System.IO;

namespace firstwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mainMap.LoadMxFile(@"E:\task\107\无标题.mxd");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("zhang");
        }
        public abstract class CustomMapTool
        {

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
        
        }
     private void tbOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd
        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

            QAWF frm = new QAWF(this);
            frm.Show();
        }

        private void 剔除异常值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removeerrorWF frm = new removeerrorWF();
            TCYCZ frm = new TCYCZ(this);
            frm.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temp frm = new temp();
            frm.Show();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 筛选参考值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SXCKZ frm = new SXCKZ(this);
            frm.Show();
        }

        private void 灾前参考值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZQCKZ frm = new ZQCKZ(this);
            frm.Show();
        }

        private void 正常波动范围ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZCBDFW frm = new ZCBDFW(this);
            frm.Show();
        }

        private void 灾后波动值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZHBDFW frm = new ZHBDFW(this);
            frm.Show();
        }

        private void 差值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CZF frm = new CZF(this);
            frm.Show();
        }

        private void nDVI阈值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NDVIYZ frm = new NDVIYZ(this);
            frm.Show();
        }

        private void 图像阈值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXYZF frm = new TXYZF(this);
            frm.Show();
        }

        private void 阈值比值法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YZBZF frm = new YZBZF(this);
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

        private void Form1_Load_1(object sender, EventArgs e)
        {
//            var factory = new SharpMap.Rendering.Decoration.Legend.Factories.LegendFactory
//    {
//        HeaderFont = new System.Drawing.Font("Times New Roman", 24),
//        SymbolSize = new System.Drawing.Size(14, 14);
//        Indentation = 7;
//        //more properties are ItemSize, ForeColor; Padding
//    };

//var legend = factory.Create(map);
//// Get a legend image
//var legendImage = legend.GetLegendImage();

//// Display the legend image on the map
//map.Decorations.Add(legend);
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                string fileName;

                openFile.Title = "添加栅格数据";
                openFile.Filter = "TIFF图像(*.tif)|*.tif|所有文件(*.*)|*.*";
                openFile.ShowDialog();
                fileName = openFile.FileName;
                
               // mainMap.AddLayerFromFile(fileName, 0);
                IRasterLayer rasterLayer;
                rasterLayer = new RasterLayer();
                rasterLayer.CreateFromFilePath(fileName);
                mainMap.AddLayer(rasterLayer);
            }
            catch
            {
                MessageBox.Show("添加栅格数据错误!");
            }
        }

        private void 展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           //string a= mainMap.Map.Layer[0].Name;
        }

        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem Item = esriTOCControlItem.esriTOCControlItemNone;
                //esriTOCControlItem Item = new esriTOCControlItem();
                IBasicMap pMap = null;
                ILayer pLayer = null;
                object pOther = new object();
                object pIndex = new object();
                axTOCControl1.HitTest(e.x, e.y, ref Item, ref pMap, ref pLayer, ref pOther, ref pIndex);
                if (Item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                  rightmenu.Show(MousePosition);
                }
            }
        }

        private void 灾情分级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReclass frm = new frmReclass(this);
            //Reclassfy frm = new Reclassfy(this);
            frm.Show();
        }

        private void 工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public static void funColorForRaster_Classify(IRasterLayer pRasterLayer)
        {
            IRasterClassifyColorRampRenderer pRClassRend = new RasterClassifyColorRampRenderer() as IRasterClassifyColorRampRenderer;
            IRasterRenderer pRRend = pRClassRend as IRasterRenderer;

            IRaster pRaster = pRasterLayer.Raster;
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(0);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            pRRend.Raster = pRaster;
            pRClassRend.ClassCount = 10;
            pRRend.Update();

            IRgbColor pFromColor = new RgbColor() as IRgbColor;
            pFromColor.Red = 255;
            pFromColor.Green = 0;
            pFromColor.Blue = 0;
            IRgbColor pToColor = new RgbColor() as IRgbColor;
            pToColor.Red = 0;
            pToColor.Green = 0;
            pToColor.Blue = 255;

            IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRamp() as IAlgorithmicColorRamp;
            colorRamp.Size = 10;
            colorRamp.FromColor = pFromColor;
            colorRamp.ToColor = pToColor;
            bool createColorRamp;

            colorRamp.CreateRamp(out createColorRamp);

            IFillSymbol fillSymbol = new SimpleFillSymbol() as IFillSymbol;
            for (int i = 0; i < pRClassRend.ClassCount; i++)
            {
                fillSymbol.Color = colorRamp.get_Color(i);
                pRClassRend.set_Symbol(i, fillSymbol as ISymbol);
                pRClassRend.set_Label(i, pRClassRend.get_Break(i).ToString("0.00"));
            }
            pRasterLayer.Renderer = pRRend;
        }

        ///
        /// 打开遥感图像
        ///
        /// 图像的地址
        /// IRasterLayer
        private IRasterLayer OpenImage(string imagePath)
        {
            string ws = Path.GetDirectoryName(imagePath);
            string fbs = Path.GetFileName(imagePath);

            IWorkspaceFactory pWork = new RasterWorkspaceFactory();
            IRasterWorkspace pRasterWs = pWork.OpenFromFile(ws, 0) as IRasterWorkspace;
            IRasterDataset pRasterDataset = pRasterWs.OpenRasterDataset(fbs);

            IRasterLayer pRasterLayer = new RasterLayer() as IRasterLayer;
            pRasterLayer.CreateFromDataset(pRasterDataset);
            return pRasterLayer;
        }

        private void 渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RasterRender frm = new RasterRender(this);
            frm.Show();
        }

        private void huanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRasterRender frm = new FrmRasterRender(this);
            frm.Show();
        }

        private void 重分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReclass frm = new frmReclass(this);
            frm.Show();
        }
    //    private void RasterView(IRasterLayer RasterLayer, double BreakPoint1, double BreakPoint2, double BreakPoint3, double BreakPoint4, double BreakPoint5)
    //    {
    //        IRasterClassifyColorRampRenderer ClassifyColor = new RasterClassifyColorRampRenderer();
    //        IRasterRenderer RasterRender = ClassifyColor as IRasterRenderer;
    //        RasterRender.Raster = RasterLayer.Raster;
    //        RasterRender.Update();

    //        //断点设置  
    //        ClassifyColor.ClassCount = 6;
    //        ClassifyColor.set_Break(0, -1);
    //        ClassifyColor.set_Break(1, BreakPoint1);
    //        ClassifyColor.set_Break(2, BreakPoint2);
    //        ClassifyColor.set_Break(3, BreakPoint3);
    //        ClassifyColor.set_Break(4, BreakPoint4);
    //        ClassifyColor.set_Break(5, BreakPoint5);
    //        ClassifyColor.set_Break(6, 1);

    //        //各个分类的颜色设置  
    //        IFillSymbol Symbol = new SimpleFillSymbol() as IFillSymbol;
    //        Symbol.Color = SetHSVColor(0, 100, 100);
    //        ClassifyColor.set_Symbol(0, Symbol as ISymbol);
    //        Symbol.Color = SetHSVColor(25, 100, 100);
    //        ClassifyColor.set_Symbol(1, Symbol as ISymbol);
    //        Symbol.Color = SetHSVColor(0, 50, 100);
    //        ClassifyColor.set_Symbol(2, Symbol as ISymbol);
    //        Symbol.Color = SetHSVColor(60, 100, 100);
    //        ClassifyColor.set_Symbol(3, Symbol as ISymbol);
    //        Symbol.Color = SetHSVColor(90, 50, 100);
    //        ClassifyColor.set_Symbol(4, Symbol as ISymbol);
    //        Symbol.Color = SetHSVColor(120, 100, 100);
    //        ClassifyColor.set_Symbol(5, Symbol as ISymbol);

    //        RasterLayer.Renderer = RasterRender;

    //        //label的设置,一定要放在RasterLayer.Renderer = RasterRender这句后面，否则无效  
    //        string str1 = BreakPoint1.ToString();
    //        string str2 = BreakPoint2.ToString();
    //        string str3 = BreakPoint3.ToString();
    //        string str4 = BreakPoint4.ToString(); ;
    //        string str5 = BreakPoint5.ToString();
    //        ClassifyColor.set_Label(0, "-1 - " + str1);
    //        ClassifyColor.set_Label(1, str1 + " - " + str2);
    //        ClassifyColor.set_Label(2, str2 + " - " + str3);
    //        ClassifyColor.set_Label(3, str3 + " - " + str4);
    //        ClassifyColor.set_Label(4, str4 + " - " + str5);
    //        ClassifyColor.set_Label(5, str5 + " - 1");

    //        ILayerEffects layereffects = RasterLayer as ILayerEffects;//栅格的半透明显示  
    //        layereffects.Transparency = 50;
    //    }  
    }
}
