using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ConnectionData
    {
        public string conn_name;
        public string database;
        public string server;
        public string port;

        public string Tostring()
        {
            return conn_name;
        }
    }
}
