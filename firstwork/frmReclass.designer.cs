namespace firstwork
{
    partial class frmReclass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReclass));
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imgCmbSingleClassify = new System.Windows.Forms.ImageCombo();
            this.iltColorRamp = new System.Windows.Forms.ImageList(this.components);
            this.DataGridFilterData = new System.Windows.Forms.DataGrid();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbLineCount = new System.Windows.Forms.ComboBox();
            this.ComboBoxInLayer = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.BtnInput = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFilterData)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.FileName = "OpenFileDialog1";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(273, 258);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(69, 23);
            this.BtnCancel.TabIndex = 16;
            this.BtnCancel.Text = "关闭";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(209, 258);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(58, 23);
            this.BtnOK.TabIndex = 15;
            this.BtnOK.Text = "确定";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.imgCmbSingleClassify);
            this.GroupBox1.Controls.Add(this.DataGridFilterData);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.CmbLineCount);
            this.GroupBox1.Location = new System.Drawing.Point(14, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(389, 220);
            this.GroupBox1.TabIndex = 14;
            this.GroupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "色带选择:";
            // 
            // imgCmbSingleClassify
            // 
            this.imgCmbSingleClassify.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imgCmbSingleClassify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgCmbSingleClassify.FormattingEnabled = true;
            this.imgCmbSingleClassify.ImageList = this.iltColorRamp;
            this.imgCmbSingleClassify.Location = new System.Drawing.Point(97, 41);
            this.imgCmbSingleClassify.Name = "imgCmbSingleClassify";
            this.imgCmbSingleClassify.Size = new System.Drawing.Size(177, 22);
            this.imgCmbSingleClassify.TabIndex = 20;
            // 
            // iltColorRamp
            // 
            this.iltColorRamp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iltColorRamp.ImageStream")));
            this.iltColorRamp.TransparentColor = System.Drawing.Color.Transparent;
            this.iltColorRamp.Images.SetKeyName(0, "YellowToRed.bmp");
            this.iltColorRamp.Images.SetKeyName(1, "GreenToBlue.bmp");
            this.iltColorRamp.Images.SetKeyName(2, "GreenToRed.bmp");
            // 
            // DataGridFilterData
            // 
            this.DataGridFilterData.CaptionVisible = false;
            this.DataGridFilterData.DataMember = "";
            this.DataGridFilterData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGridFilterData.Location = new System.Drawing.Point(6, 81);
            this.DataGridFilterData.Name = "DataGridFilterData";
            this.DataGridFilterData.Size = new System.Drawing.Size(377, 133);
            this.DataGridFilterData.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 12);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "分类级数：";
            // 
            // CmbLineCount
            // 
            this.CmbLineCount.FormattingEnabled = true;
            this.CmbLineCount.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.CmbLineCount.Location = new System.Drawing.Point(97, 15);
            this.CmbLineCount.Name = "CmbLineCount";
            this.CmbLineCount.Size = new System.Drawing.Size(58, 20);
            this.CmbLineCount.TabIndex = 9;
            this.CmbLineCount.Text = "5";
            this.CmbLineCount.SelectedIndexChanged += new System.EventHandler(this.CmbLineCount_SelectedIndexChanged);
            // 
            // ComboBoxInLayer
            // 
            this.ComboBoxInLayer.FormattingEnabled = true;
            this.ComboBoxInLayer.Location = new System.Drawing.Point(77, 6);
            this.ComboBoxInLayer.Name = "ComboBoxInLayer";
            this.ComboBoxInLayer.Size = new System.Drawing.Size(290, 20);
            this.ComboBoxInLayer.TabIndex = 12;
            this.ComboBoxInLayer.SelectedIndexChanged += new System.EventHandler(this.ComboBoxInLayer_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "输入图层";
            // 
            // BtnInput
            // 
            this.BtnInput.Image = ((System.Drawing.Image)(resources.GetObject("BtnInput.Image")));
            this.BtnInput.Location = new System.Drawing.Point(371, 5);
            this.BtnInput.Name = "BtnInput";
            this.BtnInput.Size = new System.Drawing.Size(26, 21);
            this.BtnInput.TabIndex = 36;
            this.BtnInput.UseVisualStyleBackColor = true;
            this.BtnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 37;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmReclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 309);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnInput);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.ComboBoxInLayer);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReclass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "重分类";
            this.Load += new System.EventHandler(this.frmReclass_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFilterData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog OpenFileDlg;
        internal System.Windows.Forms.SaveFileDialog SaveFileDlg;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.DataGrid DataGridFilterData;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox CmbLineCount;
        internal System.Windows.Forms.ComboBox ComboBoxInLayer;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ImageCombo imgCmbSingleClassify;
        internal System.Windows.Forms.ImageList iltColorRamp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnInput;
        private System.Windows.Forms.Button button1;
    }
}