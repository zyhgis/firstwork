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
    public partial class MessageForm : Form
    {
        string result;
        public MessageForm(string result)
        {
            this.result = result;
            InitializeComponent();
            if (result.Substring(0, 2) == "ok")
                label1.Text = result;
            else
                label1.Text = result.Substring(2) + "执行失败";
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            //if (result.Substring(0, 2) == "ok")
            //    label1.Text = result;
            //else
            //    label1.Text = result.Substring(2)+"执行失败";
        }
    }
}
