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
    public partial class Form1 : Form
    {
        public Form1()
        {   
            InitializeComponent();
            load_treeView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void load_treeView()
        {
            Globals.connections = new List<ConnectionData>();
            using (BinaryReader br = new BinaryReader(File.Open("connections.cn", FileMode.OpenOrCreate)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    ConnectionData temp = new ConnectionData();
                    temp.conn_name = br.ReadString();
                    temp.server = br.ReadString();
                    temp.database = br.ReadString();
                    temp.port = br.ReadString();
                    Globals.connections.Add(temp);
                    treeView1.Nodes.Add(new TreeNode(temp.Tostring()));
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newConn = new Form2("null");
            newConn.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Tables")
            {
                panel1.Controls.Clear();
                Form6 tdata = new Form6(treeView1.SelectedNode.Text, treeView1.SelectedNode.Parent.Parent.Text);
                tdata.TopLevel = false;
                tdata.AutoScroll = true;
                tdata.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(tdata);
                tdata.Show();
            }
            else if (treeView1.SelectedNode.Text == "Tables")
            {
                panel1.Controls.Clear();
                Tablas tablas = new Tablas(treeView1.SelectedNode.Parent.Text);
                tablas.TopLevel = false;
                tablas.AutoScroll = true;
                tablas.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(tablas);
                tablas.Show();
            }
            else if (treeView1.SelectedNode.Text == "Views")
            {
                panel1.Controls.Clear();
                Views views = new Views(treeView1.SelectedNode.Parent.Text);
                views.TopLevel = false;
                views.AutoScroll = true;
                views.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(views);
                views.Show();
            }
            else if (treeView1.SelectedNode.Text == "Procedures")
            {
                panel1.Controls.Clear();
                Procedures procedures = new Procedures(treeView1.SelectedNode.Parent.Text);
                procedures.TopLevel = false;
                procedures.AutoScroll = true;
                procedures.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(procedures);
                procedures.Show();
            }
            else if (treeView1.SelectedNode.Text == "Checks")
            {
                panel1.Controls.Clear();
                Checks checks = new Checks(treeView1.SelectedNode.Parent.Text);
                checks.TopLevel = false;
                checks.AutoScroll = true;
                checks.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(checks);
                checks.Show();
            }
            else if (treeView1.SelectedNode.Text == "Indexes")
            {
                panel1.Controls.Clear();
                Indexes indexes = new Indexes(treeView1.SelectedNode.Parent.Text);
                indexes.TopLevel = false;
                indexes.AutoScroll = true;
                indexes.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(indexes);
                indexes.Show();
            }
            else if (treeView1.SelectedNode.Text == "Triggers")
            {
                panel1.Controls.Clear();
                Triggers triggers = new Triggers(treeView1.SelectedNode.Parent.Text);
                triggers.TopLevel = false;
                triggers.AutoScroll = true;
                triggers.FormBorderStyle = FormBorderStyle.None;
                panel1.Controls.Add(triggers);
                triggers.Show();
            }
            else
            {
                string text = treeView1.SelectedNode.Text;
                foreach (var con in Globals.connections)
                {
                    if (con.conn_name == text)
                    {
                        Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + con.server + ";Port=" + con.port + ";";
                        Form3 login = new Form3();
                        login.ShowDialog();
                        OdbcConnection conn = new OdbcConnection(Globals.connection_string);
                        conn.Open();
                        OdbcCommand command = conn.CreateCommand();
                        OdbcDataReader reader;
                        command.CommandText = "select name from sysdatabases";
                        reader = command.ExecuteReader();
                        List<string> list = new List<string>();
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                        conn.Close();
                        List<TreeNode> dbs = new List<TreeNode>();

                        foreach (var db in list)
                        {
                            List<TreeNode> objects = new List<TreeNode>();
                            List<TreeNode> tabs = new List<TreeNode>();
                            string idk = Globals.connection_string + "database=" + db + ";";
                            conn = new OdbcConnection(idk);
                            try
                            {
                                conn.Open();
                                command = conn.CreateCommand();
                                command.CommandText = "select name from sysobjects where type = 'U' and uid = user_id()";
                                reader = command.ExecuteReader();
                                List<string> list1 = new List<string>();
                                while (reader.Read())
                                {
                                    list1.Add(reader.GetString(0));
                                }
                                conn.Close();
                                foreach (var tab in list1)
                                {
                                    tabs.Add(new TreeNode(tab));
                                }
                                objects.Add(new TreeNode("Tables", tabs.ToArray()));
                                objects.Add(new TreeNode("Views"));
                                objects.Add(new TreeNode("Indexes"));
                                objects.Add(new TreeNode("Procedures"));
                                objects.Add(new TreeNode("Triggers"));
                                objects.Add(new TreeNode("Checks"));
                                dbs.Add(new TreeNode(db, objects.ToArray()));
                            }
                            catch (Exception)
                            {

                            }

                        }
                        treeView1.BeginUpdate();
                        treeView1.SelectedNode.Remove();
                        treeView1.Nodes.Add(new TreeNode(text, dbs.ToArray()));
                        treeView1.EndUpdate();
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Form5 sql = new Form5();
            sql.TopLevel = false;
            sql.AutoScroll = true;
            sql.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(sql);
            sql.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 edit = new Form2(treeView1.SelectedNode.Text);
            edit.ShowDialog();
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            load_treeView();
            treeView1.EndUpdate();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            foreach (var con in Globals.connections)
            {
                if(con.conn_name == treeView1.SelectedNode.Text)
                {
                    Globals.connections.Remove(con);
                    break;
                }
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open("connections.cn", FileMode.Create)))
            {
                foreach (var con in Globals.connections)
                {
                    bw.Write(con.conn_name);
                    bw.Write(con.server);
                    bw.Write(con.database);
                    bw.Write(con.port);
                }
            }
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            load_treeView();
            treeView1.EndUpdate();
        }
    }

    public static class Globals
    {
        public static List<ConnectionData> connections = new List<ConnectionData>();
        public static string connection_string;
        public static string conn_name;

        public static string username;
    }
}
