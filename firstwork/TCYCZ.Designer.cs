namespace firstwork
{
    partial class TCYCZ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCYCZ));
            this.resulttext = new System.Windows.Forms.TextBox();
            this.hidehelpbt = new System.Windows.Forms.Button();
            this.showhelpbt = new System.Windows.Forms.Button();
            this.concelbt = new System.Windows.Forms.Button();
            this.resfilebt = new System.Windows.Forms.Button();
            this.selfilebt = new System.Windows.Forms.Button();
            this.datafilebt = new System.Windows.Forms.Button();
            this.selectcomboBox = new System.Windows.Forms.ComboBox();
            this.invaliddata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.okbt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datacomboBox = new System.Windows.Forms.ComboBox();
            this.ignoredata = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.helptext = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // resulttext
            // 
            this.resulttext.Location = new System.Drawing.Point(16, 148);
            this.resulttext.Name = "resulttext";
            this.resulttext.Size = new System.Drawing.Size(298, 21);
            this.resulttext.TabIndex = 32;
            // 
            // hidehelpbt
            // 
            this.hidehelpbt.Location = new System.Drawing.Point(286, 218);
            this.hidehelpbt.Name = "hidehelpbt";
            this.hidehelpbt.Size = new System.Drawing.Size(74, 23);
            this.hidehelpbt.TabIndex = 31;
            this.hidehelpbt.Text = "<<隐藏帮助";
            this.hidehelpbt.UseVisualStyleBackColor = true;
            this.hidehelpbt.Visible = false;
            this.hidehelpbt.Click += new System.EventHandler(this.hidehelpbt_Click);
            // 
            // showhelpbt
            // 
            this.showhelpbt.Location = new System.Drawing.Point(281, 226);
            this.showhelpbt.Name = "showhelpbt";
            this.showhelpbt.Size = new System.Drawing.Size(74, 23);
            this.showhelpbt.TabIndex = 30;
            this.showhelpbt.Text = "显示帮助>>";
            this.showhelpbt.UseVisualStyleBackColor = true;
            this.showhelpbt.Click += new System.EventHandler(this.showhelpbt_Click);
            // 
            // concelbt
            // 
            this.concelbt.Location = new System.Drawing.Point(214, 226);
            this.concelbt.Name = "concelbt";
            this.concelbt.Size = new System.Drawing.Size(61, 23);
            this.concelbt.TabIndex = 29;
            this.concelbt.Text = "取消";
            this.concelbt.UseVisualStyleBackColor = true;
            this.concelbt.Click += new System.EventHandler(this.concelbt_Click);
            // 
            // resfilebt
            // 
            this.resfilebt.Image = ((System.Drawing.Image)(resources.GetObject("resfilebt.Image")));
            this.resfilebt.Location = new System.Drawing.Point(329, 147);
            this.resfilebt.Name = "resfilebt";
            this.resfilebt.Size = new System.Drawing.Size(26, 21);
            this.resfilebt.TabIndex = 28;
            this.resfilebt.UseVisualStyleBackColor = true;
            this.resfilebt.Click += new System.EventHandler(this.resfilebt_Click);
            // 
            // selfilebt
            // 
            this.selfilebt.Image = ((System.Drawing.Image)(resources.GetObject("selfilebt.Image")));
            this.selfilebt.Location = new System.Drawing.Point(329, 95);
            this.selfilebt.Name = "selfilebt";
            this.selfilebt.Size = new System.Drawing.Size(26, 21);
            this.selfilebt.TabIndex = 27;
            this.selfilebt.UseVisualStyleBackColor = true;
            this.selfilebt.Click += new System.EventHandler(this.selfilebt_Click);
            // 
            // datafilebt
            // 
            this.datafilebt.Image = ((System.Drawing.Image)(resources.GetObject("datafilebt.Image")));
            this.datafilebt.Location = new System.Drawing.Point(329, 36);
            this.datafilebt.Name = "datafilebt";
            this.datafilebt.Size = new System.Drawing.Size(26, 21);
            this.datafilebt.TabIndex = 26;
            this.datafilebt.UseVisualStyleBackColor = true;
            this.datafilebt.Click += new System.EventHandler(this.datafilebt_Click);
            // 
            // selectcomboBox
            // 
            this.selectcomboBox.FormattingEnabled = true;
            this.selectcomboBox.Location = new System.Drawing.Point(15, 89);
            this.selectcomboBox.Name = "selectcomboBox";
            this.selectcomboBox.Size = new System.Drawing.Size(300, 20);
            this.selectcomboBox.TabIndex = 25;
            // 
            // invaliddata
            // 
            this.invaliddata.Location = new System.Drawing.Point(82, 191);
            this.invaliddata.Name = "invaliddata";
            this.invaliddata.Size = new System.Drawing.Size(57, 21);
            this.invaliddata.TabIndex = 24;
            this.invaliddata.Text = "-3000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "无效值设定";
            // 
            // okbt
            // 
            this.okbt.Location = new System.Drawing.Point(148, 226);
            this.okbt.Name = "okbt";
            this.okbt.Size = new System.Drawing.Size(60, 23);
            this.okbt.TabIndex = 22;
            this.okbt.Text = "确定";
            this.okbt.UseVisualStyleBackColor = true;
            this.okbt.Click += new System.EventHandler(this.okbt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "结果文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "筛选文件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "数据文件";
            // 
            // datacomboBox
            // 
            this.datacomboBox.FormattingEnabled = true;
            this.datacomboBox.Location = new System.Drawing.Point(16, 37);
            this.datacomboBox.Name = "datacomboBox";
            this.datacomboBox.Size = new System.Drawing.Size(299, 20);
            this.datacomboBox.TabIndex = 18;
            // 
            // ignoredata
            // 
            this.ignoredata.Location = new System.Drawing.Point(292, 191);
            this.ignoredata.Name = "ignoredata";
            this.ignoredata.Size = new System.Drawing.Size(63, 21);
            this.ignoredata.TabIndex = 34;
            this.ignoredata.Text = "-3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(210, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "忽略值设定";
            // 
            // helptext
            // 
            this.helptext.Location = new System.Drawing.Point(376, 13);
            this.helptext.Name = "helptext";
            this.helptext.Size = new System.Drawing.Size(148, 236);
            this.helptext.TabIndex = 35;
            this.helptext.Text = "";
            // 
            // TCYCZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.helptext);
            this.Controls.Add(this.ignoredata);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resulttext);
            this.Controls.Add(this.hidehelpbt);
            this.Controls.Add(this.showhelpbt);
            this.Controls.Add(this.concelbt);
            this.Controls.Add(this.resfilebt);
            this.Controls.Add(this.selfilebt);
            this.Controls.Add(this.datafilebt);
            this.Controls.Add(this.selectcomboBox);
            this.Controls.Add(this.invaliddata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.okbt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datacomboBox);
            this.Name = "TCYCZ";
            this.Text = "剔除NDVI异常值";
            this.Load += new System.EventHandler(this.TCYCZ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resulttext;
        private System.Windows.Forms.Button hidehelpbt;
        private System.Windows.Forms.Button showhelpbt;
        private System.Windows.Forms.Button concelbt;
        private System.Windows.Forms.Button resfilebt;
        private System.Windows.Forms.Button selfilebt;
        private System.Windows.Forms.Button datafilebt;
        private System.Windows.Forms.ComboBox selectcomboBox;
        private System.Windows.Forms.TextBox invaliddata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okbt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox datacomboBox;
        private System.Windows.Forms.TextBox ignoredata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox helptext;
    }
}