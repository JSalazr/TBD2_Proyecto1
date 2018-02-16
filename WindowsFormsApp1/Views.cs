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
    public partial class Views : Form
    {
        OdbcDataReader reader;
        OdbcDataAdapter adapter;
        DataTable table;
        string view_name;
        public Views(string database)
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string + "database=" + database + ";");
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select a.name Table_Name, b.name Column_Name, c.name Type, b.length Length, d.text DDL from sysobjects a inner join syscolumns b on a.id = b.id inner join systypes c on b.type = c.type inner join syscomments d on a.id = d.id where a.type = 'V' and a.uid = user_id()";
            reader = command.ExecuteReader();
            table = new DataTable();
            adapter = new OdbcDataAdapter();
            OdbcCommand selectCMD = new OdbcCommand("select a.name Table_Name, b.name Column_Name, c.name Type, b.length Length, d.text DDL from sysobjects a inner join syscolumns b on a.id = b.id inner join systypes c on b.type = c.type inner join syscomments d on a.id = d.id where a.type = 'V' and a.uid = user_id()", conn);
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
            
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            view_name = e.Row.Cells["Table_Name"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Update(table);
        }

        private void Views_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();

            adapter.DeleteCommand = new OdbcCommand("drop view " + view_name, conn);
            adapter.Update(table);
            table.AcceptChanges();
            conn.Close();
        }
    }
}
