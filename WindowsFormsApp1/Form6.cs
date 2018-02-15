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
    public partial class Form6 : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string view_name;
        public Form6(string table_name, string db)
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + db + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select * from " + table_name;
            reader = command.ExecuteReader();
            table = new DataTable();
            adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("select * from " + table_name, conn);
            adapter.SelectCommand = selectCMD;
            OdbcCommand UpdateCMD = new OdbcCommand("", conn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
