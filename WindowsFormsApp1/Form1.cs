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
            for(int a = 0; a < 5; a++)
            {
                Globals.connections[a] = new ConnectionData();
                Globals.connections[a].conn_name = " ";
            }
            int c = 0;
            using (BinaryReader br = new BinaryReader(File.Open("connections.cn", FileMode.OpenOrCreate)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    Globals.connections[c].conn_name = br.ReadString();
                    Globals.connections[c].server = br.ReadString();
                    Globals.connections[c].database = br.ReadString();
                    Globals.connections[c].port = br.ReadString();
                    treeView1.Nodes.Add(new TreeNode(Globals.connections[c].Tostring()));
                    c++;
                }
            }
            Globals.pos = c;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newConn = new Form2();
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
            else
            {
                string text = treeView1.SelectedNode.Text;
                for (int a = 0; a < 5; a++)
                {
                    if (Globals.connections[a].conn_name == text)
                    {
                        Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + Globals.connections[a].server + ";Port=" + Globals.connections[a].port + ";";
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
            panel1.Controls.Clear();
            Tablas tablas = new Tablas();
            tablas.TopLevel = false;
            tablas.AutoScroll = true;
            tablas.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(tablas);
            tablas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Views views = new Views();
            views.TopLevel = false;
            views.AutoScroll = true;
            views.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(views);
            views.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Indexes indexes = new Indexes();
            indexes.TopLevel = false;
            indexes.AutoScroll = true;
            indexes.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(indexes);
            indexes.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Procedures procedures = new Procedures();
            procedures.TopLevel = false;
            procedures.AutoScroll = true;
            procedures.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(procedures);
            procedures.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Triggers triggers = new Triggers();
            triggers.TopLevel = false;
            triggers.AutoScroll = true;
            triggers.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(triggers);
            triggers.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Checks checks = new Checks();
            checks.TopLevel = false;
            checks.AutoScroll = true;
            checks.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(checks);
            checks.Show();
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

    }

    public static class Globals
    {
        public static ConnectionData[] connections = new ConnectionData[5];
        public static string connection_string;

        public static string username;

        public static int pos;

        public static int get_pos()
        {
            if(pos < 4)
            {
                pos++;
            }
            else
            {
                pos = 0;
            }
            return pos;
        }
    }
}
