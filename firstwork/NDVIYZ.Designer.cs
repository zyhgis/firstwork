﻿namespace firstwork
{
    partial class NDVIYZ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NDVIYZ));
            this.nodiseasterdata = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.diseasterdata = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ignoredata = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.resulttext = new System.Windows.Forms.TextBox();
            this.hidehelpbt = new System.Windows.Forms.Button();
            this.showhelpbt = new System.Windows.Forms.Button();
            this.concelbt = new System.Windows.Forms.Button();
            this.resfilebt = new System.Windows.Forms.Button();
            this.selfilebt = new System.Windows.Forms.Button();
            this.datafilebt = new System.Windows.Forms.Button();
            this.selectcomboBox = new System.Windows.Forms.ComboBox();
            this.invalidata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.okbt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datacomboBox = new System.Windows.Forms.ComboBox();
            this.helptext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nodiseasterdata
            // 
            this.nodiseasterdata.Location = new System.Drawing.Point(288, 213);
            this.nodiseasterdata.Name = "nodiseasterdata";
            this.nodiseasterdata.Size = new System.Drawing.Size(63, 21);
            this.nodiseasterdata.TabIndex = 99;
            this.nodiseasterdata.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 98;
            this.label8.Text = "未受灾值设定";
            // 
            // diseasterdata
            // 
            this.diseasterdata.Location = new System.Drawing.Point(90, 213);
            this.diseasterdata.Name = "diseasterdata";
            this.diseasterdata.Size = new System.Drawing.Size(57, 21);
            this.diseasterdata.TabIndex = 97;
            this.diseasterdata.Text = "-1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 96;
            this.label9.Text = "受灾值设定";
            // 
            // ignoredata
            // 
            this.ignoredata.Location = new System.Drawing.Point(288, 186);
            this.ignoredata.Name = "ignoredata";
            this.ignoredata.Size = new System.Drawing.Size(63, 21);
            this.ignoredata.TabIndex = 93;
            this.ignoredata.Text = "-3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 92;
            this.label5.Text = "忽略值设定";
            // 
            // resulttext
            // 
            this.resulttext.Location = new System.Drawing.Point(12, 143);
            this.resulttext.Name = "resulttext";
            this.resulttext.Size = new System.Drawing.Size(298, 21);
            this.resulttext.TabIndex = 91;
            // 
            // hidehelpbt
            // 
            this.hidehelpbt.Location = new System.Drawing.Point(277, 250);
            this.hidehelpbt.Name = "hidehelpbt";
            this.hidehelpbt.Size = new System.Drawing.Size(74, 23);
            this.hidehelpbt.TabIndex = 90;
            this.hidehelpbt.Text = "<<隐藏帮助";
            this.hidehelpbt.UseVisualStyleBackColor = true;
            this.hidehelpbt.Visible = false;
            this.hidehelpbt.Click += new System.EventHandler(this.hidehelpbt_Click);
            // 
            // showhelpbt
            // 
            this.showhelpbt.Location = new System.Drawing.Point(277, 251);
            this.showhelpbt.Name = "showhelpbt";
            this.showhelpbt.Size = new System.Drawing.Size(74, 23);
            this.showhelpbt.TabIndex = 89;
            this.showhelpbt.Text = "显示帮助>>";
            this.showhelpbt.UseVisualStyleBackColor = true;
            this.showhelpbt.Click += new System.EventHandler(this.showhelpbt_Click);
            // 
            // concelbt
            // 
            this.concelbt.Location = new System.Drawing.Point(210, 251);
            this.concelbt.Name = "concelbt";
            this.concelbt.Size = new System.Drawing.Size(61, 23);
            this.concelbt.TabIndex = 88;
            this.concelbt.Text = "取消";
            this.concelbt.UseVisualStyleBackColor = true;
            this.concelbt.Click += new System.EventHandler(this.concelbt_Click);
            // 
            // resfilebt
            // 
            this.resfilebt.Image = ((System.Drawing.Image)(resources.GetObject("resfilebt.Image")));
            this.resfilebt.Location = new System.Drawing.Point(325, 142);
            this.resfilebt.Name = "resfilebt";
            this.resfilebt.Size = new System.Drawing.Size(26, 21);
            this.resfilebt.TabIndex = 87;
            this.resfilebt.UseVisualStyleBackColor = true;
            this.resfilebt.Click += new System.EventHandler(this.resfilebt_Click);
            // 
            // selfilebt
            // 
            this.selfilebt.Image = ((System.Drawing.Image)(resources.GetObject("selfilebt.Image")));
            this.selfilebt.Location = new System.Drawing.Point(325, 90);
            this.selfilebt.Name = "selfilebt";
            this.selfilebt.Size = new System.Drawing.Size(26, 21);
            this.selfilebt.TabIndex = 86;
            this.selfilebt.UseVisualStyleBackColor = true;
            this.selfilebt.Click += new System.EventHandler(this.selfilebt_Click);
            // 
            // datafilebt
            // 
            this.datafilebt.Image = ((System.Drawing.Image)(resources.GetObject("datafilebt.Image")));
            this.datafilebt.Location = new System.Drawing.Point(325, 31);
            this.datafilebt.Name = "datafilebt";
            this.datafilebt.Size = new System.Drawing.Size(26, 21);
            this.datafilebt.TabIndex = 85;
            this.datafilebt.UseVisualStyleBackColor = true;
            this.datafilebt.Click += new System.EventHandler(this.datafilebt_Click);
            // 
            // selectcomboBox
            // 
            this.selectcomboBox.FormattingEnabled = true;
            this.selectcomboBox.Location = new System.Drawing.Point(11, 84);
            this.selectcomboBox.Name = "selectcomboBox";
            this.selectcomboBox.Size = new System.Drawing.Size(300, 20);
            this.selectcomboBox.TabIndex = 84;
            // 
            // invalidata
            // 
            this.invalidata.Location = new System.Drawing.Point(90, 187);
            this.invalidata.Name = "invalidata";
            this.invalidata.Size = new System.Drawing.Size(57, 21);
            this.invalidata.TabIndex = 83;
            this.invalidata.Text = "-3000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 82;
            this.label4.Text = "无效值设定";
            // 
            // okbt
            // 
            this.okbt.Location = new System.Drawing.Point(144, 251);
            this.okbt.Name = "okbt";
            this.okbt.Size = new System.Drawing.Size(60, 23);
            this.okbt.TabIndex = 81;
            this.okbt.Text = "确定";
            this.okbt.UseVisualStyleBackColor = true;
            this.okbt.Click += new System.EventHandler(this.okbt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 80;
            this.label3.Text = "提取结果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "正常波动范围";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "灾后波动值";
            // 
            // datacomboBox
            // 
            this.datacomboBox.FormattingEnabled = true;
            this.datacomboBox.Location = new System.Drawing.Point(12, 32);
            this.datacomboBox.Name = "datacomboBox";
            this.datacomboBox.Size = new System.Drawing.Size(299, 20);
            this.datacomboBox.TabIndex = 77;
            // 
            // helptext
            // 
            this.helptext.Location = new System.Drawing.Point(366, 10);
            this.helptext.Multiline = true;
            this.helptext.Name = "helptext";
            this.helptext.Size = new System.Drawing.Size(115, 263);
            this.helptext.TabIndex = 100;
            // 
            // NDVIYZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 282);
            this.Controls.Add(this.helptext);
            this.Controls.Add(this.nodiseasterdata);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.diseasterdata);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.invalidata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.okbt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datacomboBox);
            this.Name = "NDVIYZ";
            this.Text = "森林冰雪冻灾受灾范围提取—NDVI 阈值法";
            this.Load += new System.EventHandler(this.NDVIYZ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nodiseasterdata;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox diseasterdata;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ignoredata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox resulttext;
        private System.Windows.Forms.Button hidehelpbt;
        private System.Windows.Forms.Button showhelpbt;
        private System.Windows.Forms.Button concelbt;
        private System.Windows.Forms.Button resfilebt;
        private System.Windows.Forms.Button selfilebt;
        private System.Windows.Forms.Button datafilebt;
        private System.Windows.Forms.ComboBox selectcomboBox;
        private System.Windows.Forms.TextBox invalidata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okbt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox datacomboBox;
        private System.Windows.Forms.TextBox helptext;
    }
}