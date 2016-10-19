using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesFile;


namespace firstwork
{
    public partial class FrmRasterRender : Form
    {
        Form1 _frmMain;

        #region 控制只打开一个界面
        public static FrmRasterRender TmpFrmRasterRender = null;
        #endregion

        int[,] m_intColorRampArray = new int[3,6];


        public FrmRasterRender()
        {
            InitializeComponent();
        }

        public FrmRasterRender(Form1 TmpFrom)
        {
            InitializeComponent();
            _frmMain = TmpFrom;
        }

        private void FrmRasterRender_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRasterRender.TmpFrmRasterRender = null;
        }

        private void FrmRasterRender_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void cmblayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRasterLayerName.Text != "")
            {
                //单波段
                if (BandsCount(cmbRasterLayerName.Text) == 1)
                {
                    lstMethodName.Items.Clear();
                    lstMethodName.Items.Add("唯一值渲染");
                    lstMethodName.Items.Add("分级渲染");
                    lstMethodName.Items.Add("拉伸渲染");
                    lstMethodName.Items.Add("离散颜色渲染");
                }
                else//多波段
                {
                    lstMethodName.Items.Clear();
                    lstMethodName.Items.Add("多波段分级渲染");
                    lstMethodName.Items.Add("RGB合成渲染");
                }
            }
        }

        private void FrmRasterRender_Load(object sender, EventArgs e)
        {
            LoadRasterLyrName();
        }

        //添加栅格图层名到combo中
        #region 添加栅格图层名到combo中
        private void LoadRasterLyrName()
        {
            int i;
            ILayer pLayer;
            cmbRasterLayerName.Items.Clear();

            for (i = 0; i < _frmMain.mainMap.LayerCount; i ++ )
            {
                pLayer = _frmMain.mainMap.get_Layer(i);
                if (pLayer is IRasterLayer)
                {
                    cmbRasterLayerName.Items.Add(pLayer.Name);
                }
            }
            if (cmbRasterLayerName.Items.Count > 0)
            {
                cmbRasterLayerName.Text = cmbRasterLayerName.Items[0].ToString();
            }
        }
        #endregion

        //判断图层是不是多波段图层
        #region 判断图层是不是多波段图层
        private int BandsCount(string strRasterLyrName)
        {
            int MyLyrIndex;
            int pBandCount = -1;
            MyLyrIndex = GetLyrIndex(strRasterLyrName);
            if (MyLyrIndex >= 0)
            {
                IRasterLayer myrasterlayer = _frmMain.mainMap.get_Layer(MyLyrIndex) as IRasterLayer;
                IRaster myRaster = myrasterlayer.Raster;
                IRasterBandCollection myRasterBandCollection = myRaster as IRasterBandCollection;
                pBandCount = myRasterBandCollection.Count;
            }
            return pBandCount;
        }

        #endregion

        //返回图层的LayerIndex
        #region 返回图层的LayerIndex
        private int GetLyrIndex(string lyrName)
        {
            int ReturnIndex = -1;
            int i;
            for (i = 0; i < _frmMain.mainMap.LayerCount; i++)
            {
                if (_frmMain.mainMap.get_Layer(i).Name == lyrName)
                {
                    ReturnIndex = i;
                    break;
                }
            }
            return ReturnIndex;
        }
        #endregion

        //确定渲染
        private void btnOk_Click(object sender, EventArgs e)
        {
            //单波段
            if (BandsCount(cmbRasterLayerName.Text) == 1)
            {
                if (lstMethodName.SelectedItem.ToString() == "唯一值渲染")
                {
                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);

                    //唯一值渲染
                    UniqueValueRender(MyLyr);
                    _frmMain.mainMap.ActiveView.Refresh();
                    _frmMain.mainMap.Refresh();
                    _frmMain.mainMap.Refresh();
                }
                else if (lstMethodName.SelectedItem.ToString() == "分级渲染")
                {
                    //
                    int ClassCount =Convert.ToInt32(cmbClassCount.Text);
                    int ColorIndex = imgCmbSingleClassify.SelectedIndex;
                    IColorRamp pRamp;
                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);
                    //获得色带
                    pRamp = AlgorithmicColorRamp(ColorIndex, ClassCount);
                    //分级色带渲染
                    SingleClassifyRender(MyLyr, ClassCount, pRamp);
                    _frmMain.mainMap.ActiveView.Refresh();
                    _frmMain.mainMap.Refresh();
                   
                    _frmMain.axTOCControl1.Refresh();
                }
                else if (lstMethodName.SelectedItem.ToString() == "拉伸渲染")
                {
                    int ColorIndex = imgCmbStrech.SelectedIndex;
                    IColorRamp pRamp;
                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);
                    //获得色带
                    pRamp = StretchAlgorithmicColorRamp(ColorIndex);
                    //拉伸色带渲染
                    StretchColorRampRenderer(MyLyr, pRamp);
                    _frmMain.mainMap.ActiveView.Refresh();
                    _frmMain.mainMap.Refresh();
                    _frmMain.axTOCControl1.Refresh();
                }
                else if (lstMethodName.SelectedItem.ToString() == "离散颜色渲染")
                {
                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);

                    //离散颜色渲染
                    DiscreteColorRender(MyLyr);
                    _frmMain.mainMap.ActiveView.Refresh();
                    _frmMain.mainMap.Refresh();
                    _frmMain.axTOCControl1.Refresh();
                }
            }
            else//多波段
            {
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择渲染方法时
        private void lstMethodName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //单波段
            if (BandsCount(cmbRasterLayerName.Text) == 1)
            {
                if (lstMethodName.SelectedItem.ToString() == "唯一值渲染")
                {
                    //grpSingleStrech.Visible = false;
                    //grpSingleClassify.Visible = false;
                    //grpUniqueValue.Visible = true;
                    //grpDiscreteColor.Visible = false;

                    //grpRGBComposite.Visible = false;
                    //grpMultiBandsStretch.Visible = false;
                }
                else if (lstMethodName.SelectedItem.ToString() == "分级渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = true;
                    

                    SingleClassifySet();
                }
                else if (lstMethodName.SelectedItem.ToString() == "拉伸渲染")
                {
                    grpSingleStrech.Visible = true;
                    grpSingleClassify.Visible = false;
                   
                    SingleStrechSet();
                }
                else if (lstMethodName.SelectedItem.ToString() == "离散颜色渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = false;
                }
                //
            }
            else//多波段
            {
                
            }
        }

        #region 分级渲染设置
        private void SingleClassifySet()
        {
            int i;
            cmbClassCount.Items.Clear();
            for (i = 0; i < 32; i ++ )
            {
                cmbClassCount.Items.Add(i + 1);
            }
            cmbClassCount.Text = "5";

            InitColorRamp();
        }

        //设置色带（以后改）
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

        /// <summary>
        /// 创建一个Random色带
        /// </summary>
        /// <returns></returns>
        public IColorRamp RandomColorRamp(int ImageLstIndex, int ClassCount)
        {
            //为渲染符号创建一个色带
            IRandomColorRamp pRandomColorRamp = new RandomColorRamp();
            if (ImageLstIndex >= 0 && ImageLstIndex <= 2)
            {
                pRandomColorRamp.StartHue = m_intColorRampArray[ImageLstIndex, 0];
                pRandomColorRamp.EndHue = m_intColorRampArray[ImageLstIndex, 1];
                pRandomColorRamp.MinValue = m_intColorRampArray[ImageLstIndex, 2];
                pRandomColorRamp.MaxValue = m_intColorRampArray[ImageLstIndex, 3];
                pRandomColorRamp.MinSaturation = m_intColorRampArray[ImageLstIndex, 4];
                pRandomColorRamp.MaxSaturation = m_intColorRampArray[ImageLstIndex, 5];
            }
            else
            {
                pRandomColorRamp.StartHue = m_intColorRampArray[0, 0];
                pRandomColorRamp.EndHue = m_intColorRampArray[0, 1];
                pRandomColorRamp.MinValue = m_intColorRampArray[0, 2];
                pRandomColorRamp.MaxValue = m_intColorRampArray[0, 3];
                pRandomColorRamp.MinSaturation = m_intColorRampArray[0, 4];
                pRandomColorRamp.MaxSaturation = m_intColorRampArray[0, 5];
            }
            
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = 43;

            bool blnout = true;
            pRandomColorRamp.CreateRamp(out blnout);
            return pRandomColorRamp as IColorRamp;
        }

        private IColorRamp UniqueValueRandomColorRamp(int NumOfValues, int seedCount)
        {
            //为渲染符号创建一个色带
            IRandomColorRamp pRandomColorRamp = new RandomColorRamp();
          
            pRandomColorRamp.UseSeed = true;
            pRandomColorRamp.Seed = seedCount;
            pRandomColorRamp.Size = NumOfValues;

            bool blnout = true;
            pRandomColorRamp.CreateRamp(out blnout);
            return pRandomColorRamp as IColorRamp;
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

        private IColorRamp StretchAlgorithmicColorRamp(int ImageLstIndex)
        {
            IAlgorithmicColorRamp pRamp = new AlgorithmicColorRamp();

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
            pRamp.Size = 255;
            bool blncreate = true;
            pRamp.CreateRamp(out blncreate);

            return pRamp as IColorRamp;
        }
        #endregion

        #region 分级色带渲染方法
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
            pRasRen =(IRasterRenderer) pClassRen;
    
            //Set raster for the render and update
            pRasRen.Raster = pRaster;
            //pClassRen.ClassCount = NumOfClass;
            pClassRen.ClassCount = NumOfClass;

            //pRasRen.Update();

            
            //Create symbol for the classes
            IFillSymbol pFSymbol;
            pFSymbol = new SimpleFillSymbol();

            //loop through the classes and apply the color and label
            int i;
            for (i = 0; i < pClassRen.ClassCount; i ++)
            {
                pFSymbol.Color = colorRamp.get_Color(i);
                pClassRen.set_Symbol(i,(ISymbol)pFSymbol);
                pClassRen.set_Label(i, "Class" + i.ToString());
            }
            //Update the renderer and plug into layer
            //pRasRen.Update();
            pRLayer.Renderer =(IRasterRenderer) pClassRen;
        }


        /// <summary>
        /// 分类色带渲染
        /// </summary>
        /// <param name="classCount">分类数</param>
        /// <param name="colorRamp">色带</param>
        public void ClassifyColorRampRenderer(ILayer pLayerR, IColorRamp colorRamp, string classfield, System.Windows.Forms.DataGridView datagridview)
        {
            try
            {
                IRasterLayer pRasterLayer = pLayerR as IRasterLayer;
                IRaster raster = pRasterLayer.Raster;
                IRasterRenderer pRasterRenderer = new RasterClassifyColorRampRenderer() as IRasterRenderer;
                pRasterRenderer.Raster = raster;
                IRasterClassifyColorRampRenderer classifyRenderer = pRasterRenderer as IRasterClassifyColorRampRenderer;
                
                
                int classcount = datagridview.RowCount;
                classifyRenderer.ClassCount = classcount;
                classifyRenderer.ClassField = classfield;
                for (int i = 0; i < datagridview.RowCount; i++)
                {
                    classifyRenderer.set_Break(i, double.Parse(datagridview.Rows[i].Cells[0].Value.ToString()));
                }
                pRasterRenderer.Update();
                colorRamp.Size = 15;
                bool pOk;
                colorRamp.CreateRamp(out pOk);
                //create symbol for the classes
                IFillSymbol fillSymbol = new SimpleFillSymbol();
                for (int i = 0; i < classifyRenderer.ClassCount - 1; i++)
                {
                    fillSymbol.Color = colorRamp.get_Color(i);
                    classifyRenderer.set_Symbol(i, (ISymbol)fillSymbol);
                    classifyRenderer.set_Label(i, classifyRenderer.get_Break(i).ToString() + "—" + datagridview.Rows[i].Cells[1].Value.ToString());
                }
                pRasterLayer.Renderer = classifyRenderer as IRasterRenderer;
            }
            catch
            {

            }
        }


        #endregion

        #region 拉伸渲染设置
        private void SingleStrechSet()
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
            imgCmbStrech.Items.Clear();
            for (i = 0; i < 3; i++)
            {
                imgCmbStrech.Items.Add(new ImageComboItem("", i, false));
            }
            imgCmbStrech.SelectedIndex = 0;
        }


        #endregion

        #region 拉伸渲染

        //采用 AlgorithmicColorRamp 色带
        private void StretchColorRampRenderer(ILayer pLayerR, IColorRamp colorRamp) 
        {
            //Get raster input from layer
            IRasterLayer pRLayer =(IRasterLayer) pLayerR;
            IRaster pRaster = pRLayer.Raster;

            //Create renderer and QI RasterRenderer
            IRasterStretchColorRampRenderer pStretchRen = new RasterStretchColorRampRenderer();
            IRasterRenderer pRasRen;
            pRasRen = (IRasterRenderer)pStretchRen;
    
            //Set raster for the renderer and update
            pRasRen.Raster = pRaster;
            pRasRen.Update();

            // Plug this colorramp into renderer and select a band
            pStretchRen.BandIndex = 0;
            pStretchRen.ColorRamp = colorRamp;

            //Update the renderer with new settings and plug into layer
            pRasRen.Update();
            pRLayer.Renderer =(IRasterRenderer) pStretchRen;
        }
        #endregion

        #region 唯一值渲染
        private void UniqueValueRender(ILayer pLayerR)
        {
            //Get raster input from layer
            IRasterLayer pRLayer =(IRasterLayer) pLayerR;
            IRaster pRaster = pRLayer.Raster;

            //Get the number of rows from raster table
            ITable pTable;
            IRasterBand pBand;
            IRasterBandCollection pBandCol;
            pBandCol = (IRasterBandCollection)pRaster;
            pBand = pBandCol.Item(0);
            bool TableExist;
            pBand.HasTable(out TableExist);

            if (TableExist == false)
            {
                return;
            }
            pTable = pBand.AttributeTable;
            int NumOfValues;
            NumOfValues = pTable.RowCount(null);

            //Specified a field and get the field index for the specified field to be rendered.
            int FieldIndex;
            string FieldName;
            //Value is the default field, you can specify other field here
            FieldName = "Value";
            FieldIndex = pTable.FindField(FieldName);

            IColorRamp MyColorRamp = UniqueValueRandomColorRamp(NumOfValues, 100);

            ISimpleFillSymbol pFSymbol;
            //Create UniqueValue renderer and QI RasterRenderer
            IRasterUniqueValueRenderer pUVRen = new RasterUniqueValueRenderer();
            IRasterRenderer pRasRen;
            pRasRen =(IRasterRenderer) pUVRen;

            //Connect the renderer and the raster
            pRasRen.Raster = pRaster;
            pRasRen.Update();

            //Set UniqueValue renerer
            pUVRen.HeadingCount = 1; //' Use one heading
            pUVRen.set_Heading(0, "All Data Values");
            pUVRen.set_ClassCount(0,NumOfValues);
            pUVRen.Field = FieldName;

            int i;
            IRow pRow;
            object LabelValue;
            for (i = 0; i < NumOfValues; i ++)
            {
                //Get a row from the table
                pRow = pTable.GetRow(i);
                LabelValue = pRow.get_Value(FieldIndex);
                pUVRen.AddValue(0, i, LabelValue);//Get a row from the table
                pUVRen.set_Label(0, i,Convert.ToString(LabelValue));

                pFSymbol = new SimpleFillSymbol();
                pFSymbol.Color = MyColorRamp.get_Color(i);

                pUVRen.set_Symbol(0, i,(ISymbol) pFSymbol);
            }
            //Update render and refresh layer
            pRasRen.Update();
            pRLayer.Renderer =(IRasterRenderer) pUVRen;
         }

        #endregion

        #region 离散颜色渲染
        private void DiscreteColorRender(ILayer pLayerR)
        {
            //Get raster input from layer
            IRasterLayer pRLayer = (IRasterLayer)pLayerR;
            IRaster pRaster = pRLayer.Raster;
            IRasterDiscreteColorRenderer pDiscreteColorRenderer = new RasterDiscreteColorRenderer();
            IRasterRenderer pRasterRenderer = pDiscreteColorRenderer as IRasterRenderer;

            IColorRamp MyColorRamp;
            MyColorRamp = UniqueValueRandomColorRamp(300,100);
            int colornum = 300;

            IRasterRendererColorRamp pRasterEndererColorRamp = pRasterRenderer as IRasterRendererColorRamp;
            pRasterEndererColorRamp.ColorRamp = MyColorRamp;
            pDiscreteColorRenderer.NumColors = colornum;
            pRasterRenderer.Raster = pRLayer.Raster;
            pRLayer.Renderer = pRasterRenderer;
        }

        #endregion

        #region RGB组合渲染
        private void RGBCompositeRender(ILayer pLayerR, int bandred, int bandgreen, int bandblue)
        {
            // Get raster input from layer
            IRasterLayer rasterLayer = (IRasterLayer)pLayerR;
            IRaster raster = rasterLayer.Raster;
            IRasterBandCollection bandCol = (IRasterBandCollection)raster;
            if (bandCol.Count < 3)
            {
                return;
            }

            // Create UniqueValue renderer and QI RasterRenderer
            IRasterRGBRenderer2 rasterRGBRen = new RasterRGBRenderer() as IRasterRGBRenderer2;
            IRasterRenderer rasterRen = (IRasterRenderer)rasterRGBRen;

            // Connect the renderer and the raster
            rasterRen.Raster = raster;
            rasterRen.Update();

            rasterRGBRen.RedBandIndex = bandred;
            rasterRGBRen.GreenBandIndex = bandgreen;
            rasterRGBRen.BlueBandIndex = bandblue;

            //Update render and refresh layer
            rasterRen.Update();
            rasterLayer.Renderer = (IRasterRenderer)rasterRGBRen;
        }

        #endregion

        

        

        #region 多波段拉伸渲染
        private void MultiBandsStretchRender(ILayer pLayerR, int BandRenderNumber, IColorRamp colorRamp)
        {
            //Get raster input from layer
            IRasterLayer pRLayer = (IRasterLayer)pLayerR;
            IRaster pRaster = pRLayer.Raster;

            //Create renderer and QI RasterRenderer
            IRasterStretchColorRampRenderer pStretchRen = new RasterStretchColorRampRenderer();
            IRasterRenderer pRasRen;
            pRasRen = (IRasterRenderer)pStretchRen;

            //Set raster for the renderer and update
            pRasRen.Raster = pRaster;
            pRasRen.Update();

            // Plug this colorramp into renderer and select a band
            pStretchRen.BandIndex = BandRenderNumber;
            pStretchRen.ColorRamp = colorRamp;

            //Update the renderer with new settings and plug into layer
            pRasRen.Update();
            pRLayer.Renderer = (IRasterRenderer)pStretchRen;
        }
        #endregion



        //颜色条变化  在datagridview中更新
        private void imgCmbSingleClassify_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //数量变化  在datagirdview中更新
        private void cmbClassCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            double RasterMaxValue;
            double RasterMinValue;
            int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
            ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);

            GvwSingleClassify.Rows.Clear();
            GvwSingleClassify.AllowUserToAddRows = false;
            for (i = 0; i < Convert.ToInt32(cmbClassCount.Text); i ++ )
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(GvwSingleClassify);
                dr.Cells[0].Value = (i + 1).ToString();
                dr.Cells[1].Value = "";
                dr.Cells[1].Style.BackColor = Color.Blue;
                dr.Cells[2].Value = "";
                dr.Cells[3].Value = "";
                dr.Cells[4].Value = "";
                //dgv.Rows.Insert(0, dr);                     //添加的行作为第一行
                GvwSingleClassify.Rows.Add(dr);                         //添加的行作为最后一行
            }
        }

        private void lstMethodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //单波段
            if (BandsCount(cmbRasterLayerName.Text) == 1)
            {
                if (lstMethodName.SelectedItem.ToString() == "唯一值渲染")
                {
                }
                else if (lstMethodName.SelectedItem.ToString() == "分级渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = true;
                    SingleClassifySet();
                }
                else if (lstMethodName.SelectedItem.ToString() == "拉伸渲染")
                {
                    grpSingleStrech.Visible = true;
                    grpSingleClassify.Visible = false;
                   
                    SingleStrechSet();
                }
                else if (lstMethodName.SelectedItem.ToString() == "离散颜色渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = false;
                    
                }
                //
            }
            else//多波段
            {
                if (lstMethodName.SelectedItem.ToString() == "分级渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = false;
                  

                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);
                  
                }
                else if (lstMethodName.SelectedItem.ToString() == "RGB合成渲染")
                {
                    grpSingleStrech.Visible = false;
                    grpSingleClassify.Visible = false;
                    

                    int LyrIndex = GetLyrIndex(cmbRasterLayerName.Text);
                    ILayer MyLyr = _frmMain.mainMap.get_Layer(LyrIndex);
                   
                }
            }
        }

    }
}
