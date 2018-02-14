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
                    listBox1.Items.Add(Globals.connections[c].Tostring());
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
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            for (int a = 0; a < 5; a++)
            {
                if(Globals.connections[a].conn_name == text)
                {
                    Globals.connection_string = "Driver=Adaptive Server Enterprise; Server=" + Globals.connections[a].server + ";Port=" + Globals.connections[a].port + ";database=" + Globals.connections[a].database + ";";
                    Form3 login = new Form3();
                    login.Show();
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
