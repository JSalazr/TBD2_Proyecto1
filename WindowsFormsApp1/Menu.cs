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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablas tablas = new Tablas();
            tablas.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Views views = new Views();
            views.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Triggers triggers = new Triggers();
            triggers.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Procedures procedures = new Procedures();
            procedures.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Indexes indexes = new Indexes();
            indexes.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Checks checks = new Checks();
            checks.Show();
        }
    }
}
