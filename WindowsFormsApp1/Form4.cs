using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Form1 form1 = new Form1();
            form1.TopLevel = false;
            form1.AutoScroll = true;
            form1.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(form1);
            form1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
