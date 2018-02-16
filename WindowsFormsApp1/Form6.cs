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
        string table_name;
        string db;
        string column_val;
        public Form6(string table_name, string db)
        {
            InitializeComponent();
            this.table_name = table_name;
            this.db = db;
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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            column_val = e.Row.Cells[0].Value.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + db + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            string insert = "insert into " + table_name + "(";
            for (var i = 0; i < dataGridView1.ColumnCount; i++)
            {   if(i == 0)
                    insert += dataGridView1.Columns[i].HeaderText;
                else
                    insert += ", " + dataGridView1.Columns[i].HeaderText;
            }
            insert += ") VALUES (";
            for (var i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (i == 0)
                    insert += dataGridView1.CurrentRow.Cells[i].Value.ToString();
                else
                    insert += ", " + dataGridView1.CurrentRow.Cells[i].Value.ToString();
            }
            insert += ")";
            Console.WriteLine(insert);
            adapter.InsertCommand = new OdbcCommand(insert, conn);
            adapter.Update(table);
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + db + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            string update = "update " + table_name + " set ";
            for (var i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (i == 0)
                    update += dataGridView1.Columns[i].HeaderText + " = " + dataGridView1.CurrentRow.Cells[i].Value.ToString();
                else
                    update += ", " + dataGridView1.Columns[i].HeaderText + " = " + dataGridView1.CurrentRow.Cells[i].Value.ToString();
            }
            update += " where " + dataGridView1.Columns[0].HeaderText + " = " + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Console.WriteLine(update);
            adapter.UpdateCommand = new OdbcCommand(update, conn);
            adapter.Update(table);
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + db + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            string delete = "delete from " + table_name + " where " + dataGridView1.Columns[0].HeaderText + " = " + column_val;
            Console.WriteLine(delete);
            adapter.DeleteCommand = new OdbcCommand(delete, conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }
    }
}
