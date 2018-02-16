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
    public partial class Triggers : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string database;
        string trigger_name;
        public Triggers(string database)
        {
            InitializeComponent();
            this.database = database;
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + database + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select a.name Trigger_Name, c.name Dependant_Name, d.text DDL from sysobjects a inner join sysdepends b on a.id = b.id inner join sysobjects c on b.depid = c.id inner join syscomments d on a.id = d.id where a.type = 'TR' and a.uid = user_id()";
            reader = command.ExecuteReader();
            table = new DataTable();
            adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("select a.name Trigger_Name, c.name Dependant_Name, d.text DDL from sysobjects a inner join sysdepends b on a.id = b.id inner join sysobjects c on b.depid = c.id inner join syscomments d on a.id = d.id where a.type = 'TR' and a.uid = user_id()", conn);
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
            trigger_name = e.Row.Cells["Trigger_Name"].Value.ToString();
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

            adapter.DeleteCommand = new OdbcCommand("drop trigger " + trigger_name, conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }
    }
}
