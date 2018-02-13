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
                    this.Hide();
                }
            }
        }
    }

    public static class Globals
    {
        public static ConnectionData[] connections = new ConnectionData[5];
        public static string connection_string;

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
