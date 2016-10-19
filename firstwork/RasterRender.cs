using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class RasterRender : Form
    {
        Form1 mainfrm;
        public RasterRender(Form1 frm)
        {
            this.mainfrm = frm;
            InitializeComponent();
        }
        public IRasterLayer funColorForRaster_Classify(IRasterLayer pRasterLayer)
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
            //ESRI.ArcGIS.Display.IMultiPartColorRamp colorRamp = new MultiPartColorRamp() as IMultiPartColorRamp;
            comboBox1.Items.Add(colorRamp);
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
            return pRasterLayer;
        }
        public IRasterLayer funColorForRaster(IRasterLayer pRasterLayer)
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
            //ESRI.ArcGIS.Display.IMultiPartColorRamp colorRamp = new MultiPartColorRamp() as IMultiPartColorRamp;
            comboBox1.Items.Add(colorRamp);
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
            return pRasterLayer;
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "tif files (*.tif)|*.tif|All files (*.*)|*.*"; //过滤文件类型
            fd.InitialDirectory = Application.StartupPath + "\\Temp\\";//设定初始目录
            fd.ShowReadOnly = true; //设定文件是否只读
            DialogResult r = fd.ShowDialog();
            if (r == DialogResult.OK)
            {
                layerpath.Text = fd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IRasterLayer raster = new RasterLayer();
           raster=funColorForRaster_Classify(OpenImage(layerpath.Text.Trim()));
           mainfrm.mainMap.AddLayer(raster);
        }
    }
}
