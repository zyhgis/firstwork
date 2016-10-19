namespace firstwork
{
    partial class RasterRender
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.imgCmbStrech = new System.Windows.Forms.ImageCombo();
            this.layerpath = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(286, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // imgCmbStrech
            // 
            this.imgCmbStrech.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imgCmbStrech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imgCmbStrech.FormattingEnabled = true;
            this.imgCmbStrech.Location = new System.Drawing.Point(82, 68);
            this.imgCmbStrech.Name = "imgCmbStrech";
            this.imgCmbStrech.Size = new System.Drawing.Size(167, 22);
            this.imgCmbStrech.TabIndex = 4;
            // 
            // layerpath
            // 
            this.layerpath.FormattingEnabled = true;
            this.layerpath.Location = new System.Drawing.Point(12, 8);
            this.layerpath.Name = "layerpath";
            this.layerpath.Size = new System.Drawing.Size(237, 20);
            this.layerpath.TabIndex = 7;
            // 
            // RasterRender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 238);
            this.Controls.Add(this.layerpath);
            this.Controls.Add(this.imgCmbStrech);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "RasterRender";
            this.Text = "RasterRender";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageCombo imgCmbStrech;
        private System.Windows.Forms.ComboBox layerpath;
    }
}