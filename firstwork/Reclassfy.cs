using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class Reclassfy : Form
    {
        object varNewValues, varNewCounts;
        private DataTable FilterDataTable = new DataTable();
        float minValue, maxValue;//记录grid值的最大最小值
        IRaster pRster;
        Form1 mainfrm;
        IClassifyGEN mClassify;  
        public Reclassfy(Form1 frm)
        {
            this.mainfrm = frm;
            InitializeComponent();
        }
        public List<string> GetLayerPath()
        {
            List<string> LayerPathList = new List<string>();
            ILayer pEnumLayer;
            for (int i = 0; i < mainfrm.mainMap.LayerCount; i++)
            {
                pEnumLayer = mainfrm.mainMap.get_Layer(i);
                IDataLayer2 dlayer = pEnumLayer as IDataLayer2;
                IDatasetName ds = dlayer.DataSourceName as IDatasetName;
                IWorkspaceName ws = ds.WorkspaceName;
                string layerpath = ws.PathName + pEnumLayer.Name;
                LayerPathList.Add(layerpath);
            }
            return LayerPathList;
        }

        private void Reclassfy_Load(object sender, EventArgs e)
        {
            List<string> layerpathList = new List<string>();
            layerpathList = GetLayerPath();
            if (layerpathList == null)
                return;
            foreach (string item in layerpathList)
            {
                layerpath.Items.Add(item);
                //selectcomboBox.Items.Add(item);
            }
            DataRow FilterRow;
            DataColumn ContourLineOldValue = new DataColumn("旧值", System.Type.GetType("System.String"));
            DataColumn ContourLineNewValue = new DataColumn("新值", System.Type.GetType("System.Int32"));

            

            try
            {
                FilterDataTable.Columns.Add(ContourLineOldValue);
                FilterDataTable.Columns.Add(ContourLineNewValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DataGridFilterData.DataSource = FilterDataTable;
            DataGridFilterData.Refresh();
            FilterDataTable.Rows.Clear();
            for (int i = 0; i < FilterDataTable.Rows.Count; i++)
            {
                FilterDataTable.Rows[i].Delete();// 'RemoveAt(i)
            }
            CmbLineCount.Text = "5";
            FilterDataTable.Rows.Clear();

            //ComboBoxInLayer.Items.Clear();
            //for (int i = 0; i < FrmGISMain.m_mapControl.LayerCount; i++)
            //{
            //    ILayer pLayer;
            //    pLayer = FrmGISMain.m_mapControl.get_Layer(i);
            //    if (pLayer is IRasterLayer)
            //    {
            //        ComboBoxInLayer.Items.Add(pLayer.Name);
            //    }
            //}
        }
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

        private void BtnInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDlg = new OpenFileDialog();
            String strPath; //  '文件名
            OpenFileDlg.FileName = "";
            OpenFileDlg.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            OpenFileDlg.FilterIndex = 2;
            OpenFileDlg.ShowDialog();


            strPath = OpenFileDlg.FileName.Trim();


            layerpath.Text = strPath;
            //获取图层的栅格信息
            IRasterWorkspace pRWS;
            IWorkspaceFactory pWorkspaceFactory;
            pWorkspaceFactory = new RasterWorkspaceFactory();
            String wsp;
            int r;
            int l;
            r = layerpath.Text.LastIndexOf("\\");
            l = layerpath.Text.LastIndexOf(".");
            wsp = layerpath.Text.Substring(0, r);
            pRWS = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(wsp, 0);
            
            try
            {
                string ws = Path.GetDirectoryName(layerpath.Text);
            string fbs = Path.GetFileName(layerpath.Text);

            IWorkspaceFactory pWork = new RasterWorkspaceFactory();
            IRasterWorkspace pRasterWs = pWork.OpenFromFile(ws, 0) as IRasterWorkspace;
                pRster = pRasterWs.OpenRasterDataset(fbs).CreateDefaultRaster();

               
                //pRster = pRWS.OpenRasterDataset(sp)
                IRasterBandCollection pRasterBandCol;
                pRasterBandCol = (IRasterBandCollection)pRster;


                IRawPixels pRawpixel;
                pRawpixel = (IRawPixels)pRasterBandCol.Item(0);
                IRasterProps pRasterProps;
                pRasterProps = (IRasterProps)pRawpixel;
                IPnt pSize;
                pSize = new DblPnt();
                pSize.SetCoords(pRasterProps.Width, pRasterProps.Height);
                IPixelBlock pPixelBlock;
                pPixelBlock = pRawpixel.CreatePixelBlock(pSize);
                IPnt pPnt;
                pPnt = new DblPnt();
                pPnt.X = 0; //the origin (top left corner) of the PixelBlock
                pPnt.Y = 0;
                pRawpixel.Read(pPnt, pPixelBlock);
                float PixelValue;

                minValue = 10000000;
                maxValue = 0;
                for (int i = 0; i < pPixelBlock.Width; i++)
                {
                    for (int j = 0; j < pPixelBlock.Height; j++)
                    {
                        PixelValue = (float)pPixelBlock.GetVal(0, i, j);
                        if (PixelValue != null)
                        {
                            if (PixelValue > maxValue)
                            {
                                maxValue = PixelValue;
                            }
                            if (PixelValue < minValue)
                            {
                                minValue = PixelValue;
                            }
                        }
                    }
                }

                IRasterBand pRasterBand;
                pRasterBand = pRasterBandCol.Item(0);
                pRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRasterStatistic;
                pRasterStatistic = pRasterBand.Statistics;
                maxValue = (float)pRasterStatistic.Maximum;
                minValue = (float)pRasterStatistic.Minimum;

                //先求每个等分间距
                float Tmpincrement;
                DataRow FilterRow;
                Tmpincrement = (maxValue - minValue) / Convert.ToInt16(CmbLineCount.Text);
                FilterDataTable.Rows.Clear();
                for (int i = 1; i < Convert.ToInt16(CmbLineCount.Text); i++)
                {
                    FilterRow = FilterDataTable.NewRow();
                    FilterRow[0] = Convert.ToString(minValue + Tmpincrement * (i - 1)) + "~" + Convert.ToString(minValue + Tmpincrement * i);
                    FilterRow[1] = i;
                    FilterDataTable.Rows.Add(FilterRow);
                }
                DataGridFilterData.DataSource = FilterDataTable;
                DataGridFilterData.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void layerpath_SelectedIndexChanged(object sender, EventArgs e)
        {
            double Tmpincrement;
            IRasterLayer pLayer;
            int selindex = -1;
            for (int i = 0; i < mainfrm.mainMap.LayerCount; i++)
            {
                if (mainfrm.mainMap.get_Layer(i).Name == layerpath.Text)
                    selindex = i;
            }
            if (selindex == -1) return;
            pLayer = (IRasterLayer)mainfrm.mainMap.get_Layer(selindex);

            try
            {
                pRster = pLayer.Raster;
                IRasterBandCollection pRasterBandCol;
                pRasterBandCol = (IRasterBandCollection)pRster;

                IRasterBand pRasterBand;
                pRasterBand = pRasterBandCol.Item(0);
                pRasterBand.ComputeStatsAndHist();
                IRasterStatistics pRasterStatistic;
                pRasterStatistic = pRasterBand.Statistics;
                maxValue = (float)pRasterStatistic.Maximum;
                minValue = (float)pRasterStatistic.Minimum;

                //先求每个等分间距
                DataRow FilterRow;
                Tmpincrement = (maxValue - minValue) / Convert.ToInt16(CmbLineCount.Text);
                FilterDataTable.Rows.Clear();
                for (int i = 1; i <= Convert.ToInt16(CmbLineCount.Text); i++)
                {
                    FilterRow = FilterDataTable.NewRow();
                    FilterRow[0] = Convert.ToString(minValue + Tmpincrement * (i - 1)) + "-" + Convert.ToString(minValue + Tmpincrement * i);
                    FilterRow[1] = i;
                    FilterDataTable.Rows.Add(FilterRow);
                }
                DataGridFilterData.DataSource = FilterDataTable;
                DataGridFilterData.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CmbLineCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layerpath.Text.Length > 0)
            {
                //先求每个等分间距
                float Tmpincrement;
                DataRow FilterRow;
                Tmpincrement = (maxValue - minValue) / Convert.ToInt16(CmbLineCount.Text);
                FilterDataTable.Rows.Clear();
                for (int i = 1; i <= Convert.ToInt16(CmbLineCount.Text); i++)
                {
                    FilterRow = FilterDataTable.NewRow();
                    FilterRow[0] = Convert.ToString(minValue + Tmpincrement * (i - 1)) + "~" + Convert.ToString(minValue + Tmpincrement * i);
                    FilterRow[1] = i;
                    FilterDataTable.Rows.Add(FilterRow);
                }
                DataGridFilterData.DataSource = FilterDataTable;
                DataGridFilterData.Refresh();
            }
        }

        private void BtnOutput_Click(object sender, EventArgs e)
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

         private void BtnOK_Click(object sender, EventArgs e)
        {
            List<string> indexlist = new List<string>();
            indexlist.Add(layerpath.Text.Trim());
            indexlist.Add(resulttext.Text.Trim());
            for (int i = 1; i <= Convert.ToInt32(CmbLineCount.Text)-1; i++)
            {
                String str;
                str = DataGridFilterData[i - 1, 0].ToString();
                string fvalue, tvalue;
                int p;
                p = str.LastIndexOf("~");
                fvalue = str.Substring(0, p);
                indexlist.Add(fvalue);
                //tvalue = Convert.ToSingle(str.Substring(p + 1, str.Length - p - 1));
                //pSRemap.MapRange(fvalue, tvalue, i);
            }
            string str2 = DataGridFilterData[Convert.ToInt32(CmbLineCount.Text)-2, 0].ToString();
            int p2;
            p2 = str2.LastIndexOf("~");
            indexlist.Add(str2.Substring(p2 + 1, str2.Length - p2 - 1));
            for (int i = 1; i <= Convert.ToInt32(CmbLineCount.Text) - 1; i++)
            {
                String str;
                str = DataGridFilterData[i - 1, 1].ToString();
                indexlist.Add(str);
            }
            string sArgName = "Recalssify2.py";
            string args = "";
            List<string> teps = indexlist;
            Control.CheckForIllegalCrossThreadCalls = false;
            Process pro = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "python\\" + sArgName;// 获得python文件的绝对路径
            pro.StartInfo.FileName = @"C:\Python27\python.exe";
            string sArguments = path;
            if (teps.Count > 0)
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
            pro.StartInfo.Arguments = sArguments;
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true; //FALSE为显示cmd窗口

            pro.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            pro.Start();
            pro.BeginOutputReadLine();
            //p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived); //监听获得cmd中的输出信息
            pro.EnableRaisingEvents = true;//程序退出引发事件
            //p.Exited += new EventHandler(robotOpenProcess_Exited);
            //Console.ReadLine();
            pro.WaitForExit();
            IRasterLayer rasterLayer;
            rasterLayer = new RasterLayer();
            rasterLayer.CreateFromFilePath(resulttext.Text.Trim());
            mainfrm.mainMap.AddLayer(rasterLayer);
           // mainfrm.mainMap.AddLayer(resulttext.Text.Trim());
            //Subfrm.Close();
            //RunPythonScript rps = new RunPythonScript(mainfrm, "");
            ////QAClass inputqa = new QAClass();
            //rps.pythonscript = "firstndvimean.py";
            //rps.temp = "";
            //rps.index = indexlist;
            //rps.RunPythonScriptFunction();
        }
    }
}
