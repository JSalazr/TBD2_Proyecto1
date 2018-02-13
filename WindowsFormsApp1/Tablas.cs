﻿using System;
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
    public partial class Tablas : Form
    {
        public Tablas()
        {
            InitializeComponent();
            OdbcConnection conn = new OdbcConnection(Globals.connection_string);
            conn.Open();
            OdbcCommand command = conn.CreateCommand();
            command.CommandText = "select a.name Table_Name, b.name Column_Name, c.name Type, b.length Length from sysobjects a inner join syscolumns b on a.id = b.id inner join systypes c on b.type = c.type where a.type = 'U'";
            OdbcDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
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
            Console.WriteLine(dataGridView1.CurrentCell.Value.ToString());
        }
    }
}