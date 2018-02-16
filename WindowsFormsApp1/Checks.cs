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
    public partial class Checks : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        public Checks(string database)
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + database + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select a.name Check_Name, c.name Table_with_check  from sysobjects a inner join sysconstraints b on a.id = b.constrid inner join sysobjects c on b.tableid = c.id";
            reader = command.ExecuteReader();
            table = new DataTable();
            adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("select a.name Check_Name, c.name Table_with_check  from sysobjects a inner join sysconstraints b on a.id = b.constrid inner join sysobjects c on b.tableid = c.id", conn);
            adapter.SelectCommand = selectCMD;
            OdbcCommand UpdateCMD = new OdbcCommand("", conn);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            conn.Close();
        }

        private void Tablas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.spt_jdbc_table_types' table. You can move, or remove it, as needed.
            this.spt_jdbc_table_typesTableAdapter.Fill(this.dataSet1.spt_jdbc_table_types);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView1.CurrentRow.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Update(table);
        }
    }
}
