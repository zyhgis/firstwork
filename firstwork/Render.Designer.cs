namespace firstwork
{
    partial class Render
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Render));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRasterLayerName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpMultiBandsStretch = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbBandSelect = new System.Windows.Forms.ComboBox();
            this.grpRGBComposite = new System.Windows.Forms.GroupBox();
            this.cmbBlue = new System.Windows.Forms.ComboBox();
            this.cmbGreen = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRed = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpDiscreteColor = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpUniqueValue = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSingleStrech = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpSingleClassify = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClassCount = new System.Windows.Forms.ComboBox();
            this.GvwSingleClassify = new System.Windows.Forms.DataGridView();
            this.CmnIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnStartRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnEndRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstMethodName = new System.Windows.Forms.ListBox();
            this.iltColorRamp = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2.SuspendLayout();
            this.grpMultiBandsStretch.SuspendLayout();
            this.grpRGBComposite.SuspendLayout();
            this.grpDiscreteColor.SuspendLayout();
            this.grpUniqueValue.SuspendLayout();
            this.grpSingleStrech.SuspendLayout();
            this.grpSingleClassify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvwSingleClassify)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择栅格图层:";
            // 
            // cmbRasterLayerName
            // 
            this.cmbRasterLayerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRasterLayerName.FormattingEnabled = true;
            this.cmbRasterLayerName.Location = new System.Drawing.Point(127, 9);
            this.cmbRasterLayerName.Name = "cmbRasterLayerName";
            this.cmbRasterLayerName.Size = new System.Drawing.Size(194, 20);
            this.cmbRasterLayerName.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(397, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(306, 327);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grpMultiBandsStretch);
            this.groupBox2.Controls.Add(this.grpRGBComposite);
            this.groupBox2.Controls.Add(this.grpDiscreteColor);
            this.groupBox2.Controls.Add(this.grpUniqueValue);
            this.groupBox2.Controls.Add(this.grpSingleStrech);
            this.groupBox2.Controls.Add(this.grpSingleClassify);
            this.groupBox2.Location = new System.Drawing.Point(151, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 272);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置参数";
            // 
            // grpMultiBandsStretch
            // 
            this.grpMultiBandsStretch.Controls.Add(this.label7);
            this.grpMultiBandsStretch.Controls.Add(this.label8);
            this.grpMultiBandsStretch.Controls.Add(this.cmbBandSelect);
            this.grpMultiBandsStretch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMultiBandsStretch.Location = new System.Drawing.Point(3, 17);
            this.grpMultiBandsStretch.Name = "grpMultiBandsStretch";
            this.grpMultiBandsStretch.Size = new System.Drawing.Size(539, 252);
            this.grpMultiBandsStretch.TabIndex = 4;
            this.grpMultiBandsStretch.TabStop = false;
            this.grpMultiBandsStretch.Text = "多波段拉伸渲染";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "波段选择:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "色带选择:";
            // 
            // cmbBandSelect
            // 
            this.cmbBandSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBandSelect.FormattingEnabled = true;
            this.cmbBandSelect.Location = new System.Drawing.Point(103, 25);
            this.cmbBandSelect.Name = "cmbBandSelect";
            this.cmbBandSelect.Size = new System.Drawing.Size(92, 20);
            this.cmbBandSelect.TabIndex = 0;
            // 
            // grpRGBComposite
            // 
            this.grpRGBComposite.Controls.Add(this.cmbBlue);
            this.grpRGBComposite.Controls.Add(this.cmbGreen);
            this.grpRGBComposite.Controls.Add(this.label11);
            this.grpRGBComposite.Controls.Add(this.label10);
            this.grpRGBComposite.Controls.Add(this.cmbRed);
            this.grpRGBComposite.Controls.Add(this.label9);
            this.grpRGBComposite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRGBComposite.Location = new System.Drawing.Point(3, 17);
            this.grpRGBComposite.Name = "grpRGBComposite";
            this.grpRGBComposite.Size = new System.Drawing.Size(539, 252);
            this.grpRGBComposite.TabIndex = 1;
            this.grpRGBComposite.TabStop = false;
            this.grpRGBComposite.Text = "多波段RGB合成渲染";
            // 
            // cmbBlue
            // 
            this.cmbBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlue.FormattingEnabled = true;
            this.cmbBlue.Location = new System.Drawing.Point(106, 93);
            this.cmbBlue.Name = "cmbBlue";
            this.cmbBlue.Size = new System.Drawing.Size(121, 20);
            this.cmbBlue.TabIndex = 10;
            // 
            // cmbGreen
            // 
            this.cmbGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGreen.FormattingEnabled = true;
            this.cmbGreen.Location = new System.Drawing.Point(106, 58);
            this.cmbGreen.Name = "cmbGreen";
            this.cmbGreen.Size = new System.Drawing.Size(121, 20);
            this.cmbGreen.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "蓝色B:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "绿色G:";
            // 
            // cmbRed
            // 
            this.cmbRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRed.FormattingEnabled = true;
            this.cmbRed.Location = new System.Drawing.Point(106, 23);
            this.cmbRed.Name = "cmbRed";
            this.cmbRed.Size = new System.Drawing.Size(121, 20);
            this.cmbRed.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "红色R:";
            // 
            // grpDiscreteColor
            // 
            this.grpDiscreteColor.Controls.Add(this.label6);
            this.grpDiscreteColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDiscreteColor.Location = new System.Drawing.Point(3, 17);
            this.grpDiscreteColor.Name = "grpDiscreteColor";
            this.grpDiscreteColor.Size = new System.Drawing.Size(539, 252);
            this.grpDiscreteColor.TabIndex = 1;
            this.grpDiscreteColor.TabStop = false;
            this.grpDiscreteColor.Text = "离散颜色渲染";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "离散颜色渲染";
            // 
            // grpUniqueValue
            // 
            this.grpUniqueValue.Controls.Add(this.label5);
            this.grpUniqueValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUniqueValue.Location = new System.Drawing.Point(3, 17);
            this.grpUniqueValue.Name = "grpUniqueValue";
            this.grpUniqueValue.Size = new System.Drawing.Size(539, 252);
            this.grpUniqueValue.TabIndex = 6;
            this.grpUniqueValue.TabStop = false;
            this.grpUniqueValue.Text = "唯一值渲染";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "唯一值渲染";
            // 
            // grpSingleStrech
            // 
            this.grpSingleStrech.Controls.Add(this.label4);
            this.grpSingleStrech.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSingleStrech.Location = new System.Drawing.Point(3, 17);
            this.grpSingleStrech.Name = "grpSingleStrech";
            this.grpSingleStrech.Size = new System.Drawing.Size(539, 252);
            this.grpSingleStrech.TabIndex = 5;
            this.grpSingleStrech.TabStop = false;
            this.grpSingleStrech.Text = "拉伸渲染";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "色带选择:";
            // 
            // grpSingleClassify
            // 
            this.grpSingleClassify.Controls.Add(this.label3);
            this.grpSingleClassify.Controls.Add(this.label2);
            this.grpSingleClassify.Controls.Add(this.cmbClassCount);
            this.grpSingleClassify.Controls.Add(this.GvwSingleClassify);
            this.grpSingleClassify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSingleClassify.Location = new System.Drawing.Point(3, 17);
            this.grpSingleClassify.Name = "grpSingleClassify";
            this.grpSingleClassify.Size = new System.Drawing.Size(539, 252);
            this.grpSingleClassify.TabIndex = 0;
            this.grpSingleClassify.TabStop = false;
            this.grpSingleClassify.Text = "分级渲染";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "色带选择:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分级数:";
            // 
            // cmbClassCount
            // 
            this.cmbClassCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassCount.FormattingEnabled = true;
            this.cmbClassCount.Location = new System.Drawing.Point(327, 20);
            this.cmbClassCount.Name = "cmbClassCount";
            this.cmbClassCount.Size = new System.Drawing.Size(64, 20);
            this.cmbClassCount.TabIndex = 2;
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
            this.GvwSingleClassify.Location = new System.Drawing.Point(12, 74);
            this.GvwSingleClassify.Name = "GvwSingleClassify";
            this.GvwSingleClassify.ReadOnly = true;
            this.GvwSingleClassify.RowTemplate.Height = 23;
            this.GvwSingleClassify.Size = new System.Drawing.Size(521, 169);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstMethodName);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 285);
            this.groupBox1.TabIndex = 6;
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
            // 
            // iltColorRamp
            // 
            this.iltColorRamp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iltColorRamp.ImageStream")));
            this.iltColorRamp.TransparentColor = System.Drawing.Color.Transparent;
            this.iltColorRamp.Images.SetKeyName(0, "YellowToRed.bmp");
            this.iltColorRamp.Images.SetKeyName(1, "GreenToBlue.bmp");
            this.iltColorRamp.Images.SetKeyName(2, "GreenToRed.bmp");
            // 
            // Render
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRasterLayerName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Render";
            this.Text = "Render";
            this.groupBox2.ResumeLayout(false);
            this.grpMultiBandsStretch.ResumeLayout(false);
            this.grpMultiBandsStretch.PerformLayout();
            this.grpRGBComposite.ResumeLayout(false);
            this.grpRGBComposite.PerformLayout();
            this.grpDiscreteColor.ResumeLayout(false);
            this.grpDiscreteColor.PerformLayout();
            this.grpUniqueValue.ResumeLayout(false);
            this.grpUniqueValue.PerformLayout();
            this.grpSingleStrech.ResumeLayout(false);
            this.grpSingleStrech.PerformLayout();
            this.grpSingleClassify.ResumeLayout(false);
            this.grpSingleClassify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvwSingleClassify)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRasterLayerName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpMultiBandsStretch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBandSelect;
        private System.Windows.Forms.GroupBox grpRGBComposite;
        private System.Windows.Forms.ComboBox cmbBlue;
        private System.Windows.Forms.ComboBox cmbGreen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbRed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpDiscreteColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpUniqueValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpSingleStrech;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpSingleClassify;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClassCount;
        private System.Windows.Forms.DataGridView GvwSingleClassify;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnStartRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnEndRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnRemark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstMethodName;
        internal System.Windows.Forms.ImageList iltColorRamp;
    }
}