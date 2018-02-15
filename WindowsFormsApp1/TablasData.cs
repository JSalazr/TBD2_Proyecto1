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
    public partial class TablasData : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string column_name;
        string table_name;
        public TablasData()
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            try
            {
                conn.Open();
                OdbcCommand command = conn.CreateCommand();
                command.CommandText = "select a.name Table_Name, b.name Column_Name, c.name Type, b.length Length from sysobjects a inner join syscolumns b on a.id = b.id inner join systypes c on b.type = c.type where a.type = 'U' and a.uid = user_id()";
                reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                adapter = new OdbcDataAdapter();
                OdbcCommand selectCMD = new OdbcCommand("select a.name Table_Name, b.name Column_Name, c.name Type, b.length Length from sysobjects a inner join syscolumns b on a.id = b.id inner join systypes c on b.type = c.type where a.type = 'U' and a.uid = user_id()", conn);
                adapter.SelectCommand = selectCMD;
                OdbcCommand UpdateCMD = new OdbcCommand("", conn);
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }

        private void TablasData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.spt_jdbc_table_types' table. You can move, or remove it, as needed.
            this.spt_jdbc_table_typesTableAdapter.Fill(this.dataSet1.spt_jdbc_table_types);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView1.CurrentRow.Cells["Type"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Update(table);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            table_name = e.Row.Cells["Table_Name"].Value.ToString();
            column_name = e.Row.Cells["Column_Name"].Value.ToString();
            Console.WriteLine(column_name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();
           
            adapter.DeleteCommand = new OdbcCommand("drop table " + table_name, conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();

            adapter.DeleteCommand = new OdbcCommand("alter table " + table_name + " drop " + column_name + " with no datacopy", conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();

            adapter.UpdateCommand = new OdbcCommand("alter table " + dataGridView1.CurrentRow.Cells["Table_Name"].Value.ToString() + " modify " + dataGridView1.CurrentRow.Cells["Column_Name"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["Type"].Value.ToString(), conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();

            adapter.UpdateCommand = new OdbcCommand("alter table " + dataGridView1.CurrentRow.Cells["Table_Name"].Value.ToString() + " modify " + dataGridView1.CurrentRow.Cells["Column_Name"].Value.ToString() + " " + dataGridView1.CurrentRow.Cells["Type"].Value.ToString(), conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }
    }
}
