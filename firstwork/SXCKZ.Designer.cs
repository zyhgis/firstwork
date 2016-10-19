namespace firstwork
{
    partial class SXCKZ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SXCKZ));
            this.delectbt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.datafilebt = new System.Windows.Forms.Button();
            this.filepathtextBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.invaildtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ignoretextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hidehelpbt = new System.Windows.Forms.Button();
            this.showhelpbt = new System.Windows.Forms.Button();
            this.concelbt = new System.Windows.Forms.Button();
            this.okbt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.resulttext = new System.Windows.Forms.TextBox();
            this.helptext = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // delectbt
            // 
            this.delectbt.Image = ((System.Drawing.Image)(resources.GetObject("delectbt.Image")));
            this.delectbt.Location = new System.Drawing.Point(343, 89);
            this.delectbt.Name = "delectbt";
            this.delectbt.Size = new System.Drawing.Size(26, 21);
            this.delectbt.TabIndex = 38;
            this.delectbt.UseVisualStyleBackColor = true;
            this.delectbt.Click += new System.EventHandler(this.delectbt_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(343, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 21);
            this.button2.TabIndex = 37;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "输入第一次筛选后的NDVI数据";
            // 
            // datafilebt
            // 
            this.datafilebt.Image = ((System.Drawing.Image)(resources.GetObject("datafilebt.Image")));
            this.datafilebt.Location = new System.Drawing.Point(343, 31);
            this.datafilebt.Name = "datafilebt";
            this.datafilebt.Size = new System.Drawing.Size(26, 21);
            this.datafilebt.TabIndex = 35;
            this.datafilebt.UseVisualStyleBackColor = true;
            this.datafilebt.Click += new System.EventHandler(this.datafilebt_Click);
            // 
            // filepathtextBox
            // 
            this.filepathtextBox.Location = new System.Drawing.Point(12, 32);
            this.filepathtextBox.Name = "filepathtextBox";
            this.filepathtextBox.Size = new System.Drawing.Size(325, 21);
            this.filepathtextBox.TabIndex = 34;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(325, 160);
            this.listBox1.TabIndex = 33;
            // 
            // invaildtextBox
            // 
            this.invaildtextBox.Location = new System.Drawing.Point(269, 283);
            this.invaildtextBox.Name = "invaildtextBox";
            this.invaildtextBox.Size = new System.Drawing.Size(100, 21);
            this.invaildtextBox.TabIndex = 46;
            this.invaildtextBox.Text = "-3000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "无效值设定";
            // 
            // ignoretextBox
            // 
            this.ignoretextBox.Location = new System.Drawing.Point(82, 283);
            this.ignoretextBox.Name = "ignoretextBox";
            this.ignoretextBox.Size = new System.Drawing.Size(99, 21);
            this.ignoretextBox.TabIndex = 44;
            this.ignoretextBox.Text = "-3000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "忽略值设定";
            // 
            // hidehelpbt
            // 
            this.hidehelpbt.Location = new System.Drawing.Point(295, 318);
            this.hidehelpbt.Name = "hidehelpbt";
            this.hidehelpbt.Size = new System.Drawing.Size(74, 23);
            this.hidehelpbt.TabIndex = 42;
            this.hidehelpbt.Text = "<<隐藏帮助";
            this.hidehelpbt.UseVisualStyleBackColor = true;
            this.hidehelpbt.Visible = false;
            this.hidehelpbt.Click += new System.EventHandler(this.hidehelpbt_Click);
            // 
            // showhelpbt
            // 
            this.showhelpbt.Location = new System.Drawing.Point(295, 318);
            this.showhelpbt.Name = "showhelpbt";
            this.showhelpbt.Size = new System.Drawing.Size(74, 23);
            this.showhelpbt.TabIndex = 41;
            this.showhelpbt.Text = "显示帮助>>";
            this.showhelpbt.UseVisualStyleBackColor = true;
            this.showhelpbt.Click += new System.EventHandler(this.showhelpbt_Click);
            // 
            // concelbt
            // 
            this.concelbt.Location = new System.Drawing.Point(228, 318);
            this.concelbt.Name = "concelbt";
            this.concelbt.Size = new System.Drawing.Size(61, 23);
            this.concelbt.TabIndex = 40;
            this.concelbt.Text = "取消";
            this.concelbt.UseVisualStyleBackColor = true;
            this.concelbt.Click += new System.EventHandler(this.concelbt_Click);
            // 
            // okbt
            // 
            this.okbt.Location = new System.Drawing.Point(162, 318);
            this.okbt.Name = "okbt";
            this.okbt.Size = new System.Drawing.Size(60, 23);
            this.okbt.TabIndex = 39;
            this.okbt.Text = "确定";
            this.okbt.UseVisualStyleBackColor = true;
            this.okbt.Click += new System.EventHandler(this.okbt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "结果文件";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(343, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 21);
            this.button1.TabIndex = 49;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // resulttext
            // 
            this.resulttext.Location = new System.Drawing.Point(12, 251);
            this.resulttext.Name = "resulttext";
            this.resulttext.Size = new System.Drawing.Size(325, 21);
            this.resulttext.TabIndex = 48;
            // 
            // helptext
            // 
            this.helptext.Location = new System.Drawing.Point(381, 2);
            this.helptext.Multiline = true;
            this.helptext.Name = "helptext";
            this.helptext.Size = new System.Drawing.Size(148, 352);
            this.helptext.TabIndex = 50;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(343, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 25);
            this.button3.TabIndex = 51;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SXCKZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 350);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.helptext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resulttext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.invaildtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ignoretextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hidehelpbt);
            this.Controls.Add(this.showhelpbt);
            this.Controls.Add(this.concelbt);
            this.Controls.Add(this.okbt);
            this.Controls.Add(this.delectbt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datafilebt);
            this.Controls.Add(this.filepathtextBox);
            this.Controls.Add(this.listBox1);
            this.Name = "SXCKZ";
            this.Text = "第二次筛选NDVI 数据的参考数据";
            this.Load += new System.EventHandler(this.SXCKZ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delectbt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button datafilebt;
        private System.Windows.Forms.TextBox filepathtextBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox invaildtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ignoretextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button hidehelpbt;
        private System.Windows.Forms.Button showhelpbt;
        private System.Windows.Forms.Button concelbt;
        private System.Windows.Forms.Button okbt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox resulttext;
        private System.Windows.Forms.TextBox helptext;
        private System.Windows.Forms.Button button3;
    }
}