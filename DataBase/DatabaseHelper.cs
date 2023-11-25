using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoLIstApp.DataBase
{
    public static class DatabaseHelper
    {
        //private static readonly string ConnectionString = "YourConnectionStringHere"; // Replace with your actual connection string

        public static MySqlConnection GetOpenConnection()
        {
            string server = "localhost";
            string database = "todo";
            string username = "root";
            string password = "";
            string connectionString = "Server=" + server + ";" + "database=" + database + ";" +
                "uid=" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
            

        }
    }
}
