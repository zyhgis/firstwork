namespace firstwork
{
    partial class FrmRasterRender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRasterRender));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMethodName = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpSingleStrech = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imgCmbStrech = new System.Windows.Forms.ImageCombo();
            this.iltColorRamp = new System.Windows.Forms.ImageList(this.components);
            this.grpSingleClassify = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClassCount = new System.Windows.Forms.ComboBox();
            this.imgCmbSingleClassify = new System.Windows.Forms.ImageCombo();
            this.GvwSingleClassify = new System.Windows.Forms.DataGridView();
            this.CmnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnStartRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnEndRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbRasterLayerName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpSingleStrech.SuspendLayout();
            this.grpSingleClassify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvwSingleClassify)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMethodName);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "渲染方法";
            // 
            // lstMethodName
            // 
            this.lstMethodName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethodName.FormattingEnabled = true;
            this.lstMethodName.ItemHeight = 12;
            this.lstMethodName.Location = new System.Drawing.Point(3, 17);
            this.lstMethodName.Name = "lstMethodName";
            this.lstMethodName.Size = new System.Drawing.Size(132, 265);
            this.lstMethodName.TabIndex = 0;
            this.lstMethodName.SelectedIndexChanged += new System.EventHandler(this.lstMethodName_SelectedIndexChanged);
            this.lstMethodName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMethodName_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpSingleStrech);
            this.groupBox2.Controls.Add(this.grpSingleClassify);
            this.groupBox2.Location = new System.Drawing.Point(156, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 272);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置参数";
            // 
            // grpSingleStrech
            // 
            this.grpSingleStrech.Controls.Add(this.label4);
            this.grpSingleStrech.Controls.Add(this.imgCmbStrech);
            this.grpSingleStrech.Location = new System.Drawing.Point(327, 31);
            this.grpSingleStrech.Name = "grpSingleStrech";
            this.grpSingleStrech.Size = new System.Drawing.Size(195, 217);
            this.grpSingleStrech.TabIndex = 5;
            this.grpSingleStrech.TabStop = false;
            this.grpSingleStrech.Text = "拉伸渲染";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "色带选择:";
            // 
            // imgCmbStrech
            // 
            this.imgCmbStrech.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imgCmbStrech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgCmbStrech.FormattingEnabled = true;
            this.imgCmbStrech.ImageList = this.iltColorRamp;
            this.imgCmbStrech.Location = new System.Drawing.Point(23, 80);
            this.imgCmbStrech.Name = "imgCmbStrech";
            this.imgCmbStrech.Size = new System.Drawing.Size(167, 22);
            this.imgCmbStrech.TabIndex = 2;
            // 
            // iltColorRamp
            // 
            this.iltColorRamp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iltColorRamp.ImageStream")));
            this.iltColorRamp.TransparentColor = System.Drawing.Color.Transparent;
            this.iltColorRamp.Images.SetKeyName(0, "YellowToRed.bmp");
            this.iltColorRamp.Images.SetKeyName(1, "GreenToBlue.bmp");
            this.iltColorRamp.Images.SetKeyName(2, "GreenToRed.bmp");
            // 
            // grpSingleClassify
            // 
            this.grpSingleClassify.Controls.Add(this.label3);
            this.grpSingleClassify.Controls.Add(this.label2);
            this.grpSingleClassify.Controls.Add(this.cmbClassCount);
            this.grpSingleClassify.Controls.Add(this.imgCmbSingleClassify);
            this.grpSingleClassify.Controls.Add(this.GvwSingleClassify);
            this.grpSingleClassify.Location = new System.Drawing.Point(0, 20);
            this.grpSingleClassify.Name = "grpSingleClassify";
            this.grpSingleClassify.Size = new System.Drawing.Size(321, 228);
            this.grpSingleClassify.TabIndex = 0;
            this.grpSingleClassify.TabStop = false;
            this.grpSingleClassify.Text = "分级渲染";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "色带选择:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分级数:";
            // 
            // cmbClassCount
            // 
            this.cmbClassCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassCount.FormattingEnabled = true;
            this.cmbClassCount.Location = new System.Drawing.Point(91, 49);
            this.cmbClassCount.Name = "cmbClassCount";
            this.cmbClassCount.Size = new System.Drawing.Size(64, 20);
            this.cmbClassCount.TabIndex = 2;
            this.cmbClassCount.SelectedIndexChanged += new System.EventHandler(this.cmbClassCount_SelectedIndexChanged);
            // 
            // imgCmbSingleClassify
            // 
            this.imgCmbSingleClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imgCmbSingleClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgCmbSingleClassify.FormattingEnabled = true;
            this.imgCmbSingleClassify.ImageList = this.iltColorRamp;
            this.imgCmbSingleClassify.Location = new System.Drawing.Point(72, 20);
            this.imgCmbSingleClassify.Name = "imgCmbSingleClassify";
            this.imgCmbSingleClassify.Size = new System.Drawing.Size(214, 22);
            this.imgCmbSingleClassify.TabIndex = 1;
            this.imgCmbSingleClassify.SelectedIndexChanged += new System.EventHandler(this.imgCmbSingleClassify_SelectedIndexChanged);
            // 
            // GvwSingleClassify
            // 
            this.GvwSingleClassify.AllowUserToAddRows = false;
            this.GvwSingleClassify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvwSingleClassify.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CmnIndex,
            this.CmnColor,
            this.ClnStartRange,
            this.CmnEndRange,
            this.CmnRemark});
            this.GvwSingleClassify.Location = new System.Drawing.Point(11, 85);
            this.GvwSingleClassify.Name = "GvwSingleClassify";
            this.GvwSingleClassify.ReadOnly = true;
            this.GvwSingleClassify.RowTemplate.Height = 23;
            this.GvwSingleClassify.Size = new System.Drawing.Size(283, 127);
            this.GvwSingleClassify.TabIndex = 0;
            // 
            // CmnIndex
            // 
            this.CmnIndex.HeaderText = "序号";
            this.CmnIndex.Name = "CmnIndex";
            this.CmnIndex.ReadOnly = true;
            this.CmnIndex.Width = 60;
            // 
            // CmnColor
            // 
            this.CmnColor.HeaderText = "颜色";
            this.CmnColor.Name = "CmnColor";
            this.CmnColor.ReadOnly = true;
            this.CmnColor.Width = 60;
            // 
            // ClnStartRange
            // 
            this.ClnStartRange.HeaderText = "起始范围";
            this.ClnStartRange.Name = "ClnStartRange";
            this.ClnStartRange.ReadOnly = true;
            this.ClnStartRange.Width = 80;
            // 
            // CmnEndRange
            // 
            this.CmnEndRange.HeaderText = "终止范围";
            this.CmnEndRange.Name = "CmnEndRange";
            this.CmnEndRange.ReadOnly = true;
            this.CmnEndRange.Width = 80;
            // 
            // CmnRemark
            // 
            this.CmnRemark.HeaderText = "标注";
            this.CmnRemark.Name = "CmnRemark";
            this.CmnRemark.ReadOnly = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(232, 342);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(402, 342);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbRasterLayerName
            // 
            this.cmbRasterLayerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRasterLayerName.FormattingEnabled = true;
            this.cmbRasterLayerName.Location = new System.Drawing.Point(132, 25);
            this.cmbRasterLayerName.Name = "cmbRasterLayerName";
            this.cmbRasterLayerName.Size = new System.Drawing.Size(194, 20);
            this.cmbRasterLayerName.TabIndex = 4;
            this.cmbRasterLayerName.SelectedIndexChanged += new System.EventHandler(this.cmblayerName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择栅格图层:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(429, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 20);
            this.comboBox1.TabIndex = 6;
            // 
            // FrmRasterRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 399);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRasterLayerName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRasterRender";
            this.Text = "栅格数据渲染";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRasterRender_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRasterRender_FormClosed);
            this.Load += new System.EventHandler(this.FrmRasterRender_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpSingleStrech.ResumeLayout(false);
            this.grpSingleStrech.PerformLayout();
            this.grpSingleClassify.ResumeLayout(false);
            this.grpSingleClassify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvwSingleClassify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstMethodName;
        private System.Windows.Forms.ComboBox cmbRasterLayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSingleClassify;
        private System.Windows.Forms.DataGridView GvwSingleClassify;
        private System.Windows.Forms.ImageCombo imgCmbSingleClassify;
        internal System.Windows.Forms.ImageList iltColorRamp;
        private System.Windows.Forms.ComboBox cmbClassCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnStartRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnEndRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnRemark;
        private System.Windows.Forms.GroupBox grpSingleStrech;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageCombo imgCmbStrech;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}