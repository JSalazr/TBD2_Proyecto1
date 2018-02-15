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
    public partial class Form5 : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string sql_command;
        public Form5()
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            try
            {
                conn.Open();
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            sql_command = textBox1.Text;
            conn.Open();
            if (sql_command.StartsWith("select"))
            {
                table = new DataTable();
                adapter = new OdbcDataAdapter();
                OdbcCommand selectCMD = new OdbcCommand(sql_command, conn);
                adapter.SelectCommand = selectCMD;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                OdbcCommand command = conn.CreateCommand();
                command.CommandText = sql_command;
                reader = command.ExecuteReader();
            }
            conn.Close();
        }
    }
}
