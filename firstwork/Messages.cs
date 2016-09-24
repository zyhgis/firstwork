using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstwork
{
    public partial class Messages : Form
    {
        public Messages()
        {
            
            InitializeComponent();
            
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    {
        //        timer1.Enabled = false;

        //        for (int i = 0; i <= this.Height - 14; i++)
        //        {
        //            Point p = new Point(this.Location.X, this.Location.Y + i);//弹出框向下移动消失 
        //            this.PointToScreen(p);//即时转换成屏幕坐标 
        //            this.Location = p;// new Point(this.Location.X, this.Location.Y + 1);
        //            System.Threading.Thread.Sleep(50);//线程睡眠时间调的越小向下消失的速度越快。 
        //        }
        //        this.Close();
        //        this.Dispose();
        //    }
        //}
    }
}
