using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SpatialAnalyst;
using System.IO;
namespace firstwork
{
    public partial class frmReclass : Form
    {
        int[,] m_intColorRampArray = new int[3, 6];
        private DataTable FilterDataTable= new DataTable();
        float minValue, maxValue ;//记录grid值的最大最小值
        IRaster pRster;
        Form1 FrmGISMain;
        #region 控制只打开一个界面
        public static frmReclass FrmReclass = null;
        #endregion
        public frmReclass(Form1 frm)
        {
            this.FrmGISMain = frm;
            InitializeComponent();
        }

        private void frmReclass_Load(object sender, EventArgs e)
        {
            DataRow FilterRow;
            DataColumn ContourLineOldValue = new DataColumn("旧值", System.Type.GetType("System.String"));
            DataColumn ContourLineNewValue = new DataColumn("新值", System.Type.GetType("System.Int32"));
            DataColumn ContourLineLabelValue = new DataColumn("显示", System.Type.GetType("System.String"));
            //for(int i = 0;i< FrmGISMain.mainMap.LayerCount;i++)
            //{
            //    ILayer pLayer;
            //    pLayer = FrmGISMain.mainMap.get_Layer(i);
            //    if (pLayer is IRasterLayer) 
            //    {
            //        ComboBoxInLayer.Items.Add(pLayer.Name);
            //    }
            //}

            try
            {
                FilterDataTable.Columns.Add(ContourLineOldValue);
                FilterDataTable.Columns.Add(ContourLineNewValue);
                FilterDataTable.Columns.Add(ContourLineLabelValue);
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DataGridFilterData.DataSource = FilterDataTable;
            DataGridFilterData.Refresh();
            FilterDataTable.Rows.Clear();
            for(int i = 0;i< FilterDataTable.Rows.Count;i++)
            {
                FilterDataTable.Rows[i].Delete();// 'RemoveAt(i)
            }
            CmbLineCount.Text = "5";
            FilterDataTable.Rows.Clear();
            List<string> layerpathList = new List<string>();
            layerpathList = GetLayerPath();
            if (layerpathList == null)
                return;
            foreach (string item in layerpathList)
            {
                ComboBoxInLayer.Items.Add(item);
                //selectcomboBox.Items.Add(item);
            }
            //ComboBoxInLayer.Items.Clear();
            //for (int i = 0; i < FrmGISMain.mainMap.LayerCount; i++)
            //{
            //    ILayer pLayer;
            //    pLayer = FrmGISMain.mainMap.get_Layer(i);
            //    if (pLayer is IRasterLayer) 
            //    {
            //        ComboBoxInLayer.Items.Add(pLayer.Name);
            //    }
            //}
            InitColorRamp();
        }
        public List<string> GetLayerPath()
        {
            List<string> LayerPathList = new List<string>();
            ILayer pEnumLayer;
            for (int i = 0; i < FrmGISMain.mainMap.LayerCount; i++)
            {
                pEnumLayer = FrmGISMain.mainMap.get_Layer(i);
                IDataLayer2 dlayer = pEnumLayer as IDataLayer2;
                IDatasetName ds = dlayer.DataSourceName as IDatasetName;
                IWorkspaceName ws = ds.WorkspaceName;
                string layerpath = ws.PathName + pEnumLayer.Name;
                LayerPathList.Add(layerpath);
            }
            return LayerPathList;
        }
       
        public void Reclassify()
        {
            InitColorRamp();
            IRasterWorkspace pRWS;
            IWorkspaceFactory pWorkspaceFactory;
            pWorkspaceFactory = new RasterWorkspaceFactory();
            String wsp;
            int r;
            int l;
            r = ComboBoxInLayer.Text.LastIndexOf("\\");
            l = ComboBoxInLayer.Text.LastIndexOf(".");
            wsp = ComboBoxInLayer.Text.Substring(0, r);
            pRWS = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(wsp, 0);
            try
            {
                string ws = System.IO.Path.GetDirectoryName(ComboBoxInLayer.Text);
                string fbs = System.IO.Path.GetFileName(ComboBoxInLayer.Text);

                IWorkspaceFactory pWork = new RasterWorkspaceFactory();
                IRasterWorkspace pRasterWs = pWork.OpenFromFile(ws, 0) as IRasterWorkspace;
                pRster = pRasterWs.OpenRasterDataset(fbs).CreateDefaultRaster();



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
                List<double> allValue = new List<double>();
                for (int i = 0; i < pPixelBlock.Width; i++)
                {
                    for (int j = 0; j < pPixelBlock.Height; j++)
                    {
                        PixelValue = (float)pPixelBlock.GetVal(0, i, j);
                        allValue.Add(PixelValue);
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

                IRasterBand pRasterBand = new RasterBand();
                pRasterBand = pRasterBandCol.Item(0);
                pRasterBand.ComputeStatsAndHist();

                IRasterStatistics pRasterStatistic;
                //double[] amount = pRasterBand.Histogram.Counts;
                pRasterStatistic = pRasterBand.Statistics;
                maxValue = (float)pRasterStatistic.Maximum;
                minValue = (float)pRasterStatistic.Minimum;

                //if (comboBox1.Text.Trim() == "等间隔")
                //{//先求每个等分间距
                    float Tmpincrement;
                    DataRow FilterRow;
                    Tmpincrement = (maxValue - minValue) / Convert.ToInt16(CmbLineCount.Text);
                    FilterDataTable.Rows.Clear();
                    for (int i = 1; i <= Convert.ToInt16(CmbLineCount.Text); i++)
                    {
                        FilterRow = FilterDataTable.NewRow();
                        FilterRow[0] = Convert.ToString(minValue + Tmpincrement * (i - 1)) + "~" + Convert.ToString(minValue + Tmpincrement * i);
                        FilterRow[1] = i;
                        FilterRow[2] = i;
                        FilterDataTable.Rows.Add(FilterRow);
                    }
                    DataGridFilterData.DataSource = FilterDataTable;
                    DataGridFilterData.Refresh();
               // }
//else
               // {
                    ////allValue.Sort();
                    ////List<double> valuesort = new List<double>();
                    ////valuesort = BublleSort(allValue);
                    //allValue.Sort();
                    //int amount = pPixelBlock.Width * pPixelBlock.Height;
                    //int Tmpincrement;
                    //DataRow FilterRow;
                    //Tmpincrement = (amount) / Convert.ToInt16(CmbLineCount.Text);
                    //FilterDataTable.Rows.Clear();
                    //for (int i = 1; i < Convert.ToInt16(CmbLineCount.Text); i++)
                    //{
                    //    FilterRow = FilterDataTable.NewRow();
                    //    if (allValue[Tmpincrement * (i - 1)] == allValue[Tmpincrement * (i)])
                    //        break;
                    //    FilterRow[0] = Convert.ToString(allValue[Tmpincrement * (i - 1)]) + "~" + Convert.ToString(allValue[Tmpincrement * (i)]);
                    //    FilterRow[1] = i;
                    //    FilterDataTable.Rows.Add(FilterRow);
                    //}
                    //if (allValue[Tmpincrement * Convert.ToInt16(CmbLineCount.Text)] != maxValue)
                    //{
                    //    FilterRow = FilterDataTable.NewRow();
                    //    FilterRow[0] = Convert.ToString(allValue[Tmpincrement * Convert.ToInt16(CmbLineCount.Text)]) + "~" + Convert.ToString(maxValue);
                    //    FilterRow[1] = Convert.ToInt16(CmbLineCount.Text);
                    //    FilterDataTable.Rows.Add(FilterRow);
                    //}
                    //DataGridFilterData.DataSource = FilterDataTable;
                    //DataGridFilterData.Refresh();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
            String strPath ; //  '文件名
            OpenFileDlg.FileName = "";
            OpenFileDlg.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*";
            OpenFileDlg.FilterIndex = 2;
            OpenFileDlg.ShowDialog();


            strPath = OpenFileDlg.FileName.Trim();
            if (strPath == "") return;

            ComboBoxInLayer.Text = strPath;
            //获取图层的栅格信息
            Reclassify();
        }

        private void ComboBoxInLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
           //获得绘制的等值线的最大值 和最小值 以 设置绘制级数 
            Reclassify();
            //double Tmpincrement;
            //IRasterLayer pLayer;
            //int selindex = -1;
            //for (int i = 0; i < FrmGISMain.mainMap.LayerCount; i++)
            //{
            //    if (FrmGISMain.mainMap.get_Layer(i).Name == ComboBoxInLayer.Text)
            //    selindex = i;
            //}
            //if (selindex ==-1) return ;
            //pLayer = (IRasterLayer)FrmGISMain.mainMap.get_Layer(selindex);

            //try
            //{
            //    pRster = pLayer.Raster;
            //    IRasterBandCollection pRasterBandCol ;
            //    pRasterBandCol = (IRasterBandCollection)pRster;

            //    IRasterBand pRasterBand;
            //    pRasterBand = pRasterBandCol.Item(0);
            //    pRasterBand.ComputeStatsAndHist();
            //    IRasterStatistics pRasterStatistic ;
            //    pRasterStatistic = pRasterBand.Statistics;
            //    maxValue =(float) pRasterStatistic.Maximum;
            //    minValue = (float)pRasterStatistic.Minimum;

            //    //先求每个等分间距
            //    DataRow FilterRow ;
            //    Tmpincrement = (maxValue - minValue) / Convert.ToInt16(CmbLineCount.Text);
            //    FilterDataTable.Rows.Clear();
            //    for (int i = 1 ;i<= Convert.ToInt16(CmbLineCount.Text);i++)
            //    {
            //        FilterRow = FilterDataTable.NewRow();
            //        FilterRow[0] = Convert.ToString(minValue + Tmpincrement * (i - 1)) + "~" + Convert.ToString(minValue + Tmpincrement * i);
            //        FilterRow[1] = i;
            //        FilterDataTable.Rows.Add(FilterRow);
            //    }
            //    DataGridFilterData.DataSource = FilterDataTable;
            //    DataGridFilterData.Refresh();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
        }

        private void CmbLineCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reclassify();
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitColorRamp()
        {
            //设置参数
            m_intColorRampArray[0, 0] = 0;
            m_intColorRampArray[0, 1] = 60;
            m_intColorRampArray[0, 2] = 90;
            m_intColorRampArray[0, 3] = 100;
            m_intColorRampArray[0, 4] = 70;
            m_intColorRampArray[0, 5] = 85;

            m_intColorRampArray[1, 0] = 120;
            m_intColorRampArray[1, 1] = 220;
            m_intColorRampArray[1, 2] = 90;
            m_intColorRampArray[1, 3] = 100;
            m_intColorRampArray[1, 4] = 70;
            m_intColorRampArray[1, 5] = 85;

            m_intColorRampArray[2, 0] = 0;
            m_intColorRampArray[2, 1] = 120;
            m_intColorRampArray[2, 2] = 90;
            m_intColorRampArray[2, 3] = 100;
            m_intColorRampArray[2, 4] = 70;
            m_intColorRampArray[2, 5] = 85;

            ///////////////////////////
            //加载图例

            int i = 0;
            imgCmbSingleClassify.Items.Clear();
            for (i = 0; i < 3; i++)
            {
                imgCmbSingleClassify.Items.Add(new ImageComboItem("", i, false));
            }
            imgCmbSingleClassify.SelectedIndex = 0;

        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            IReclassOp reCla;
            reCla = new RasterReclassOp() as IReclassOp;
            //为分类着色用
            IRemap pRemap;
            INumberRemap pSRemap;
            pSRemap = new NumberRemap() as INumberRemap;

            for (int i = 1; i <= Convert.ToInt32(DataGridFilterData.VisibleRowCount-1); i++)
            {
                String str ;
                //DataGridFilterData.ce
                str = DataGridFilterData[i - 1,0].ToString();
                
                float fvalue, tvalue;
                int p ;
                p = str.LastIndexOf("~");
                fvalue = Convert.ToSingle(str.Substring(0, p));
                tvalue = Convert.ToSingle(str.Substring(p+1, str.Length - p-1));
                pSRemap.MapRange(fvalue, tvalue, i);
               
            }

            // pSRemap.MapValueToNoData(-9999)
            pRemap = (IRemap)pSRemap;
            
            IGeoDataset pOutputRaster = null ;
            try
            {
                pOutputRaster = reCla.ReclassByRemap((IGeoDataset)pRster, pRemap, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            IRasterLayer pRlayer;
            pRlayer = new RasterLayer();
            pRlayer.CreateFromRaster((IRaster)pOutputRaster);
            pRlayer.Name = Name + "Reclass";
            IRaster ds;
            ds = (IRaster)pOutputRaster;
            IRasterLayer pla;
            pla = SetStretchRenderer(ds); 
            IColorRamp pRamp;
            //获得色带
            int index = imgCmbSingleClassify.SelectedIndex;
            pRamp = AlgorithmicColorRamp(index, DataGridFilterData.VisibleRowCount - 1);
            //分级色带渲染
            SingleClassifyRender(pRlayer, DataGridFilterData.VisibleRowCount - 1, pRamp);
            FrmGISMain.mainMap.AddLayer(pRlayer, 0);
            //FrmGISMain.mainMap.AddLayer(pRlayer, 0);
            Oput(pRlayer);
            //Output(pRlayer);

        }
        public IColorRamp AlgorithmicColorRamp(int ImageLstIndex, int ClassCount)
        {
            //Create a color ramp to use
            IAlgorithmicColorRamp pRamp;
            pRamp = new AlgorithmicColorRamp();
            bool blncreate = true;
            pRamp.Size = ClassCount;

            IRgbColor pFromRgbColor = new RgbColor();//构建一个RgbColorClass
            IRgbColor pToRgbColor = new RgbColor();//构建一个RgbColorClass
            if (ImageLstIndex == 0)
            {
                pFromRgbColor.Red = 255;//设置Red属性
                pFromRgbColor.Green = 255;//设置Green属性
                pFromRgbColor.Blue = 0;//设置Blue属性

                pToRgbColor.Red = 255;//设置Red属性
                pToRgbColor.Green = 0;//设置Green属性
                pToRgbColor.Blue = 0;//设置Blue属性
            }
            else if (ImageLstIndex == 1)
            {
                pFromRgbColor.Red = 0;//设置Red属性
                pFromRgbColor.Green = 255;//设置Green属性
                pFromRgbColor.Blue = 0;//设置Blue属性

                pToRgbColor.Red = 0;//设置Red属性
                pToRgbColor.Green = 0;//设置Green属性
                pToRgbColor.Blue = 255;//设置Blue属性
            }
            else if (ImageLstIndex == 2)
            {
                pFromRgbColor.Red = 0;//设置Red属性
                pFromRgbColor.Green = 255;//设置Green属性
                pFromRgbColor.Blue = 0;//设置Blue属性

                pToRgbColor.Red = 255;//设置Red属性
                pToRgbColor.Green = 0;//设置Green属性
                pToRgbColor.Blue = 0;//设置Blue属性
            }
            else
            {
                pFromRgbColor.Red = 255;//设置Red属性
                pFromRgbColor.Green = 255;//设置Green属性
                pFromRgbColor.Blue = 0;//设置Blue属性

                pToRgbColor.Red = 255;//设置Red属性
                pToRgbColor.Green = 0;//设置Green属性
                pToRgbColor.Blue = 0;//设置Blue属性
            }
            pRamp.FromColor = (IColor)pFromRgbColor;
            pRamp.ToColor = (IColor)pToRgbColor;

            pRamp.CreateRamp(out blncreate);

            return pRamp as IColorRamp;
        }

       
        //更新色带渲染
        private void SingleClassifyRender(ILayer pLayerR, int NumOfClass, IColorRamp colorRamp)
        {
            // Get raster input from layer
            IRasterLayer pRLayer;
            pRLayer = pLayerR as IRasterLayer;
            IRaster pRaster;
            pRaster = pRLayer.Raster;

            //Create classfy renderer and QI RasterRenderer interface
            IRasterClassifyColorRampRenderer pClassRen;
            pClassRen = new RasterClassifyColorRampRenderer();
            IRasterRenderer pRasRen;
            pRasRen = (IRasterRenderer)pClassRen;

            //Set raster for the render and update
            pRasRen.Raster = pRaster;
            //pClassRen.ClassCount = NumOfClass;
            pClassRen.ClassCount = NumOfClass;

            //pRasRen.Update();


            //Create symbol for the classes
            IFillSymbol pFSymbol;
            pFSymbol = new SimpleFillSymbol();
            //http://blog.csdn.net/jack5s/article/details/48184819
            pRLayer.Renderer = (IRasterRenderer)pClassRen;  //label的设置,一定要放在RasterLayer.Renderer = RasterRender这句后面，否则无效  
            //loop through the classes and apply the color and label
            int i;
            for (i = 0; i < pClassRen.ClassCount; i++)
            {
                pFSymbol.Color = colorRamp.get_Color(i);
                pClassRen.set_Symbol(i, (ISymbol)pFSymbol);
                pClassRen.set_Label(i, DataGridFilterData[i,2].ToString());
                //pClassRen.set_Label(i, "Class" + i.ToString());
            }
            //Update the renderer and plug into layer
            //pRasRen.Update();
            pRLayer.Renderer = (IRasterRenderer)pClassRen;
        }


        public static IRasterLayer SetStretchRenderer(IRaster pRaster)
        {
            try
            {
                //创建着色类和QI栅格着色
                IRasterStretchColorRampRenderer pStretchRen = new RasterStretchColorRampRenderer();
                IRasterRenderer pRasRen = pStretchRen as IRasterRenderer;
                //为着色和更新设置栅格数据
                pRasRen.Raster = pRaster;
                pRasRen.Update();
                //定义起点和终点颜色
                IColor pFromColor = new RgbColor();
                IRgbColor pRgbColor = pFromColor as IRgbColor;
                pRgbColor.Red = 255;
                pRgbColor.Green = 0;
                pRgbColor.Blue = 0;
                IColor pToColor = new RgbColor();
                pRgbColor = pToColor as IRgbColor;
                pRgbColor.Red = 0;
                pRgbColor.Green = 255;
                pRgbColor.Blue = 0;
                //创建颜色分级
                IAlgorithmicColorRamp pRamp = new AlgorithmicColorRamp();
                pRamp.Size = 255;
                pRamp.FromColor = pFromColor;
                pRamp.ToColor = pToColor;
                bool ok = true;
                pRamp.CreateRamp(out ok);
                //把颜色分级插入着色中并选择一个波段
                pStretchRen.BandIndex = 0;
                pStretchRen.ColorRamp = pRamp;
                pRasRen.Update();
                IRasterLayer pRLayer = new RasterLayer();
                pRLayer.CreateFromRaster(pRaster);
                pRLayer.Renderer = pStretchRen as IRasterRenderer;
                return pRLayer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Oput(IRasterLayer rasterLayer)
        {

            IRaster pRaster = rasterLayer.Raster;
            IRasterProps pRasterProps = (IRasterProps)pRaster;
            IRasterLayerExport rLayerExport = new RasterLayerExport();
            rLayerExport.RasterLayer = rasterLayer;
            rLayerExport.Extent = pRasterProps.Extent;//设置提取栅格数据的范围即为Raster数据的范围
            rLayerExport.SpatialReference = pRasterProps.SpatialReference;// 设置当前栅格数据的投影信息
            IWorkspaceFactory pWF = new RasterWorkspaceFactory();

            string filePath = System.IO.Path.GetDirectoryName(ComboBoxInLayer.Text);
            //string fbs = System.IO.Path.GetFileName(ComboBoxInLayer.Text);
            string fileName = "";

            //Export file
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            //IWorkspace workspace = workspaceFactory.OpenFromFile(ws, 0);
            //string filePath = "", fileName = "", outputFormat = "";
           // filePath = saveDG.FileName;
            fileName = "wew.tif";
             

            //filePath = "";
           // IWorkspace pRasterWorkspace = pWF.OpenFromFile("C:\\", 0);

           // IRasterDataset outGeoDataset = rLayerExport.Export(pRasterWorkspace, fileName, "TIFF");
        }

        
        public void Output(IRasterLayer rasterLayer)
        {
            //Create and fill the IRasterLayer object
            //IRasterLayer rasterLayer = new RasterLayerClass();
            //rasterLayer.CreateFromDataset(productDataset);
            //rasterLayer.Renderer = StretchRenderer(rasterLayer.Raster);

            //Prepare the export
            var rle = new RasterLayerExport();
            IRasterLayerExport rle2 = rle as IRasterLayerExport;
            rle2.RasterLayer = rasterLayer;
            rle2.Extent = rasterLayer.VisibleExtent;
            rle2.Force2RGB = false;
            //IRasterStorageDef rsd = new RasterStorageDef();
            //rsd.CompressionType = esriRasterCompressionType.esriRasterCompressionUncompressed;
            //rle2.StorageDef = rsd;

            string ws = System.IO.Path.GetDirectoryName(ComboBoxInLayer.Text);
            string fbs = System.IO.Path.GetFileName(ComboBoxInLayer.Text);

            //IWorkspaceFactory pWork = new RasterWorkspaceFactory();
            //IRasterWorkspace pRasterWs = pWork.OpenFromFile(ws, 0) as IRasterWorkspace;

            //Export file
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(ws, 0);
            var test = rle2.Export(workspace, "FILEX.TIF", "TIFF");
            MessageBox.Show("");
        }
        private void BtnOutput_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reclassify();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
