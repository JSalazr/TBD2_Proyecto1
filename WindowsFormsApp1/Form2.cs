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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + textserver.Text + ";uid=" + textuser.Text + ";pwd=" + textpass.Text + ";Port=" + textport.Text + ";database=" + textdb.Text + ";";
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            try
            {
                conn.Open();
                MessageBox.Show("Conexion exitosa!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int curr_pos = Globals.get_pos();
            Globals.connections[curr_pos] = new ConnectionData();
            Globals.connections[curr_pos].conn_name = textconn.Text;
            Globals.connections[curr_pos].server = textserver.Text;
            Globals.connections[curr_pos].database = textdb.Text;
            Globals.connections[curr_pos].port = textport.Text;
            using (BinaryWriter bw = new BinaryWriter(File.Open("connections.cn", FileMode.Append)))
            {
                bw.Write(Globals.connections[curr_pos].conn_name);
                bw.Write(Globals.connections[curr_pos].server);
                bw.Write(Globals.connections[curr_pos].database);
                bw.Write(Globals.connections[curr_pos].port);
            }
            Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + textserver.Text + ";uid=" + textuser.Text + ";pwd=" + textpass.Text + ";Port=" + textport.Text + ";database=" + textdb.Text + ";";
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
