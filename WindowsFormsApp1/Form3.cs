using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.connection_string += ";uid=" + textBox1.Text + ";pwd=" + textBox2.Text + ";";
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            try
            {
                conn.Open();
                conn.Close();
                Menu menu = new WindowsFormsApp1.Menu();
                menu.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
