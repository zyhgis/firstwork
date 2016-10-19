namespace firstwork
{
    partial class Reclassfy
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
            this.resulttext = new System.Windows.Forms.TextBox();
            this.BtnOutput = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DataGridFilterData = new System.Windows.Forms.DataGrid();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbLineCount = new System.Windows.Forms.ComboBox();
            this.BtnInput = new System.Windows.Forms.Button();
            this.layerpath = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFilterData)).BeginInit();
            this.SuspendLayout();
            // 
            // resulttext
            // 
            this.resulttext.Location = new System.Drawing.Point(72, 218);
            this.resulttext.Name = "resulttext";
            this.resulttext.Size = new System.Drawing.Size(161, 21);
            this.resulttext.TabIndex = 28;
            // 
            // BtnOutput
            // 
            this.BtnOutput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BtnOutput.ForeColor = System.Drawing.Color.Magenta;
            this.BtnOutput.Location = new System.Drawing.Point(266, 218);
            this.BtnOutput.Name = "BtnOutput";
            this.BtnOutput.Size = new System.Drawing.Size(25, 20);
            this.BtnOutput.TabIndex = 27;
            this.BtnOutput.Text = "√";
            this.BtnOutput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOutput.UseVisualStyleBackColor = false;
            this.BtnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 221);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 12);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "输出图层";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(213, 247);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 25;
            this.BtnCancel.Text = "关闭";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(71, 247);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 24;
            this.BtnOK.Text = "确定";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.comboBox1);
            this.GroupBox1.Controls.Add(this.DataGridFilterData);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.CmbLineCount);
            this.GroupBox1.Location = new System.Drawing.Point(14, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(374, 180);
            this.GroupBox1.TabIndex = 23;
            this.GroupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "分类方法：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "等间距",
            "等数量"});
            this.comboBox1.Location = new System.Drawing.Point(238, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(58, 20);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "等间隔";
            // 
            // DataGridFilterData
            // 
            this.DataGridFilterData.CaptionVisible = false;
            this.DataGridFilterData.DataMember = "";
            this.DataGridFilterData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGridFilterData.Location = new System.Drawing.Point(6, 41);
            this.DataGridFilterData.Name = "DataGridFilterData";
            this.DataGridFilterData.Size = new System.Drawing.Size(351, 133);
            this.DataGridFilterData.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 18);
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
            this.CmbLineCount.Location = new System.Drawing.Point(89, 15);
            this.CmbLineCount.Name = "CmbLineCount";
            this.CmbLineCount.Size = new System.Drawing.Size(58, 20);
            this.CmbLineCount.TabIndex = 9;
            this.CmbLineCount.Text = "5";
            this.CmbLineCount.SelectedIndexChanged += new System.EventHandler(this.CmbLineCount_SelectedIndexChanged);
            // 
            // BtnInput
            // 
            this.BtnInput.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BtnInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BtnInput.ForeColor = System.Drawing.Color.Magenta;
            this.BtnInput.Location = new System.Drawing.Point(266, 6);
            this.BtnInput.Name = "BtnInput";
            this.BtnInput.Size = new System.Drawing.Size(25, 20);
            this.BtnInput.TabIndex = 22;
            this.BtnInput.Text = "√";
            this.BtnInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnInput.UseVisualStyleBackColor = false;
            this.BtnInput.Click += new System.EventHandler(this.BtnInput_Click);
            // 
            // layerpath
            // 
            this.layerpath.FormattingEnabled = true;
            this.layerpath.Location = new System.Drawing.Point(71, 6);
            this.layerpath.Name = "layerpath";
            this.layerpath.Size = new System.Drawing.Size(163, 20);
            this.layerpath.TabIndex = 21;
            this.layerpath.SelectedIndexChanged += new System.EventHandler(this.layerpath_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 20;
            this.Label1.Text = "输入图层";
            // 
            // Reclassfy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 272);
            this.Controls.Add(this.resulttext);
            this.Controls.Add(this.BtnOutput);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.BtnInput);
            this.Controls.Add(this.layerpath);
            this.Controls.Add(this.Label1);
            this.Name = "Reclassfy";
            this.Text = "Reclassfy";
            this.Load += new System.EventHandler(this.Reclassfy_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridFilterData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox resulttext;
        internal System.Windows.Forms.Button BtnOutput;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.Button BtnOK;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.DataGrid DataGridFilterData;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox CmbLineCount;
        internal System.Windows.Forms.Button BtnInput;
        internal System.Windows.Forms.ComboBox layerpath;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox comboBox1;
    }
}