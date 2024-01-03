using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StudentAttendanceSystem
{
    internal class Connect : IDisposable
    {
        private MySqlConnection connection;
        private string connectionString;

        public Connect()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string server = "127.0.0.1";
            string database = "db_studentattendancesystem";
            string user = "root";
            string password = "";

            connectionString = $"Server={server};Database={database};User={user};Password={password};";
            connection = new MySqlConnection(connectionString);
        }

        public DataTable RetrieveData(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return dataTable;
        }

        public void RunCommand(string query)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}