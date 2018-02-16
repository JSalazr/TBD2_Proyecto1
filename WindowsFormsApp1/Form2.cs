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
        string curr_con;
        public Form2(string con_to_edit)
        {
            InitializeComponent();
            curr_con = con_to_edit;
            if (curr_con != "null")
            {
                foreach (var con in Globals.connections)
                {
                    if (con.conn_name == curr_con)
                    {
                        textconn.Text = con.conn_name;
                        textserver.Text = con.server;
                        textdb.Text = con.database;
                        textport.Text = con.port;
                        break;
                    }
                }
            }
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
            if(curr_con != "null")
            {
                foreach (var con in Globals.connections)
                {
                    if (con.conn_name == curr_con)
                    {
                        con.conn_name = textconn.Text;
                        con.server = textserver.Text;
                        con.database = textdb.Text;
                        con.port = textport.Text;
                        break;
                    }
                }
                using (BinaryWriter bw = new BinaryWriter(File.Open("connections.cn", FileMode.OpenOrCreate)))
                {
                    foreach (var con in Globals.connections)
                    {
                        bw.Write(con.conn_name);
                        bw.Write(con.server);
                        bw.Write(con.database);
                        bw.Write(con.port);
                    }
                }
                this.Close();
            }
            else
            {
                ConnectionData temp = new ConnectionData();
                temp.conn_name = textconn.Text;
                temp.server = textserver.Text;
                temp.database = textdb.Text;
                temp.port = textport.Text;
                Globals.connections.Add(temp);
                using (BinaryWriter bw = new BinaryWriter(File.Open("connections.cn", FileMode.OpenOrCreate)))
                {
                    foreach (var con in Globals.connections)
                    {
                        bw.Write(con.conn_name);
                        bw.Write(con.server);
                        bw.Write(con.database);
                        bw.Write(con.port);
                    }
                }
                Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + textserver.Text + ";uid=" + textuser.Text + ";pwd=" + textpass.Text + ";Port=" + textport.Text + ";";
                OdbcConnection conn = new OdbcConnection(Globals.connection_string);
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
