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
    public partial class Procedures : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string procedure_name;
        string database;
        public Procedures(string database)
        {
            InitializeComponent();
            this.database = database;
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + database + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select a.name Name, b.text DDL from sysobjects a inner join syscomments b on a.id = b.id where a.type = 'P' or a.type = 'SF' or a.type = 'XP' and a.uid = user_id()";
            reader = command.ExecuteReader();
            table = new DataTable();
            adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("select a.name Name, b.text DDL from sysobjects a inner join syscomments b on a.id = b.id where a.type = 'P' or a.type = 'SF' or a.type = 'XP' and a.uid = user_id()", conn);
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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            procedure_name = e.Row.Cells["Name"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView1.CurrentRow.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Update(table);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + database + ";");
            conn.Open();

            adapter.DeleteCommand = new OdbcCommand("drop procedure " + procedure_name, conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }
    }
}
