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
    public partial class temp : Form
    {
        public temp()
        {
            InitializeComponent();
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {
            //axAcroPDF1.LoadFile(@"E:\学生会\8283.pdf");
        }

        private void temp_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(@"E:\学生会\8283.pdf");
        }
    }
}
